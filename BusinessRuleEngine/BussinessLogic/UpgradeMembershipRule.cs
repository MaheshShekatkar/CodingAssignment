using BusinessRuleEngine.Models;
using BusinessRuleEngine.NotificationHandler;
using System;

namespace BusinessRuleEngine.BussinessLogic
{
  /// <summary>
  /// Responsible for execute upgrade membership rule.
  /// </summary>
  public class UpgradeMembershipRule : IBusinessRule
  {
    ICutomerNotifier cutomerNotifier;

    /// <summary>
    /// Initialize customer notifier.
    /// </summary>
    public UpgradeMembershipRule(ICutomerNotifier cutomerNotifier)
    {
      this.cutomerNotifier = cutomerNotifier;
    }

    /// <summary>
    /// Execute upgrade membership rule.
    /// </summary>
    /// <param name="order">Order</param>
    /// <returns>Message</returns>
    public string Execute(Order order)
    {
      var Upgradeinfo = $"Customer id:{order.CutomerInfo.Id} , name:{order.CutomerInfo.Name} membership is upgraded";

      Func<string> updateCustomer = ()  => "Customer notifided by email for membership upgrade";

      var regitrationData = new RegistrationData()
      {
        Customer = order.CutomerInfo,
        GetUpdateMessage = updateCustomer
      };

      cutomerNotifier.Register(regitrationData);
      cutomerNotifier.Notify();

      return Upgradeinfo;
    }
  }
}
