using ExportImport.PartnerAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class ImportToSbx
    {
        public static void loadAPIObjectsByFolder(String folderPathIn)
        {
            string[] files = Directory.GetFiles(folderPathIn);

            foreach (string file in files)
            {
                using (StreamReader srFile = File.OpenText(file))
                using (JsonTextReader reader = new JsonTextReader(srFile))
                {
                    JObject obj = (JObject)JToken.ReadFrom(reader);
                    //APIObject apiObj = (APIObject) obj;
                }
            }
            
        }
    }
}
