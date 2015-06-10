using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Xml;
using System.Globalization;

/// <summary>
/// Summary description for Plant
/// </summary>
namespace Ext.Net.Examples.Examples.Form.ComboBox.Custom_Search
{
    public class Plant
    {

        public Plant(string tencot, string chugiai)
        {
            this.tencot = tencot;
            this.chugiai = chugiai;

        }

        public Plant()
        {
        }

        public string tencot { get; set; }

        public string chugiai { get; set; }


        public static Paging<Plant> PlantsPaging(int start, int limit, string sort, string dir, string filter)
        {
            List<Plant> plants = Plant.TestData;

            if (!string.IsNullOrEmpty(filter) && filter != "*")
            {
                plants.RemoveAll(plant => !plant.tencot.ToLower().StartsWith(filter.ToLower()));

            }
            else
            {

            }

            if (!string.IsNullOrEmpty(sort))
            {
                plants.Sort(delegate(Plant x, Plant y)
                {
                    object a;
                    object b;

                    int direction = dir == "DESC" ? -1 : 1;

                    a = x.GetType().GetProperty(sort).GetValue(x, null);
                    b = y.GetType().GetProperty(sort).GetValue(y, null);

                    return CaseInsensitiveComparer.Default.Compare(a, b) * direction;
                });
            }

            if ((start + limit) > plants.Count)
            {
                limit = plants.Count - start;
            }

            List<Plant> rangePlants = (start < 0 || limit < 0) ? plants : plants.GetRange(start, limit);

            return new Paging<Plant>(rangePlants, plants.Count);
        }


        public static List<Plant> TestData
        {
            get
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath("Plants.xml"));
                List<Plant> data = new List<Plant>();
                IFormatProvider culture = new CultureInfo("en-US", true);

                foreach (XmlNode plantNode in xmlDoc.SelectNodes("catalog/plant"))
                {
                    Plant plant = new Plant();

                    plant.tencot = plantNode.SelectSingleNode("tencot").InnerText;
                    plant.chugiai = plantNode.SelectSingleNode("chugiai").InnerText;
                    
                    data.Add(plant);
                }

                return data;
            }
        }

     
    }
}