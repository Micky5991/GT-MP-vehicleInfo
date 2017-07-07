using System;
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
            if (e.KeyCode == Keys.NumPad4)
            {
                foreach (var weapon in Enum.GetValues(typeof(WeaponHash)))
                {
                    Game.Player.Character.Weapons.Give((WeaponHash) weapon, 100, true, true);
                }
                
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                Console.Info("HORN: " + Game.GetLocalizedString("MUSICAL_HORN_BUSINESS_3"));
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                Vehicle veh = World.CreateVehicle((VehicleHash) Game.GenerateHash(Game.GetUserInput()),
                    Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f,
                    Game.Player.Character.Heading);
                veh.PlaceOnGround();

                
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                GTA.UI.Screen.ShowNotification("~y~Starting...");
                
                VehicleLoader.LoadVehicles();
                ModAssignProcessor.Process();
                LocalizationProcessor.Process();
                CleanupProcessor.Process();
                

                JsonSerializerSettings settings = new JsonSerializerSettings();
                //settings.Formatting = Formatting.Indented;
                // Normal, with translation
                OutputProcessor.Process(settings, ".full");
                
                // Smaller, without translation
                settings.ContractResolver = new NoLocalizationResolver();
                OutputProcessor.Process(settings, ".noloc");
                
                // Smallest, without lists
                settings.ContractResolver = new NoListsResolver();
                OutputProcessor.Process(settings, ".nolist");
               
                
                GTA.UI.Screen.ShowNotification("~g~Finished!");
            }
        }
    }
}