using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class EmailUtil
    {
        public static void DescribeEmail(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Email";

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

        public static void DescribeEmailSendDefinition(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "EmailSendDefinition";

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

        public static APIObject[] GetAllEmails(SoapClient soapClientIn)
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

            rr.ObjectType = "Email";
            rr.Properties = new String[] { "ID", "PartnerKey", "CreatedDate", "ModifiedDate", "Client.ID",
                "Name", "PreHeader", "Folder", "CategoryID", "HTMLBody", "TextBody", "Subject", "IsActive",
                "IsHTMLPaste", "ClonedFromID", "Status", "EmailType", "CharacterSet", "HasDynamicSubjectLine",
                "ContentCheckStatus", "Client.PartnerClientKey", "ContentAreas", "CustomerKey" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);
                
                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Emails: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Emails: " + totalResults.Length);

            Console.ReadLine();
            return totalResults;
        }

        public static Email GetEmailByID(SoapClient soapClientIn, int idIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            Email emailResult = new Email();

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "Email.ID";
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

            rr.ObjectType = "Email";
            rr.Properties = new String[] { "ID", "PartnerKey", "CreatedDate", "ModifiedDate", "Client.ID",
                "Name", "PreHeader", "Folder", "CategoryID", "HTMLBody", "TextBody", "Subject", "IsActive",
                "IsHTMLPaste", "ClonedFromID", "Status", "EmailType", "CharacterSet", "HasDynamicSubjectLine",
                "ContentCheckStatus", "Client.PartnerClientKey", "ContentAreas", "CustomerKey" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);
            Console.WriteLine(status);
            //Console.WriteLine("Num Data Folders: " + results.Length + "\n");

            foreach (Email email in results)
            {
                //Console.WriteLine("Email Name: " + email.Name);
                emailResult = email;
            }

            return emailResult;
        }

        public static APIObject[] GetAllUIEmailSendDefinitions(SoapClient soapClientIn) // user-initiated
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

            rr.ObjectType = "EmailSendDefinition";
            rr.Properties = new String[] { "Client.ID", "CreatedDate", "ModifiedDate", "ObjectID", "CustomerKey",
                "Name", "CategoryID", "Description", "SendClassification.CustomerKey", "SenderProfile.CustomerKey", "SenderProfile.FromName",
                "SenderProfile.FromAddress", "DeliveryProfile.CustomerKey", "DeliveryProfile.SourceAddressType",
                "DeliveryProfile.PrivateIP", "DeliveryProfile.DomainType", "DeliveryProfile.PrivateDomain", "DeliveryProfile.HeaderSalutationSource",
                "DeliveryProfile.FooterSalutationSource", "SuppressTracking",
                "IsSendLogging", "Email.ID", "CCEmail", "BccEmail","AutoBccEmail", "TestEmailAddr", "EmailSubject", "DynamicEmailSubject", "IsMultipart",
                "IsWrapped", "SendLimit", "SendWindowOpen", "DeduplicateByEmail", "ExclusionFilter", "Additional",
                "SendDefinitionList" };
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
                Console.WriteLine("Num Email Send Defs: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Email Send Defs: " + totalResults.Length);

            Console.ReadLine();
            return totalResults;
        }
    }
}
