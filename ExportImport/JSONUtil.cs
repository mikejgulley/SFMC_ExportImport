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
            string directory = "C:\\SylvanJSON\\Accounts";
            Directory.CreateDirectory(directory);

            string newName = accountIn.Name;
            string filepath = String.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("_");
            sb.Append(accountIn.CustomerKey);
            sb.Append("_");
            sb.Append(accountIn.ParentID);
            sb.Append(".json");

            if (newName.Contains(@"\") || newName.Contains(@"/"))
            {
                newName = newName.Replace(@"\", "");
                newName = newName.Replace(@"/", "");
            }

            filepath = Path.Combine(directory, newName);

            using (StreamWriter file = File.CreateText(filepath + sb))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, accountIn);
            }
        }

        public static void saveAccountUserToJSON(AccountUser accountUserIn)
        {
            string directory = "C:\\SylvanJSON\\AccountUsers";
            Directory.CreateDirectory(directory);

            StringBuilder sb = new StringBuilder();
            sb.Append("_");
            sb.Append(accountUserIn.CustomerKey);
            sb.Append("_");
            sb.Append(accountUserIn.Client.ID);
            sb.Append(".json");

            using (StreamWriter file = File.CreateText(Path.Combine(directory, accountUserIn.Name) + sb))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, accountUserIn);
            }
        }

        public static void saveBusinessUnitToJSON(BusinessUnit buIn)
        {
            string directory = "C:\\SylvanJSON\\BusinessUnits";
            Directory.CreateDirectory(directory);

            string newName = buIn.Name;
            string filepath = String.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("_");
            sb.Append(buIn.CustomerKey);
            sb.Append("_");
            sb.Append(buIn.ParentID);
            sb.Append(".json");

            if (newName.Contains(@"\") || newName.Contains(@"/"))
            {
                newName = newName.Replace(@"\", "");
                newName = newName.Replace(@"/", "");
            }

            filepath = Path.Combine(directory, newName);

            using (StreamWriter file = File.CreateText(filepath + sb))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, buIn);
            }
        }

        public static void saveDEToJSON(DataExtension deIn)
        {
            string directory = "C:\\SylvanJSON\\DataExtensions";
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
           string directory = "C:\\SylvanJSON\\DataFolders";
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

       public static void saveEmailToJSON(Email emailIn)
       {
           string directory = "C:\\SylvanJSON\\Emails";
           Directory.CreateDirectory(directory);

           StringBuilder sb = new StringBuilder();
           sb.Append("_");
           sb.Append(emailIn.CustomerKey);
           sb.Append("_");
           sb.Append(emailIn.Client.ID);
           sb.Append(".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, emailIn.Name) + sb))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, emailIn);
           }
       }

       public static void saveImportDefToJSON(ImportDefinition idIn)
       {
           string directory = "C:\\SylvanJSON\\ImportDefinitions";
           Directory.CreateDirectory(directory);

           StringBuilder sb = new StringBuilder();
           sb.Append("_");
           sb.Append(idIn.CustomerKey);
           sb.Append("_");
           sb.Append(idIn.Client.ClientID1);
           sb.Append(".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, idIn.Name) + sb))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, idIn);
           }
       }

       public static void saveQueryToJSON(QueryDefinition qdIn)
       {
           string directory = "C:\\SylvanJSON\\Queries";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", qdIn.Name, "_", qdIn.CustomerKey, qdIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, qdIn);
           }
       }

       public static void saveRoleToJSON(Role roleIn)
       {
           string directory = "C:\\SylvanJSON\\Roles";
           Directory.CreateDirectory(directory);

           StringBuilder sb = new StringBuilder();
           if (!roleIn.Name.Equals(roleIn.CustomerKey))
           {
               sb.Append("_");
               sb.Append(roleIn.CustomerKey);               
           }
           sb.Append("_");
           sb.Append(roleIn.Client.ID);
           sb.Append(".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, roleIn.Name) + sb))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, roleIn);
           }
       }
    }
}
