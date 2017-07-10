using System.IO;
using GTA;
using GT_MP_vehicleInfo.Data;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Processors
{
    public class OutputProcessor
    {

        public static void OutputVehicleInfo()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings {Formatting = Formatting.Indented};

            // Large, Indented (For research purposes)
            OutputToJson(settings, ".ind");
                
            settings.Formatting = Formatting.None;
                
            // Normal, with translation
            OutputToJson(settings, ".full");
                
            // Smaller, without translation
            settings.ContractResolver = new NoLocalizationResolver();
            OutputToJson(settings, ".noloc");
                
            // Smallest, without lists
            settings.ContractResolver = new NoListsResolver();
            OutputToJson(settings, ".nolist");
        }
        
        private static void OutputToJson(JsonSerializerSettings settings, string extension)
        {
            Process(@"output/vehicleInfo" + extension + ".json", Main.Storage.vehicleStorage, settings);
        }
        
        public static void Process(string path, object data, JsonSerializerSettings settings = null)
        {
            string payload = JsonConvert.SerializeObject(data, settings);
            
            try
            {
                File.WriteAllText(Main.GetPath(path, true), payload);
            }
            catch (IOException e)
            {
                Console.Error("AN ERROR OCCURED: " + e.Message);
            }
            
        }
        
        
    }
}