using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class SenderProfileUtil
    {
        public static void DescribeSenderProfile(SoapClient soapClientIn)
        {
            string requestID;
            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "SenderProfile";

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

        public static APIObject[] GetAllSenderProfiles(SoapClient soapClientIn)
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

            rr.ObjectType = "SenderProfile";
            rr.Properties = new String[] { "Name", "Description", "FromName", "FromAddress", "UseDefaultRMMRules", "AutoForwardToEmailAddress", "AutoForwardToName",
                "DirectForward", "AutoForwardTriggeredSend.ObjectID", "AutoReply", "AutoReplyTriggeredSend.ObjectID", "SenderHeaderEmailAddress",
                "SenderHeaderName", "DataRetentionPeriodLength", "ReplyManagementRuleSet.ObjectID", "RMMRuleCollection.ObjectID",
                "Client.ID", "PartnerKey", "CreatedDate", "ModifiedDate", "ObjectID", "CustomerKey", "Client.CreatedBy", "Client.ModifiedBy" };
            // "DataRetentionPeriodUnitOfMeasure" causes error about needing to provide proper info to parse the string

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Sender Profiles: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Sender Profiles: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static SenderProfile GetSenderProfileByCustomerKey(SoapClient soapClientIn, string customerKeyIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            SenderProfile senderProfileResult = new SenderProfile();

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "SenderProfile.CustomerKey";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { customerKeyIn };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "SenderProfile";
            rr.Properties = new String[] { "Name", "Description", "FromName", "FromAddress", "UseDefaultRMMRules", "AutoForwardToEmailAddress", "AutoForwardToName",
                "DirectForward", "AutoForwardTriggeredSend.ObjectID", "AutoReply", "AutoReplyTriggeredSend.ObjectID", "SenderHeaderEmailAddress",
                "SenderHeaderName", "DataRetentionPeriodLength", "ReplyManagementRuleSet.ObjectID", "RMMRuleCollection.ObjectID",
                "Client.ID", "PartnerKey", "CreatedDate", "ModifiedDate", "ObjectID", "CustomerKey", "Client.CreatedBy", "Client.ModifiedBy" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);
            Console.WriteLine(status);

            foreach (SenderProfile sProfile in results)
            {
                Console.WriteLine("Sender Profile Name: " + sProfile.Name);
                senderProfileResult = sProfile;
            }

            return senderProfileResult;
        }

        public static SenderProfile GetSenderProfileByID(SoapClient soapClientIn, string objectIDIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            SenderProfile senderProfileResult = new SenderProfile();

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "SenderProfile.ObjectID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { objectIDIn };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "SenderProfile";
            rr.Properties = new String[] { "Name", "Description", "FromName", "FromAddress", "UseDefaultRMMRules", "AutoForwardToEmailAddress", "AutoForwardToName",
                "DirectForward", "AutoForwardTriggeredSend.ObjectID", "AutoReply", "AutoReplyTriggeredSend.ObjectID", "SenderHeaderEmailAddress",
                "SenderHeaderName", "DataRetentionPeriodLength", "ReplyManagementRuleSet.ObjectID", "RMMRuleCollection.ObjectID",
                "Client.ID", "PartnerKey", "CreatedDate", "ModifiedDate", "ObjectID", "CustomerKey", "Client.CreatedBy", "Client.ModifiedBy" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);
            Console.WriteLine(status);

            foreach (SenderProfile sProfile in results)
            {
                Console.WriteLine("Sender Profile Name: " + sProfile.Name);
                senderProfileResult = sProfile;
            }

            return senderProfileResult;
        }
    }
}
