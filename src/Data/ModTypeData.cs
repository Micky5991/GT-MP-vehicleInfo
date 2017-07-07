using System.Collections.Generic;

namespace GT_MP_vehicleInfo.Data
{
    public class ModTypeData : ILocalizable
    {
        public int amount;
        public Dictionary<int, ModData> list = new Dictionary<int, ModData>();

        public void Localize()
        {
            foreach (var data in this.list.Values) data.Localize();
        }
    }
}