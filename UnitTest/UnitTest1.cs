using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectMvvm.Models;
using ProjectMvvm.ViewModels;
using Xamarin.Forms;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IDependencyService _dependencyService;
        Page c = new Page();
        [TestMethod]
        public void TestMethod1()
        {
            

            var vm = new LoginViewModel(_dependencyService);
            //vm.Login = "";
            //vm.Password = "";
            //vm.SubmitCommand.Execute(null);
            //Assert.IsNull(vm.Login, "login must be not null");
            //Assert.IsNull(vm.Password, "password must be not null");
            Assert.IsNotNull(vm.SubmitCommand, "Login and password must be not null");
        }
        public void Setup()
        {
            _dependencyService = new DependencyServiceStub();
        }
    }
}
