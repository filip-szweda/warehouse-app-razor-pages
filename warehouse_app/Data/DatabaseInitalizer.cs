using warehouse_app.Data;

namespace warehouse_app.Data
{
    public class DatabaseInitalizer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            List<PackagingType> packingTypes = new List<PackagingType>()
            {
                new PackagingType { Type = "Bottle", Capacity = 0.5 },
                new PackagingType { Type = "Can", Capacity = 0.33 },
                new PackagingType { Type = "Bottle", Capacity = 1.5 },
                new PackagingType { Type = "Bottle", Capacity = 2 },
                new PackagingType { Type = "Bottle", Capacity = 5 },
                new PackagingType { Type = "Bottle", Capacity = 10 },
            };

            if (!context.PackagingTypes.Any())
            {
                context.PackagingTypes.AddRange(packingTypes);
                context.SaveChanges();
            }

            var companies = new List<Company>()
            {
                new Company { Name = "AquaPure", PhoneNumber = "123-456-7890", Email = "contact@aquapure.com" },
                new Company { Name = "HydroFlow", PhoneNumber = "987-654-3210", Email = "info@hydroflow.com" },
                new Company { Name = "WaterWays", PhoneNumber = "123-456-7890", Email = "Watter@water.com" },
                new Company { Name = "WaterWorks", PhoneNumber = "987-654-3210", Email = "Test@Test.pl" },
                new Company { Name = "Nałęczowianka", PhoneNumber = "123-456-7890", Email = "Nałę@Nałę.pl" },
                new Company { Name = "Cisowianka", PhoneNumber = "987-654-3210", Email = "Cisowianka@wp.pl" },
                new Company { Name = "Muszynianka", PhoneNumber = "123-456-7890", Email = "Muszy@mus.pl" },
            };

            var waterTypes = new List<WaterType>()
            {
                new WaterType { Type = "Still" },
                new WaterType { Type = "Sparkling" },
            };

            if (!context.WaterTypes.Any())
            {
                context.WaterTypes.AddRange(waterTypes);
            }

            if (!context.Companies.Any())
            {
                context.Companies.AddRange(companies);
                context.SaveChanges();
            }

            var waters = new List<Water>()
            {
                new Water
                {
                    Name = "AquaPure", Type = waterTypes[0], Producer = companies[0], pH = 7.5M,
                    Packaging = packingTypes[0]
                },
                new Water
                {
                    Name = "HydroFlow", Type = waterTypes[0], Producer = companies[1], pH = 7.5M,
                    Packaging = packingTypes[1]
                },
                new Water
                {
                    Name = "WaterWays", Type = waterTypes[0], Producer = companies[2], pH = 7.5M,
                    Packaging = packingTypes[2]
                },
                new Water
                {
                    Name = "WaterWorks", Type = waterTypes[0], Producer = companies[3], pH = 7.5M,
                    Packaging = packingTypes[3]
                },
                new Water
                {
                    Name = "Nałęczowianka", Type = waterTypes[0], Producer = companies[4], pH = 7.5M,
                    Packaging = packingTypes[4]
                },
                new Water
                {
                    Name = "Cisowianka", Type = waterTypes[0], Producer = companies[5], pH = 7.5M,
                    Packaging = packingTypes[5]
                },
                new Water
                {
                    Name = "Muszynianka", Type = waterTypes[0], Producer = companies[6], pH = 7.5M,
                    Packaging = packingTypes[0]
                },
                new Water
                {
                    Name = "AquaPure", Type = waterTypes[1], Producer = companies[0], pH = 7.5M,
                    Packaging = packingTypes[1]
                },
                new Water
                {
                    Name = "HydroFlow", Type = waterTypes[1], Producer = companies[1], pH = 7.5M,
                    Packaging = packingTypes[2]
                },
                new Water
                {
                    Name = "WaterWays", Type = waterTypes[1], Producer = companies[2], pH = 7.5M,
                    Packaging = packingTypes[3]
                },
                new Water
                {
                    Name = "WaterWorks", Type = waterTypes[1], Producer = companies[3], pH = 7.5M,
                    Packaging = packingTypes[4]
                },
            };

