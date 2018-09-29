using System.Linq;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels
{
    [TestFixture]
    internal class DocumentDetailViewModelTests
    {
        private const string TEST_BENUTZER = "TestBenutzer";
        private const string TEST_STICHWORT = "TestStichwort";

        [Test]
        public void StichwortItem_StichwortItemIsNotNull_AddStichwortItem()
        {
            //arrange
            var documentDetailViewModel = new DocumentDetailViewModel(TEST_BENUTZER, delegate { });

            //act
            documentDetailViewModel.Stichwoerter = TEST_STICHWORT;
         
            //assert
            Assert.That(documentDetailViewModel.Stichwoerter.Count, Is.GreaterThan(0));

        }

        [Test]
        public void CmdAddStichwortItem_StichwortItemIsNotNull_AddStichwortItem()
        {
            //arrange
            var documentDetailViewModel = new DocumentDetailViewModel(TEST_BENUTZER, delegate { });

            //act
            documentDetailViewModel.Stichwoerter = TEST_BENUTZER;

            //assert
            Assert.That(documentDetailViewModel.Stichwoerter.Count, Is.GreaterThan(0));

        }
    }
}