using System.Collections.Generic;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class HashProcessor
    {

        public static void Process(IEnumerable<IHashable> hashables)
        {
            foreach (var hashable in hashables) Process(hashable);
        }

        public static void Process(IHashable hashable) => hashable.Hash();
        
    }
}