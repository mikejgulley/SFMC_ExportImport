using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class AccountUtil
    {
        public static void DescribeAccount(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "Account";

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

        public static APIObject[] GetAllAccounts(SoapClient soapClientIn)
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

            rr.ObjectType = "Account";
            rr.Properties = new String[] { "ID", "AccountType", "ParentID", "BrandID", "PrivateLabelID", "ReportingParentID",
                "Name", "Email", "FromName", "BusinessName", "Phone", "Address", "Fax", "City", "State", "Zip", "Country",
                "IsActive", "IsTestAccount", "Client.ClientID1", "DBID", "CustomerID", "DeletedDate", "EditionID", "ModifiedDate", "CreatedDate", 
                "ParentName", "Subscription.SubscriptionID", "Subscription.HasPurchasedEmails", "Subscription.EmailsPurchased", "Subscription.Period",
                "Subscription.AccountsPurchased", "Subscription.LPAccountsPurchased", "Subscription.DOTOAccountsPurchased", "Subscription.BUAccountsPurchased",
                "Subscription.AdvAccountsPurchased", "Subscription.BeginDate", "Subscription.EndDate", "Subscription.Notes",
                "PartnerKey", "Client.PartnerClientKey", "InheritAddress", "UnsubscribeBehavior", "Subscription.ContractNumber", "Subscription.ContractModifier",
                "IsTrialAccount", "Client.EnterpriseID", "ParentAccount.ID", "ParentAccount.Name", "ParentAccount.ParentID", "ParentAccount.CustomerKey",
                "ParentAccount.AccountType", "CustomerKey", "Locale.LocaleCode", "TimeZone.ID", "TimeZone.Name", "Roles", "ContextualRoles" };

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Accounts: " + results.Length);

            Console.ReadLine();

            return results;
        }

        private void CreateAccount(SoapClient soapClientIn, Account accountIn)
        {
            String requestID;
            String status;
            Account acct = new Account();
            acct.CustomerKey = accountIn.CustomerKey;
            acct.AccountType = accountIn.AccountType;
            acct.Name = accountIn.Name;
            acct.Email = accountIn.Email;
            acct.FromName = accountIn.FromName;
            acct.BusinessName = accountIn.BusinessName;
            acct.Address = accountIn.Address;
            acct.City = accountIn.City;
            acct.State = accountIn.State;
            acct.Zip = accountIn.Zip;
            acct.IsTestAccount = accountIn.IsTestAccount;
            acct.IsTestAccountSpecified = accountIn.IsTestAccountSpecified;
            acct.EditionID = accountIn.EditionID;
            acct.EditionIDSpecified = accountIn.EditionIDSpecified;
            acct.IsActive = accountIn.IsActive;
            acct.IsActiveSpecified = accountIn.IsActiveSpecified;
            CreateOptions co = new CreateOptions();
            CreateResult[] cresults = soapClientIn.Create(co, new APIObject[] { acct }, out requestID, out status);
            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }
            Console.WriteLine(requestID + ": " + status);
            //Readline will pause the output so you can see the results
            Console.ReadLine();
        }
    }
}
