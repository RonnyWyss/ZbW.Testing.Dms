using System;
using FakeItEasy;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.IntegrationTests._TestResources;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.IntegrationTests
{
    [TestFixture]
    public class AddFileRepositoryTest
    {
        [Test]
        public void AddFile_GenerateNewGuid_ReturnTrue()
        {
            var documentId = new Guid("f53a8091-2987-4213-a736-2c80672e76f9");
            var deleteFileIsFalse = false;
            //arrange
            var stubMetaDataItemFactory = new IMetaDataItemFactory();
            var metadataItemStub = stubMetaDataItemFactory.GetMetadataItem();
            var metadataItemMock = A.Fake<IMetadataItem>();

            var addFileRepositoryStub = A.Fake<IAddFileRepository>();
            A.CallTo(() => addFileRepositoryStub.AddFile(metadataItemMock, deleteFileIsFalse)).MustHaveHappened();
            
            var guidGeneratorStub = A.Fake<ICreateGuid>();
            A.CallTo(() => guidGeneratorStub.GetNewGuid()).Returns(documentId);
            
            var filenameGeneratorStub = A.Fake<IFilenameGenerator>();
            A.CallTo(() => filenameGeneratorStub.GetContentFilename(metadataItemStub.DocumentId, ".pdf")).Returns(metadataItemStub.DocumentId + "_content");
            A.CallTo(() => filenameGeneratorStub.GetMetadataFilename(metadataItemStub.DocumentId)).Returns(metadataItemStub.DocumentId + "_metadata");

            var xmlServiceStub = A.Fake<IAddFileRepository>();
           

            var sut = new AddFileRepository();

            //act
            sut.AddFile(metadataItemStub, false);

            //assert
            A.CallTo(() => guidGeneratorStub.GetNewGuid()).MustHaveHappened();
            Assert.AreEqual(documentId.ToString(), metadataItemStub.DocumentId.ToString());
     
        }

        [Test]
        public void FileRepository_AddFiles_WasSuccesfull()
        {
            //Arrange
            var metadataItemMock = A.Fake<IMetadataItem>();
            var deleteFileIsFalse = false;

            var addFileRepositoryStub = A.Fake<IAddFileRepository>();
            A.CallTo(() => addFileRepositoryStub.AddFile(metadataItemMock, deleteFileIsFalse)).MustHaveHappened();

            //Act
            addFileRepositoryStub.AddFile(metadataItemMock, deleteFileIsFalse);

            //Assert
            A.CallTo(() => addFileRepositoryStub.AddFile(metadataItemMock, deleteFileIsFalse)).MustHaveHappened();
        }
    }
}