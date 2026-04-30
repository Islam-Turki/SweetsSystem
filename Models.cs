using System;
using System.Collections.Generic;

namespace sweetSystem
{
    public enum OrderType    { Retail, Wholesale }
    public enum EmployeeRole { Cook, Packager }
    public enum OrderStatus  { Pending, Assigned, Completed }

    public class Product
    {
        public int     Id             { get; set; }
        public string  Name           { get; set; } = "";
        public string  Category       { get; set; } = "";
        public decimal RetailPrice    { get; set; }
        public decimal WholesalePrice { get; set; }
        public string  Unit           { get; set; } = "قطعة";
        public override string ToString() => Name;
    }

    public class Employee
    {
        public int          Id               { get; set; }
        public string       Name             { get; set; } = "";
        public EmployeeRole Role             { get; set; }
        public List<int>    SkillProductIds  { get; set; } = new();
        public int          TodayAssignments { get; set; } = 0;
        public override string ToString() => Name;
    }

    public class WholesaleClient
    {
        public int     Id               { get; set; }
        public string  Name             { get; set; } = "";
        public string  Phone            { get; set; } = "";
        public decimal RemainingBalance { get; set; }
        public override string ToString() => Name;
    }

    public class OrderLine
    {
        public Product Product   { get; set; } = new();
        public int     Quantity  { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => UnitPrice * Quantity;
    }

    public class Order
    {
        public int            Id              { get; set; }
        public DateTime       Date            { get; set; } = DateTime.Today;
        public OrderType      Type            { get; set; }
        public string         CustomerName    { get; set; } = "";
        public WholesaleClient? WholesaleClient { get; set; }
        public List<OrderLine> Lines          { get; set; } = new();
        public OrderStatus    Status          { get; set; } = OrderStatus.Pending;
        public Employee?      AssignedPackager { get; set; }
        public string         Notes           { get; set; } = "";

        public decimal Subtotal       => Lines.Sum(l => l.LineTotal);
        public decimal PreviousBalance => WholesaleClient?.RemainingBalance ?? 0m;
        public decimal GrandTotal     => Subtotal + PreviousBalance;
        public string  DisplayCustomer => Type == OrderType.Wholesale
            ? WholesaleClient?.Name ?? ""
            : CustomerName;
    }
}
