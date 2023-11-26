using warehouse_lib.Model;

namespace warehouse_app.Data
{
    public class DatabaseInitalizer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            List<PackagingType> packingTypes = new List<PackagingType>()
            {
                new PackagingType { Type = "Small Bottle", Capacity = 0.5 },
                new PackagingType { Type = "Medium Bottle", Capacity = 1.0 },
                new PackagingType { Type = "Large Bottle", Capacity = 1.5 },
                new PackagingType { Type = "Jug", Capacity = 5 },
                new PackagingType { Type = "Drum", Capacity = 20 },
                new PackagingType { Type = "Tanker", Capacity = 1000 },
            };

            if (!context.PackagingTypes.Any())
            {
                context.PackagingTypes.AddRange(packingTypes);
                context.SaveChanges();
            }

            var companies = new List<Company>()
            {
                new Company { Name = "HydroFlow Essentials", PhoneNumber = "321-654-0987", Email = "contact@hydroflow.com" },
                new Company { Name = "BlueWave Hydration", PhoneNumber = "234-567-8901", Email = "info@bluewave.com" },
                new Company { Name = "CrystalClear Waters", PhoneNumber = "345-678-9012", Email = "support@crystalclear.com" },
                new Company { Name = "SpringSource", PhoneNumber = "456-789-0123", Email = "hello@springsource.com" },
                new Company { Name = "MountainFlow", PhoneNumber = "567-890-1234", Email = "inquiry@mountainflow.com" },
                new Company { Name = "PureStream", PhoneNumber = "678-901-2345", Email = "sales@purestream.com" },
                new Company { Name = "RiverBend Beverages", PhoneNumber = "789-012-3456", Email = "contactus@riverbend.com" },
            };

            if (!context.Companies.Any())
            {
                context.Companies.AddRange(companies);
                context.SaveChanges();
            }

            var waterTypes = new List<WaterType>()
            {
                new WaterType { Type = "Still" },
                new WaterType { Type = "Sparkling" },
            };

            if (!context.WaterTypes.Any())
            {
                context.WaterTypes.AddRange(waterTypes);
            }

            var waters = new List<Water>()
            {
                new Water
                {
                    Name = "HydroFlow", Type = waterTypes[0], Producer = companies[0], pH = 7.5M,
                    Packaging = packingTypes[0], Photo = ""
                },
                new Water
                {
                    Name = "BlueWave", Type = waterTypes[0], Producer = companies[1], pH = 8.0M,
                    Packaging = packingTypes[1], Photo = ""
                },
                new Water
                {
                    Name = "CrystalClear", Type = waterTypes[0], Producer = companies[2], pH = 6.8M,
                    Packaging = packingTypes[2], Photo = ""
                },
                new Water
                {
                    Name = "SpringSource", Type = waterTypes[0], Producer = companies[3], pH = 7.2M,
                    Packaging = packingTypes[3], Photo = ""
                },
                new Water
                {
                    Name = "MountainFlow", Type = waterTypes[0], Producer = companies[4], pH = 7.8M,
                    Packaging = packingTypes[4], Photo = ""
                },
                new Water
                {
                    Name = "PureStream", Type = waterTypes[0], Producer = companies[5], pH = 6.5M,
                    Packaging = packingTypes[5], Photo = ""
                },
                new Water
                {
                    Name = "RiverBend", Type = waterTypes[0], Producer = companies[6], pH = 8.2M,
                    Packaging = packingTypes[0], Photo = ""
                },
                new Water
                {
                    Name = "HydroFlow", Type = waterTypes[1], Producer = companies[0], pH = 7.0M,
                    Packaging = packingTypes[1], Photo = ""
                },
                new Water
                {
                    Name = "BlueWave", Type = waterTypes[1], Producer = companies[1], pH = 7.4M,
                    Packaging = packingTypes[2], Photo = ""
                },
                new Water
                {
                    Name = "CrystalClear", Type = waterTypes[1], Producer = companies[2], pH = 7.1M,
                    Packaging = packingTypes[3], Photo = ""
                }
            };

            if (!context.Waters.Any())
            {
                context.Waters.AddRange(waters);
                context.SaveChanges();
            }

            List<Cation> cations = new List<Cation>()
            {
                new Cation { Name = "Magnesium", Symbol = "Mg", Content = 0.03, CationWater = waters[2] },
                new Cation { Name = "Sodium", Symbol = "Na", Content = 0.025, CationWater = waters[0] },
                new Cation { Name = "Potassium", Symbol = "K", Content = 0.02, CationWater = waters[3] },
                new Cation { Name = "Calcium", Symbol = "Ca", Content = 0.015, CationWater = waters[1] },
                new Cation { Name = "Iron", Symbol = "Fe", Content = 0.001, CationWater = waters[4] },
                new Cation { Name = "Manganese", Symbol = "Mn", Content = 0.0005, CationWater = waters[5] },
                new Cation { Name = "Zinc", Symbol = "Zn", Content = 0.0002, CationWater = waters[6] },
                new Cation { Name = "Copper", Symbol = "Cu", Content = 0.0003, CationWater = waters[7] },
                new Cation { Name = "Lithium", Symbol = "Li", Content = 0.0004, CationWater = waters[8] },
                new Cation { Name = "Strontium", Symbol = "Sr", Content = 0.0001, CationWater = waters[9] }
            };

            if (!context.Cation.Any())
            {
                context.Cation.AddRange(cations);
                context.SaveChanges();
            }

