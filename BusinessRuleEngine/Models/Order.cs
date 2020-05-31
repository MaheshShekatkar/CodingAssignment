using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Models
{
  public class Order
  {
    public Product[] Products { get; set; }

    public CutomerInfo CutomerInfo { get; set; }
  }
}
