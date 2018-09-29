using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class FileRepository : IFileRepository
    {
        private readonly IFilenameGenerator _filenameGenerator;
        private readonly IAppSettingService _appSettingService;
        public FileRepository()
        {
            _filenameGenerator = new FilenameGenerator();
            _appSettingService = new AppSettingService();
        }

        public void LoadMetadata(List<KeyValuePair<string, List<IMetadataItem>>> yearItems)
        {
            foreach (var yearItem in yearItems)
            {
                var metadataFiles = Directory.GetFiles(yearItem.Key, "*_Metadata.xml");

                foreach (var metadataFile in metadataFiles)
                {
                    var xmlSerializer = new XmlSerializer(typeof(MetadataItem));
                    var streamReader = new StreamReader(metadataFile);
                    var metadataItem = (MetadataItem) xmlSerializer.Deserialize(streamReader);
                    /*
                                        var ocrFile = metadataFile.Replace("Metadata.xml", "Ocr.txt");

                                         if (File.Exists(ocrFile))
                                           {
                                               metadataItem.OcrData = File.ReadAllText(ocrFile);
                                           } */

                    yearItem.Value.Add(metadataItem);
                }
            }
        }

        /*  private List<KeyValuePair<string, List<MetadataItem>>> GetYearItems()
         {
             var yearItems = new List<KeyValuePair<string, List<MetadataItem>>>();

         }*/

        public void AddFile(IMetadataItem metadataItem, bool deleteFile)
        {
            var repositoryDir = _appSettingService.GetRepositoryDir();// @"C:\Temp\DMS1";
            // _appSettingsService.GetRepositoryDir();
            var year = metadataItem.ValutaDatum.Year;
            var documentId = Guid.NewGuid();
            var extension = Path.GetExtension(metadataItem.OrginalPath);
            var contentFileName = _filenameGenerator.GetContentFilename(documentId, extension);
            var metadataFileName = _filenameGenerator.GetMetadataFilename(documentId);

            var targetDir = Path.Combine(repositoryDir, year.ToString());

            metadataItem.ContentFileExtension = extension;
            metadataItem.ContentFilename = contentFileName;
            metadataItem.MetadataFilename = metadataFileName;
            metadataItem.DocumentId = documentId;
            metadataItem.ValutaYear = year.ToString();

            var xmlSerializer = new XmlSerializer(typeof(MetadataItem));

            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            var streamWriter = new StreamWriter(Path.Combine(targetDir, metadataFileName));
            xmlSerializer.Serialize(streamWriter, metadataItem);
            streamWriter.Flush();
            streamWriter.Close();

            //move file
            File.Copy(metadataItem.OrginalPath, Path.Combine(targetDir, contentFileName));

            if (deleteFile)
            {
                var task = Task.Factory.StartNew(
                    () =>
                    {
                        Task.Delay(500);
                        File.Delete(metadataItem.OrginalPath);
                    });
                try
                {
                    Task.WaitAll(task);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}