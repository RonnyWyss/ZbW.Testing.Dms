using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services.Interface
{
    internal interface IAddFileRepository
    {
        void AddFile(IMetadataItem metadataItem, bool deleteFile);
    }
}