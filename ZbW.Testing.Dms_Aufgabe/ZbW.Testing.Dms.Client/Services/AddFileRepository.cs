using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class AddFileRepository : IAddFileRepository
    {
        private readonly IAppSettingService _appSettingService;
        private readonly IFilenameGenerator _filenameGenerator;

        public AddFileRepository()
        {
            _filenameGenerator = new FilenameGenerator();
            _appSettingService = new AppSettingService();
        }

        public void AddFile(IMetadataItem metadataItem, bool deleteFile)
        {
            var repositoryDir = _appSettingService.GetRepositoryDir();
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

            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            WriteXml(targetDir, metadataFileName, metadataItem);


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

        public virtual void WriteXml(string targetDir, string metadataFileName, IMetadataItem metadataItem)
        {
            var xmlSerializer = new XmlSerializer(typeof(MetadataItem));
            var streamWriter = new StreamWriter(Path.Combine(targetDir, metadataFileName));
            xmlSerializer.Serialize(streamWriter, metadataItem);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}