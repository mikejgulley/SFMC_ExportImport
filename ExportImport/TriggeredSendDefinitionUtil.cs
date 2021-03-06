﻿using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class TriggeredSendDefinitionUtil
    {
        public static void DescribeSendDefinition(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "TriggeredSendDefinition";

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

        public static APIObject[] GetAllTriggeredEmailSendDefinitions(SoapClient soapClientIn) // user-initiated
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

            rr.ObjectType = "TriggeredSendDefinition";
            rr.Properties = new String[] { "ObjectID", "PartnerKey", "CreatedDate", "ModifiedDate", "Client.ID",
                "CustomerKey", "Email.ID", "List.ID", "Name", "Description", "TriggeredSendType", "TriggeredSendStatus", "HeaderContentArea.ID",
                "FooterContentArea.ID", "SendClassification.ObjectID", "SendClassification.CustomerKey", "SenderProfile.CustomerKey", "SenderProfile.ObjectID",
                "DeliveryProfile.CustomerKey", "DeliveryProfile.ObjectID", "PrivateDomain.ObjectID", "PrivateIP.ID", "AutoAddSubscribers", 
                "AutoUpdateSubscribers","BatchInterval", "FromName", "FromAddress", "BccEmail", "EmailSubject", "DynamicEmailSubject", "IsMultipart",
                "IsWrapped", "TestEmailAddr", "AllowedSlots", "NewSlotTrigger", "SendLimit", "SendWindowOpen", "SendWindowClose", "SuppressTracking",
                "Keyword", "List.PartnerKey", "Email.PartnerKey", "SendClassification.PartnerKey", "PrivateDomain.PartnerKey",
                "PrivateIP.PartnerKey", "Client.PartnerClientKey", "CategoryID" };
            // these broke the call even thought they are supposed to be valid retrievable attrs according to the Describe
            // "DeliveryProfile.FooterContentArea.ID", "DeliveryProfile.HeaderContentArea.ID", "SendWindowCloses"
            // "IsPlatformObject" -- breaks Name attr

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Triggered Send Defs: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Triggered Send Defs: " + totalResults.Length);

            Console.ReadLine();
            return totalResults;
        }
    }
}
