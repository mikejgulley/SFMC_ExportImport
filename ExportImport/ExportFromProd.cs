using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;

namespace ExportImport
{
    class ExportFromProd
    {
        public static void PerformExport(SoapClient soapClientIn)
        {
            APIObject[] dataExts = { };
            APIObject[] dataExtFields = { };
            APIObject[] dataFolders = { };
            APIObject[] dataFoldersByDE = { };
            APIObject[] queries = { };
            APIObject[] importDefs = { };
            APIObject[] roles = { };
            APIObject[] bUnits = { };
            APIObject[] accounts = { };
            APIObject[] accountUsers = { };
            APIObject[] emails = { };
            APIObject[] portfolioObjects = { };
            APIObject[] contentAreas = { };
            APIObject[] lists = { };
            APIObject[] pubLists = { };
            APIObject[] suppressionLists = { };
            APIObject[] templates = { };
            APIObject[] emailSendDefs = { };
            APIObject[] triggeredEmailSendDefs = { };
            APIObject[] emailSendClassifications = { };

            //Data Extensions
            //dataExts = DataExtensionUtil.GetAllDataExtensions(soapProd);

            //foreach (DataExtension de in dataExts)
            //{
            //    de.Fields = (DataExtensionField[]) DataExtensionFieldsUtil.GetDataExtensionFieldsByDECustomerKey(soapProd, de);
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
            //queries = QueryDefinitionUtil.GetAllQueries(soapProd);

            //foreach (QueryDefinition qd in queries)
            //{
            //    JSONUtil.saveQueryToJSON(qd);
            //}

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

            // Portfolio
            //portfolioObjects = PortfolioUtil.GetAllPortfolioItems(soapProd);

            //foreach (Portfolio port in portfolioObjects)
            //{
            //    //Console.WriteLine(port.FileName);
            //    JSONUtil.savePortfolioItemToJSON(port);
            //}

            // Content Area
            //contentAreas = ContentAreaUtil.GetAllContentAreas(soapProd);

            //foreach (ContentArea content in contentAreas)
            //{
            //    //Console.WriteLine(content.Name);
            //    JSONUtil.saveContentAreaToJSON(content);
            //}

            // Lists
            //lists = ListsUtil.GetAllLists(soapProd);

            //foreach (List list in lists)
            //{
            //    //Console.WriteLine(list.ListName);
            //    JSONUtil.saveListToJSON(list);
            //}

            //// Publications
            //pubLists = PublicationListUtil.GetAllPublicationLists(soapProd);

            //foreach (Publication pub in pubLists)
            //{
            //    Console.WriteLine(pub.Name);
            //    //JSONUtil.savePublicationListToJSON(pubList);
            //}

            // Suppression List
            //suppressionLists = SuppressionListUtil.GetAllSuppressionLists(soapProd);

            //foreach (SuppressionListDefinition supList in suppressionLists)
            //{
            //    Console.WriteLine(supList.Name);
            //    //JSONUtil.saveSuppressionListToJSON(pubList);
            //}

            // Templates
            //templates = TemplateUtil.GetAllTemplates(soapProd);

            //foreach (Template template in templates)
            //{
            //    //Console.WriteLine(template.TemplateName);
            //    JSONUtil.saveTemplateToJSON(template);
            //}

            // Email Send Definitions (User-initiated)
            //emailSendDefs = EmailUtil.GetAllUIEmailSendDefinitions(soapProd);

            //foreach (EmailSendDefinition eSendDef in emailSendDefs)
            //{
            //    //Console.WriteLine(eSendDef.Name);
            //    JSONUtil.saveUIEmailSendDefinitionToJSON(eSendDef);
            //}

            // Email Send Definitions (User-initiated)
            //emailSendClassifications = SendClassificationUtil.GetAllSendClassifications(soapClientIn);

            //foreach (SendClassification sendClass in emailSendClassifications)
            //{
            //    //Console.WriteLine(sendClass.Name);
            //    JSONUtil.saveSendClassificationToJSON(sendClass);
            //}

            // Triggered Email Send Definitions
            triggeredEmailSendDefs = TriggeredSendDefinitionUtil.GetAllTriggeredEmailSendDefinitions(soapClientIn);

            foreach (TriggeredSendDefinition tSendDef in triggeredEmailSendDefs)
            {
                Console.WriteLine(tSendDef.Name);

                tSendDef.Email = EmailUtil.GetEmailByID(soapClientIn, tSendDef.Email.ID);
                tSendDef.List = ListsUtil.GetListByID(soapClientIn, tSendDef.List.ID);
                //tSendDef.SendClassification = SendClassificationUtil.GetSendClassificationByID(soapClientIn, tSendDef.SendClassification.ID);

                JSONUtil.saveTriggeredSendDefinitionToJSON(tSendDef);
            }
        }
    }
}
