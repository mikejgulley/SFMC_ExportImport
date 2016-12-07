using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class QueryDefinitionUtil
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

        public static void CreateQuery(SoapClient soapClientIn)
        {
            String requestID;
            String status;

            QueryDefinition qd = new QueryDefinition();
            qd.Name = "API Created Query";
            qd.CustomerKey = "New Query Key32";
            qd.Description = "Some Description";
            qd.TargetUpdateType = "Overwrite";
            qd.TargetType = "DE";
            qd.QueryText = "Select * as from [SocialPages_DataExtension]";

            InteractionBaseObject ibo = new InteractionBaseObject();
            ibo.CustomerKey = "FIRST SEND";
            ibo.Name = "First Send";
            
            qd.DataExtensionTarget = ibo;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { qd }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
        }

        public static void CreateQueries(SoapClient soapClientIn, APIObject[] queryArrayIn)
        {
            String requestID;
            String status;

            foreach (QueryDefinition qdefIn in queryArrayIn)
            {
                QueryDefinition qd = new QueryDefinition();
                qd.Name = qdefIn.Name;
                qd.CustomerKey = qdefIn.CustomerKey;
                qd.Description = qdefIn.Description;
                qd.TargetUpdateType = qdefIn.TargetType;
                qd.TargetType = qdefIn.TargetType;
                qd.QueryText = qdefIn.QueryText;
                qd.DataExtensionTarget = qdefIn.DataExtensionTarget;

                CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { qd }, out requestID, out status);

                foreach (CreateResult result in cresults)
                {
                    Console.WriteLine(result.StatusMessage);
                }

                Console.WriteLine(requestID + ": " + status);
            }
            
        }
    }
}
