using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// penamaan MyTaskDataPath.json
// berguna untuk menyimpan semua nama file json account

namespace MyTaskData
{
    public class DataPath
    {
        public List<string> Paths { get; set; }

        public void WriteToFile(string filePath)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
                // Tulis string JSON ke file
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat menulis ke file: {ex.Message}");
            }
        }

        public static DataPath ReadFromFile(string filePath)
        {
            try
            {
                // Baca string JSON dari file
                string jsonString = File.ReadAllText(filePath);
                // Konversi string JSON ke objek
                DataPath dataPath = JsonConvert.DeserializeObject<DataPath>(jsonString);
                return dataPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat membaca dari file: {ex.Message}");
                return null;
            }
        }
    }
}
