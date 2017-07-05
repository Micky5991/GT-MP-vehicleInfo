using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GT_MP_vehicleInfo
{
    class NoLocalizationResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization
                memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = propInstance => !property.UnderlyingName.StartsWith("localized");
            return property;
        }
    }
    
    class NoListsResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization
                memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = propInstance => !(property.UnderlyingName.StartsWith("localized") || property.UnderlyingName == "list" );
            return property;
        }
    }
}