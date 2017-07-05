using System.IO;
using GTA;
using GT_MP_vehicleInfo.Data;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Processors
{
    public class OutputProcessor
    {

        public static void Process(JsonSerializerSettings settings, string extension)
        {
            string payload = JsonConvert.SerializeObject(Main.Storage.vehicleStorage, settings);
            
            try
            {
                string fileName = Path.Combine(Main.BasePath, "output/vehicleInfo" + extension + ".json");
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                File.WriteAllText(fileName, payload);
            }
            catch (IOException e)
            {
                Console.Error("AN ERROR OCCURED: " + e.Message);
            }
            
        }
        public static void Process(string name, object data)
        {

            string payload = JsonConvert.SerializeObject(data);
            
            try
            {
                string fileName = Path.Combine(Main.BasePath, "gen_vdata/" + name + ".json");
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                File.WriteAllText(fileName, payload);
            }
            catch (IOException e)
            {
                Console.Error("AN ERROR OCCURED: " + e.Message);
            }
            
        }
        
        
    }
}