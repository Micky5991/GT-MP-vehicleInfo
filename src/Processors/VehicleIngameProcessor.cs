using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class VehicleIngameProcessor
    {
        public static int counter;

	    private static List<string> vehicleBones = LoadVehicleBones().ToList();
        
        public static void Process(VehicleData vehicle)
        {
            vehicle.vehicleClass = (int) Vehicle.GetModelClass(vehicle.hash);
	        vehicle.vehicleClassName = "VEH_CLASS_" + vehicle.vehicleClass;
            vehicle.displayName = Vehicle.GetModelDisplayName(vehicle.hash);

	        vehicle.maxSpeed = Function.Call<float>(Hash._GET_VEHICLE_MODEL_MAX_SPEED, vehicle.hash);
	        vehicle.maxBraking = Function.Call<float>(Hash.GET_VEHICLE_MODEL_MAX_BRAKING, vehicle.hash);
	        vehicle.maxTraction = Function.Call<float>(Hash.GET_VEHICLE_MODEL_MAX_TRACTION, vehicle.hash);
	        vehicle.maxAcceleration = Function.Call<float>(Hash.GET_VEHICLE_MODEL_ACCELERATION, vehicle.hash);
	        vehicle._0xBFBA3BA79CFF7EBF = Function.Call<float>((Hash) Convert.ToUInt64("0xBFBA3BA79CFF7EBF", 16), vehicle.hash);
	        vehicle._0x53409B5163D5B846 = Function.Call<float>((Hash) Convert.ToUInt64("0x53409B5163D5B846", 16), vehicle.hash);
	        vehicle._0xC6AD107DDC9054CC = Function.Call<float>((Hash) Convert.ToUInt64("0xC6AD107DDC9054CC", 16), vehicle.hash);
	        vehicle._0x5AA3F878A178C4FC = Function.Call<float>((Hash) Convert.ToUInt64("0x5AA3F878A178C4FC", 16), vehicle.hash);
	        vehicle.maxNumberOfPassengers = Function.Call<int>((Hash) Convert.ToUInt64("0x2AD93716F184EDA4", 16), vehicle.hash) - 1;
	        vehicle.maxOccupants = Function.Call<int>((Hash) Convert.ToUInt64("0x2AD93716F184EDA4", 16), vehicle.hash);
	        
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
	            
	        OutputProcessor.Process(@"gen_vdata/" + vehicle.name + ".json", new VehicleCache
	        {
		        mods = ProcessVehicleMods(veh),
		        liveries = ProcessVehicleLiveries(veh),
		        dimensions = GetVehicleDimensions(veh.Model.Hash),
		        bones = GetVehicleBones(veh),
		        neon = veh.Mods.HasNeonLights,
		        wheelType = veh.Mods.WheelType
	        });
	            
	        veh.Delete();
	        Script.Wait(150);
        }

	    public static IEnumerable<string> LoadVehicleBones()
	    {
		    using (var reader = new StreamReader(Main.GetPath(@"vehicleBones.txt")))
		    {
			    string line;
			    while ((line = reader.ReadLine()) != null)
			    {
				    yield return line;
			    }
		    }
	    }

	    private static Dictionary<string, int> GetVehicleBones(Vehicle vehicle)
	    {
		    var bones = new Dictionary<string, int>();

		    foreach (string vehicleBone in vehicleBones)
		    {
			    var bone = vehicle.Bones[vehicleBone];
			    if (bone.IsValid) bones.Add(vehicleBone, bone.Index);
		    }
		    
		    return bones;
	    }

	    private static VehicleDimensions GetVehicleDimensions(int hash)
	    {

		    Vector3 min, max;
		    unsafe
		    {
			    Function.Call(Hash.GET_MODEL_DIMENSIONS, hash, &min, &max);
		    }
		    
			return new VehicleDimensions{ min = min, max = max};
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
		    SortedDictionary<int, ModTypeData> modTypeData = new SortedDictionary<int, ModTypeData>();
		    veh.Mods.InstallModKit();
		    for (int mod = 0; mod < 90; mod++)
		    {
			    var count = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, veh.Handle, mod);
			    var data = new ModTypeData {amount = count};

			    Function.Call(Hash.REMOVE_VEHICLE_MOD, veh.Handle);
			    var defMod = Function.Call<int>(Hash.GET_VEHICLE_MOD, veh.Handle, mod);

			    for (int i = -1; i < count; i++)
			    {
				    var name = GetModName(veh, (VehicleModType) mod, i);
				    
				    if(i == -1 && i != defMod && name == string.Empty) continue;
				    
				    if (i == -1 && name == string.Empty)
				    {
					    name = "CMOD_DEF_0";
				    } 
				    
				    var modObj = new ModData
				    {
					    name = name
				    };

				    if (i == defMod)
				    {
					    modObj.flags.Add("stock");
				    }
				    
				    data.list.Add(i, modObj);
				    ApplyFlags(modObj, (VehicleModType) mod, count, i);
			    }

			    modTypeData.Add(mod, data);
		    }
		    
		    AddHardCodedMods(modTypeData);
		    
		    return modTypeData.ToDictionary(x => x.Key, y => y.Value);
	    }

	    public static void AddHardCodedMods(SortedDictionary<int, ModTypeData> modTypeDatas)
	    {
		    // LIGHTS
		    try
		    {
			    modTypeDatas.Remove(22);
				var modType = new ModTypeData {amount = 2};
				
				modType.list.Add(0, new ModData{ name = "CMOD_LGT_0"});
				modType.list.Add(1, new ModData{ name = "CMOD_LGT_1"});
				
				modTypeDatas.Add(22, modType);
		    } catch {}

		    try
		    {
			    modTypeDatas.Remove(18);
			    var modType = new ModTypeData {amount = 2};

			    modType.list.Add(0, new ModData {name = "CMOD_TUR_0", flags = new List<string> {"stock"}});
			    modType.list.Add(1, new ModData {name = "CMOD_TUR_1"});

			    modTypeDatas.Add(18, modType);
		    } catch {}

		    try
		    {
			    modTypeDatas.Remove(69);
			    var modType = new ModTypeData {amount = 5};

			    modType.list.Add(0, new ModData {name = "CMOD_WIN_0", flags = new List<string> {"stock"}});
			    modType.list.Add(1, new ModData {name = "CMOD_WIN_4"});
			    modType.list.Add(2, new ModData {name = "CMOD_WIN_3"});
			    modType.list.Add(3, new ModData {name = "CMOD_WIN_2"});
			    modType.list.Add(4, new ModData {name = "CMOD_WIN_1"});

			    modTypeDatas.Add(69, modType);
		    } catch {}
		    
		    try
		    {
			    modTypeDatas.Remove(62);
			    var modType = new ModTypeData {amount = 5};

			    modType.list.Add(0, new ModData {name = "CMOD_PLA_0", flags = new List<string> {"stock"}});
			    modType.list.Add(1, new ModData {name = "CMOD_PLA_1"});
			    modType.list.Add(2, new ModData {name = "CMOD_PLA_2"});
			    modType.list.Add(3, new ModData {name = "CMOD_PLA_3"});
			    modType.list.Add(4, new ModData {name = "CMOD_PLA_4"});

			    modTypeDatas.Add(62, modType);
		    } catch {}
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
		    //if(index == -1) mod.flags.Add("stock");
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
