using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Models
{
  public class Video : Product
  {
    public override DeliveyType DeliveyType => DeliveyType.Online;
  }
}
