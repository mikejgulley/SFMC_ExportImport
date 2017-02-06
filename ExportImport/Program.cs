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
            // Data Views = 82914; Data Feeds = 8455; DE folder = 830; Exclusion = 9218; Journey Builder = 82920; Processing = 9201; CASL = 10610; Nightly Candidate RP Process = 9595; 
            // VOC = 11058; Appointment Confirmation = 83625; Appointment Reminder = 83632; Appointment Survey Resend = 86029; Connector - Booked = 83432; Connector - December = 99370;
            // Connector - January = 101939; Connector - November = 95759; Connector - October = 93046; Connector - September EDGE = 83218; Connector - September Prep = 83457;
            // Connector - Tested = 83211; Enrolled Welcome = 83214; Handraiser = 83215; Inquiry Connector and NonConnector = 83216; Online Registration Abandon = 83217;
            // Candidate ID Generation = 9593; Email Consents = 84057; Explicit = 82031; Implicit = 82032; Emma Manual Unsubscribe = 88858; Adding and Updating = 9609; Comparing = 9610;
            // File Generation = 11059; Results = 11060; Flat Data = 82928; Backfeed = 59036; User Associations = 83142; Activity Report = 83791; Tracking Imports = 88801;
            // My Templates = 807; Logs = 9559; Portfolio = 814; Activity Report Portfolio = 83756;
            // Build Your Own Portfolio = 10874; EDGE = 84124; Header Images = 10877; Prep = 85681; Promotional Graphics = 10876; Demo = 6291;
            // Letter Assets = 8230; Letter Template = 8229; Moved from Shared = 98804; Newsletter Assets = 8231; Subscription Center = 83023; Supporting = 9205; Connector = 12464
            // Campaign Archive (Parent = Connector) = 102948; Internal = 95621; Staging = 83291; Campaign Archive (Parent = Staging) = 103248; Segments = 8537; Triggered Emails = 8885;
            // User Initiated Send = 88894; Sylvan Source = 88895; Shared Data Extensions = 831;

            // Data Folder ID's - SBX
            // Data Views = 102133; Data Feeds = 102118; DE folder = 99425; Exclusion = 102135; Journey Builder = 102140; Processing = 102134; CASL = 102196; 
            // Nightly Candidate RP Process = 102195; VOC = 102197; Appointment Confirmation = 102170; Appointment Reminder = 102171; Appointment Survey Resend = 102172; 
            // Connector - Booked = 102168; Connector - December = 102175; Connector - January = 102176; Connector - November = 102174; Connector - October = 102173; Connector - September EDGE = 102167;
            // Connector - September Prep = 102169; Connector - Tested = 102162; Enrolled Welcome = 102163; Handraiser = 102164; Inquiry Connector and NonConnector = 102165;
            // Online Registration Abandon = 102166; Candidate ID Generation = 102194; Email Consents = 102206; Explicit = 102204; Implicit = 102205; Emma Manual Unsubscribe = 102198;
            // Adding and Updating = 102207; Comparing = 102208; File Generation = 102209; Results = 102210; Flat Data = 102256; Backfeed = 102257; User Associations = 102258;
            // Activity Report = 102259; Tracking Imports = 102260; My Templates = 99398; Logs = 102319; Portfolio = 99405; Activity Report Portfolio = 102240;
            // Build Your Own Portfolio = 102241; EDGE = 102242; Header Images = 102243; Prep = 102244; Promotional Graphics = 102245; Demo = 102246;
            // Letter Assets = 102247; Letter Template = 102248; Moved from Shared = 102249; Newsletter Assets = 102250; Subscription Center = 102251; Supporting = 102252; Connector = 103723
            // Campaign Archive (Parent = Connector) = 103724; Internal = 103725; Staging = 103726; Campaign Archive (Parent = Staging) = 103727; Segments = 103747; Triggered Emails = 103748;
            // User Initiated Send = 103749; Sylvan Source = 103750; Shared Data Extensions = 99426; 

            int prodCatNum = 831;
            int sbxCatNum = 99426;
            int prodPortCatNum = 9205;
            int sbxPortCatNum = 102252;

            APIObject[] dataFolders = { };
            List<APIObject> dataFoldersByParent = new List<APIObject>();
            APIObject[] dataFoldersByParentArray = { }; 
            APIObject[] dataExts = { };
            APIObject[] dataExtensionFields = { };
            APIObject[] propertyDefs = { };
            APIObject[] automations = { };
            APIObject[] roles = { };
            APIObject[] templates = { };
            APIObject[] portItems = { };
            APIObject[] importDefs = { };

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
                //DataFolderUtil.GetDataFolderByName(soapProd, "Segments");

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
                //DataFolderUtil.GetDataFolderByName(soapProd, "Shared Data Extensions");
                //dataExts = DataExtensionUtil.GetAllDataExtensionsByCategoryID(soapProd, prodCatNum);
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

                //---------------------------------------------------------------------------------
                // Templates
                //templates = TemplateUtil.GetAllTemplates(soapProd);
                //templates = TemplateUtil.GetTemplateByCategoryId(soapProd, 807);

                //foreach (Template template in templates)
                //{
                //    Console.WriteLine("Template: " + template.TemplateName);
                //    //JSONUtil.saveTemplateToJSON(template);
                //}

                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Portfolio
                //portItems = PortfolioUtil.GetAllPortfolioItemsByCategoryID(soapProd, prodPortCatNum);

                //---------------------------------------------------------------------------------
                // Import Defs
                importDefs = ImportDefinitionUtil.GetAllImportDefinitions(soapProd);
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
                //DataFolderUtil.GetDataFolderByName(soapSbx, "Staging");
                //foreach (DataFolder df in dataFoldersByParentArray)
                //{
                //    Console.WriteLine("Creating Data Folder: " + df.Name);
                //    DataFolderUtil.CreateDataFolderFromExistingInProdByParentFolderID(soapSbx, df, 102170);
                //}
                

                //--------------------------------------------------------------------------------------------
                // Creating Data Extensions in Data Feeds folder based on DE's in Prod
                //DataFolderUtil.GetDataFolderByName(soapSbx, "Shared Data Extensions");

                //Console.WriteLine("Creating Data Extensions...");
                //foreach (DataExtension de in dataExts)
                //{
                //    DataExtensionUtil.CreateDataExtensionFromExistingInProd(soapSbx, de, sbxCatNum);
                //}
                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Create Role
                //foreach (Role role in roles)
                //{
                //    RoleUtil.CreateRoleFromExistingInProd(soapSbx, role);    
                //}

                //---------------------------------------------------------------------------------
                // Templates
                //foreach (Template temp in templates)
                //{
                //    TemplateUtil.CreateTemplateFromExisting(soapSbx, temp, 99398);
                //}

                //---------------------------------------------------------------------------------
                // Portfolio
                //foreach (Portfolio port in portItems)
                //{
                //    PortfolioUtil.CreatePortfolioItemFromExisting(soapSbx, port, sbxPortCatNum);
                //}

                //---------------------------------------------------------------------------------
                // Import Definitions
                //int counter = 0;

                //foreach (ImportDefinition iDef in importDefs)
                //{
                //    while (counter < 1)
                //    {
                //        ImportDefinitionUtil.CreateImportDefFromExisting(soapSbx, iDef);
                //        counter++;   
                //    }
                //    break;
                //}

                foreach (ImportDefinition iDef in importDefs)
                {
                    ImportDefinitionUtil.CreateImportDefFromExisting(soapSbx, iDef);
                }
            }
            
        }
    }
}
