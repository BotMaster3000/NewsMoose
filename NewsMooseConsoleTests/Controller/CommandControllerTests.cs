using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsMooseConsole.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMooseConsole.Controller.Tests
{
    [TestClass]
    public class CommandControllerTests
    {
        [TestMethod]
        public void CanExecuteTest_ExecuteDisplayMainMenu_ShouldBeExecutable()
        {
            CommandController controller = new CommandController();
            Assert.IsTrue(controller.CanExecute("DisplayMainMenu"));
        }

        [TestMethod]
        public void CanExecuteTest_ExecuteRandomMethod_ShouldNotExecute()
        {
            CommandController controller = new CommandController();
            Assert.IsFalse(controller.CanExecute("RandomBlaBullBla" + Guid.NewGuid()));
        }

        [TestMethod]
        public void ExecuteTest_ExecuteDisplayMainMenu_ShouldExecute()
        {
            CommandController controller = new CommandController();
            controller.Execute("DisplayMainMenu");
        }

        [TestMethod]
        public void ExecuteTest_ExecuteRandomMethod_ShouldThrowException()
        {
            CommandController controller = new CommandController();
            Assert.ThrowsException<Exception>(() => controller.Execute("RandomBla" + Guid.NewGuid()));
        }

        [TestMethod]
        public void DisplayPublishersTest_ShouldExecute()
        {
            CommandController controller = new CommandController();
            controller.Execute("ShowPublishers");
        }

        [TestMethod]
        public void DisplayNewspapersTest_ShouldExecute()
        {
            CommandController controller = new CommandController();
            controller.Execute("ShowNewsPaper");
        }
    }
}