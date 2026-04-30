using System;
using System.Collections.Generic;

namespace sweetSystem
{
    public static class MockData
    {
        // ── المنتجات (Products) ───────────────────────────────────────────────
        public static List<Product> Products { get; set; } = new()
        {
            new Product { Id=1,  Name="كعك الشوكولاتة",        Category="كعك",      RetailPrice=4.50m,  WholesalePrice=3.00m, Unit="قطعة" },
            new Product { Id=2,  Name="كعك بالجلاسير",          Category="كعك",      RetailPrice=3.50m,  WholesalePrice=2.20m, Unit="قطعة" },
            new Product { Id=3,  Name="بقلاوة بالفستق",         Category="بقلاوة",   RetailPrice=8.00m,  WholesalePrice=5.50m, Unit="قطعة" },
            new Product { Id=4,  Name="بقلاوة بالعسل",          Category="بقلاوة",   RetailPrice=7.50m,  WholesalePrice=5.00m, Unit="قطعة" },
            new Product { Id=5,  Name="كنافة",                  Category="كنافة",    RetailPrice=6.00m,  WholesalePrice=4.00m, Unit="شريحة"},
            new Product { Id=6,  Name="كريم بف",                Category="معجنات",   RetailPrice=5.00m,  WholesalePrice=3.50m, Unit="قطعة" },
            new Product { Id=7,  Name="كرواسون",                 Category="معجنات",   RetailPrice=4.00m,  WholesalePrice=2.50m, Unit="قطعة" },
            new Product { Id=8,  Name="ماكارون (علبة 6 قطع)",    Category="ماكارون",  RetailPrice=12.00m, WholesalePrice=8.00m, Unit="علبة" },
            new Product { Id=9,  Name="شريحة تشيزكيك",          Category="كيك",      RetailPrice=9.00m,  WholesalePrice=6.50m, Unit="شريحة"},
            new Product { Id=10, Name="كعكة الشوكولاتة الكاملة", Category="كيك",      RetailPrice=35.00m, WholesalePrice=25.00m,Unit="كعكة" },
        };

        // ── الموظفون (Employees) ──────────────────────────────────────────────
        public static List<Employee> Employees { get; set; } = new()
        {
            new Employee { Id=1, Name="أحمد حسن",    Role=EmployeeRole.Cook,     SkillProductIds=new(){1,2,6,7}, TodayAssignments=0 },
            new Employee { Id=2, Name="فاطمة علي",   Role=EmployeeRole.Cook,     SkillProductIds=new(){3,4,5},   TodayAssignments=0 },
            new Employee { Id=3, Name="خالد عمر",    Role=EmployeeRole.Cook,     SkillProductIds=new(){8,9,10},  TodayAssignments=0 },
            new Employee { Id=4, Name="سارة محمود",  Role=EmployeeRole.Packager, SkillProductIds=new(),          TodayAssignments=3 },
            new Employee { Id=5, Name="عمر الفارسي", Role=EmployeeRole.Packager, SkillProductIds=new(),          TodayAssignments=4 },
            new Employee { Id=6, Name="ليلى إبراهيم",Role=EmployeeRole.Packager, SkillProductIds=new(),          TodayAssignments=2 },
        };

        // ── عملاء الجملة (Wholesale Clients) ─────────────────────────────────
        public static List<WholesaleClient> WholesaleClients { get; set; } = new()
        {
            new WholesaleClient { Id=1, Name="محل النور",            Phone="0913-234-5678", RemainingBalance=250.00m  },
            new WholesaleClient { Id=2, Name="كافيه السويت كورنر",   Phone="0922-876-5432", RemainingBalance=0m       },
            new WholesaleClient { Id=3, Name="حلويات فندق الواحة",   Phone="0933-111-2222", RemainingBalance=1500.00m },
            new WholesaleClient { Id=4, Name="سوبرماركت النجمة",     Phone="0944-333-4444", RemainingBalance=80.00m   },
            new WholesaleClient { Id=5, Name="كافتيريا الجامعة",     Phone="0955-555-6666", RemainingBalance=320.00m  },
        };

        // ── الطلبات (Orders) ──────────────────────────────────────────────────
        public static List<Order> Orders { get; set; } = new();