            List<Anion> anions = new List<Anion>()
            {
                new Anion { Name = "Bicarbonate", Symbol = "HCO3", Content = 0.02, AnionWater = waters[2] },
                new Anion { Name = "Chloride", Symbol = "Cl", Content = 0.015, AnionWater = waters[0] },
                new Anion { Name = "Sulfate", Symbol = "SO4", Content = 0.005, AnionWater = waters[1] },
                new Anion { Name = "Bromide", Symbol = "Br", Content = 0.001, AnionWater = waters[5] },
                new Anion { Name = "Nitrate", Symbol = "NO3", Content = 0.0005, AnionWater = waters[3] },
                new Anion { Name = "Fluoride", Symbol = "F", Content = 0.0002, AnionWater = waters[4] },
                new Anion { Name = "Phosphate", Symbol = "PO4", Content = 0.0003, AnionWater = waters[7] },
                new Anion { Name = "Iodide", Symbol = "I", Content = 0.0001, AnionWater = waters[6] },
                new Anion { Name = "Silicate", Symbol = "SiO2", Content = 0.0004, AnionWater = waters[8] },
                new Anion { Name = "Borate", Symbol = "BO3", Content = 0.0001, AnionWater = waters[9] }
            };

            if (!context.Anion.Any())
            {
                context.Anion.AddRange(anions);
                context.SaveChanges();
            }

            var deliveries = new List<Delivery>
            {
                new Delivery
                {
                    Employee = "employee1",
                    Supplier = companies[0],
                    DeliveryDate = DateTime.Now
                },
                new Delivery
                {
                    Employee = "employee2",
                    Supplier = companies[1],
                    DeliveryDate = DateTime.Now.AddDays(-1)
                },
                new Delivery
                {
                    Employee = "employee3",
                    Supplier = companies[2],
                    DeliveryDate = DateTime.Now.AddDays(-2)
                },
                new Delivery
                {
                    Employee = "employee4",
                    Supplier = companies[3],
                    DeliveryDate = DateTime.Now.AddDays(-3)
                },
                new Delivery
                {
                    Employee = "employee5",
                    Supplier = companies[4],
                    DeliveryDate = DateTime.Now.AddDays(-4)
                },
                new Delivery
                {
                    Employee = "employee6",
                    Supplier = companies[5],
                    DeliveryDate = DateTime.Now.AddDays(-5)
                },
            };

            if (!context.Deliveries.Any())
            {
                context.Deliveries.AddRange(deliveries);
                context.SaveChanges();
            }

            var deliveryDetails = new List<DeliveryDetails>
            {
                new DeliveryDetails { NumberOfPallets = 12, BottlesPerPallet = 550, Water = waters[3], Delivery = deliveries[1] },
                new DeliveryDetails { NumberOfPallets = 14, BottlesPerPallet = 580, Water = waters[2], Delivery = deliveries[4] },
                new DeliveryDetails { NumberOfPallets = 11, BottlesPerPallet = 510, Water = waters[5], Delivery = deliveries[3] },
                new DeliveryDetails { NumberOfPallets = 13, BottlesPerPallet = 570, Water = waters[4], Delivery = deliveries[2] },
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[1], Delivery = deliveries[5] },
                new DeliveryDetails { NumberOfPallets = 15, BottlesPerPallet = 600, Water = waters[0], Delivery = deliveries[0] },
                new DeliveryDetails { NumberOfPallets = 9,  BottlesPerPallet = 490, Water = waters[6], Delivery = deliveries[5] },
                new DeliveryDetails { NumberOfPallets = 16, BottlesPerPallet = 610, Water = waters[0], Delivery = deliveries[3] },
                new DeliveryDetails { NumberOfPallets = 8,  BottlesPerPallet = 480, Water = waters[2], Delivery = deliveries[4] },
                new DeliveryDetails { NumberOfPallets = 17, BottlesPerPallet = 620, Water = waters[1], Delivery = deliveries[1] },
                new DeliveryDetails { NumberOfPallets = 7,  BottlesPerPallet = 470, Water = waters[3], Delivery = deliveries[2] },
            };

            if (!context.DeliveryDetails.Any())
            {
                context.DeliveryDetails.AddRange(deliveryDetails);
                context.SaveChanges();
            }

            var sales = new List<Sale>
            {
                new Sale
                {
                    Customer = "customer1",
                    SaleDate = DateTime.Now
                },
                new Sale
                {
                    Customer = "customer2",
                    SaleDate = DateTime.Now.AddDays(-1)
                },
                new Sale
                {
                    Customer = "customer3",
                    SaleDate = DateTime.Now.AddDays(-2)
                },
                new Sale
                {
                    Customer = "customer4",
                    SaleDate = DateTime.Now.AddDays(-3)
                },
            };

            if (!context.Sales.Any())
            {
                context.Sales.AddRange(sales);
                context.SaveChanges();
            }

            var saleDetails = new List<SaleDetails>
            {
                new SaleDetails { NumberOfBottles = 275, Water = waters[3], Sale = sales[1] },
                new SaleDetails { NumberOfBottles = 325, Water = waters[2], Sale = sales[2] },
                new SaleDetails { NumberOfBottles = 375, Water = waters[5], Sale = sales[2] },
                new SaleDetails { NumberOfBottles = 425, Water = waters[4], Sale = sales[3] },
                new SaleDetails { NumberOfBottles = 475, Water = waters[6], Sale = sales[0] },
                new SaleDetails { NumberOfBottles = 225, Water = waters[1], Sale = sales[1] },
                new SaleDetails { NumberOfBottles = 525, Water = waters[7], Sale = sales[3] },
                new SaleDetails { NumberOfBottles = 200, Water = waters[0], Sale = sales[0] },
            };

            if (!context.SaleDetails.Any())
            {
                context.SaleDetails.AddRange(saleDetails);
                context.SaveChanges();
            }
        }
    }
}
