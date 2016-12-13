using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class AutomationUtil
    {
        public static void DescribeAutomation(SoapClient soapClientIn)
        {
            string requestID;
            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Automation";

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

        public static void GetAllAutomations(SoapClient soapClientIn)
        {
            //String requestID;
            //String status;
            //APIObject[] results;
            //APIObject[] totalResults = { new APIObject() };
            //List<APIObject> totalResultsList = new List<APIObject>();
            //int totalCount = 0;

            //RetrieveRequest rr = new RetrieveRequest();

            //ClientID clientID = new ClientID();
            //clientID.ID = 7237980;
            //clientID.IDSpecified = true;
            //ClientID[] targetClientIDs = { clientID };
            //rr.ClientIDs = targetClientIDs;
            //rr.QueryAllAccounts = true;
            //rr.QueryAllAccountsSpecified = true;

            //rr.ObjectType = "Automation";
            //rr.Properties = new String[] { "ObjectID", "Name", "Description", "Schedule.ID", "CustomerKey",
            //    "Client.ID", "IsActive", "CreatedDate", "Client.CreatedBy", "ModifiedDate", "Client.ModifiedBy",
            //    "Status", "Client.EnterpriseID" };

            //do
            //{
            //    status = soapClientIn.Retrieve(rr, out requestID, out results);

            //    totalCount += results.Length;

            //    foreach (Automation automation in results)
            //    {
            //        totalResultsList.Add(automation);
            //    }

            //    Console.WriteLine(status);
            //    Console.WriteLine("Num Automations: " + totalCount);

            //    rr = new RetrieveRequest();
            //    rr.ContinueRequest = requestID;
            //} while (status.Equals("MoreDataAvailable"));

            //totalResults = totalResultsList.ToArray<APIObject>();
            //Console.WriteLine("Total Automations: " + totalResults.Length);

            //Console.ReadLine();
            //return totalResults;

            RetrieveRequest rr = new RetrieveRequest();
            rr.ObjectType = "Automation";
            //SimpleFilterPart sf = new SimpleFilterPart();
            //sf.Property = "CustomerKey";
            //sf.SimpleOperator = SimpleOperators.equals;
            //sf.Value = new String[] { iAutomationCustomerKey };
            //rr.Filter = sf;
            rr.Properties = new string[] { "ProgramID", "Name", "Description", "RecurrenceID", "CustomerKey", "IsActive", "CreatedDate", "ModifiedDate", "Status" };
            string sStatus = "";
            string sRequestId = "";
            APIObject[] rResults;
            sStatus = soapClientIn.Retrieve(rr, out sRequestId, out rResults);
            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("RequestID: " + sRequestId);
            foreach (Automation automation in rResults)
            {
                Console.WriteLine("ObjectID: " + automation.ObjectID);
                Console.WriteLine("Name: " + automation.Name);
                Console.WriteLine("Description: " + automation.Description);
                if (automation.Schedule != null)
                {
                    Console.WriteLine("Schedule.ID: " + automation.Schedule.ID);
                }
                Console.WriteLine("CustomerKey: " + automation.CustomerKey);
                Console.WriteLine("IsActive: " + automation.IsActive);
                Console.WriteLine("CreatedDate: " + automation.CreatedDate.ToString());
                Console.WriteLine("ModifiedDate: " + automation.ModifiedDate);
                Console.WriteLine("Status: " + automation.Status);
            }

            //return rResults;
        }
    }
}
