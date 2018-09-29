using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FileSystemService
    {
        private const string TargetPath = @"C:\Temp\DMS1";

        public FileSystemService()
        {
            FileRepository = new FileRepository();
            CreateGuid = new CreateGuid();
            FilenameGenerator = new FilenameGenerator();
        }

        /*     public FileSystemService(IFileRepository fileRepository, IFilenameGenerator filenameGenerator, ICreateGuid creadeGuid)
        {
            FileRepository = fileRepository;
            CreateGuid = creadeGuid;
            FilenameGenerator = filenameGenerator;

        }*/

        private IFileRepository FileRepository { get; }

        private ICreateGuid CreateGuid { get; }

        private IFilenameGenerator FilenameGenerator { get; }
    }
}