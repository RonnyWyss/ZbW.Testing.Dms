using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;


namespace ZbW.Testing.Dms.Client.UnitTests.ViewModels
{
    [TestFixture]
    class LoginViewModelTest
    {
        private const string TEST_USERNAME_RIGHT = "TestBenutzer";
        private const string TEST_USERNAME_WRONG = "";

        [Test]
        public void CmdAddStichwortItem_StichwortItemIsNotNull_AddStichwortItem()
        {
            //arrange
            var loginViewModelFake = A.Fake <LoginViewModel>();

           var loginView= new LoginViewModel();
  
            //act
       
   

            

            //assert
   
        }
    }
}