            if (!context.Waters.Any())
            {
                context.Waters.AddRange(waters);
                context.SaveChanges();
            }

            context.Database.EnsureCreated();
            List<Cation> cations = new List<Cation>()
            {
                new Cation { Name = "Sodium", Symbol = "Na", Content = 0.02, CationWater = waters[0] },
                new Cation { Name = "Calcium", Symbol = "Ca", Content = 0.015, CationWater = waters[1] },
                new Cation { Name = "Magnesium", Symbol = "Mg", Content = 0.01, CationWater = waters[2] },
                new Cation { Name = "Potassium", Symbol = "K", Content = 0.005, CationWater = waters[3] },
                new Cation { Name = "Iron", Symbol = "Fe", Content = 0.0001, CationWater = waters[4] },
                new Cation { Name = "Manganese", Symbol = "Mn", Content = 0.0001, CationWater = waters[5] },
                new Cation { Name = "Zinc", Symbol = "Zn", Content = 0.0001, CationWater = waters[6] },
                new Cation { Name = "Copper", Symbol = "Cu", Content = 0.0001, CationWater = waters[7] },
                new Cation { Name = "Lithium", Symbol = "Li", Content = 0.0001, CationWater = waters[8] },
                new Cation { Name = "Strontium", Symbol = "Sr", Content = 0.0001, CationWater = waters[9] },
                new Cation { Name = "Barium", Symbol = "Ba", Content = 0.0001, CationWater = waters[10] }
            };

            List<Anion> anions = new List<Anion>()
            {
                new Anion { Name = "Chloride", Symbol = "Cl", Content = 0.03, AnionWater = waters[0] },
                new Anion { Name = "Sulfate", Symbol = "SO4", Content = 0.01, AnionWater = waters[1] },
                new Anion { Name = "Bicarbonate", Symbol = "HCO3", Content = 0.01, AnionWater = waters[2] },
                new Anion { Name = "Nitrate", Symbol = "NO3", Content = 0.001, AnionWater = waters[3] },
                new Anion { Name = "Fluoride", Symbol = "F", Content = 0.0001, AnionWater = waters[4] },
                new Anion { Name = "Bromide", Symbol = "Br", Content = 0.0001, AnionWater = waters[5] },
                new Anion { Name = "Iodide", Symbol = "I", Content = 0.0001, AnionWater = waters[6] },
                new Anion { Name = "Phosphate", Symbol = "PO4", Content = 0.0001, AnionWater = waters[7] },
                new Anion { Name = "Silicate", Symbol = "SiO2", Content = 0.0001, AnionWater = waters[8] },
                new Anion { Name = "Borate", Symbol = "BO3", Content = 0.0001, AnionWater = waters[9] },
                new Anion { Name = "Bromate", Symbol = "BrO3", Content = 0.0001, AnionWater = waters[10] }
            };

            if (!context.Cation.Any())
            {
                context.Cation.AddRange(cations);
                context.SaveChanges();
            }

            if (!context.Anion.Any())
            {
                context.Anion.AddRange(anions);
                context.SaveChanges();
            }

