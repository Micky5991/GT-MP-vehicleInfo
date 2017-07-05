using System.Linq;
using System.Xml.Linq;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class FlagProcessor
    {

        public static void Process(VehicleData vehicle, XElement element)
        {
            ProcessSingleData(vehicle, element);
            if (element.Element("flags") == null || element.Element("flags").IsEmpty) return;
            string[] flags = element.Element("flags").Value.Split(' ');

            vehicle.electric = flags.Contains("FLAG_IS_ELECTRIC");

        }

        public static void ProcessSingleData(VehicleData vehicle, XElement element)
        {
            vehicle.convertible = !element.Element("animConvRoofName").IsEmpty &&
                                  element.Element("animConvRoofName").Value == "roof";
            vehicle.manufacteurName = element.Element("vehicleMakeName").Value;
            vehicle.trailer = element.Element("type").Value == "VEHICLE_TYPE_TRAILER";
        }
        
    }
}