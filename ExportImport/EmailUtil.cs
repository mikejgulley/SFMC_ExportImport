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

        public static APIObject[] GetAllEmailsByCategoryID(SoapClient soapClientIn, int catIdIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            APIObject[] totalResults = { new APIObject() };
            List<APIObject> totalResultsList = new List<APIObject>();
            int totalCount = 0;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "CategoryID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new string[] { catIdIn.ToString() }; 

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;
            rr.Filter = sfp;

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
                Console.WriteLine("Email Name: " + email.Name);
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

        public static void CreateEmailFromExisting(SoapClient soapClientIn, Email emailIn) {
            String requestID;
            String status;

            Email email = new Email();
            // make switch statment
            email.CategoryID = 99396;
            //You can get the Category ID by hovering over the folder in the account and looking at the CID= in the URL at the bottom.                  
            email.CategoryIDSpecified = true;
            email.CharacterSet = emailIn.CharacterSet;
            email.Client = new ClientID();
            email.Client.ID = 7294703;
            email.Client.IDSpecified = emailIn.Client.IDSpecified;
            //email.ClonedFromID = emailIn.ClonedFromID;
            //email.ClonedFromID = 1449; Template ID
            email.ClonedFromID = 19410;
            email.ClonedFromIDSpecified = emailIn.ClonedFromIDSpecified;
            email.ContentAreas = new ContentArea[emailIn.ContentAreas.Length];
            email.ContentAreas = emailIn.ContentAreas;
            email.ContentCheckStatus = emailIn.ContentCheckStatus;
            email.CorrelationID = emailIn.CorrelationID;
            email.CustomerKey = emailIn.CustomerKey;
            email.EmailType = emailIn.EmailType;
            email.Folder = emailIn.Folder;
            email.HasDynamicSubjectLine = emailIn.HasDynamicSubjectLine;
            email.HasDynamicSubjectLineSpecified = emailIn.HasDynamicSubjectLineSpecified;
            email.HTMLBody = emailIn.HTMLBody;
            email.IsActive = emailIn.IsActive;
            email.IsActiveSpecified = emailIn.IsActiveSpecified;
            email.IsHTMLPaste = emailIn.IsHTMLPaste;
            email.IsHTMLPasteSpecified = emailIn.IsHTMLPasteSpecified;
            email.Name = emailIn.Name;
            email.ObjectState = emailIn.ObjectState;
            email.Owner = emailIn.Owner;
            email.PreHeader = emailIn.PreHeader;
            email.Status = emailIn.Status;
            email.Subject = emailIn.Subject;
            email.SyncTextWithHTML = emailIn.SyncTextWithHTML;
            email.SyncTextWithHTMLSpecified = emailIn.SyncTextWithHTMLSpecified;
            email.TextBody = emailIn.TextBody;


            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { email }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
        }

        public static void CreateEmailFromExisting(SoapClient soapClientIn, Email emailIn, int catIdIn)
        {
            String requestID;
            String status;

            Email email = new Email();
            // make switch statment
            email.CategoryID = catIdIn;
            //You can get the Category ID by hovering over the folder in the account and looking at the CID= in the URL at the bottom.                  
            email.CategoryIDSpecified = true;
            email.CharacterSet = emailIn.CharacterSet;
            email.Client = new ClientID();
            email.Client.ID = 7294703;
            email.Client.IDSpecified = emailIn.Client.IDSpecified;
            //email.ClonedFromID = emailIn.ClonedFromID;
            //email.ClonedFromID = 1449; Email ID this was copied from NOT the Template ID... drat
            //switch (emailIn.ClonedFromID)
            //{   
            //    case 1296:
            //        email.ClonedFromID = 1445;
            //        break;
            //    case 1295:
            //        email.ClonedFromID = 1446;
            //        break;
            //    case 1268:
            //        email.ClonedFromID = 1447;
            //        break;
            //    case 1266:
            //        email.ClonedFromID = 1448;
            //        break;
            //    case 1416:
            //        email.ClonedFromID = 1449;
            //        break;
            //    case 1265:
            //        email.ClonedFromID = 1450;
            //        break;
            //    case 1244:
            //        email.ClonedFromID = 1451;
            //        break;
            //    case 1231:
            //        email.ClonedFromID = 1452;
            //        break;
            //    case 648:
            //        email.ClonedFromID = 1453;
            //        break;
            //    case 1245:
            //        email.ClonedFromID = 1454;
            //        break;
            //    case 1422:
            //        email.ClonedFromID = 1455;
            //        break;
            //    case 647:
            //        email.ClonedFromID = 1456;
            //        break;
            //    case 1307:
            //        email.ClonedFromID = 1457;
            //        break;
            //    case 1375:
            //        email.ClonedFromID = 1458;
            //        break;
            //    case 1294:
            //        email.ClonedFromID = 1459;
            //        break;
            //    case 1198:
            //        email.ClonedFromID = 1460;
            //        break;
            //    case 1243:
            //        email.ClonedFromID = 1461;
            //        break;
            //    //default:
            //        //break;
            //}
            //email.ClonedFromIDSpecified = emailIn.ClonedFromIDSpecified;

            if (emailIn.ContentAreas != null)
            {
                email.ContentAreas = new ContentArea[emailIn.ContentAreas.Length];
                email.ContentAreas = emailIn.ContentAreas;
            }
            email.ContentCheckStatus = emailIn.ContentCheckStatus;
            email.CorrelationID = emailIn.CorrelationID;
            email.CustomerKey = emailIn.CustomerKey;
            email.EmailType = emailIn.EmailType;
            email.Folder = emailIn.Folder;
            email.HasDynamicSubjectLine = emailIn.HasDynamicSubjectLine;
            email.HasDynamicSubjectLineSpecified = emailIn.HasDynamicSubjectLineSpecified;
            email.HTMLBody = emailIn.HTMLBody;
            email.IsActive = emailIn.IsActive;
            email.IsActiveSpecified = emailIn.IsActiveSpecified;
            email.IsHTMLPaste = emailIn.IsHTMLPaste;
            email.IsHTMLPasteSpecified = emailIn.IsHTMLPasteSpecified;
            email.Name = emailIn.Name;
            email.ObjectState = emailIn.ObjectState;
            email.Owner = emailIn.Owner;
            email.PreHeader = emailIn.PreHeader;
            email.Status = emailIn.Status;
            email.Subject = emailIn.Subject;
            email.SyncTextWithHTML = emailIn.SyncTextWithHTML;
            email.SyncTextWithHTMLSpecified = emailIn.SyncTextWithHTMLSpecified;
            email.TextBody = emailIn.TextBody;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { email }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
        }
    }
}
