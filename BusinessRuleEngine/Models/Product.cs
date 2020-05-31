using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Models
{
  /// <summary>
  /// 
  /// </summary>
  public abstract class Product
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Agent { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public abstract DeliveyType DeliveyType { get; }

    public string FreeProduct { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public enum DeliveyType
  {
    Physical,
    Online,
  }
}
