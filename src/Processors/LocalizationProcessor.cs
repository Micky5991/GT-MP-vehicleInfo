using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class LocalizationProcessor
    {

        public static void ProcessVehicle(VehicleData data)
        {
            data.Localize();
        }
        
    }
}