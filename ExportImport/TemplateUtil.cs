using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class TemplateUtil
    {
        public static void DescribeTemplate(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Template";

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

        public static APIObject[] GetAllTemplates(SoapClient soapClientIn)
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

            rr.ObjectType = "Template";
            rr.Properties = new String[] { "ObjectID", "ID", "Client.ID", "TemplateName", "LayoutHTML", "BackgroundColor",
                "BorderColor", "BorderWidth", "Cellpadding", "Cellspacing", "Width", "Align", "ActiveFlag", "CategoryID",
                "CategoryType", "OwnerID", "HeaderContent.ID", "HeaderContent.ObjectID", "Layout.ID", "Layout.LayoutName",
                "CustomerKey", "TemplateSubject", "IsTemplateSubjectLocked" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Templates: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Templates: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static APIObject[] GetTemplateByCategoryId(SoapClient soapClientIn, int catIdIn)
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

            rr.ObjectType = "Template";
            rr.Properties = new String[] { "ObjectID", "ID", "Client.ID", "TemplateName", "LayoutHTML", "BackgroundColor",
                "BorderColor", "BorderWidth", "Cellpadding", "Cellspacing", "Width", "Align", "ActiveFlag", "CategoryID",
                "CategoryType", "OwnerID", "HeaderContent.ID", "HeaderContent.ObjectID", "Layout.ID", "Layout.LayoutName",
                "CustomerKey", "TemplateSubject", "IsTemplateSubjectLocked" };
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
                Console.WriteLine("Num Templates: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Templates: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static void CreateTemplateFromExisting(SoapClient soapClientIn, Template templateIn, int catIdIn)
        {
            Console.WriteLine("Entering CreateTemplateFromExisting()...");
            String requestID;
            String status;

            Template template = new Template();
            template.ActiveFlag = templateIn.ActiveFlag;
            template.ActiveFlagSpecified = templateIn.ActiveFlagSpecified;
            template.Align = templateIn.Align;
            template.BackgroundColor = templateIn.BackgroundColor;
            template.BorderColor = templateIn.BorderColor;
            template.BorderWidth = templateIn.BorderWidth;
            template.BorderWidthSpecified = templateIn.BorderWidthSpecified;
            template.CategoryID = catIdIn;
            template.CategoryIDSpecified = true;
            template.CategoryType = templateIn.CategoryType;
            template.Cellpadding = templateIn.Cellpadding;
            template.CellpaddingSpecified = templateIn.CellpaddingSpecified;
            template.Cellspacing = templateIn.Cellspacing;
            template.CellspacingSpecified = templateIn.CellspacingSpecified;
            template.CustomerKey = templateIn.CustomerKey;
            template.HeaderContent = templateIn.HeaderContent;
            template.IsTemplateSubjectLocked = templateIn.IsTemplateSubjectLocked;
            template.IsTemplateSubjectLockedSpecified = templateIn.IsTemplateSubjectLockedSpecified;
            template.Layout = templateIn.Layout;
            template.LayoutHTML = templateIn.LayoutHTML;
            template.PreHeader = templateIn.PreHeader;
            template.TemplateName = templateIn.TemplateName;
            template.TemplateSubject = templateIn.TemplateSubject;
            template.Width = templateIn.Width;
            template.WidthSpecified = templateIn.WidthSpecified;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { template }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Template: " + template.TemplateName);
            Console.WriteLine("Exiting CreateTemplateFromExisting()...\n");
        }
    }
}
