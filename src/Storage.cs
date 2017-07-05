using System.Collections.Generic;
using System.Xml.Linq;
using GTA;
using GT_MP_vehicleInfo.Data;
using GT_MP_vehicleInfo.Processors;

namespace GT_MP_vehicleInfo
{
    public class Storage
    {
        public readonly Dictionary<int, VehicleData> vehicleStorage = new Dictionary<int, VehicleData>();

        public bool HasVehicle(VehicleData data)  => HasVehicle(data.hash);
        public bool HasVehicle(VehicleHash hash)  => HasVehicle((int) hash);
        public bool HasVehicle(uint hash)         => HasVehicle((int) hash);
        public bool HasVehicle(int hash)          => this.vehicleStorage.ContainsKey(hash);
        
        public void Add(VehicleData vehicle, XElement element)
        {
            vehicle.Hash();
            if (HasVehicle(vehicle)) return;
            GeneralProcessor.ProcessVehicle(vehicle, element);
            
            this.vehicleStorage.Add((int) vehicle.hash, vehicle);
            
        }
        
    }

    public static class GeneralProcessor
    {
        public static void ProcessVehicle(VehicleData vehicleData, XElement element)
        {
            FlagProcessor.Process(vehicleData, element);
            VehicleIngameProcessor.Process(vehicleData);
            LocalizationProcessor.ProcessVehicle(vehicleData);
            
        }
    }
}