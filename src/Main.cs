using System.IO;
using System.Windows.Forms;
using GTA;
using GTA.UI;
using GT_MP_vehicleInfo.Processors;

namespace GT_MP_vehicleInfo
{
    public class Main : Script
    {

        public static readonly string BasePath = @"scripts/vehicleinfo/";
        public static readonly Storage Storage = new Storage();
        public static string languageCode = "";

        public Main()
        {  
            this.KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.NumPad4)
            {
                foreach (var weapon in Enum.GetValues(typeof(WeaponHash)))
                {
                    Game.Player.Character.Weapons.Give((WeaponHash) weapon, 100, true, true);
                }
                
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                Vehicle veh = World.CreateVehicle((VehicleHash) Game.GenerateHash(Game.GetUserInput()),
                    Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f,
                    Game.Player.Character.Heading);
                veh.PlaceOnGround();
            }*/
            if (e.KeyCode == Keys.NumPad1)
            {
                if (string.IsNullOrEmpty(languageCode)) languageCode = Game.GetUserInput("de");
                
                Notification.Show("~y~Starting...");
                
                VehicleLoader.LoadVehicles();
                ModAssignProcessor.Process();
                LocalizationProcessor.Process();
                CleanupProcessor.Process();
                

                OutputProcessor.OutputVehicleInfo();
               
                
                Notification.Show("~g~Finished!");
            }
        }
        
        public static string GetPath(string path, bool create = false)
        {
            string resultPath = Path.Combine(BasePath, path);
            if (create)Directory.CreateDirectory(Path.GetDirectoryName(resultPath));
            return resultPath;
        }
    }
}
