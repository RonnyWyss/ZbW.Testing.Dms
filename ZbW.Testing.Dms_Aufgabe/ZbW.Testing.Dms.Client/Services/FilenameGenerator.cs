using System;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class FilenameGenerator : IFilenameGenerator
    {
        public string GetContentFilename(Guid guid, string extension)
        {
            return extension != null ? guid + "_Content" + extension : null;
        }

        public string GetMetadataFilename(Guid guid)
        {
            return guid + "_Metadata.xml";
        }
    }
}