using System;

namespace ZbW.Testing.Dms.Client.Services.Interface
{
    internal interface IFilenameGenerator
    {
        string GetContentFilename(Guid guid, string extension);

        string GetMetadataFilename(Guid guid);
    }
}