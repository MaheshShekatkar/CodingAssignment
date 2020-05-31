using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.NotificationHandler
{
  /// <summary>
  /// Responsible for sending notification to customer those subscribe to notifier.
  /// </summary>
  public class CutomerNotifier : ICutomerNotifier
  {
    Dictionary<int, RegistrationData> regitrations;

    /// <summary>
    /// Initialize regitration data.
    /// </summary>
    public CutomerNotifier()
    {
      regitrations = new Dictionary<int, RegistrationData>();
    }

    /// <summary>
    /// Notify the update to customer.
    /// </summary>
    public void Notify()
    {
      foreach(var reg in regitrations)
      {
        var customer = reg.Value;
        var message = customer.GetUpdateMessage();
        customer.Customer.Update(message);
      }
    }

    /// <summary>
    /// Register customer to notifier.
    /// </summary>
    /// <param name="registrationData">registration data.</param>
    /// <param name="customer"></param>
    public void Register(RegistrationData registrationData)
    {
      regitrations.Add(registrationData.Customer.Id, registrationData);
    }

    /// <summary>
    /// Unsubscribe the customer from notifier.
    /// </summary>
    /// <param name="id">Customer Id</param>
    public void Remove(int id)
    {
      regitrations.Remove(id);
    }
  }
}
