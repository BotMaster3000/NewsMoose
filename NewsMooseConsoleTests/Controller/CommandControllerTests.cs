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
    }
}