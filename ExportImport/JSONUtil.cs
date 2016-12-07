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
        public static void saveAccountToJSON(Account accountIn)
        {
            string directory = "C:\\Desktop\\SylvanJSON\\Accounts";
            Directory.CreateDirectory(directory);

            string newName = accountIn.Name;
            string filepath = String.Empty;

            if (newName.Contains(@"\") || newName.Contains(@"/"))
            {
                newName = newName.Replace(@"\", "");
                newName = newName.Replace(@"/", "");
            }

            filepath = Path.Combine(directory, newName);

            using (StreamWriter file = File.CreateText(filepath + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, accountIn);
            }
        }

        public static void saveBusinessUnitToJSON(BusinessUnit buIn)
        {
            string directory = "C:\\Desktop\\SylvanJSON\\BusinessUnits";
            Directory.CreateDirectory(directory);

            string newName = buIn.Name;
            string filepath = String.Empty;

            if (newName.Contains(@"\") || newName.Contains(@"/"))
            {
                newName = newName.Replace(@"\", "");
                newName = newName.Replace(@"/", "");
            }

            filepath = Path.Combine(directory, newName);

            using (StreamWriter file = File.CreateText(filepath + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, buIn);
            }
        }

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

       public static void saveDataFolderToJSON(DataFolder dfIn)
       {
           string directory = "C:\\Desktop\\SylvanJSON\\DataFolders";
           Directory.CreateDirectory(directory);

           string newName = dfIn.Name;
           string filepath = String.Empty;

           if (newName.Contains(@"\") || newName.Contains(@"/"))
           {
               newName = newName.Replace(@"\", "");
               newName = newName.Replace(@"/", "");
           }

           filepath = Path.Combine(directory, newName);

           using (StreamWriter file = File.CreateText(filepath + ".json"))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, dfIn);
           }
       }

       public static void saveImportDefToJSON(ImportDefinition idIn)
       {
           string directory = "C:\\Desktop\\SylvanJSON\\ImportDefinitions";
           Directory.CreateDirectory(directory);

           using (StreamWriter file = File.CreateText(Path.Combine(directory, idIn.Name) + ".json"))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, idIn);
           }
       }

       public static void saveQueryToJSON(QueryDefinition qdIn)
       {
           string directory = "C:\\Desktop\\SylvanJSON\\Queries";
           Directory.CreateDirectory(directory);

           using (StreamWriter file = File.CreateText(Path.Combine(directory, qdIn.Name) + ".json"))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, qdIn);
           }
       }

       public static void saveRoleToJSON(Role roleIn)
       {
           string directory = "C:\\Desktop\\SylvanJSON\\Roles";
           Directory.CreateDirectory(directory);

           using (StreamWriter file = File.CreateText(Path.Combine(directory, roleIn.Name) + ".json"))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, roleIn);
           }
       }
    }
}
