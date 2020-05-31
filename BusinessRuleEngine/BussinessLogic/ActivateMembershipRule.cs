using BusinessRuleEngine.Models;
using BusinessRuleEngine.NotificationHandler;
using System;

namespace BusinessRuleEngine.BussinessLogic
{
  /// <summary>
  /// Responsible for execute activation membership rule.
  /// </summary>
  public class ActivateMembershipRule : IBusinessRule
  {
    ICutomerNotifier cutomerNotifier;

    /// <summary>
    /// Initialize customer notifier.
    /// </summary>
    public ActivateMembershipRule(ICutomerNotifier cutomerNotifier)
    {
      this.cutomerNotifier = cutomerNotifier;
    }

    /// <summary>
    /// Execute activation membership rule.
    /// </summary>
    /// <param name="order">Order</param>
    /// <returns>Message</returns>
    public string Execute(Order order)
    {
      var activationInfo = $"Customer id:{order.CutomerInfo.Id} , name:{order.CutomerInfo.Name} membership is activated";
      Func<string> updateCustomer = () => "Customer notifided by email for membership activation";

      var regitrationData = new RegistrationData()
      {
        Customer = order.CutomerInfo,
        GetUpdateMessage = updateCustomer
      };

      cutomerNotifier.Register(regitrationData);
      cutomerNotifier.Notify();

      return activationInfo;
    }
  }
}
