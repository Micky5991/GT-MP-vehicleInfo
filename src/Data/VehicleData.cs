using GTA;

namespace GT_MP_vehicleInfo.Data
{
    public class VehicleData : IHashable, ILocalizable
    {

        public VehicleHash hash;
        public string name;
        public string displayName;
        public string localizedName;
        public string manufacteurName;
        public string localizedManufacteur;

        public bool convertible;
        public bool electric;
        //public bool neon;
        
        public int vehicleClass;
        public string localizedVehicleClass;

        public void Hash()
        {
            this.hash = (VehicleHash) Game.GenerateHash(name);
        }

        public void Localize()
        {
            
        }
    }
}