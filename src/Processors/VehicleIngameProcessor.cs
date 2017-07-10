using System.Collections.Generic;
using System.IO;
using GTA;
using GTA.Native;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class VehicleIngameProcessor
    {
        public static int counter;
        
        public static void Process(VehicleData vehicle)
        {
            vehicle.vehicleClass = (int) Vehicle.GetModelClass(vehicle.hash);
	        vehicle.vehicleClassName = "VEH_CLASS_" + vehicle.vehicleClass;
            vehicle.displayName = Vehicle.GetModelDisplayName(vehicle.hash);

            if (File.Exists(Path.Combine(Main.BasePath, "gen_vdata/") + vehicle.name + ".json")) return;
            
            if (counter++ == 0)
            {
                if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, "mod_mnu", 10))
                {
                    Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, 10, true);
                    Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, "mod_mnu", 10);
                }
            }
            
            Vehicle veh = World.CreateVehicle(vehicle.hash,
                Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3.0f,
                Game.Player.Character.Rotation.Z + 90f);
            
            Script.Wait(25);

	        if (veh == null) return;
	        
	        var mods = ProcessVehicleMods(veh);
	        var liveries = ProcessVehicleLiveries(veh);
	            
	        OutputProcessor.Process(@"gen_vdata/" + vehicle.name + ".json", new VehicleCache
	        {
		        mods = mods,
		        liveries = liveries
	        });
	            
	        veh.Delete();
	        Script.Wait(150);
        }

	    private static VehicleLiveries ProcessVehicleLiveries(Vehicle vehicle)
	    {
		    var amount = Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, vehicle);
		    var vLivery = new VehicleLiveries
		    {
			    amount = amount < 0 ? 0 : amount
		    };

		    for (int i = 0; i < vLivery.amount; i++)
		    {
			    var name = Function.Call<string>(Hash.GET_LIVERY_NAME, vehicle, i);
			    vLivery.list.Add(i, new LiveryData
			    {
				    id = i, 
				    name = name
			    });
		    }
		    
		    return vLivery;
	    }

	    private static Dictionary<int, ModTypeData> ProcessVehicleMods(Vehicle veh)
	    {
		    Dictionary<int, ModTypeData> modTypeData = new Dictionary<int, ModTypeData>();
		    veh.Mods.InstallModKit();
		    foreach (var mod in veh.Mods.GetAllMods())
		    {
			    var data = new ModTypeData {amount = mod.ModCount};

			    for (int i = -1; i < mod.ModCount; i++)
			    {
				    var name = GetModName(veh, mod.ModType, i);
				    if(i == -1 && name == string.Empty) continue;

				    var modObj = new ModData
				    {
					    name = name
				    };
				    data.list.Add(i, modObj);
				    ApplyFlags(modObj, mod.ModType, mod.ModCount, i);
			    }

			    modTypeData.Add((int) mod.ModType, data);
		    }
		    return modTypeData;
	    }

        private static string GetModName(Vehicle vehicle, VehicleModType modtype, int index)
        {
            switch (modtype)
            {
                case VehicleModType.Armor:
                    return "CMOD_ARM_" + (index + 1);
                case VehicleModType.Brakes:
                    return "CMOD_BRA_" + (index + 1);
                case VehicleModType.Engine:
                    if (index == -1)  return "CMOD_ARM_0";
                    return "CMOD_ENG_" + (index + 2);
                case VehicleModType.Suspension:
                    return "CMOD_SUS_" + (index + 1);
                case VehicleModType.Transmission:
                    return "CMOD_GBX_" + (index + 1);
				case VehicleModType.Horns:
					if (VehicleHorns.HornNames.ContainsKey(index)) return VehicleHorns.HornNames[index].Item1;
					return "";
                default: return Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, vehicle, (int) modtype, index);
            }
        }

	    private static void ApplyFlags(ModData mod, VehicleModType modtype, int count, int index)
	    {
		    if(index == -1) mod.flags.Add("stock");
		    switch (modtype)
		    {
			    case VehicleModType.FrontWheel:
			    case VehicleModType.RearWheel:
				    if (index >= count / 2) mod.flags.Add("chrome");
				    break;
		    }
	    }
    }
}