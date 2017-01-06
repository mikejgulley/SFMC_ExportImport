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

        public static APIObject[] GetAutomationByCustomerKey(SoapClient soapClientIn, string custKeyIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            //------------------------ WORKING ---- CAN ONLY RETRIEVE ONE AT A TIME BY USING SFP - OTHERWISE API IS BROKEN -------------------------------//

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "Automation";
            rr.QueryAllAccounts = true;
            //rr.Properties = new string[] { "Name", "CustomerKey", "ProgramID" };// must have ProgramID - this comes back as ObjectID
            //rr.Properties = new String[] { "Name", "Description", "CustomerKey",
            //    "IsActive", "CreatedDate", "ModifiedDate", "Status", "ProgramID" };
            //rr.Properties = new String[] { "*" }; // using * will return AutomationTasks node, but ONLY IF automation was created via API
            rr.Properties = new string[] { "ProgramID", "Name", "Description", "RecurrenceID", "CustomerKey", "IsActive", "CreatedDate", "ModifiedDate", "Status" }; // from Documentation

            SimpleFilterPart sfp = new SimpleFilterPart(); // must have SimpleFilterPart
            sfp.Property = "CustomerKey";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { custKeyIn };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            foreach (Automation automation in results) 
            {
                Console.WriteLine("Automation: " + automation.Name + "\nCustomerKey: " + automation.CustomerKey + "\n");
            }

            return results;
        }
    }
}
