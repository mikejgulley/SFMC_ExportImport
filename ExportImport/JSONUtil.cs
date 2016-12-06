using ExportImport.PartnerAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class JSONUtil
    {
        //public static string saveAPIObjectToJSON(APIObject[] apiObjectIn) 
        //{
        //    string jsonFile = JsonConvert.SerializeObject(apiObjectIn, Formatting.Indented);

        //    using (StreamWriter file = File.CreateText(@"C:\Desktop\SylvanJSON" + "\\" + apiObjectIn.GetType().ToString() + "\\" + deIn.Name))


        //    return jsonFile;
        //}

        public static void saveDEToJSON(DataExtension deIn)
        {
            string directory = "C:\\Desktop\\SylvanJSON\\DataExtensions";
            Directory.CreateDirectory(directory);
            
            //string jsonFile = JsonConvert.SerializeObject(deIn, Formatting.Indented);

            using (StreamWriter file = File.CreateText(Path.Combine(directory, deIn.Name) + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, deIn);
            }
        }
    }
}
