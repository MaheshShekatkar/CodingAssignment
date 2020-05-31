using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.BussinessLogic
{
  public interface IBusinessRuleEngine
  {
    void Add(IBusinessRule busineeRule);

    string Execute();
  }
}
