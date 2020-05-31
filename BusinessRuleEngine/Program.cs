using BusinessRuleEngine.BussinessLogic;
using BusinessRuleEngine.Models;
using BusinessRuleEngine.NotificationHandler;
using System;
using System.Collections.Generic;

namespace BusinessRuleEngine
{
  class Program
  {
    static void Main(string[] args)
    {
      var bookOrder = new Order()
      {
        Products = new Product[] { new Book()
        {
          Id = 1001,
          Agent = "xyz compny",
          Description ="Technical book",
          Name = "Computer fundamental",
          Quantity = 1,
          UnitPrice = 1000
        }},
        CutomerInfo = new CutomerInfo()
        {
          Id = 20001,
          Name = "Abc",
          Address = "Pune"
        },
      };

      var videoOrder = new Order()
      {
        Products = new Product[] { new Video()
        {
          Id = 2001,
          Agent = "xyz compny",
          Description ="Learning video",
          Name = "Learning to Ski",
          Quantity = 1,
          UnitPrice = 200,
          FreeProduct ="First Aid"
        }},
        CutomerInfo = new CutomerInfo()
        {
          Id = 20001,
          Name = "Abc",
          Address = "Pune"
        },
      };

      var activationOrder = new Order()
      {
        CutomerInfo = new CutomerInfo()
        {
          Id = 20001,
          Name = "Abc",
          Address = "Pune"
        },
      };

      var updradeOrder = new Order()
      {
        CutomerInfo = new CutomerInfo()
        {
          Id = 20001,
          Name = "Abc",
          Address = "Pune"
        },
      };

      var businessRuleEngineBookOrder = new BussinessLogic.BusinessRuleEngine(bookOrder);
      businessRuleEngineBookOrder.Add(new PackingSlipRule(true));
      businessRuleEngineBookOrder.Add(new AgentCommissionRule());
      Console.WriteLine(businessRuleEngineBookOrder.Execute());

      var businessRuleEngineVideoOrder = new BussinessLogic.BusinessRuleEngine(videoOrder);
      businessRuleEngineVideoOrder.Add(new PackingSlipRule(new FreeProductRule(),false));
      businessRuleEngineVideoOrder.Add(new AgentCommissionRule());
      Console.WriteLine(businessRuleEngineVideoOrder.Execute());

      var businessRuleEngineactivationOrder = new BussinessLogic.BusinessRuleEngine(activationOrder);
      businessRuleEngineactivationOrder.Add(new ActivateMembershipRule(new CutomerNotifier()));
      Console.WriteLine(businessRuleEngineactivationOrder.Execute());

      var businessRuleEngineaupdradeOrder = new BussinessLogic.BusinessRuleEngine(updradeOrder);
      businessRuleEngineaupdradeOrder.Add(new UpgradeMembershipRule(new CutomerNotifier()));
      Console.WriteLine(businessRuleEngineaupdradeOrder.Execute());

      Console.ReadLine();
    }
  }
}


