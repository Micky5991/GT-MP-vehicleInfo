using System.Linq;
using GTA;
using GT_MP_vehicleInfo.Data;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Processors
{
    public class CleanupProcessor
    {

        public static void Process()
        {
            foreach (var vehicleData in Main.Storage.vehicleStorage.Values)
            {
                CleanUpWheels(vehicleData);
                RemoveEmptyMods(vehicleData);
            }
        }

        public static void CleanUpWheels(VehicleData vehicle)
        {
            // If the stock wheel doesnt exist, clear
            if (!vehicle.mods.ContainsKey(23)) return;
            var mods = vehicle.mods[23];
            if (!mods.list.ContainsKey(0)) return;
            if (string.IsNullOrEmpty(mods.list[0].name)) vehicle.mods.Remove(23);
        }

        public static void RemoveEmptyMods(VehicleData vehicle)
        {
            var emptyIds = vehicle.mods.Where(e => e.Value.amount == 0).Select(e => e.Key).ToArray();

            Console.Debug("EMPTYIDS: " + JsonConvert.SerializeObject(emptyIds));
            
            foreach (int emptyId in emptyIds)
            {
                vehicle.mods.Remove(emptyId);
            }
        }
        
    }
}