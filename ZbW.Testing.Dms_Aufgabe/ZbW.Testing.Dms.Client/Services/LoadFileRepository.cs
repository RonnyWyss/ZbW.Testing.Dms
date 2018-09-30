using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    public class LoadFileRepository : ILoadFileRepository
    {
        public void LoadMetadaten(List<KeyValuePair<string, List<IMetadataItem>>> yearItems)
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
            // Irgendetwas noch
        }*/
    }
}