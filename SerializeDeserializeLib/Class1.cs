using System.Text.Json;

namespace SerializeDeserializeLib
{
    public static class Json
    {
        public static void SerializeToFile<T>(T obj, string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Объект успешно сериализован и записан в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            try
            {
                    string jsonString = File.ReadAllText(filePath);
                    T obj = JsonSerializer.Deserialize<T>(jsonString);
                    return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return default;
            }
        }           
    }
}