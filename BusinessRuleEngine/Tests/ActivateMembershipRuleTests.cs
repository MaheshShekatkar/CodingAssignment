using BusinessRuleEngine.BussinessLogic;
using BusinessRuleEngine.Models;
using BusinessRuleEngine.NotificationHandler;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Tests
{
  [TestFixture]
  class ActivateMembershipRuleTests
  {
    [Test,TestCaseSource("TestData")]
    public void Execute_Test(Order order,string expected)
    {
      var cutomerNotifiermock = new Moq.Mock<ICutomerNotifier>(MockBehavior.Strict);
      cutomerNotifiermock.Setup(x => x.Notify());
      cutomerNotifiermock.Setup(x => x.Register(It.IsAny<RegistrationData>()));
      cutomerNotifiermock.Setup(x => x.Remove(It.IsAny<int>()));
      var sut = new ActivateMembershipRule(cutomerNotifiermock.Object);

      var actual = sut.Execute(order);

      Assert.That(expected, Is.EqualTo(actual));
      cutomerNotifiermock.Verify(m => m.Register(It.IsAny<RegistrationData>()), Moq.Times.Once);
      cutomerNotifiermock.Verify(m => m.Notify(), Moq.Times.Once);
    }

    public static IEnumerable<TestCaseData> TestData
    {
      get
      {
        yield return new TestCaseData( new Order()
        {
          Products = new Product[] { new Book()
        {
          Id = 1001,
          Agent = "xyz compny",
          Description ="Technical book",
          Name = "Computer fundamental",
          Quantity = 1,
          UnitPrice = 1000
        }},
          CutomerInfo = new CutomerInfo()
          {
            Id = 20001,
            Name = "Abc",
            Address = "Pune"
          },
        }, "Customer id:20001 , name:Abc membership is activated");
      }
    }
  }
}
