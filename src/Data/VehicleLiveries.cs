using System.Collections.Generic;

namespace GT_MP_vehicleInfo.Data
{
    public class VehicleLiveries : ILocalizable
    {
        public int amount;
        public Dictionary<int, LiveryData> list = new Dictionary<int, LiveryData>();


        public void Localize()
        {
            foreach (var livery in this.list.Values)
            {
                livery.Localize();
            }
        }
    }
}