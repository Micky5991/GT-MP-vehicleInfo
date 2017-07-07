using System.Runtime.InteropServices;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class LocalizationProcessor
    {

        public static void Process()
        {
            foreach (var vehicle in Main.Storage.vehicleStorage.Values)    
            {
                ProcessVehicle(vehicle);
            }
        }
        
        public static void ProcessVehicle(VehicleData data)
        {
            data.Localize();
        }
        
    }
}