using System.Linq;
using System.Xml.Linq;
using GTA;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class FlagProcessor
    {

        public static void Process(VehicleData vehicle, XElement element)
        {
            ProcessSingleData(vehicle, element);
            ProcessFlags(vehicle, element);
            ProcessRewards(vehicle, element);
        }

        public static void ProcessFlags(VehicleData vehicle, XElement element)
        {
            if (element.Element("flags") == null || element.Element("flags").IsEmpty) return;
            string[] flags = element.Element("flags").Value.Split(' ');

            vehicle.electric = flags.Contains("FLAG_IS_ELECTRIC");
            //vehicle.neon     = flags.Contains("FLAG_CAN_HAVE_NEONS"); // NOT ALL VEHICLES...
        }

        public static void ProcessSingleData(VehicleData vehicle, XElement element)
        {
            vehicle.convertible = !element.Element("animConvRoofName").IsEmpty &&
                                  element.Element("animConvRoofName").Value == "roof";
            vehicle.manufacturerName = element.Element("vehicleMakeName").Value;
            vehicle.trailer = element.Element("type").Value == "VEHICLE_TYPE_TRAILER";
        }

        public static void ProcessRewards(VehicleData vehicle, XElement element)
        {
            var el = element.Element("rewards");

            if (el == null || el.IsEmpty) return;
            foreach (var item in el.Elements())
            {
                vehicle.rewards.Add(item.Value);
            }
        }
        
    }
}