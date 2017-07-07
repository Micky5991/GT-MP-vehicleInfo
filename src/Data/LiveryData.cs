using GTA;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Data
{
    public class LiveryData : ILocalizable
    {
        public int id;
        public string name;
        
        public string localizedName;
        
        public void Localize()
        {
            this.localizedName = Game.GetLocalizedString(this.name);
        }
    }
}