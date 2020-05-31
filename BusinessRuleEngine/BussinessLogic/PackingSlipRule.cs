using BusinessRuleEngine.Models;
using System;

namespace BusinessRuleEngine.BussinessLogic
{
  /// <summary>
  /// Responsible for execute packing slip rule.
  /// </summary>
  public class PackingSlipRule : IBusinessRule
  {
    IBusinessRule rule;
    bool IsRequiredDuplicate;

    /// <summary>
    /// Initialize when no need of customization.
    /// </summary>
    public PackingSlipRule()
    {

    }

    /// <summary>
    /// Initialize business rule.
    /// </summary>
    /// <param name="rule">Business rule.</param>
    public PackingSlipRule(IBusinessRule rule)
    {
      this.rule = rule;
    }

    /// <summary>
    /// Initialize for duplicate receipt.
    /// </summary>
    /// <param name="IsRequiredDuplicate">True/False</param>
    public PackingSlipRule(bool IsRequiredDuplicate)
    {
      this.IsRequiredDuplicate = IsRequiredDuplicate;
    }

    /// <summary>
    /// Initialize business rule & duplicate receipt.
    /// </summary>
    /// <param name="rule">Business rule.</param>
    /// <param name="IsRequiredDuplicate">True/False</param>
    public PackingSlipRule(IBusinessRule rule, bool IsRequiredDuplicate)
    {
      this.rule = rule;
      this.IsRequiredDuplicate = IsRequiredDuplicate;
    }

    /// <summary>
    /// Execute packing slip rule.
    /// </summary>
    /// <param name="order">Order</param>
    /// <returns>Messagge</returns>
    public string Execute(Order order)
    {
      var packingslip = $"Customer info Name: {order.CutomerInfo.Name} Address : {order.CutomerInfo.Address}\n";
      string duplicateCopy = "";
      string freeproduct = "";
      foreach (var product in order.Products)
      {
        packingslip += $"Order Details Product id {product.Id} " +
        $"Name {product.Name} " +
        $"Quantity : {product.Quantity}" +
        $" Price : {product.UnitPrice} \n";

        if (IsRequiredDuplicate)
          duplicateCopy += (string)packingslip.Clone();
      }

      if (rule != null)
        freeproduct = rule.Execute(order);

      packingslip += freeproduct;
      if(!string.IsNullOrEmpty(duplicateCopy))
      duplicateCopy += freeproduct;

      packingslip += duplicateCopy;

      return packingslip;
    }
  }
}
