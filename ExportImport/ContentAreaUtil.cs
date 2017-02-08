using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class ContentAreaUtil
    {
        public static void DescribeContentArea(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "ContentArea";

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

        public static APIObject[] GetAllContentAreas(SoapClient soapClientIn)
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

            rr.ObjectType = "ContentArea";
            rr.Properties = new String[] { "RowObjectID", "ObjectID", "ID", "CustomerKey", "Client.ID", "ModifiedDate", "CreatedDate",
                "CategoryID", "Name", "Layout", "IsDynamicContent", "Content", "IsSurvey", "IsBlank", "Key" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Content Areas: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Content Areas: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static void CreateContentAreaFromExisting(SoapClient soapClientIn, ContentArea caIn)
        {
            Console.WriteLine("Entering CreateContentAreaFromExisting()...");
            String requestID;
            String status;

            ContentArea ca = new ContentArea();
            ca.BackgroundColor = caIn.BackgroundColor;
            ca.BorderColor = caIn.BorderColor;
            ca.BorderWidth = caIn.BorderWidth;
            ca.BorderWidthSpecified = caIn.BorderWidthSpecified;
            // switch statement to update parent folder id to dest parent folder id
            switch (caIn.CategoryID)
            {
                case 810:
                    ca.CategoryID = 99401;
                    break;
                case 10829:
                    ca.CategoryID = 103936;
                    break;
                case 88501:
                    ca.CategoryID = 103948;
                    break;
                case 88790:
                    ca.CategoryID = 103949;
                    break;
                case 88791:
                    ca.CategoryID = 103960;
                    break;
                case 88792:
                    ca.CategoryID = 103961;
                    break;
                case 88793:
                    ca.CategoryID = 103962;
                    break;
                case 88794:
                    ca.CategoryID = 103964;
                    break;
                case 88795:
                    ca.CategoryID = 103965;
                    break;
                case 88722:
                    ca.CategoryID = 103950;
                    break;
                case 88726:
                    ca.CategoryID = 103953;
                    break;
                case 88724:
                    ca.CategoryID = 103948;
                    break;
                case 88789:
                    ca.CategoryID = 103956;
                    break;
                case 88725:
                    ca.CategoryID = 103957;
                    break;
                case 88723:
                    ca.CategoryID = 103958;
                    break;
                case 88901:
                    ca.CategoryID = 103952;
                    break;
                case 6296:
                    ca.CategoryID = 103930;
                    break;
                case 81336:
                    ca.CategoryID = 103937;
                    break;
                case 81337:
                    ca.CategoryID = 103947;
                    break;
                case 8465:
                    ca.CategoryID = 103935;
                    break;
                case 7588:
                    ca.CategoryID = 103933;
                    break;
                case 8464:
                    ca.CategoryID = 103934;
                    break;
                case 81669:
                    ca.CategoryID = 103938;
                    break;
                case 81714:
                    ca.CategoryID = 103944;
                    break;
                case 81971:
                    ca.CategoryID = 103945;
                    break;
                case 83869:
                    ca.CategoryID = 103939;
                    break;
                case 103749:
                    ca.CategoryID = 103932;
                    break;
                case 7587:
                    ca.CategoryID = 103942;
                    break;
                case 817:
                    ca.CategoryID = 99408;
                    break;
                case 821:
                    ca.CategoryID = 99412;
                    break;
                case 99646:
                    ca.CategoryID = 103981;
                    break;
                case 88038:
                    ca.CategoryID = 103982;
                    break;
                case 89100:
                    ca.CategoryID = 103984;
                    break;
                case 89103:
                    ca.CategoryID = 103986;
                    break;
                case 89105:
                    ca.CategoryID = 103987;
                    break;
                case 89107:
                    ca.CategoryID = 103988;
                    break;
                case 89106:
                    ca.CategoryID = 103989;
                    break;
                case 89104:
                    ca.CategoryID = 103990;
                    break;
                case 89101:
                    ca.CategoryID = 103985;
                    break;
                case 89108:
                    ca.CategoryID = 103991;
                    break;
                case 89109:
                    ca.CategoryID = 103992;
                    break;
                case 103698:
                    ca.CategoryID = 103993;
                    break;
                case 89112:
                    ca.CategoryID = 103995;
                    break;
                case 89110:
                    ca.CategoryID = 103996;
                    break;
                case 89111:
                    ca.CategoryID = 103997;
                    break;
                case 0:
                    ca.CategoryID = 0;
                    break;
                default:
                    //ca.CategoryID = 99401;
                    //break;
                    Console.WriteLine("Error creating Category ID for : " + ca.Name);
                    return;
            }
            ca.CategoryIDSpecified = caIn.CategoryIDSpecified;
            ca.Cellpadding = caIn.Cellpadding;
            ca.CellpaddingSpecified = caIn.CellpaddingSpecified;
            ca.Client = new ClientID();
            //ca.Client.ID = caIn.Client.ID;
            ca.Client.ID = 7294703;
            ca.Client.IDSpecified = caIn.Client.IDSpecified;
            ca.Content = caIn.Content;
            ca.CorrelationID = caIn.CorrelationID;
            ca.CustomerKey = caIn.CustomerKey;
            ca.FontFamily = caIn.FontFamily;
            ca.HasFontSize = caIn.HasFontSize;
            ca.HasFontSizeSpecified = caIn.HasFontSizeSpecified;
            ca.IsBlank = caIn.IsBlank;
            ca.IsBlankSpecified = caIn.IsBlankSpecified;
            ca.IsDynamicContent = caIn.IsDynamicContent;
            ca.IsDynamicContentSpecified = caIn.IsDynamicContentSpecified;
            ca.IsLocked = caIn.IsLocked;
            ca.IsLockedSpecified = caIn.IsLockedSpecified;
            ca.IsSurvey = caIn.IsSurvey;
            ca.IsSurveySpecified = caIn.IsSurveySpecified;
            ca.Key = caIn.Key;
            ca.Layout = caIn.Layout;
            ca.LayoutSpecified = caIn.LayoutSpecified;
            ca.Name = caIn.Name;
            ca.ObjectState = caIn.ObjectState;
            ca.Owner = caIn.Owner;
            ca.Width = caIn.Width;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { ca }, out requestID, out status);
            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }
            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Content Area: " + ca.Name);
            Console.WriteLine("Exiting CreateContentAreaFromExisting()...\n");
        }
    }
}