        static MockData()
        {
            // اليوم — Today
            Orders.Add(new Order
            {
                Id=1, Date=DateTime.Today, Type=OrderType.Retail,
                CustomerName="منى سامر", Status=OrderStatus.Pending,
                Lines = new()
                {
                    new OrderLine { Product=Products[0], Quantity=12, UnitPrice=Products[0].RetailPrice },
                    new OrderLine { Product=Products[5], Quantity=6,  UnitPrice=Products[5].RetailPrice },
                }
            });
            Orders.Add(new Order
            {
                Id=2, Date=DateTime.Today, Type=OrderType.Wholesale,
                WholesaleClient=WholesaleClients[0], Status=OrderStatus.Assigned,
                AssignedPackager=Employees[3],
                Lines = new()
                {
                    new OrderLine { Product=Products[0], Quantity=50, UnitPrice=Products[0].WholesalePrice },
                    new OrderLine { Product=Products[1], Quantity=30, UnitPrice=Products[1].WholesalePrice },
                }
            });
            Orders.Add(new Order
            {
                Id=3, Date=DateTime.Today, Type=OrderType.Retail,
                CustomerName="حسن كمال", Status=OrderStatus.Pending,
                Lines = new()
                {
                    new OrderLine { Product=Products[2], Quantity=4, UnitPrice=Products[2].RetailPrice },
                    new OrderLine { Product=Products[3], Quantity=4, UnitPrice=Products[3].RetailPrice },
                }
            });
            Orders.Add(new Order
            {
                Id=4, Date=DateTime.Today, Type=OrderType.Wholesale,
                WholesaleClient=WholesaleClients[2], Status=OrderStatus.Pending,
                Lines = new()
                {
                    new OrderLine { Product=Products[0], Quantity=60, UnitPrice=Products[0].WholesalePrice },
                    new OrderLine { Product=Products[7], Quantity=20, UnitPrice=Products[7].WholesalePrice },
                    new OrderLine { Product=Products[8], Quantity=15, UnitPrice=Products[8].WholesalePrice },
                }
            });
            Orders.Add(new Order
            {
                Id=5, Date=DateTime.Today, Type=OrderType.Retail,
                CustomerName="نادية يوسف", Status=OrderStatus.Assigned,
                AssignedPackager=Employees[4],
                Lines = new()
                {
                    new OrderLine { Product=Products[6], Quantity=3, UnitPrice=Products[6].RetailPrice },
                    new OrderLine { Product=Products[9], Quantity=1, UnitPrice=Products[9].RetailPrice },
                }
            });
            // غداً — Tomorrow
            Orders.Add(new Order
            {
                Id=6, Date=DateTime.Today.AddDays(1), Type=OrderType.Retail,
                CustomerName="حفل عيد ميلاد", Status=OrderStatus.Pending,
                Lines = new()
                {
                    new OrderLine { Product=Products[9], Quantity=2,  UnitPrice=Products[9].RetailPrice },
                    new OrderLine { Product=Products[7], Quantity=5,  UnitPrice=Products[7].RetailPrice },
                }
            });
            Orders.Add(new Order
            {
                Id=7, Date=DateTime.Today.AddDays(1), Type=OrderType.Wholesale,
                WholesaleClient=WholesaleClients[4], Status=OrderStatus.Pending,
                Lines = new()
                {
                    new OrderLine { Product=Products[0], Quantity=80, UnitPrice=Products[0].WholesalePrice },
                    new OrderLine { Product=Products[1], Quantity=50, UnitPrice=Products[1].WholesalePrice },
                    new OrderLine { Product=Products[4], Quantity=40, UnitPrice=Products[4].WholesalePrice },
                }
            });
        }

        public static int NextOrderId()   => Orders.Count   == 0 ? 1 : Orders.Max(o => o.Id)   + 1;
        public static int NextProductId() => Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;
        public static int NextEmployeeId()=> Employees.Count== 0 ? 1 : Employees.Max(e => e.Id)+ 1;
        public static int NextClientId()  => WholesaleClients.Count==0 ? 1 : WholesaleClients.Max(c=>c.Id)+1;

        public static string OrderTypeAr(OrderType t)     => t == OrderType.Retail ? "قطاعي" : "جملة";
        public static string OrderStatusAr(OrderStatus s) => s switch
        {
            OrderStatus.Pending   => "قيد الانتظار",
            OrderStatus.Assigned  => "تم التكليف",
            OrderStatus.Completed => "مكتمل",
            _ => ""
        };
        public static string RoleAr(EmployeeRole r) => r == EmployeeRole.Cook ? "طباخ" : "معبّئ";

        public static Employee? GetCookForProduct(Product p)
            => Employees.FirstOrDefault(e => e.Role == EmployeeRole.Cook && e.SkillProductIds.Contains(p.Id));
    }
}
