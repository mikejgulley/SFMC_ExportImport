using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class AccountUserUtil
    {
        public static void DescribeAccountUser(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "AccountUser";

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

        public static APIObject[] GetAllAccountUsers(SoapClient soapClientIn)
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

            rr.ObjectType = "AccountUser";
            rr.Properties = new String[] { "ID", "CreatedDate", "ModifiedDate", "Client.ID", "AccountUserID", "UserID",
                "Name", "Email", "MustChangePassword", "ActiveFlag", "ChallengePhrase", "ChallengeAnswer", "IsAPIUser", "NotificationEmailAddress",
                "Client.PartnerClientKey", "Password", "Locale.LocaleCode", "TimeZone.ID", "TimeZone.Name", "CustomerKey",
                "DefaultBusinessUnit", "LanguageLocale.LocaleCode", "Client.ModifiedBy" };

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num AccountUsers: " + results.Length);

            Console.ReadLine();

            return results;
        }

        public void AddUserToAccount(SoapClient soapClientIn)
        {
            Account account = new Account();
            account.ID = 12334;
            if (account != null)
            {
                AccountUser accountUser = new AccountUser();
                accountUser.Name = "ACRUZ";
                accountUser.UserID = "ACRUZ";
                accountUser.IsAPIUser = true;
                accountUser.IsAPIUserSpecified = true;
                accountUser.IsLocked = false;
                accountUser.IsLockedSpecified = true;
                accountUser.Password = "XXX";
                accountUser.MustChangePassword = false;
                accountUser.MustChangePasswordSpecified = true;
                accountUser.Email = "acruz@example.com";

                UserAccess access = new UserAccess();
                //3 CLIENT_ADMIN Add Users to Account 
                //4 PRO_ADMIN Create/View Accounts 
                access.ID = 3;
                access.IDSpecified = true; //.Net specific
                accountUser.UserPermissions = new UserAccess[] { access };

                //This tells that create user in subaccount
                ClientID clientID = new ClientID();
                clientID.PartnerClientKey = "12345";
                clientID.IDSpecified = true;
                accountUser.Client = clientID;
                APIObject[] apiObjects = { accountUser };
                String requestId = null;
                String overAllStatus = null;
                CreateResult[] results = soapClientIn.Create(new CreateOptions(), apiObjects, out requestId, out overAllStatus);
                if (results != null)
                {
                    foreach (CreateResult result in results)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Status Message ### " +
                        result.StatusMessage);
                    }
                }
                else
                {
                    Console.Write("Error ...... ");
                }
            }
        }
    }
}
