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

            Console.ReadLine();
        }

        // returns nothing for Permission and PermissionSet
        //public static void DescribePermission(SoapClient soapClientIn)
        //{
        //    string requestID;

        //    ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
        //    objDefs.ObjectType = "PermissionSet";

        //    ObjectDefinition[] definitions = soapClientIn.Describe(new ObjectDefinitionRequest[] { objDefs }, out requestID);

        //    foreach (ObjectDefinition od in definitions)
        //    {
        //        Console.WriteLine("***Object Name: " + od.ObjectType + "****");

        //        foreach (PropertyDefinition pd in od.Properties)
        //        {
        //            Console.WriteLine("  Property Name: " + pd.Name);
        //            Console.WriteLine("  IsRetrievable: " + pd.IsRetrievable.ToString() + "\n");
        //        }
        //        Console.WriteLine("");
        //    }
        //}

        public static APIObject[] GetAllRoles(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

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

            rr.ObjectType = "Permission";
            rr.Properties = new String[] { "ObjectID", "CustomerKey", "Name", "Description", "IsPrivate", "IsSystemDefined",
                "Client.EnterpriseID", "Client.ID", "Client.CreatedBy", "CreatedDate", "Client.ModifiedBy", "ModifiedDate" };
            // Trying to also retrieve "PermissionSets" and "Permissions" caused an error

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Permissions: " + results.Length);

            Console.ReadLine();

            return results;
        }

        public static APIObject[] GetUserRoleByCustomerKey(SoapClient soapClientIn, AccountUser accountUserIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            //ClientID clientID = new ClientID();
            //clientID.ID = 7237980;
            //clientID.IDSpecified = true;
            //ClientID[] targetClientIDs = { clientID };
            //rr.ClientIDs = targetClientIDs;
            //rr.QueryAllAccounts = true;
            //rr.QueryAllAccountsSpecified = true;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "CustomerKey";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new string[] { accountUserIn.CustomerKey };

            rr.ObjectType = "Role";
            rr.Properties = new String[] { "ObjectID", "CustomerKey", "Name", "Description", "IsPrivate", "IsSystemDefined",
                "Client.EnterpriseID", "Client.ID", "Client.CreatedBy", "CreatedDate", "Client.ModifiedBy", "ModifiedDate" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("User name: " + accountUserIn.Name);
            Console.WriteLine("Num Roles: " + results.Length);

            foreach (Role role in results)
            {
                //foreach (Permission permission in role.Permissions)
                //{
                //    Console.WriteLine("Permission: " + permission.Name);
                //}

                //foreach (PermissionSet permSet in role.PermissionSets)
                //{
                //    Console.WriteLine("PermissionSets: " + permSet.Name);
                //}
            }

            Console.ReadLine();

            return results;
        }

        public static APIObject[] GetUserRoleByName(SoapClient soapClientIn, String nameIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "Name";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new string[] { nameIn };

            rr.ObjectType = "Role";
            rr.Properties = new String[] { "ObjectID", "CustomerKey", "Name", "Description", "IsPrivate", "IsSystemDefined",
                "Client.EnterpriseID", "Client.ID", "Client.CreatedBy", "CreatedDate", "Client.ModifiedBy", "ModifiedDate" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Roles: " + results.Length);

            foreach (Role role in results)
            {
                Console.WriteLine("Role: " + role.Name);                
            }

            Console.ReadLine();

            return results;
        }

        public static void CreateRoleFromExistingInProd(SoapClient soapClientIn, Role roleIn)
        {
            Console.WriteLine("Entering CreateRoleFromExistingInProd()...");
            String requestID;
            String status;

            Role role = new Role();
            role.Name = roleIn.Name;
            role.Description = roleIn.Description;
            role.IsPrivate = roleIn.IsPrivate;
            role.IsPrivateSpecified = roleIn.IsPrivateSpecified;
            role.IsSystemDefined = roleIn.IsSystemDefined;
            role.IsSystemDefinedSpecified = roleIn.IsSystemDefinedSpecified;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { role }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Role: " + role.Name);
            Console.WriteLine("Exiting CreateRoleFromExistingInProd()...\n");
        }
    }
}
