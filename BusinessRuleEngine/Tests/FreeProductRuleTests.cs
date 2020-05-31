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
  class FreeProductRuleTests
  {
    [Test, TestCaseSource("TestData")]
    public void Execute_Test(Order order, string expected)
    {
      var sut = new FreeProductRule();
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
        }, "You will get the free product  with this order\n");
      }
    }
  }
}
