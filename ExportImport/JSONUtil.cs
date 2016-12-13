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

        public static void saveContentAreaToJSON(ContentArea contentAreaIn)
        {
            string directory = "C:\\SylvanJSON\\ContentAreas";
            Directory.CreateDirectory(directory);

            String filename = String.Format("{0}{1}{2}{1}{3}{4}", contentAreaIn.Name.Equals(null) || contentAreaIn.Name.Equals(String.Empty) ? "noName" : contentAreaIn.Name ,
                "_", contentAreaIn.CustomerKey, contentAreaIn.Client.ID, ".json");

            using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, contentAreaIn);
            }
        }

        public static void saveDEToJSON(DataExtension deIn)
        {
            string directory = "C:\\SylvanJSON\\DataExtensions";
            Directory.CreateDirectory(directory);

            String filename = String.Format("{0}{1}{2}{1}{3}{4}", deIn.Name, "_", deIn.CustomerKey, deIn.Client.ID, ".json");
            
            using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
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
           string newCustomerKey = dfIn.CustomerKey;
           string filepath = String.Empty;

           if (newName.Contains(@"\") || newName.Contains(@"/"))
           {
               newName = newName.Replace(@"\", "");
               newName = newName.Replace(@"/", "");
           }

           if (dfIn.CustomerKey.Contains(@"\") || dfIn.CustomerKey.Contains(@"/"))
           {
               newCustomerKey = newCustomerKey.Replace(@"\", "");
               newCustomerKey = newCustomerKey.Replace(@"/", "");
           }

           StringBuilder sb = new StringBuilder();
           sb.Append(newName);
           if (!newName.Equals(newCustomerKey) && !newCustomerKey.Equals(String.Empty))
           {
               sb.Append("_");
               sb.Append(newCustomerKey);
           }
           sb.Append("_");
           sb.Append(dfIn.ID);
           sb.Append("_");
           sb.Append(dfIn.Client.ID);
           sb.Append(".json");

           //String filename = String.Format("{0}{1}{2}{1}{3}{4}", newName, "_", newCustomerKey, dfIn.Client.ID, ".json");
           String filename = sb.ToString();

           filepath = Path.Combine(directory, filename);
           
           using (StreamWriter file = File.CreateText(filepath))
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

       public static void saveUIEmailSendDefinitionToJSON(EmailSendDefinition eSendDefIn)
       {
           string directory = "C:\\SylvanJSON\\SendDefinitions\\User-Initiated";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", eSendDefIn.Name, "_", eSendDefIn.CustomerKey, eSendDefIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, eSendDefIn);
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

       public static void saveListToJSON(List listIn)
       {
           string directory = "C:\\SylvanJSON\\Lists";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", listIn.ListName, "_", listIn.CustomerKey, listIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, listIn);
           }
       }

       public static void savePortfolioItemToJSON(Portfolio portIn)
       {
           string directory = "C:\\SylvanJSON\\Portfolio";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", portIn.DisplayName, "_", portIn.CustomerKey, portIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, portIn);
           }
       }

       public static void saveSendClassificationToJSON(SendClassification sendClassIn)
       {
           string directory = "C:\\SylvanJSON\\SendClassifications";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", sendClassIn.Name, "_", sendClassIn.CustomerKey, sendClassIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, sendClassIn);
           }
       }

       public static void saveSenderProfileToJSON(SenderProfile senderProfileIn)
       {
           string directory = "C:\\SylvanJSON\\SenderProfiles";
           Directory.CreateDirectory(directory);

           string newName = senderProfileIn.Name;
           string newCustomerKey = senderProfileIn.CustomerKey;
           string filepath = String.Empty;

           if (newName.Contains(@"\") || newName.Contains(@"/"))
           {
               newName = newName.Replace(@"\", "");
               newName = newName.Replace(@"/", "");
           }

           if (senderProfileIn.CustomerKey.Contains(@"\") || senderProfileIn.CustomerKey.Contains(@"/"))
           {
               newCustomerKey = newCustomerKey.Replace(@"\", "");
               newCustomerKey = newCustomerKey.Replace(@"/", "");
           }

           StringBuilder sb = new StringBuilder();
           sb.Append(newName);
           if (!newName.Equals(newCustomerKey) && !newCustomerKey.Equals(String.Empty))
           {
               sb.Append("_");
               sb.Append(newCustomerKey);
           }
           sb.Append("_");
           sb.Append(senderProfileIn.ID);
           sb.Append("_");
           sb.Append(senderProfileIn.Client.ID);
           sb.Append(".json");

           String filename = sb.ToString();

           filepath = Path.Combine(directory, filename);

           using (StreamWriter file = File.CreateText(filepath))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, senderProfileIn);
           }
       }

       public static void saveRMMConfigsToJSON(ReplyMailManagementConfiguration rmmIn)
       {
           string directory = "C:\\SylvanJSON\\RMM";
           Directory.CreateDirectory(directory);

           string newName = rmmIn.EmailDisplayName;
           string filepath = String.Empty;

           if (newName.Contains(@"\") || newName.Contains(@"/"))
           {
               newName = newName.Replace(@"\", "");
               newName = newName.Replace(@"/", "");
           }

           StringBuilder sb = new StringBuilder();
           sb.Append(newName);
           sb.Append("_");
           sb.Append(rmmIn.ID);
           sb.Append("_");
           sb.Append(rmmIn.Client.ID);
           sb.Append(".json");

           String filename = sb.ToString();

           filepath = Path.Combine(directory, filename);

           using (StreamWriter file = File.CreateText(filepath))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, rmmIn);
           }
       }

       public static void saveQueryToJSON(QueryDefinition qdIn)
       {
           string directory = "C:\\SylvanJSON\\Queries";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}", qdIn.Name, "_", qdIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, qdIn);
           }
       }

       public static void saveSendToJSON(Send sendIn)
       {
           string directory = "C:\\SylvanJSON\\Sends";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", sendIn.ID, "_", sendIn.CustomerKey, sendIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, sendIn);
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

       public static void saveTemplateToJSON(Template templateIn)
       {
           string directory = "C:\\SylvanJSON\\Templates";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", templateIn.TemplateName, "_", templateIn.CustomerKey, templateIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, templateIn);
           }
       }

       public static void saveTriggeredSendDefinitionToJSON(TriggeredSendDefinition tSendDefIn)
       {
           string directory = "C:\\SylvanJSON\\SendDefinitions\\Triggered";
           Directory.CreateDirectory(directory);

           String filename = String.Format("{0}{1}{2}{1}{3}{4}", tSendDefIn.Name, "_", tSendDefIn.CustomerKey, tSendDefIn.Client.ID, ".json");

           using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
           {
               JsonSerializer serializer = new JsonSerializer();
               serializer.Serialize(file, tSendDefIn);
           }
       }
    }
}
