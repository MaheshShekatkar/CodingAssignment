using BusinessRuleEngine.BussinessLogic;
using BusinessRuleEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Tests
{
  [TestFixture]
  class PackingSlipRuleTests
  {
    [Test, TestCaseSource("TestData")]
    public void Execute_Test(Order order, string expected,bool IsDuplicateRequired)
    {
      var mock = new Moq.Mock<IBusinessRule>();
      mock.Setup(m => m.Execute(Moq.It.IsAny<Order>())).Returns("Hurry! got free product");

      var sut = new PackingSlipRule(mock.Object, IsDuplicateRequired);
      var actual = sut.Execute(order);
      Assert.That(expected, Is.EqualTo(actual));
    }

    public static IEnumerable<TestCaseData> TestData
    {
      get
      {
        yield return new TestCaseData(new Order()
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
        }, "Customer info Name: Abc Address : Pune\nOrder Details Product id 1001 Name Computer fundamental Quantity : 1 Price : 1000 \nHurry! got free product",
        false);

        yield return new TestCaseData(new Order()
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
        }, "Customer info Name: Abc Address : Pune\nOrder Details Product id 1001 Name Computer fundamental Quantity : 1 Price : 1000 \nHurry! got free productCustomer info Name: Abc Address : Pune\nOrder Details Product id 1001 Name Computer fundamental Quantity : 1 Price : 1000 \nHurry! got free product",
        true);
      }
    }
  }
}
