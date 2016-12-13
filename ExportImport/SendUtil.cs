using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class SendUtil
    {
        public static void DescribeSend(SoapClient soapClientIn)
        {
            string requestID;
            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Send";

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

        public static APIObject[] GetAllSends(SoapClient soapClientIn)
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

            rr.ObjectType = "Send";
            rr.Properties = new String[] { "ID", "PartnerKey", "CreatedDate", "ModifiedDate", "Client.ID",
                "Client.PartnerClientKey", "Email.ID", "Email.PartnerKey", "SendDate",
                "FromAddress", "FromName", "Duplicates", "InvalidAddresses", "ExistingUndeliverables", "ExistingUnsubscribes",
                "HardBounces", "SoftBounces", "OtherBounces", "ForwardedEmails", "UniqueClicks", "UniqueOpens",
                "NumberSent", "NumberDelivered", "NumberTargeted", "NumberErrored", "NumberExcluded", "Unsubscribes",
                "MissingAddresses", "Subject", "PreviewURL", "SentDate", "EmailName", "Status", "IsMultipart", "SendLimit",
                "SendWindowOpen", "SendWindowClose", "IsAlwaysOn", "Additional", "BCCEmail", "EmailSendDefinition.ObjectID", 
                "EmailSendDefinition.CustomerKey" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Sends: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Sends: " + totalResults.Length);

            Console.ReadLine();
            return totalResults;
        }
    }
}
