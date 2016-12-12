using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class SendClassificationUtil
    {
        public static void DescribeSendClassification(SoapClient soapClientIn)
        {
            string requestID;
            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "SendClassification";

            ObjectDefinition[] definitions = soapClientIn.Describe(new ObjectDefinitionRequest[] { objDefs }, out requestID);

            foreach (ObjectDefinition od in definitions)
            {
                Console.WriteLine("***Object Name: " + od.ObjectType + "****");

                foreach (PropertyDefinition pd in od.Properties)
                {
                    Console.WriteLine("  Property Name: " + pd.Name);
                    Console.WriteLine("  IsRetrievable: " + pd.IsRetrievable.ToString() + "\n");
                }
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        public static APIObject[] GetAllSendClassifications(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            APIObject[] totalResults = { new APIObject() };
            List<APIObject> totalResultsList = new List<APIObject>();
            int totalCount = 0;

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "SendClassification";
            rr.Properties = new String[] { "ObjectID", "SendClassificationType", "Name", "Description", "CustomerKey",
                "SenderProfile.CustomerKey", "SenderProfile.ObjectID", "DeliveryProfile.CustomerKey", "DeliveryProfile.ObjectID",
                "ArchiveEmail", "Client.ID", "Client.PartnerClientKey", "PartnerKey", "CreatedDate", "ModifiedDate" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Send Classifcations: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Send Classifcations: " + totalResults.Length);

            Console.ReadLine();
            return totalResults;
        }

        public static SendClassification GetSendClassificationByID(SoapClient soapClientIn, int idIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            SendClassification sendClassResult = new SendClassification();

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "SendClassification.ObjectID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { idIn.ToString() };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "SendClassification";
            rr.Properties = new String[] { "ObjectID", "SendClassificationType", "Name", "Description", "CustomerKey",
                "SenderProfile.CustomerKey", "SenderProfile.ObjectID", "DeliveryProfile.CustomerKey", "DeliveryProfile.ObjectID",
                "ArchiveEmail", "Client.ID", "Client.PartnerClientKey", "PartnerKey", "CreatedDate", "ModifiedDate" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);
            Console.WriteLine(status);
            //Console.WriteLine("Num Data Folders: " + results.Length + "\n");

            foreach (SendClassification sClass in results)
            {
                Console.WriteLine("SendClassification Name: " + sClass.Name);
                sendClassResult = sClass;
            }

            return sendClassResult;
        }
    }
}
