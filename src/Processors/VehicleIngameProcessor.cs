using GTA;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class VehicleIngameProcessor
    {
        public static void Process(VehicleData vehicle)
        {
            vehicle.vehicleClass = (int) Vehicle.GetModelClass(vehicle.hash);
            vehicle.displayName = Vehicle.GetModelDisplayName(vehicle.hash);

            Vehicle veh = World.CreateVehicle(vehicle.hash,
                Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f,
                Game.Player.Character.Rotation.Z + 90f);

            Script.Wait(25);
            
            if (veh != null)
            {
                veh.Delete();
                Script.Wait(100);
            }
        }
    }
}