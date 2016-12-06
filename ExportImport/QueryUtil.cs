using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class QueryUtil
    {
        public static void DescribeQuery(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "QueryDefinition";

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
        }

        public static APIObject[] GetAllQueries(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "QueryDefinition";
            rr.Properties = new String[] { "Name", "Description", "ObjectID", "CustomerKey", 
                "QueryText", "TargetType", "DataExtensionTarget.Name", "DataExtensionTarget.CustomerKey", 
                "DataExtensionTarget.Description", "TargetUpdateType", "FileType", "FileSpec", "Status",
                "CategoryID"};

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Queries: " + results.Length);

            Console.ReadLine();

            return results;
        }
    }
}
