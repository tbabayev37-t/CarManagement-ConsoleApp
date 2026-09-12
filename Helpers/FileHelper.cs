using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarDealershipFull.Helpers
{
    public static class FileHelper
    {
        private static readonly string filePath = "cars.json";

        public static void SaveCars(List<Car> cars)
        {
            string jsonString = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Car> LoadCars()
        {
            if (!File.Exists(filePath))
            {
                return new List<Car>();
            }

            string jsonString = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<Car>();
            }

            return JsonSerializer.Deserialize<List<Car>>(jsonString) ?? new List<Car>();
        }
    }
}