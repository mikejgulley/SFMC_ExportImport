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

        public static DataExtensionField[] GetDataExtensionFieldsByDECustomerKey(SoapClient soapClientIn, DataExtension deIn)
        {
            deIn.CategoryIDSpecified = true;

            Console.WriteLine("Current DE Name: " + deIn.Name);
            Console.WriteLine("Current DE CategoryID: " + deIn.CategoryID);

            String requestID;
            String status;
            APIObject[] results;
            List<DataExtensionField> defList = new List<DataExtensionField>(); ;
            DataExtensionField[] defArray = {};

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "DataExtension.CustomerKey";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { deIn.CustomerKey };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "DataExtensionField";
            rr.Properties = new String[] { "ObjectID", "PartnerKey", "CustomerKey", "Name", "DefaultValue", "MaxLength", "IsRequired", "Ordinal",
                "IsPrimaryKey", "FieldType", "CreatedDate", "ModifiedDate", "Scale", "Client.ID", "DataExtension.CustomerKey", "StorageType" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            foreach (DataExtensionField def in results)
            {
                defList.Add(def);
            }

            Console.WriteLine(status);
            defArray = defList.ToArray<DataExtensionField>();
            Console.WriteLine("Num DE fields for " + deIn.Name + ": " + defArray.Length + "\n");

            return defArray;
        }
    }
}
