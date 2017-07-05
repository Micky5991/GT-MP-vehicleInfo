using System.Collections.Generic;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Data
{
    public class ModData
    {
        public string name;
        
        public string localizedName;
        public List<string> flags = new List<string>();
    }
}