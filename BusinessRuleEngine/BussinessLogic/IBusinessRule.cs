using BusinessRuleEngine.Models;

namespace BusinessRuleEngine.BussinessLogic
{
  public interface IBusinessRule
  {
    string Execute(Order order);
  }
}