            var deliveryDetails = new List<DeliveryDetails>
            {
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[0] },
                new DeliveryDetails { NumberOfPallets = 15, BottlesPerPallet = 600, Water = waters[1] },
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[2] },
                new DeliveryDetails { NumberOfPallets = 15, BottlesPerPallet = 600, Water = waters[1] },
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[0] },
                new DeliveryDetails { NumberOfPallets = 15, BottlesPerPallet = 600, Water = waters[6] },
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[5] },
                new DeliveryDetails { NumberOfPallets = 15, BottlesPerPallet = 600, Water = waters[4] },
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[3] },
                new DeliveryDetails { NumberOfPallets = 15, BottlesPerPallet = 600, Water = waters[2] },
                new DeliveryDetails { NumberOfPallets = 10, BottlesPerPallet = 500, Water = waters[1] },
            };

            if (!context.DeliveryDetails.Any())
            {
                context.DeliveryDetails.AddRange(deliveryDetails);
                context.SaveChanges();
            }

            var deliveries = new List<Delivery>
            {
                new Delivery
                {
                    Employee = "emp1",
                    Supplier = companies[0],
                    DeliveryDetails = new List<DeliveryDetails> { deliveryDetails[0], deliveryDetails[1] },
                    DeliveryDate = DateTime.Now
                },
                new Delivery
                {
                    Employee = "emp2",
                    Supplier = companies[1],
                    DeliveryDetails = new List<DeliveryDetails> { deliveryDetails[2], deliveryDetails[3] },
                    DeliveryDate = DateTime.Now.AddDays(-1)
                },
                new Delivery
                {
                    Employee = "emp3",
                    Supplier = companies[2],
                    DeliveryDetails = new List<DeliveryDetails> { deliveryDetails[4], deliveryDetails[5] },
                    DeliveryDate = DateTime.Now.AddDays(-2)
                },
                new Delivery
                {
                    Employee = "emp4",
                    Supplier = companies[3],
                    DeliveryDetails = new List<DeliveryDetails> { deliveryDetails[6], deliveryDetails[7] },
                    DeliveryDate = DateTime.Now.AddDays(-3)
                },
                new Delivery
                {
                    Employee = "emp5",
                    Supplier = companies[4],
                    DeliveryDetails = new List<DeliveryDetails> { deliveryDetails[8], deliveryDetails[9] },
                    DeliveryDate = DateTime.Now.AddDays(-4)
                },
                new Delivery
                {
                    Employee = "emp6",
                    Supplier = companies[5],
                    DeliveryDetails = new List<DeliveryDetails> { deliveryDetails[10], deliveryDetails[1] },
                    DeliveryDate = DateTime.Now.AddDays(-5)
                },
            };

            if (!context.Deliveries.Any())
            {
                context.Deliveries.AddRange(deliveries);
                context.SaveChanges();
            }

            var saleDetails = new List<SaleDetails>
            {
                new SaleDetails { NumberOfBottles = 200, Water = waters[0] },
                new SaleDetails { NumberOfBottles = 250, Water = waters[1] },
                new SaleDetails { NumberOfBottles = 300, Water = waters[2] },
                new SaleDetails { NumberOfBottles = 350, Water = waters[3] },
                new SaleDetails { NumberOfBottles = 400, Water = waters[4] },
                new SaleDetails { NumberOfBottles = 450, Water = waters[5] },
                new SaleDetails { NumberOfBottles = 500, Water = waters[6] },
                new SaleDetails { NumberOfBottles = 550, Water = waters[7] },
            };

            if (!context.SaleDetails.Any())
            {
                context.SaleDetails.AddRange(saleDetails);
                context.SaveChanges();
            }

            var sales = new List<Sale>
            {
                new Sale
                {
                    Customer = "customer1",
                    SaleDetails = new List<SaleDetails> { saleDetails[0], saleDetails[1] },
                    SaleDate = DateTime.Now
                },
                new Sale
                {
                    Customer = "customer2",
                    SaleDetails = new List<SaleDetails> { saleDetails[2], saleDetails[3] },
                    SaleDate = DateTime.Now.AddDays(-1)
                },
                new Sale
                {
                    Customer = "customer3",
                    SaleDetails = new List<SaleDetails> { saleDetails[4], saleDetails[5] },
                    SaleDate = DateTime.Now.AddDays(-2)
                },
                new Sale
                {
                    Customer = "customer4",
                    SaleDetails = new List<SaleDetails> { saleDetails[6], saleDetails[7] },
                    SaleDate = DateTime.Now.AddDays(-3)
                },
            };

            if (!context.Sales.Any())
            {
                context.Sales.AddRange(sales);
                context.SaveChanges();
            }
        }
    }
}
