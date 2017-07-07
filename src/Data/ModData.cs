using System.Collections.Generic;
using GTA;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Data
{
    public class ModData : ILocalizable
    {
        public string name;
        
        public string localizedName;
        public List<string> flags = new List<string>();
        
        public void Localize()
        {
            this.localizedName = Game.GetLocalizedString(this.name);
        }
    }
}