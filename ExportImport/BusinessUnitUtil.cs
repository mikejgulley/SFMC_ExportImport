using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class BusinessUnitUtil
    {
        public static void DescribeBusinessUnit(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "BusinessUnit";

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

        public static APIObject[] GetAllBusinessUnits(SoapClient soapClientIn)
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

            rr.ObjectType = "BusinessUnit";
            rr.Properties = new String[] { "ID", "AccountType", "ParentID", "BrandID", "PrivateLabelID", "ReportingParentID",
                "Name", "Email", "FromName", "BusinessName", "Phone", "Address", "Fax", "City", "State", "Zip", "Country",
                "IsActive", "IsTestAccount", "Client.ID", "DBID", "CustomerID", "DeletedDate", "EditionID", "IsTrialAccount",
                "Locale.LocaleCode", "Client.EnterpriseID", "ModifiedDate", "CreatedDate", "Subscription.SubscriptionID",
                "Subscription.HasPurchasedEmails", "Subscription.EmailsPurchased", "Subscription.Period", "Subscription.AccountsPurchased",
                "Subscription.LPAccountsPurchased", "Subscription.DOTOAccountsPurchased", "Subscription.BUAccountsPurchased",
                "Subscription.AdvAccountsPurchased", "Subscription.BeginDate", "Subscription.EndDate", "Subscription.Notes",
                "Subscription.ContractNumber", "Subscription.ContractModifier", "PartnerKey", "Client.PartnerClientKey",
                "ParentName", "ParentAccount.ID", "ParentAccount.Name", "ParentAccount.ParentID", "ParentAccount.CustomerKey",
                "ParentAccount.AccountType", "CustomerKey", "Description", "DefaultSendClassification.ObjectID", "DefaultHomePage.ID",
                "MasterUnsubscribeBehavior", "InheritAddress", "Roles", "SubscriberFilter", "ContextualRoles", "LanguageLocale.LocaleCode" };

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Business Units: " + results.Length);

            Console.ReadLine();

            return results;
        }
    }
}
