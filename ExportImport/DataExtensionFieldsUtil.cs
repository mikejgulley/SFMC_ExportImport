using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class DataExtensionFieldsUtil
    {
        public static void DescribeDataExtensionFields(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "DataExtensionField";

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

        public static APIObject[] GetDataExtensionFieldsByDECustomerKey(SoapClient soapClientIn, DataExtension deIn)
        {
            deIn.CategoryIDSpecified = true;

            Console.WriteLine("Current DE Name: " + deIn.Name);
            Console.WriteLine("Current DE CategoryID: " + deIn.CategoryID);

            String requestID;
            String status;
            APIObject[] results;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "DataExtension.CustomerKey";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { deIn.CustomerKey };

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "DataExtensionField";
            rr.Properties = new String[] { "Name", "ObjectID", "CustomerKey" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);
            Console.WriteLine(status);
            Console.WriteLine("Num DE fields: " + results.Length + "\n");

            return results;
        }
    }
}
