using System;
using System.Security.Policy;
using System.Windows.Forms;
using GTA;
using GT_MP_vehicleInfo.Processors;
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
                GTA.Native.Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, Game.Player.Character.CurrentVehicle, false);
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                GTA.Native.Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, Game.Player.Character.CurrentVehicle, false);
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
                GTA.UI.Screen.ShowNotification("~y~Starting2...");
                
                VehicleLoader.LoadVehicles();
                OutputProcessor.Process();
                
            }
        }
    }
}