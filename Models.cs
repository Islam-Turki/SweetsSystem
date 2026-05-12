using System;
namespace sweetSystem
{
    public enum EmployeeRole
    {
        Cook,
        Packager
    }

    public enum ProductUnit
    {
        Kg,
        Piece
    }

    public enum ProductCategory
    {
        RawHoney,
        CreamedHoney,
        InfusedHoney,
        Honeycomb,
        Other
    }

    public enum PaymentStatus
    {
        None,
        Partial,
        Paid
    }

    public enum OrderStatus
    {
        Pending,
        InProduction,
        Completed,
        Delivered,
        Assigned
    }

    public static class EnumHelper
    {
        public static string ToString(Enum value)
        {
            return value switch
            {
                EmployeeRole.Cook => "cook",
                EmployeeRole.Packager => "packager",
                ProductUnit.Kg => "kg",
                ProductUnit.Piece => "piece",
                ProductCategory.RawHoney => "raw_honey",
                ProductCategory.CreamedHoney => "creamed_honey",
                ProductCategory.InfusedHoney => "infused_honey",
                ProductCategory.Honeycomb => "honeycomb",
                ProductCategory.Other => "other",
                PaymentStatus.None => "none",
                PaymentStatus.Partial => "partial",
                PaymentStatus.Paid => "paid",
                OrderStatus.Pending => "pending",
                OrderStatus.InProduction => "in_production",
                OrderStatus.Completed => "completed",
                OrderStatus.Delivered => "delivered",
                OrderStatus.Assigned => "assigned",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        public static T FromString<T>(string value) where T : struct, Enum
        {
            if (typeof(T) == typeof(EmployeeRole))
            {
                return (T)(object)(value switch
                {
                    "cook" => EmployeeRole.Cook,
                    "packager" => EmployeeRole.Packager,
                    _ => throw new ArgumentException($"Invalid EmployeeRole value: {value}")
                });
            }
            if (typeof(T) == typeof(ProductUnit))
            {
                return (T)(object)(value switch
                {
                    "kg" => ProductUnit.Kg,
                    "piece" => ProductUnit.Piece,
                    _ => throw new ArgumentException($"Invalid ProductUnit value: {value}")
                });
            }
            if (typeof(T) == typeof(ProductCategory))
            {
                return (T)(object)(value switch
                {
                    "raw_honey" => ProductCategory.RawHoney,
                    "creamed_honey" => ProductCategory.CreamedHoney,
                    "infused_honey" => ProductCategory.InfusedHoney,
                    "honeycomb" => ProductCategory.Honeycomb,
                    "other" => ProductCategory.Other,
                    _ => throw new ArgumentException($"Invalid ProductCategory value: {value}")
                });
            }
            if (typeof(T) == typeof(PaymentStatus))
            {
                return (T)(object)(value switch
                {
                    "none" => PaymentStatus.None,
                    "partial" => PaymentStatus.Partial,
                    "paid" => PaymentStatus.Paid,
                    _ => throw new ArgumentException($"Invalid PaymentStatus value: {value}")
                });
            }
            if (typeof(T) == typeof(OrderStatus))
            {
                return (T)(object)(value switch
                {
                    "pending" => OrderStatus.Pending,
                    "in_production" => OrderStatus.InProduction,
                    "completed" => OrderStatus.Completed,
                    "delivered" => OrderStatus.Delivered,
                    "assigned" => OrderStatus.Assigned,
                    _ => throw new ArgumentException($"Invalid OrderStatus value: {value}")
                });
            }

            throw new ArgumentException($"Unsupported enum type: {typeof(T)}");
        }
    }

    /// <summary>
    /// Maps to the employee table.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public EmployeeRole Role { get; set; }
        public string Phone { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }

    /// <summary>
    /// Maps to the customer table.
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Location { get; set; }
        public double OpeningBalance { get; set; } = 0;
        
        public double Balance 
        { 
            get 
            {
                // Debt from orders (Total - Paid)
                double ordersDebt = MockData.Orders
                    .Where(o => o.CustomerId == this.Id)
                    .Sum(o => o.TotalPrice - o.PaidAmount);

                // Standalone payments (deposits)
                double deposits = MockData.PaymentTransactions
                    .Where(t => t.CustomerId == this.Id && t.OrderId == null)
                    .Sum(t => t.Amount);

                return OpeningBalance + ordersDebt - deposits;
            }
        }
    }

    /// <summary>
    /// Maps to the products table.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductUnit Unit { get; set; }
        public double Price { get; set; }
        public double WholesalePrice { get; set; }
        public ProductCategory Category { get; set; }
        public string? PictureUrl { get; set; }
        public string? ImagePath { get; set; }
        public int? MakerId { get; set; } // FK -> employee(id)


        // navigation - not mapped to a column
        public Employee? Maker { get; set; }
    }

    /// <summary>
    /// Maps to the [order] table.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public int orderNumberInDay { get; set; } // for numbering in days only 
        public int? CustomerId { get; set; } // FK -> customer(id)
        public int? PackagerId { get; set; } // FK -> employee(id)
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public bool IsDelivery { get; set; } = false;
        public PaymentStatus PaymentStatus { get; set; }
        public double TotalPrice { get; set; } = 0;
        public double PaidAmount { get; set; } = 0;
        public OrderStatus Status { get; set; }
        public string? Notes { get; set; }

        // navigation - not mapped to a column
        public Customer? Customer { get; set; }
        // navigation - not mapped to a column
        public Employee? Packager { get; set; }
    }

    /// <summary>
    /// Maps to the order_items table.
    /// </summary>
    public class OrderItem
    {
        public int OrderId { get; set; } // FK -> [order](id)
        public int ProductId { get; set; } // FK -> products(id)
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }

        // navigation - not mapped to a column
        public Order? Order { get; set; }
        // navigation - not mapped to a column
        public Product? Product { get; set; }
    }

    /// <summary>
    /// Maps to the payment_transaction table.
    /// </summary>
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // FK -> customer(id)
        public int? OrderId { get; set; } // FK -> [order](id)
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        // navigation - not mapped to a column
        public Customer? Customer { get; set; }
        // navigation - not mapped to a column
        public Order? Order { get; set; }
    }
}
