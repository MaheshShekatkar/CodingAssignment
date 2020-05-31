using BusinessRuleEngine.Models;
using System;

namespace BusinessRuleEngine.BussinessLogic
{
  /// <summary>
  /// Responsible for execute agent commission rule.
  /// </summary>
  public class AgentCommissionRule : IBusinessRule
  {
    decimal payment;
    const decimal agentCommissionPercent = 2;

    /// <summary>
    /// Execute agent commission rule.
    /// </summary>
    /// <param name="order">Order</param>
    /// <returns>Message</returns>
    public string Execute(Order order)
    {
      foreach (var product in order.Products)
      {
        payment += (product.UnitPrice * product.Quantity) * (agentCommissionPercent / 100m);
      }

      return $"Agent payment is {payment}\n";
    }
  }
}
