using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class PropertyDefinitionUtil
    {
        public static APIObject[] GetAllPropertyDefinitions(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            ExportImport.PartnerAPI.Attribute[] attrs;
            int counter = 0;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "EmailAddress";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { "katherine.cross@sylvanlearning.com" };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "Subscriber";
            rr.Properties = new String[] { "EmailAddress", "ID" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine("Total Subscribers: " + results.Length);
            
            foreach (Subscriber sub in results)
            {
                Console.WriteLine("Total Subscribers Returned: " + results.Length);
                foreach (ExportImport.PartnerAPI.Attribute attr in sub.Attributes)
                {
                    Console.WriteLine("Attribute Name: " + attr.Name);
                }
                attrs = sub.Attributes;
                Console.WriteLine("Num attrs: " + attrs.Length);
                counter++;

                if (counter > 0)
                {
                    break;
                }
            }

            Console.ReadLine();

            return results;
        }
        
        //public static APIObject[] GetAllPropertyDefinitions(SoapClient soapClientIn)
        //{
        //    String requestID;
        //    String status;
        //    APIObject[] results;

        //    RetrieveRequest rr = new RetrieveRequest();

        //    ClientID clientID = new ClientID();
        //    clientID.ID = 7237980;
        //    clientID.IDSpecified = true;
        //    ClientID[] targetClientIDs = { clientID };
        //    rr.ClientIDs = targetClientIDs;
        //    rr.QueryAllAccounts = true;
        //    rr.QueryAllAccountsSpecified = true;

        //    rr.ObjectType = "PropertyDefinition";
        //    rr.Properties = new String[] { "ID" };

        //    status = soapClientIn.Retrieve(rr, out requestID, out results);

        //    Console.WriteLine("Total Properties: " + results.Length);

        //    foreach (PropertyDefinition propDef in results)
        //    {
        //        Console.WriteLine("Property Name: " + propDef.Name);
        //    }

        //    Console.ReadLine();

        //    return results;
        //}
    }
}
