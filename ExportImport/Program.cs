using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;
using System.Diagnostics;

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
            // My Templates = 807; Logs = 9559; 
            
            // Portfolio = 814; Activity Report Portfolio = 83756;
            // Build Your Own Portfolio = 10874; EDGE = 84124; Header Images = 10877; Prep = 85681; Promotional Graphics = 10876; Demo = 6291;
            // Letter Assets = 8230; Letter Template = 8229; Moved from Shared = 98804; Newsletter Assets = 8231; Subscription Center = 83023; Supporting = 9205; Connector = 12464
            // Campaign Archive (Parent = Connector) = 102948; Internal = 95621; Staging = 83291; Campaign Archive (Parent = Staging) = 103248; Segments = 8537; Triggered Emails = 8885;
            // User Initiated Send = 88894; Sylvan Source = 88895; Shared Data Extensions = 831;

            // Query = 833; Activity Report = 83902; Temp = 93590; Tracking Imports = 88862; Backfeed = 83572; Data Feeds = 9202; Data Views = 82915; Exclusion = 9588; Flat Data = 82929;
            // Journey Builder = 82919; 
            // Appointment Confirmation = 83624; Appointment Reminder = 83633; Appointment Survey Resend = 86030; Connector - Booked = 83431; Connector - December = 99372;
            // Connector - February = 103128; Connector - January = 101940; Connector - November = 95760; Connector - October = 93048; Connector - Sept - EDGE = 83438;
            // Connector - Sept - Prep = 83456; Connector - Tested = 83212; Enrollment - Welcome = 83223; Handraiser = 83440; Inquiry = 83450; Online Abandon = 83527; QA = 84582;
            // Processing = 9596; Candidate ID Generation = 9597; CASL = 10612; Email Consents = 84056; Explicit = 82809; Implicit = 82908; Emma Opt Out = 88861;
            // Nightly Candidate RP Process = 9598; Adding and Updating = 9605; Comparing = 9606; VOC = 83384; File Generation = 83385; Results = 83386; Triggered Send Reporting = 97686;
            // User Initiated Send = 88897; Sylvan Source = 88898;

            // My Contents = 810; Build Your Own = 10829; Archive = 88501; Body - Text Layouts = 88790; Announcements = 88791; EDGE = 88792; Partnership&Outreach = 88793; Prep = 88794; Tutoring = 88795;
            // Header Images = 88722; Announcements = 88726; EDGE = 88724; Partnership&Outreach = 88789; Prep = 88725; Tutoring = 88723; Needs Headers = 88901;
            // Demo = 6296; Journey = 81336; Offers = 81337; Letter = 8465; Logos = 7588; Newsletter = 8464; Seasonal = 81669; 2016-09 = 81714; Prep = 81971; Template = 83869;
            // Trigger Based = 7586; Appointment Confirmations and Reminders = 7587;

            // Shared Items = 817; Shared Contents = 821; Archive = 99646; Body-Blank Layouts = 88038;
            // Body-Text = 89100; Announcements = 89103; EDGE = 89105; Partnerships&Outreach = 89107; Prep = 89106; Tutoring = 89104;
            // Header Images = 89101; Announcements = 89108; EDGE = 89109; Holidays = 103698; Partnerships&Outreach = 89112; Prep = 89110; Tutoring = 89111;
            // Shared Portfolio = 818;

            // My Emails = 805; Trigger Emails = 8976;

            //-----------------------------------------------------------------------
            // Data Folder ID's - SBX
            // Data Views = 102133; Data Feeds = 102118; DE folder = 99425; Exclusion = 102135; Journey Builder = 102140; Processing = 102134; CASL = 102196; 
            // Nightly Candidate RP Process = 102195; VOC = 102197; Appointment Confirmation = 102170; Appointment Reminder = 102171; Appointment Survey Resend = 102172; 
            // Connector - Booked = 102168; Connector - December = 102175; Connector - January = 102176; Connector - November = 102174; Connector - October = 102173; Connector - September EDGE = 102167;
            // Connector - September Prep = 102169; Connector - Tested = 102162; Enrolled Welcome = 102163; Handraiser = 102164; Inquiry Connector and NonConnector = 102165;
            // Online Registration Abandon = 102166; Candidate ID Generation = 102194; Email Consents = 102206; Explicit = 102204; Implicit = 102205; Emma Manual Unsubscribe = 102198;
            // Adding and Updating = 102207; Comparing = 102208; File Generation = 102209; Results = 102210; Flat Data = 102256; Backfeed = 102257; User Associations = 102258;
            // Activity Report = 102259; Tracking Imports = 102260; My Templates = 99398; Logs = 102319;
            
            // Portfolio = 99405; Activity Report Portfolio = 102240;
            // Build Your Own Portfolio = 102241; EDGE = 102242; Header Images = 102243; Prep = 102244; Promotional Graphics = 102245; Demo = 102246;
            // Letter Assets = 102247; Letter Template = 102248; Moved from Shared = 102249; Newsletter Assets = 102250; Subscription Center = 102251; Supporting = 102252; Connector = 103723
            // Campaign Archive (Parent = Connector) = 103724; Internal = 103725; Staging = 103726; Campaign Archive (Parent = Staging) = 103727; Segments = 103747; Triggered Emails = 103748;
            // User Initiated Send = 103749; Sylvan Source = 103750; Shared Data Extensions = 99426;

            // Query = 99428; Activity Report = 103810; Temp = 103811; Tracking Imports = 103812; Backfeed = 103813; Data Feeds = 103814; Data Views = 103815; Exclusion = 103816; Flat Data = 103817;
            // Journey Builder = 103818; 
            // Appointment Confirmation = 103837; Appointment Reminder = 103853; Appointment Survey Resend = 103854; Connector - Booked = 103855; Connector - December = 103856;
            // Connector - February = 103857; Connector - January = 103858; Connector - November = 103859; Connector - October = 103860; Connector - Sept - EDGE = 103861; 
            // Connector - Sept - Prep = 103862; Connector - Tested = 103863; Enrollment - Welcome = 103864; Handraiser = 103865; Inquiry = 103866; Online Abandon = 103867; QA = 103868;
            // Processing = 103819; Candidate ID Generation = 103824; CASL = 103825; Email Consents = 103829; Explicit = 103830; Implicit = 103831; Emma Opt Out = 103826;
            // Nightly Candidate RP Process = 103827; Adding and Updating = 103832; Comparing = 103833; VOC = 103828; File Generation = 103834; Results = 103836; Triggered Send Reporting = 103821;
            // User Initiated Send = 103822; Sylvan Source = 103823;

            // My Contents = 99401; Build Your Own = 103936; Archive = 103948; Body - Text Layouts = 103949; Announcements = 103960; EDGE = 103961; Partnership&Outreach = 103962; Prep = 103964; Tutoring = 103965;
            // Header Images = 103950; Announcements = 103953; EDGE = 103954; Partnership&Outreach = 103956; Prep = 103957; Tutoring = 103958; Needs Headers = 103952;
            // Demo = 103930; Journey = 103937; Offers = 103947; Letter = 103935; Logos = 103933; Newsletter = 103934; Seasonal = 103938; 2016-09 = 103944; Prep = 103945; Template = 103939;
            // Trigger Based = 103932; Appointment Confirmations and Reminders = 103942;

            // Shared Items = 99408; Shared Contents = 99412; Archive = 103981; Body-Blank Layouts = 103982;
            // Body-Text = 103984; Announcements = 103986; EDGE = 103987; Partnerships&Outreach = 103988; Prep = 103989; Tutoring = 103990;
            // Header Images = 103985; Announcements = 103991; EDGE = 103992; Holidays = 103993; Partnerships&Outreach = 103995; Prep = 103996; Tutoring = 103997;
            // Shared Portfolio = 99409;

            // My Emails = 99396; Trigger Emails = 104091;

            int prodCatNum = 103127;
            int sbxCatNum = 104032;
            int prodPortCatNum = 818;
            int sbxPortCatNum = 99409;

            APIObject[] dataFolders = { };
            List<APIObject> dataFoldersByParent = new List<APIObject>();
            APIObject[] contentAreas = { };
            APIObject[] dataFoldersByParentArray = { }; 
            APIObject[] dataExts = { };
            APIObject[] dataExtensionFields = { };
            APIObject[] propertyDefs = { };
            APIObject[] automations = { };
            APIObject[] roles = { };
            APIObject[] templates = { };
            APIObject[] portItems = { };
            APIObject[] importDefs = { };
            APIObject[] queries = { };
            APIObject[] emails = { };
            string[] folderNames = { "Build Your Own", "Archive", "Body - Text Layouts", "Announcements", "EDGE", "Partnership&Outreach", "Prep", "Tutoring", 
                                       "Header Images", "Needs Headers", "Demo", "Journey", "Offers", "Letter", "Logos", "Newsletter", "Seasonal", "2016-09", 
                                       "Template", "Trigger Based", "Appointment Confirmations and Reminders" };

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
                //DataFolderUtil.GetDataFolderByName(soapProd, "My Emails");

                // Get All Folders By Name in Predefined Array
                //foreach (string currFolderName in folderNames)
                //{
                //    DataFolderUtil.GetDataFolderByName(soapProd, currFolderName);
                //}

                //DataFolderUtil.GetDataFolderByName(soapProd, "Tutoring", 89101);

                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);
                //dataFolders = DataFolderUtil.GetAllDataFoldersByParentFolderID(soapProd, 810);

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
                //DataFolderUtil.GetDataFolderByName(soapProd, "Shared Portfolio");
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
                //templates = TemplateUtil.GetTemplateByCategoryId(soapProd, 10880);

                //foreach (Template template in templates)
                //{
                //    Console.WriteLine("Template: " + template.TemplateName);
                //    //JSONUtil.saveTemplateToJSON(template);
                //}

                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Templates - PROD Retrieve ID's
                //templates = TemplateUtil.GetTemplateByCategoryId(soapProd, 807, "prod");

                //foreach (Template template in templates)
                //{
                //    Debug.WriteLine(String.Concat("Template: ", template.TemplateName, " - ID: ", template.ID));
                //    //JSONUtil.saveTemplateToJSON(template);
                //}

                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Portfolio
                //portItems = PortfolioUtil.GetAllPortfolioItemsByCategoryID(soapProd, prodPortCatNum);

                //---------------------------------------------------------------------------------
                // Import Defs
                //importDefs = ImportDefinitionUtil.GetAllImportDefinitions(soapProd);

                //---------------------------------------------------------------------------------
                // Query Definitions
                //queries = QueryDefinitionUtil.GetAllQueries(soapProd);

                //---------------------------------------------------------------------------------
                // Content Areas
                //contentAreas = ContentAreaUtil.GetAllContentAreas(soapProd);
                //contentAreas = ContentAreaUtil.GetAllContentAreasHavingCategoryNumber(soapProd);

                //---------------------------------------------------------------------------------
                // Emails
                emails = EmailUtil.GetAllEmailsByCategoryID(soapProd, 8976);
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

                // Get All Folders By Name in Predefined Array
                //foreach (string currFolderName in folderNames)
                //{
                //    DataFolderUtil.GetDataFolderByName(soapSbx, currFolderName);
                //}

                //DataFolderUtil.GetDataFolderByName(soapSbx, "Tutoring", 103985);


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
                //DataFolderUtil.GetDataFolderByName(soapSbx, "My Emails");
                //foreach (DataFolder df in dataFoldersByParentArray)
                //{
                //    Console.WriteLine("Creating Data Folder: " + df.Name);
                //    DataFolderUtil.CreateDataFolderFromExistingInProdByParentFolderID(soapSbx, df, 102170);
                //}

                //foreach (DataFolder df in dataFolders)
                //{
                //    DataFolderUtil.CreateDataFolderFromExistingInProd(soapSbx, df, 99401);
                //}
                

                //--------------------------------------------------------------------------------------------
                // Creating Data Extensions in Data Feeds folder based on DE's in Prod
                //DataFolderUtil.GetDataFolderByName(soapSbx, "Sylvan Source");

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
                //    TemplateUtil.CreateTemplateFromExisting(soapSbx, temp, 105018);
                //}

                //---------------------------------------------------------------------------------
                // Templates - SBX Retrieve ID's
                //templates = TemplateUtil.GetTemplateByCategoryId(soapSbx, 99398, "sbx");

                //foreach (Template template in templates)
                //{
                //    Debug.WriteLine(String.Concat("Template: ", template.TemplateName, " - ID: ", template.ID));
                //    //JSONUtil.saveTemplateToJSON(template);
                //}

                //Console.ReadLine();

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

                //foreach (ImportDefinition iDef in importDefs)
                //{
                //    ImportDefinitionUtil.CreateImportDefFromExisting(soapSbx, iDef);
                //}

                //---------------------------------------------------------------------------------
                // Query Definitions
                //QueryDefinitionUtil.CreateQuery(soapSbx);
                //QueryDefinitionUtil.CreateQueries(soapSbx, queries);

                //---------------------------------------------------------------------------------
                // Content Areas
                //foreach (ContentArea ca in contentAreas)
                //{
                //    ContentAreaUtil.CreateContentAreaFromExisting(soapSbx, ca);
                //}

                //---------------------------------------------------------------------------------
                // Emails
                foreach (Email currEmail in emails)
                {
                    //EmailUtil.CreateEmailFromExisting(soapSbx, currEmail);
                    EmailUtil.CreateEmailFromExisting(soapSbx, currEmail, 104091);
                }
            }
            
        }
    }
}
