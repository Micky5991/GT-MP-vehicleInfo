using System;
using System.IO;
using GTA;
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
                    vehicle.wheelType = (int) cache.wheelType;

                    vehicle.wheelTypeName = GetWheelTypeName(cache.wheelType);
                }
                catch (Exception e)
                {
                    GTA.Console.Error("FEHLER BEI: " + vehicle.name);
                }

            }
            
            
        }

        private static string GetWheelTypeName(VehicleWheelType wheelType)
        {
            var typeNames = new[]
            {
                "CMOD_WHE1_5",
                "CMOD_WHE1_3",
                "CMOD_WHE1_2",
                "CMOD_WHE1_6",
                "CMOD_WHE1_4",
                "CMOD_WHE1_7",
                "CMOD_WHE1_0",
                "CMOD_WHE1_1",
                "CMOD_WHE1_8",
                "CMOD_WHE1_9"
            };
            return typeNames[(int) wheelType];
        }
        
    }
}