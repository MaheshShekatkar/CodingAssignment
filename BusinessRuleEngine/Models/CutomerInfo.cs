using BusinessRuleEngine.NotificationHandler;
using System;

namespace BusinessRuleEngine.Models
{
  public class CutomerInfo : ICustomer
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public void Update(string message)
    {
      Console.WriteLine(message);
    }
  }
}
