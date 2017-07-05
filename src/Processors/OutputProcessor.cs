using System.IO;
using GTA;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Processors
{
    public class OutputProcessor
    {

        public static void Process()
        {

            string payload = JsonConvert.SerializeObject(Main.Storage.vehicleStorage);
            
            try
            {
                string fileName = Path.Combine(Main.BasePath, "output/vehicleInfo.json");
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