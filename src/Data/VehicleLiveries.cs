using System.Collections.Generic;

namespace GT_MP_vehicleInfo.Data
{
    public class VehicleLiveries
    {
        public int amount;
        public Dictionary<int, LiveryData> list = new Dictionary<int, LiveryData>();
    }
}