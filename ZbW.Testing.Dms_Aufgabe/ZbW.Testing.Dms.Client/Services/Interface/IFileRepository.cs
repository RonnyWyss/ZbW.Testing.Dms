using System.Collections.Generic;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services.Interface
{
    internal interface IFileRepository
    {
        void LoadMetadata(List<KeyValuePair<string, List<IMetadataItem>>> yearItems);

        void AddFile(IMetadataItem metadataItem, bool deleteFile);
    }
}