using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class AutomationTaskUtil
    {
        public static void DescribeAutomationTask(SoapClient soapClientIn)
        {
            string requestID;
            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "AutomationTask";

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

        //public static AutomationTask[] GetAutomationTasksByAutomation(SoapClient soapClientIn, Automation automationIn)
        public static AutomationTask[] GetAutomationTasksByAutomation(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            AutomationTask[] tasks = { };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "AutomationTaskInstance"; // error: AutomationTask, AutomationActivity, AutomationTaskInstance is not a valid ObjectType
            rr.Properties = new string[] { "Activites", "Automation", "AutomationTaskType", "Description", "Name", "Sequence", "CustomerKey" };
            
            status = soapClientIn.Retrieve(rr, out requestID, out results);
            //int i = 0;

            //foreach (AutomationTask at in results)
            //{
            //    Console.WriteLine(at.Name);
            //    tasks[i] = at;
            //    i++;
            //}

            tasks = (AutomationTask[]) results;

            foreach (AutomationTask task in tasks)
            {
                Console.WriteLine("Task: " + task.Name);
            }

            return tasks;
        }
    }
}
