using System;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;
using GTA;
using GT_MP_vehicleInfo.Processors;
using Newtonsoft.Json;
using Console = GTA.Console;
using Hash = GTA.Native.Hash;

namespace GT_MP_vehicleInfo
{
    public class Main : Script
    {

        public static readonly string BasePath = @"scripts/vehicleinfo/";
        public static readonly Storage Storage = new Storage();
        public static string languageCode = "";

        public Main()
        {
            this.Tick += this.OnTick;    
            this.KeyUp += OnKeyUp;
        }

        private void OnTick(object sender, EventArgs eventArgs)
        {
            Game.Player.WantedLevel = 0;
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
                
                GTA.UI.Screen.ShowNotification("~y~Starting...");
                
                VehicleLoader.LoadVehicles();
                ModAssignProcessor.Process();
                LocalizationProcessor.Process();
                CleanupProcessor.Process();
                

                OutputProcessor.OutputVehicleInfo();
               
                
                GTA.UI.Screen.ShowNotification("~g~Finished!");
            }
        }
        
        public static string GetPath(string path, bool create = false)
        {
            string resultPath = Path.Combine(BasePath, path);
            Console.Info(resultPath);
            if (create)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(resultPath));
            }
            
            return resultPath;
        }
    }
}