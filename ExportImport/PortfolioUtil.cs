using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class PortfolioUtil
    {
        public static void DescribePortfolioItem(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Portfolio"; // Portfolio, Content Area, Email, 

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

        public static APIObject[] GetAllPortfolioItems(SoapClient soapClientIn)
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

            rr.ObjectType = "Portfolio";
            rr.Properties = new String[] { "RowObjectID", "ObjectID", "PartnerKey", "CustomerKey", "Client.ID", "CategoryID",
                "FileName", "DisplayName", "Description", "TypeDescription", "IsUploaded", "IsActive", "FileSizeKB", "ThumbSizeKB", "FileWidthPX",
                "FileHeightPX", "FileURL", "ThumbURL", "CacheClearTime", "CategoryType", "CreatedDate", "CreatedBy", "ModifiedBy",
                "ModifiedDate", "ModifiedByName"};

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Portfolio Items: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Portfolio Items: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static APIObject[] GetAllPortfolioItemsByCategoryID(SoapClient soapClientIn, int catIdIn)
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

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "CategoryID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { catIdIn.ToString() };

            rr.ObjectType = "Portfolio";
            rr.Properties = new String[] { "RowObjectID", "ObjectID", "PartnerKey", "CustomerKey", "Client.ID", "CategoryID",
                "FileName", "DisplayName", "Description", "TypeDescription", "IsUploaded", "IsActive", "FileSizeKB", "ThumbSizeKB", "FileWidthPX",
                "FileHeightPX", "FileURL", "ThumbURL", "CacheClearTime", "CategoryType", "CreatedDate", "CreatedBy", "ModifiedBy",
                "ModifiedDate", "ModifiedByName"};
            rr.Filter = sfp;

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Portfolio Items: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Portfolio Items: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        //public static void CreatePortfolioItemFromExisting(SoapClient soapClientIn, Portfolio portItemIn, int catIdIn)
        //{
        //    Console.WriteLine("Entering CreatePortfolioItemFromExisting()...");
        //    String requestID;
        //    String status;

        //    Portfolio port = new Portfolio();
        //    port.CategoryID = catIdIn;
        //    port.CategoryIDSpecified = portItemIn.CategoryIDSpecified;
        //    port.CategoryType = portItemIn.CategoryType;
        //    port.Client = new ClientID();
        //    port.Client.ID = 7294703;
        //    port.Client.IDSpecified = true;
        //    port.CorrelationID = portItemIn.CorrelationID;
        //    port.CreatedDate = portItemIn.CreatedDate;
        //    port.CreatedDateSpecified = portItemIn.CreatedDateSpecified;
        //    port.CustomerKey = portItemIn.CustomerKey;
        //    port.Description = portItemIn.Description;
        //    port.DisplayName = portItemIn.DisplayName;
        //    port.FileHeightPX = portItemIn.FileHeightPX;
        //    port.FileHeightPXSpecified = portItemIn.FileHeightPXSpecified;
        //    port.FileName = portItemIn.FileName;
        //    port.FileSizeKB = portItemIn.FileSizeKB;
        //    port.FileSizeKBSpecified = portItemIn.FileSizeKBSpecified;
        //    port.FileURL = portItemIn.FileURL;
        //    port.FileWidthPX = portItemIn.FileWidthPX;
        //    port.FileWidthPXSpecified = portItemIn.FileWidthPXSpecified;
        //    port.ID = portItemIn.ID;
        //    port.IDSpecified = portItemIn.IDSpecified;
        //    port.IsActive = portItemIn.IsActive;
        //    port.IsActiveSpecified = portItemIn.IsActiveSpecified;
        //    port.IsUploaded = portItemIn.IsUploaded;
        //    port.IsUploadedSpecified = portItemIn.IsUploadedSpecified;
        //    port.ModifiedDate = portItemIn.ModifiedDate;
        //    port.ModifiedDateSpecified = portItemIn.ModifiedDateSpecified;
        //    port.ObjectID = portItemIn.ObjectID;
        //    port.ObjectState = portItemIn.ObjectState;
        //    port.Owner = portItemIn.Owner;
        //    //port.PartnerKey = portItemIn.PartnerKey;
        //    //port.PartnerProperties = portItemIn.PartnerProperties;
        //    port.Source = new ResourceSpecification();
        //    port.Source = portItemIn.Source;
        //    port.ThumbSizeKB = portItemIn.ThumbSizeKB;
        //    port.ThumbSizeKBSpecified = portItemIn.ThumbSizeKBSpecified;
        //    port.ThumbURL = portItemIn.ThumbURL;
        //    port.TypeDescription = portItemIn.TypeDescription;

        //    CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { port }, out requestID, out status);

        //    foreach (CreateResult result in cresults)
        //    {
        //        Console.WriteLine(result.StatusMessage);
        //    }

        //    Console.WriteLine(requestID + ": " + status);
        //    Console.WriteLine("Portfolio Item: " + port.DisplayName);
        //    Console.WriteLine("Exiting CreatePortfolioItemFromExisting()...\n");
        //}

        public static void CreatePortfolioItemFromExisting(SoapClient soapClientIn, Portfolio portItemIn, int catIdIn)
        {
            Console.WriteLine("Entering CreatePortfolioItemFromExisting()...");
            String requestID;
            String status;

            Portfolio port = new Portfolio();
            //port.CacheClearTime = portItemIn.CacheClearTime;
            //port.CacheClearTimeSpecified = portItemIn.CacheClearTimeSpecified;
            port.CategoryID = catIdIn;
            port.CategoryIDSpecified = portItemIn.CategoryIDSpecified;
            port.CategoryType = portItemIn.CategoryType;
            port.Client = new ClientID();
            port.Client.ID = 7294703;
            port.Client.IDSpecified = true;
            port.CorrelationID = portItemIn.CorrelationID;
            port.CreatedDate = portItemIn.CreatedDate;
            port.CreatedDateSpecified = portItemIn.CreatedDateSpecified;
            port.CustomerKey = portItemIn.CustomerKey;
            port.Description = portItemIn.Description;
            port.DisplayName = portItemIn.DisplayName;
            port.FileHeightPX = portItemIn.FileHeightPX;
            port.FileHeightPXSpecified = portItemIn.FileHeightPXSpecified;
            port.FileName = portItemIn.FileName;
            port.FileSizeKB = portItemIn.FileSizeKB;
            port.FileSizeKBSpecified = portItemIn.FileSizeKBSpecified;
            port.FileURL = portItemIn.FileURL;
            port.FileWidthPX = portItemIn.FileWidthPX;
            port.FileWidthPXSpecified = portItemIn.FileWidthPXSpecified;
            port.ID = portItemIn.ID;
            port.IDSpecified = portItemIn.IDSpecified;
            port.IsActive = portItemIn.IsActive;
            port.IsActiveSpecified = portItemIn.IsActiveSpecified;
            port.IsUploaded = portItemIn.IsUploaded;
            port.IsUploadedSpecified = portItemIn.IsUploadedSpecified;
            port.ModifiedDate = portItemIn.ModifiedDate;
            port.ModifiedDateSpecified = portItemIn.ModifiedDateSpecified;
            port.ObjectID = portItemIn.ObjectID;
            port.ObjectState = portItemIn.ObjectState;
            port.Owner = portItemIn.Owner;
            port.Source = new ResourceSpecification();
            // Use the syntax below to get the file from a public HTTP site
            //portfolio.Source.URN = "http://email.exacttarget.com/images/RequestADemo_button.jpg";
            port.Source.URN = portItemIn.FileURL;
            // Use the syntax below to get the file from your Enhanced FTP site 
            //portfolio.Source.URN = "File://ETFTP/Import/image1.jpg";
            //portfolio.FileName = "image1.jpg";
            port.ThumbSizeKB = portItemIn.ThumbSizeKB;
            port.ThumbSizeKBSpecified = portItemIn.ThumbSizeKBSpecified;
            port.ThumbURL = portItemIn.ThumbURL;
            port.TypeDescription = portItemIn.TypeDescription;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { port }, out requestID, out status);
            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }
            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Portfolio Item: " + port.DisplayName);
            Console.WriteLine("Exiting CreatePortfolioItemFromExisting()...\n");
        }
    }
}
