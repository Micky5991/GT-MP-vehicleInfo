using System;
using System.IO;
using GT_MP_vehicleInfo.Data;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Processors
{
    public class ModAssignProcessor
    {

        public static void Process()
        {
            var vehicles = Main.Storage.vehicleStorage;
            foreach (var vehicle in vehicles.Values)
            {
                try
                {
                    var path = Path.Combine(Main.BasePath, "gen_vdata/" + vehicle.name + ".json");
                    if (!File.Exists(path)) continue;

                    var cache = JsonConvert.DeserializeObject<VehicleCache>(File.ReadAllText(path));

                    vehicle.mods = cache.mods;
                    vehicle.liveries = cache.liveries;
                    vehicle.dimensions = cache.dimensions;
                    vehicle.neon = cache.neon;
                    vehicle.bones = cache.bones;
                }
                catch (Exception e)
                {
                    GTA.Console.Error("FEHLER BEI: " + vehicle.name);
                }

            }
            
            
        }
        
    }
}