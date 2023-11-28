using System.Net.Http.Json;
using System;
using System.Security.Cryptography.X509Certificates;
using warehouse_lib.DTO;

namespace warehouse_client
{
    internal class Program
    {
        static string baseUrl = "https://localhost:44384";

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
            Console.WriteLine("Enter customer: ");
            var customerUserName = Console.ReadLine();

            var buyWater = new warehouse_lib.DTO.BuyWater
            {
                Customer = customerUserName,
                BuyWaterDetails = new List<warehouse_lib.DTO.BuyWaterDetails>(),
            };

            Console.WriteLine("Enter water name (enter 'stop' to stop adding water): ");
            var waterName = Console.ReadLine();
            while (waterName != "stop")
            {
                var type = "";
                try
                {
                    Console.WriteLine("Enter type (Sparkling / Still): ");
                    type = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR] Invalid type.");
                    continue;
                }

                var numberOfBottles = 0;
                try
                {
                    Console.WriteLine("Enter number of bottles: ");
                    numberOfBottles = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR] Invalid number of bottles.");
                    continue;
                }

                var buyWaterDetails = new warehouse_lib.DTO.BuyWaterDetails
                {
                    Name = waterName,
                    NumberOfBottles = numberOfBottles,
                    Type = type,
                };

                buyWater.BuyWaterDetails.Add(buyWaterDetails);
                Console.WriteLine("Enter water name (enter 'stop' to stop adding water): ");
                waterName = Console.ReadLine();
            }

            var httpClient = new HttpClient();
            var url = $"{baseUrl}/buy-water";

            var response = httpClient.PostAsJsonAsync(url, buyWater).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success.");
                return;
            }

            Console.WriteLine("Failure.");
        }

        private static void ShowRegisteredUsers()
        {
            var httpClient = new HttpClient();
            var url = $"{baseUrl}/registered-users";

            var users = httpClient.GetFromJsonAsync<warehouse_lib.DTO.User[]>(url).Result;
            foreach (var user in users)
            {
                Console.WriteLine("====================================================");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"UserName: {user.UserName}");
                Console.WriteLine($"Email: {user.Email}");
            }
        }

        private static void ShowWarehouseWaterStock()
        {
            var httpClient = new HttpClient();
            var urlWater = $"{baseUrl}/waters";

            var waters = httpClient.GetFromJsonAsync<warehouse_lib.DTO.Water[]>(urlWater).Result;
            for (int i = 0; i < waters.Length; i++)
            {
                Console.WriteLine("====================================================");
                Console.WriteLine($"Id: {waters[i].Id}");
                Console.WriteLine($"Name: {waters[i].Name}");
                Console.WriteLine($"TypeId: {waters[i].TypeId}");
                Console.WriteLine($"ProducerId: {waters[i].ProducerId}");
                Console.WriteLine($"pH: {waters[i].pH}");
                
                Console.WriteLine($"Cations Ids: ");
                foreach (var cationId in waters[i].CationsIds)
                {
                    Console.WriteLine($"\t{cationId}");
                }

                Console.WriteLine($"Anions Ids: ");
                foreach (var anionId in waters[i].AnionsIds)
                {
                    Console.WriteLine($"\t{anionId}");
                }

                var deliveredWaterBottles = 0;
                foreach (var deliveryDetailsNumberOfBottles in waters[i].DeliveryDetailsNumberOfBottles)
                {
                    deliveredWaterBottles += deliveryDetailsNumberOfBottles;
                }
                Console.WriteLine($"Delivered water bottles: {deliveredWaterBottles}");

                var soldWaterBottles = 0;
                foreach (var saleDetailsNumberOfBottles in waters[i].SaleDetailsNumberOfBottles)
                {
                    soldWaterBottles += saleDetailsNumberOfBottles;
                }

                Console.WriteLine($"Sold water bottles: {soldWaterBottles}");
                Console.WriteLine($"Water bottles in stock: {deliveredWaterBottles - soldWaterBottles}");
            }
        }
    }
}