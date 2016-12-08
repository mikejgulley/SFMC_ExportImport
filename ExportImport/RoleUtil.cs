using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class RoleUtil
    {
        public static void DescribeRole(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Role";

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

        public static APIObject[] GetAllRoles(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "Role";
            rr.Properties = new String[] { "ObjectID", "CustomerKey", "Name", "Description", "IsPrivate", "IsSystemDefined",
                "Client.EnterpriseID", "Client.ID", "Client.CreatedBy", "CreatedDate", "Client.ModifiedBy", "ModifiedDate" };
                // Trying to also retrieve "PermissionSets" and "Permissions" caused an error

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Roles: " + results.Length);

            Console.ReadLine();

            return results;
        }

        public static APIObject[] GetPermissionsByRole(SoapClient soapClientIn, Role roleIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "PermissionSet";
            rr.Properties = new String[] { "ObjectID", "CustomerKey", "Name", "Description", "IsPrivate", "IsSystemDefined",
                "Client.EnterpriseID", "Client.ID", "Client.CreatedBy", "CreatedDate", "Client.ModifiedBy", "ModifiedDate" };
            // Trying to also retrieve "PermissionSets" and "Permissions" caused an error

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Roles: " + results.Length);

            Console.ReadLine();

            return results;
        }
    }
}
