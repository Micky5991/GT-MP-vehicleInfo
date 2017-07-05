using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using GTA;
using GT_MP_vehicleInfo.Data;

namespace GT_MP_vehicleInfo.Processors
{
    public class VehicleLoader
    {

        public static void LoadVehicles()
        {

            string[] files = Directory.GetFiles(Path.Combine(Main.BasePath, "vehiclemeta/"), "*.meta");

            List<XElement> elements = new List<XElement>();
            
            foreach (string file in files)
            {
                XDocument doc = XDocument.Load(file);
                var dec = doc.Descendants("CVehicleModelInfo__InitDataList");
                foreach (var dElement in dec)
                {
                    foreach (var el in dElement.Elements("InitDatas").Elements("Item"))
                    {
                        elements.Add(el);
                    }
                }
            }
            
            MakeWeapons(elements);

        }

        public static void MakeWeapons(IEnumerable<XElement> elements)
        {
            foreach (var element in elements)
            {
                
                Main.Storage.Add(new VehicleData
                {
                    name = element.Element("modelName").Value
                }, element);
                
            }
        }
        
    }
}