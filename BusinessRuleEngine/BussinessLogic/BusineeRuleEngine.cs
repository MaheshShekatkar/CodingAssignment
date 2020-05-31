using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.BussinessLogic
{
  /// <summary>
  /// Responsible for execute all rules associated with the order.
  /// </summary>
  public class BusinessRuleEngine : IBusinessRuleEngine
  {
    List<IBusinessRule> rules;
    Order order;
    string messages="";

    /// <summary>
    /// Initialize list of business rules & order.
    /// </summary>
    /// <param name="order">Order</param>
    public BusinessRuleEngine(Order order)
    {
      rules = new List<IBusinessRule>();
      this.order = order;
    }

    /// <summary>
    /// Add business rule in the list.
    /// </summary>
    /// <param name="busineeRule">Business rule.</param>
    public void Add(IBusinessRule busineeRule)
    {
      rules.Add(busineeRule);
    }

    /// <summary>
    /// Execute the rules in the collection.
    /// </summary>
    /// <returns>Message</returns>
    public string Execute()
    {
      foreach (var rule in rules)
        messages += rule.Execute(order);

      return messages;
    }
  }
}
