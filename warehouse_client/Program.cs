using System.Net.Http.Json;
using System;
using System.Security.Cryptography.X509Certificates;

namespace warehouse_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quit = false;
            while (!quit)
            {
                Console.WriteLine("<<< warehouse_client >>>");
                Console.WriteLine("0. Show warehouse water stock");
                Console.WriteLine("1. Show registered");
                Console.WriteLine("2. Buy water");
                Console.WriteLine("3. Quit");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        ShowWarehouseWaterStock();
                        break;
                    case "1":
                        ShowRegisteredUsers();
                        break;
                    case "2":
                        BuyWater();
                        break;
                    case "3":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("[ERROR] Invalid option, choose option 0, 1, 2 or 3.");
                        break;
                }
            }
        }

        private static void BuyWater()
        {
            Console.WriteLine("Enter the username of the customer: ");
            var customerUserName = Console.ReadLine();

            var buyWaterDto = new BuyWaterDTO
            {
                CustomerUserName = customerUserName,
                BuyWaterDetails = new List<BuyWaterDetailDTO>(),
            };

            Console.WriteLine("Enter the name of the water you want to buy (if you want to stop adding water to the sale, enter 0): ");
            var waterName = Console.ReadLine();
            while (waterName != "0")
            {
                var type = "";
                try
                {
                    Console.WriteLine("Enter the type of the water you want to buy sparkling or still: ");
                    type = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid type!");
                    continue;
                }

                var quantity = 0;
                try
                {
                    Console.WriteLine("Enter the quantity of the water you want to buy: ");
                    quantity = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid quantity!");
                    continue;
                }

                var buyWaterDetailDto = new BuyWaterDetailDTO
                {
                    Name = waterName,
                    Quantity = quantity,
                    Type = type,
                };

                buyWaterDto.BuyWaterDetails.Add(buyWaterDetailDto);
                Console.WriteLine("Enter the name of the water you want to buy (if you want to stop adding water to the sale, enter 0): ");
                waterName = Console.ReadLine();
            }

            var httpClient = new HttpClient();
            var url = "https://localhost:44375/buy-water";
            var response = httpClient.PostAsJsonAsync(url, buyWaterDto).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sale saved successfully.");
            }
            else
            {
                Console.WriteLine("Sale not saved.");
            }
        }

        private static void ShowRegisteredUsers()
        {
            var httpClient = new HttpClient();
            var url = "https://localhost:44375/users";
            var users = httpClient.GetFromJsonAsync<string[]>(url).Result;
            foreach (var user in users)
            {
                Console.WriteLine($"{user}");
            }
        }

        private static void ShowWarehouseWaterStock()
        {
            var httpClient = new HttpClient();
            var urlWater = "https://localhost:44375/waters";
            var waters = httpClient.GetFromJsonAsync<WaterDTO[]>(urlWater).Result;
            for (int i = 0; i < waters.Length; i++)
            {
                Console.WriteLine($"==================== {waters[i].Name} ====================");
                Console.WriteLine($"Producer: {waters[i].Producer.Name}");
                Console.WriteLine($"Type: {waters[i].Type.Type}");
                Console.WriteLine($"pH: {waters[i].pH}");
                Console.WriteLine($"Mineralization: {waters[i].Mineralization}");
                Console.WriteLine($"Packing: {waters[i].PackingType.Type}");
                Console.WriteLine($"Cations: ");
                foreach (var cation in waters[i].Cations)
                {
                    Console.WriteLine($"{cation.Name} - {cation.Content}");
                }
                Console.WriteLine($"Anions: ");
                foreach (var anion in waters[i].Anions)
                {
                    Console.WriteLine($"{anion.Name} - {anion.Content}");
                }

                var numberOfBottles = 0;
                foreach (var delivery in waters[i].DeliveryDetails)
                {
                    numberOfBottles += delivery.NumberOfBottlesPerPallet * delivery.NumberOfPallets;
                }
                Console.WriteLine($"Number of delivered bottles: {numberOfBottles}");

                var numberOfSoldBottles = 0;
                foreach (var sale in waters[i].SaleDetails)
                {
                    numberOfSoldBottles += sale.Quantity;
                }
                Console.WriteLine($"Number of sold bottles: {numberOfSoldBottles}");
                Console.WriteLine($"Number of bottles in stock: {numberOfBottles - numberOfSoldBottles}");
                Console.WriteLine("====================================================");
            }
        }
    }
}