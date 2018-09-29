using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client
{
    class LoadMetadaten
    {
        /*
        private void LoadMetadata(List<KeyValuePair<string, List<MetadataItem>>> yearItems)
        {
            foreach (var yearItem in yearItems)
            {
                var metadataFiles = Directory.GetFiles(yearItem.Key, "*_Metadata.xml");

                foreach (var metadataFile in metadataFiles)
                {
                    var xmlSerializer = new XmlSerializer(typeof(MetadataItem));
                    var streamReader = new StreamReader(metadataFile);
                    var metadataItem = (MetadataItem)xmlSerializer.Deserialize(streamReader);

                    yearItem.Value.Add(metadataItem);
                }
            }
        }*/
    }
}
