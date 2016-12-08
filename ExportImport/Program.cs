using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;

namespace ExportImport
{
    class Program
    {
        static void Main(string[] args)
        {
            APIObject[] dataExts = {};
            APIObject[] dataExtFields = {};
            APIObject[] dataFolders = {};
            APIObject[] dataFoldersByDE = {};
            APIObject[] queries = {};
            APIObject[] importDefs = {};
            APIObject[] roles = {};
            APIObject[] bUnits = {};
            APIObject[] accounts = {};
            APIObject[] accountUsers = {};
            APIObject[] emails = {};

            using (SoapClient soapProd = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsername, ConfigSettings.ETPassword))
            {
                // soapProd.Close(); -- when using 'using' - no need to use soapProd.Close()
                Console.WriteLine("Env: Prod\n");

                //Describe APIObjects
                //DataExtensionUtil.DescribeDataExtensions(soapProd);
                //DataFolderUtil.DescribeDataFolders(soapProd);
                //QueryUtil.DescribeQuery(soapProd);
                //ImportDefinitionUtil.DescribeImport(soapProd);
                //RoleUtil.DescribeRole(soapProd);
                //BusinessUnitUtil.DescribeBusinessUnit(soapProd);
                //AccountUtil.DescribeAccount(soapProd);
                //AccountUserUtil.DescribeAccountUser(soapProd);
                //RoleUtil.DescribePermission(soapProd);
                //EmailUtil.DescribeEmail(soapProd);

                //Data Folders
                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);
                //dataFolders = DataFolderUtil.GetAllDataFoldersByType(soapProd, "email");

                //Data Extensions
                //dataExts = DataExtensionUtil.GetAllDataExtensions(soapProd);

                //foreach (DataExtension de in dataExts)
                //{
                //    //dataExtFields = DataExtensionUtil.GetDataExtensionFieldsByDECustomerKey(soapProd, de);
                //    JSONUtil.saveDEToJSON(de);
                //}

                //foreach (DataExtension de in dataExts)
                //{
                //    //dataFoldersByDE = DataFolderUtil.GetDataFoldersByDECustomerKey(soapProd, de);
                //    dataFoldersByDE = DataFolderUtil.GetDataFolderByDECategoryID(soapProd, de);
                //    JSONUtil.saveDEToJSON(de);
                //}

                //Console.WriteLine("...");
                //Console.ReadLine();

                // Data Folders
                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);

                //foreach (DataFolder df in dataFolders)
                //{
                //    JSONUtil.saveDataFolderToJSON(df);
                //}

                //Console.WriteLine("...");
                //Console.ReadLine();

                // Queries
                queries = QueryDefinitionUtil.GetAllQueries(soapProd);

                foreach (QueryDefinition qd in queries)
                {
                    JSONUtil.saveQueryToJSON(qd);
                }

                // Import Definitions
                //importDefs = ImportDefinitionUtil.GetAllImportDefinitions(soapProd);

                //foreach (ImportDefinition id in importDefs)
                //{
                //    JSONUtil.saveImportDefToJSON(id);
                //}
                
                // Roles
                //roles = RoleUtil.GetAllRoles(soapProd);

                //foreach (Role role in roles)
                //{
                //    JSONUtil.saveRoleToJSON(role);
                //}

                // Business Units
                //bUnits = BusinessUnitUtil.GetAllBusinessUnits(soapProd);

                //foreach (BusinessUnit bu in bUnits)
                //{
                //    JSONUtil.saveBusinessUnitToJSON(bu);
                //}

                // Accounts
                //accounts = AccountUtil.GetAllAccounts(soapProd);

                //foreach (Account account in accounts)
                //{
                //    JSONUtil.saveAccountToJSON(account);

                //}

                // Account Users
                //accountUsers = AccountUserUtil.GetAllAccountUsers(soapProd);

                //foreach (AccountUser accountUser in accountUsers)
                //{
                //    JSONUtil.saveAccountUserToJSON(accountUser);
                //    //RoleUtil.GetUserRoleByCustomerKey(soapProd, accountUser);
                //}

                // Emails
                //emails = EmailUtil.GetAllEmails(soapProd);

                //foreach (Email email in emails)
                //{
                //    JSONUtil.saveEmailToJSON(email);
                //}
            }

            using (SoapClient soapSbx = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsernameSbx, ConfigSettings.ETPasswordSbx))
            {
                Console.WriteLine("Env: Sbx\n");
                //DataExtensionUtil.CreateDataExtensions(soapSbx, dataExts, dataExtFields);
                //APIObject[] dfArray = DataFolderUtil.GetAllDataFoldersByType(soapSbx, "dataextension");

                //foreach (DataFolder df in dfArray)
                //{
                //    Console.WriteLine("Data Folder Name: " + df.Name);
                //    Console.WriteLine("Data Folder ID: " + df.ID);
                //}

                //Console.ReadLine();

                //DataFolderUtil.CreateDataFolder(soapSbx);

                //int counter = 0;

                //foreach (DataFolder df in dataFolders)
                //{
                //    while (counter < 10)
                //    {
                //        Console.WriteLine("Creating Data Folder: " + df.Name);
                //        DataFolderUtil.CreateDataFolderFromExistingInProd(soapSbx, df);
                //        counter++;
                //    }
                //}

                
            }
            
        }
    }
}
