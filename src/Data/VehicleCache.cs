using System.Collections.Generic;

namespace GT_MP_vehicleInfo.Data
{
    public class VehicleCache
    {
        public Dictionary<int, ModTypeData> mods;
        public VehicleLiveries liveries;
        public VehicleDimensions dimensions;
        public bool neon;
        public Dictionary<string, int> bones;
    }
}