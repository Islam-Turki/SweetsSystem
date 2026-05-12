
using System;
using System.Collections.Generic;
using System.Linq;
using sweetSystem;

namespace sweetSystem
{
    public static class MockData
    {
        // ── المنتجات (Products) ───────────────────────────────────────────────
        public static List<Product> Products { get; set; } = new();

        // ── الموظفون (Employees) ──────────────────────────────────────────────
        public static List<Employee> Employees { get; set; } = new();

        // ── العملاء (Customers) ───────────────────────────────────────────────
        public static List<Customer> Customers { get; set; } = new();

        // ── الطلبات (Orders) ──────────────────────────────────────────────────
        public static List<Order> Orders { get; set; } = new();
        
        // ── تفاصيل الطلبات (Order Items) ──────────────────────────────────────
        public static List<OrderItem> OrderItems { get; set; } = new();

        // ── معاملات الدفع (Payment Transactions) ──────────────────────────────
        public static List<PaymentTransaction> PaymentTransactions { get; set; } = new();

        static MockData()
        {
            // Employees
            Employees.Add(new Employee { Id=1, Name="أحمد حسن",    Role=EmployeeRole.Cook,     Phone="0910000001", IsAvailable=true });
            Employees.Add(new Employee { Id=2, Name="فاطمة علي",   Role=EmployeeRole.Cook,     Phone="0910000002", IsAvailable=true });
            Employees.Add(new Employee { Id=3, Name="خالد عمر",    Role=EmployeeRole.Cook,     Phone="0910000003", IsAvailable=true });
            Employees.Add(new Employee { Id=4, Name="سارة محمود",  Role=EmployeeRole.Packager, Phone="0910000004", IsAvailable=true });
            Employees.Add(new Employee { Id=5, Name="عمر الفارسي", Role=EmployeeRole.Packager, Phone="0910000005", IsAvailable=false });
            Employees.Add(new Employee { Id=6, Name="ليلى إبراهيم",Role=EmployeeRole.Packager, Phone="0910000006", IsAvailable=true });

            // Customers
            Customers.Add(new Customer { Id=1, Number="C001", Name="محل النور",            Phone="0913234567", Balance=250.00, Location="طرابلس" });
            Customers.Add(new Customer { Id=2, Number="C002", Name="كافيه السويت كورنر",   Phone="0922876543", Balance=0, Location="بنغازي" });
            Customers.Add(new Customer { Id=3, Number="C003", Name="حلويات فندق الواحة",   Phone="0933111222", Balance=1500.00, Location="مصراتة" });
            Customers.Add(new Customer { Id=4, Number="C004", Name="سوبرماركت النجمة",     Phone="0944333444", Balance=80.00, Location="مصراتة" });
            Customers.Add(new Customer { Id=5, Number="C005", Name="كافتيريا الجامعة",     Phone="0955555666", Balance=320.00, Location="طرابلس" });

            // Products
            Products.Add(new Product { Id=1,  Name="كعك الشوكولاتة",        Category=ProductCategory.Other,      Price=4.50,  WholesalePrice=3.00, Unit=ProductUnit.Piece, MakerId=1, Maker=Employees[0] });
            Products.Add(new Product { Id=2,  Name="كعك بالجلاسير",          Category=ProductCategory.Other,      Price=3.50,  WholesalePrice=2.20, Unit=ProductUnit.Piece, MakerId=1, Maker=Employees[0] });
            Products.Add(new Product { Id=3,  Name="عسل طبيعي خام",         Category=ProductCategory.RawHoney,   Price=8.00,  WholesalePrice=5.50, Unit=ProductUnit.Kg, MakerId=2, Maker=Employees[1] });
            Products.Add(new Product { Id=4,  Name="عسل كريمي",             Category=ProductCategory.CreamedHoney,Price=7.50, WholesalePrice=5.00, Unit=ProductUnit.Kg, MakerId=2, Maker=Employees[1] });
            Products.Add(new Product { Id=5,  Name="شهد العسل",             Category=ProductCategory.Honeycomb,  Price=6.00,  WholesalePrice=4.00, Unit=ProductUnit.Piece, MakerId=3, Maker=Employees[2] });
            Products.Add(new Product { Id=6,  Name="عسل بالزعفران",         Category=ProductCategory.InfusedHoney,Price=12.00, WholesalePrice=8.50, Unit=ProductUnit.Kg, MakerId=3, Maker=Employees[2] });
            Products.Add(new Product { Id=7,  Name="كرواسون بالعسل",         Category=ProductCategory.Other,      Price=4.00,  WholesalePrice=2.50, Unit=ProductUnit.Piece, MakerId=1, Maker=Employees[0] });

            // Orders
            Orders.Add(new Order    
            {
                Id=1, orderNumberInDay=1, OrderDate=DateTime.Today, DeliveryDate=DateTime.Today.AddDays(1), 
                CustomerName="منى سامر", CustomerPhone="0921111111", Status=OrderStatus.Pending,
                PaymentStatus=PaymentStatus.None, TotalPrice = (12 * 4.50) + (6 * 12.00), IsDelivery=false
            });
            OrderItems.Add(new OrderItem { OrderId=1, ProductId=1, Quantity=12, TotalPrice=12 * 4.50, Order=Orders[0], Product=Products[0] });
            OrderItems.Add(new OrderItem { OrderId=1, ProductId=6, Quantity=6, TotalPrice=6 * 12.00, Order=Orders[0], Product=Products[5] });

            Orders.Add(new Order
            {
                Id=2, orderNumberInDay=2, OrderDate=DateTime.Today, DeliveryDate=DateTime.Today, 
                CustomerId=1, Customer=Customers[0], CustomerName=Customers[0].Name, CustomerPhone=Customers[0].Phone,
                Status=OrderStatus.InProduction, PackagerId=4, Packager=Employees[3],
                PaymentStatus=PaymentStatus.Partial, TotalPrice = (50 * 3.00) + (30 * 2.20), IsDelivery=true
            });
            OrderItems.Add(new OrderItem { OrderId=2, ProductId=1, Quantity=50, TotalPrice=50 * 3.00, Order=Orders[1], Product=Products[0] });
            OrderItems.Add(new OrderItem { OrderId=2, ProductId=2, Quantity=30, TotalPrice=30 * 2.20, Order=Orders[1], Product=Products[1] });

            Orders.Add(new Order
            {
                Id=3, orderNumberInDay=3, OrderDate=DateTime.Today, DeliveryDate=DateTime.Today, 
                CustomerName="حسن كمال", CustomerPhone="0932222222", Status=OrderStatus.Pending,
                PaymentStatus=PaymentStatus.Paid, TotalPrice = (4 * 8.00) + (4 * 7.50), IsDelivery=false
            });
            OrderItems.Add(new OrderItem { OrderId=3, ProductId=3, Quantity=4, TotalPrice=4 * 8.00, Order=Orders[2], Product=Products[2] });
            OrderItems.Add(new OrderItem { OrderId=3, ProductId=4, Quantity=4, TotalPrice=4 * 7.50, Order=Orders[2], Product=Products[3] });

            Orders.Add(new Order
            {
                Id=4, orderNumberInDay=4, OrderDate=DateTime.Today, DeliveryDate=DateTime.Today.AddDays(2), 
                CustomerId=3, Customer=Customers[2], CustomerName=Customers[2].Name, CustomerPhone=Customers[2].Phone,
                Status=OrderStatus.Pending, PaymentStatus=PaymentStatus.None,
                TotalPrice = (60 * 3.00) + (20 * 2.50), IsDelivery=true
            });
            OrderItems.Add(new OrderItem { OrderId=4, ProductId=1, Quantity=60, TotalPrice=60 * 3.00, Order=Orders[3], Product=Products[0] });
            OrderItems.Add(new OrderItem { OrderId=4, ProductId=7, Quantity=20, TotalPrice=20 * 2.50, Order=Orders[3], Product=Products[6] });

            Orders.Add(new Order
            {
                Id=5, orderNumberInDay=5, OrderDate=DateTime.Today, DeliveryDate=DateTime.Today, 
                CustomerName="نادية يوسف", CustomerPhone="0913333333", Status=OrderStatus.Completed,
                PackagerId=5, Packager=Employees[4],
                PaymentStatus=PaymentStatus.Paid, TotalPrice = (3 * 12.00) + (2 * 4.50), IsDelivery=true
            });
            OrderItems.Add(new OrderItem { OrderId=5, ProductId=6, Quantity=3, TotalPrice=3 * 12.00, Order=Orders[4], Product=Products[5] });
            OrderItems.Add(new OrderItem { OrderId=5, ProductId=1, Quantity=2, TotalPrice=2 * 4.50, Order=Orders[4], Product=Products[0] });

            // غداً — Tomorrow
            Orders.Add(new Order
            {
                Id=6, orderNumberInDay=1, OrderDate=DateTime.Today.AddDays(1), DeliveryDate=DateTime.Today.AddDays(2), 
                CustomerName="حفل عيد ميلاد", CustomerPhone="0924444444", Status=OrderStatus.Pending,
                PaymentStatus=PaymentStatus.None, TotalPrice = (2 * 8.00) + (5 * 4.00), IsDelivery=false
            });
            OrderItems.Add(new OrderItem { OrderId=6, ProductId=3, Quantity=2, TotalPrice=2 * 8.00, Order=Orders[5], Product=Products[2] });
            OrderItems.Add(new OrderItem { OrderId=6, ProductId=7, Quantity=5, TotalPrice=5 * 4.00, Order=Orders[5], Product=Products[6] });
        }

        public static int NextOrderId()   => Orders.Count   == 0 ? 1 : Orders.Max(o => o.Id)   + 1;
        public static int NextProductId() => Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;
        public static int NextEmployeeId()=> Employees.Count== 0 ? 1 : Employees.Max(e => e.Id)+ 1;
        public static int NextCustomerId()=> Customers.Count== 0 ? 1 : Customers.Max(c => c.Id)+ 1;

        public static string OrderStatusAr(OrderStatus s) => s switch
        {
            OrderStatus.Pending      => "قيد الانتظار",
            OrderStatus.InProduction => "قيد الإنتاج",
            OrderStatus.Completed    => "مكتمل",
            OrderStatus.Delivered    => "تم التوصيل",
            OrderStatus.Assigned     => "تم التكليف",
            _ => ""
        };

        public static string RoleAr(EmployeeRole r) => r == EmployeeRole.Cook ? "طباخ" : "موظف تعبئة";

        public static Employee? GetCookForProduct(Product p)
        {
            if (p.Maker != null) return p.Maker;
            return Employees.FirstOrDefault(e => e.Role == EmployeeRole.Cook);
        }
    }
}
