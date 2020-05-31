using BusinessRuleEngine.Models;
using System;

namespace BusinessRuleEngine.BussinessLogic
{
  /// <summary>
  /// Responsible for execute free product rule.
  /// </summary>
  public class FreeProductRule : IBusinessRule
  {
    /// <summary>
    /// Execute free product rule.
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public string Execute(Order order)
    {
      string freeProducts="";
      foreach(var line in order.Products)
        freeProducts += $"You will get the free product {line.FreeProduct} with this order\n";
      return freeProducts;
    }
  }
}
