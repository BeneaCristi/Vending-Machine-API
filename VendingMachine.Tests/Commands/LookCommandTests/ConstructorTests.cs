using System;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.UseCases.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.Commands.LookCommandTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IUseCaseFactory> useCaseFactory;

        [TestInitialize]
        public void TestSetup()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void HavingANullUseCaseFactory_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LookCommand(null);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheCommand_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new LookCommand(useCaseFactory.Object));
        }
    }
}
