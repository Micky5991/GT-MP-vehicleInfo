using System.Collections.Generic;
using GTA;
using Newtonsoft.Json;

namespace GT_MP_vehicleInfo.Data
{
    public class VehicleData : IHashable, ILocalizable
    {

        public VehicleHash hash;
        public string name;
        public string displayName;
        public string localizedName;
        public string manufacturerName;
        public string localizedManufacturer;
        
        public int vehicleClass;
        public string vehicleClassName;
        public string localizedVehicleClass;
        public int wheelType;
        public string wheelTypeName;
        public string localizedWheelTypeName;

        public bool convertible;
        public bool electric;
        public bool trailer;
        public bool neon;
        public VehicleDimensions dimensions;
        public Dictionary<string, int> bones;

        public float maxSpeed;
        public float maxBraking;
        public float maxTraction;
        public float maxAcceleration;
        public float _0xBFBA3BA79CFF7EBF;
        public float _0x53409B5163D5B846;
        public float _0xC6AD107DDC9054CC;
        public float _0x5AA3F878A178C4FC;
        public int maxNumberOfPassengers;
        public int maxOccupants;
        
        
        public List<string> rewards = new List<string>();
        public Dictionary<int, ModTypeData> mods;
        public VehicleLiveries liveries;

        public void Hash()
        {
            this.hash = (VehicleHash) Game.GenerateHash(name);
        }

        public void Localize()
        {
            this.localizedManufacturer = Game.GetLocalizedString(this.manufacturerName);
            this.localizedName         = Game.GetLocalizedString(this.displayName);
            this.localizedVehicleClass = Game.GetLocalizedString("VEH_CLASS_" + this.vehicleClass);
            this.localizedWheelTypeName = Game.GetLocalizedString("VEH_CLASS_" + this.vehicleClass);

            this.liveries?.Localize();

            if (this.mods == null) return;
            foreach (var mod in this.mods.Values) mod.Localize();
        }
    }
}