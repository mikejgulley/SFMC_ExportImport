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
            // Data Folder ID's - PROD
            // Data Feeds = 8455; Data Views = 82914; Exclusion = 9218; Journey Builder = 82920; Processing = 9201; CASL = 10610; Nightly Candidate RP Process = 9595; 
            // VOC = 11058; Appointment Confirmation = 83625; Appointment Reminder = 83632; Appointment Survey Resend = 86029; Connector - Booked = 83432; Connector - December = ;
            // Connector - January = 101939; Connector - November = ; Connector - October = ; Connector - September EDGE = ; Connector - September Prep = ;
            // Connector - Tested = 83211; Enrolled Welcome = 83214; Handraiser = 83215; Inquiry Connector and NonConnector = 83216; Online Registration Abandon = 83217;
            // Candidate ID Generation = 9593; Email Consents = 84057; Explicit = 82031; Implicit = 82032; Emma Manual Unsubscribe = 88858; Adding and Updating = 9609; Comparing = 9610;
            // File Generation = 11059; Results = 11060; Flat Data = 82928; Backfeed = 59036; User Associations = 83142; Activity Report = 83791; Tracking Imports = 88801;
            // My Templates = 807;

            // Data Folder ID's - SBX
            // Data View = 102133; Data Feeds = 102118; DE folder = 99425; Exclusion = 102135; Journey Builder = 102140; Processing = 102134; CASL = 102196; 
            // Nightly Candidate RP Process = 102195; VOC = 102197; Appointment Confirmation = 102170; Appointment Reminder = 102171; Appointment Survey Resend = 102172; 
            // Connector - Booked = 102168; Connector - December = ; Connector - January = 102176; Connector - November = ; Connector - October = ; Connector - September EDGE = ;
            // Connector - September Prep = ; Connector - Tested = 102162; Enrolled Welcome = 102163; Handraiser = 102164; Inquiry Connector and NonConnector = 102165;
            // Online Registration Abandon = 102166; Candidate ID Generation = 102194; Email Consents = 102206; Explicit = 102204; Implicit = 102205; Emma Manual Unsubscribe = 102198;
            // Adding and Updating = 102207; Comparing = 102208; File Generation = 102209; Results = 102210; Flat Data = 102256; Backfeed = 102257; User Associations = 102258;
            // Activity Report = 102259; Tracking Imports = 102260; My Templates = 99398;

            APIObject[] dataFolders = { };
            List<APIObject> dataFoldersByParent = new List<APIObject>();
            APIObject[] dataFoldersByParentArray = { }; 
            APIObject[] dataExts = { };
            APIObject[] dataExtensionFields = { };
            APIObject[] propertyDefs = { };
            APIObject[] automations = { };
            APIObject[] roles = { };
            APIObject[] templates = { };

            using (SoapClient soapProd = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsername, ConfigSettings.ETPassword))
            {
                // soapProd.Close(); -- when using 'using' - no need to use soapProd.Close()
                Console.WriteLine("Env: Prod\n");

                //Describe APIObjects
                //Describer.DescribeAPIObjects(soapProd);

                // Perform Export
                //ExportFromProd.PerformExport(soapProd);

                //----------------------------------------------------------------------------------
                // Data Folders
                //DataFolderUtil.GetDataFolderByName(soapProd, "My Templates");

                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);

                //foreach (DataFolder df in dataFolders)
                //{
                //    if (df.ParentFolder.ID == 11058)
                //    {
                //        dataFoldersByParent.Add(df);
                //    }
                //}

                //dataFoldersByParentArray = dataFoldersByParent.ToArray();
                //Console.WriteLine("Num Data Folder By Parent ID: " + dataFoldersByParentArray.Length);

                //---------------------------------------------------------------------------------
                // Save Data Folders

                //foreach (DataFolder df in dataFolders)
                //{
                //    JSONUtil.saveDataFolderToJSON(df);
                //}

                //Console.WriteLine("...");
                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Data Extensions
                //DataFolderUtil.GetDataFolderByName(soapProd, "Exclusion");
                //dataExts = DataExtensionUtil.GetAllDataExtensionsByCategoryID(soapProd, 88801);
                //Console.WriteLine("Num DE's: " + dataExts.Length);

                //foreach (DataExtension de in dataExts)
                //{
                //    de.Fields = (DataExtensionField[])DataExtensionFieldsUtil.GetDataExtensionFieldsByDECustomerKey(soapProd, de);
                //}

                //Console.WriteLine("...");
                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Profile Attributes
                //propertyDefs = PropertyDefinitionUtil.GetAllPropertyDefinitions(soapProd);

                //---------------------------------------------------------------------------------
                // Automations
                //automations = AutomationUtil.GetAutomationByCustomerKey(soapProd, "b7e0de14-bee8-415b-49bc-60c2d57509b8");
                //AutomationTaskUtil.GetAutomationTasksByAutomation(soapProd);

                //---------------------------------------------------------------------------------
                // Roles
                //roles = RoleUtil.GetUserRoleByName(soapProd, "FranchiseeUser"); // SBX is not currently configured to allow Role creation.

                // Templates
                //templates = TemplateUtil.GetAllTemplates(soapProd);
                templates = TemplateUtil.GetTemplateByCategoryId(soapProd, 807);

                foreach (Template template in templates)
                {
                    Console.WriteLine("Template: " + template.TemplateName);
                    //JSONUtil.saveTemplateToJSON(template);
                }

                Console.ReadLine();
            }

            using (SoapClient soapSbx = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsernameSbx, ConfigSettings.ETPasswordSbx))
            {
                Console.WriteLine("Env: Sbx\n");
                //--------------------------------------------------------------------------------------------

                //DataFolder df = new DataFolder();

                //foreach(DataFolder df2 in DataFolderUtil.GetDataFolderByName(soapSbx, "API Created Folder"))
                //{
                //    df = df2;
                //}

                //DataFolderUtil.UpdateDataFolder(soapSbx, df);

                //--------------------------------------------------------------------------------------------
                // Creating Data Feeds folder in SBX based on same folder in Prod
                //int counter = 0;
                //int fileCounter = 1;

                //foreach (DataFolder df in dataFolders)
                //{
                //    Console.WriteLine("File Count: " + fileCounter);
                //    //while (counter < 3)
                //    //{
                //    //if (df.ParentFolder.ID != 0)
                //    //if (!df.Name.StartsWith("_") && df.Client.ID == 7237980 && df.ParentFolder.ID != 0)
                //    if (df.Name.Equals("Data Feeds") && df.ID == 8455)
                //    {
                //        Console.WriteLine("Creating Data Folder: " + df.Name);
                //        Console.WriteLine("Data Folder Content Type: " + df.ContentType);
                //        DataFolderUtil.CreateDataFolderFromExistingInProd(soapSbx, df);
                //        counter++;
                //    }
                //    //}

                //    fileCounter++;
                //}

                //--------------------------------------------------------------------------------------------
                // Data Folders -- Create folders by Parent Folder ID
                //DataFolderUtil.GetDataFolderByName(soapSbx, "VOC");
                //foreach (DataFolder df in dataFoldersByParentArray)
                //{
                //    Console.WriteLine("Creating Data Folder: " + df.Name);
                //    DataFolderUtil.CreateDataFolderFromExistingInProdByParentFolderID(soapSbx, df, 102170);
                //}
                

                //--------------------------------------------------------------------------------------------
                // Creating Data Extensions in Data Feeds folder based on DE's in Prod
                //DataFolderUtil.GetDataFolderByName(soapSbx, "My Templates");
                //DataExtensionUtil.CreateDataExtensionsByParentFolderID(soapSbx, dataExts, 8455);
                //DataExtensionUtil.GetDataExtensionByName(soapSbx, "RPAreaOfInterest");

                //Console.WriteLine("Creating Data Extensions...");
                //Console.ReadLine();
                //foreach (DataExtension de in dataExts)
                //{
                //    DataExtensionUtil.CreateDataExtensionFromExistingInProd(soapSbx, de, 102260);
                //}

                //---------------------------------------------------------------------------------
                // Create Role
                //foreach (Role role in roles)
                //{
                //    RoleUtil.CreateRoleFromExistingInProd(soapSbx, role);    
                //}

                // Templates
                foreach (Template temp in templates)
                {
                    TemplateUtil.CreateTemplateFromExisting(soapSbx, temp, 99398);
                }
                
            }
            
        }
    }
}
