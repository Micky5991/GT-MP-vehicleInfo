using GTA;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class LocalizationProcessor
    {

        public static void ProcessVehicle(VehicleData data)
        {
            data.localizedManufacturer = Game.GetLocalizedString(data.manufacturerName);
            data.localizedName = Game.GetLocalizedString(data.displayName);
            data.localizedVehicleClass = Game.GetLocalizedString("VEH_CLASS_" + data.vehicleClass);
        }
        
    }
}