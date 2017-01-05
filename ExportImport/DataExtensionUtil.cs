using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;

namespace ExportImport
{
    class DataExtensionUtil
    {
        public static void DescribeDataExtensions(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            //objDefs.ObjectType = "DataExtensionField";
            objDefs.ObjectType = "DataExtension";

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

        public static APIObject[] GetAllDataExtensions(SoapClient soapClientIn) 
        {
            String requestID;
            String status;
            APIObject[] results;
            APIObject[] totalResults = { new APIObject() };
            List<APIObject> totalResultsList = new List<APIObject>();
            int totalCount = 0;

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "DataExtension"; // the DataExtensionObject is the actual record in the DE
            rr.Properties = new String[] { "ObjectID", "PartnerKey", "CustomerKey", "Name", "CreatedDate", "ModifiedDate", "Client.ID",
                "Description", "IsSendable", "IsTestable", "SendableDataExtensionField.Name", "SendableSubscriberField.Name", "Template.CustomerKey",
                "CategoryID", "Status", "DataRetentionPeriodLength", "DataRetentionPeriodUnitOfMeasure", "RowBasedRetention",
                "ResetRetentionPeriodOnImport", "DeleteAtEndOfRetentionPeriod", "RetainUntil" };
                // including "DataRetentionPeriod" in props causes error. ("Must specify valid information for parsing in the string")
                // including "IsPlatformObject", makes Name come back Null

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Data Extensions: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Data Extensions: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static APIObject[] GetAllDataExtensionsByCategoryID(SoapClient soapClientIn, int categoryIdIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            APIObject[] totalResults = { new APIObject() };
            List<APIObject> totalResultsList = new List<APIObject>();
            int totalCount = 0;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "CategoryID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { categoryIdIn.ToString() };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "DataExtension"; // the DataExtensionObject is the actual record in the DE
            rr.Properties = new String[] { "ObjectID", "PartnerKey", "CustomerKey", "Name", "CreatedDate", "ModifiedDate", "Client.ID",
                "Description", "IsSendable", "IsTestable", "SendableDataExtensionField.Name", "SendableSubscriberField.Name", "Template.CustomerKey",
                "CategoryID", "Status", "DataRetentionPeriodLength", "DataRetentionPeriodUnitOfMeasure", "RowBasedRetention",
                "ResetRetentionPeriodOnImport", "DeleteAtEndOfRetentionPeriod", "RetainUntil" };
            // including "DataRetentionPeriod" in props causes error. ("Must specify valid information for parsing in the string")
            // including "IsPlatformObject", makes Name come back Null
            rr.Filter = sfp;

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Data Extensions: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Data Extensions: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static APIObject[] GetDataExtensionByName(SoapClient soapClientIn, string nameIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            APIObject[] totalResults = { new APIObject() };
            List<APIObject> totalResultsList = new List<APIObject>();
            int totalCount = 0;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "Name";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { nameIn };

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7294703; // 7294703 = SBX; 7237980 = Prod
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "DataExtension"; // the DataExtensionObject is the actual record in the DE
            rr.Properties = new String[] { "ObjectID", "PartnerKey", "CustomerKey", "Name", "CreatedDate", "ModifiedDate", "Client.ID",
                "Description", "IsSendable", "IsTestable", "SendableDataExtensionField.Name", "SendableSubscriberField.Name", "Template.CustomerKey",
                "CategoryID", "Status", "DataRetentionPeriodLength", "DataRetentionPeriodUnitOfMeasure", "RowBasedRetention",
                "ResetRetentionPeriodOnImport", "DeleteAtEndOfRetentionPeriod", "RetainUntil" };
            // including "DataRetentionPeriod" in props causes error. ("Must specify valid information for parsing in the string")
            // including "IsPlatformObject", makes Name come back Null
            rr.Filter = sfp;

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                foreach (DataExtension de in results)
                {
                    Console.WriteLine("Data Extension Name: " + de.Name);
                    Console.WriteLine("Data Extension Category ID: " + de.CategoryID);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num Data Extensions: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Data Extensions: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        //public static APIObject[] GetAllSharedDataExtensions(SoapClient soapClientIn)
        //{
        //    String requestID;
        //    String status;
        //    APIObject[] results;
        //    APIObject[] totalResults = { new APIObject() };
        //    List<APIObject> totalResultsList = new List<APIObject>();
        //    int totalCount = 0;

        //    RetrieveRequest rr = new RetrieveRequest();

        //    ClientID clientID = new ClientID();
        //    clientID.ID = 7237980;
        //    clientID.IDSpecified = true;
        //    ClientID[] targetClientIDs = { clientID };
        //    rr.ClientIDs = targetClientIDs;
        //    rr.QueryAllAccounts = true;
        //    rr.QueryAllAccountsSpecified = true;

        //    rr.ObjectType = "DataExtension"; // the DataExtensionObject is the actual record in the DE
        //    rr.Properties = new String[] { "ObjectID", "PartnerKey", "CustomerKey", "Name", "CreatedDate", "ModifiedDate", "Client.ID",
        //        "Description", "IsSendable", "IsTestable", "SendableDataExtensionField.Name", "SendableSubscriberField.Name", "Template.CustomerKey",
        //        "CategoryID", "Status", "DataRetentionPeriodLength", "DataRetentionPeriodUnitOfMeasure", "RowBasedRetention",
        //        "ResetRetentionPeriodOnImport", "DeleteAtEndOfRetentionPeriod", "RetainUntil" };
        //    // including "DataRetentionPeriod" in props causes error. ("Must specify valid information for parsing in the string")
        //    // including "IsPlatformObject", makes Name come back Null

        //    do
        //    {
        //        status = soapClientIn.Retrieve(rr, out requestID, out results);

        //        totalCount += results.Length;

        //        foreach (APIObject apiObject in results)
        //        {
        //            totalResultsList.Add(apiObject);
        //        }

        //        Console.WriteLine(status);
        //        Console.WriteLine("Num Data Extensiones: " + totalCount);

        //        rr = new RetrieveRequest();
        //        rr.ContinueRequest = requestID;
        //    } while (status.Equals("MoreDataAvailable"));

        //    totalResults = totalResultsList.ToArray<APIObject>();
        //    Console.WriteLine("Total Data Extensions: " + totalResults.Length);

        //    Console.ReadLine();

        //    return totalResults;
        //}


        //public static APIObject[] GetDataExtensionFolderByParentFolderCustomerKey
        //    (SoapClient soapClientIn, DataExtension deIn)
        //{
        //    Console.WriteLine("Current DE Name: " + deIn.Name);

        //    String requestID;
        //    String status;
        //    APIObject[] results;

        //    SimpleFilterPart sfp = new SimpleFilterPart();
        //    //sfp.Property = "ParentFolder.CustomerKey";
        //    sfp.Property = "CustomerKey";
        //    sfp.SimpleOperator = SimpleOperators.equals;
        //    sfp.Value = new String[] { deIn.CustomerKey };

        //    RetrieveRequest rr = new RetrieveRequest();

        //    rr.ObjectType = "DataFolder";
        //    rr.Properties = new String[] { "Name", "ObjectID", "CustomerKey" };
        //    rr.Filter = sfp;

        //    status = soapClientIn.Retrieve(rr, out requestID, out results);
        //    Console.WriteLine(status);
        //    Console.WriteLine("Num Data Folders: " + results.Length + "\n");

        //    foreach (DataFolder df in results)
        //    {
        //        Console.WriteLine("Data Folder Name: " + df.Name);
        //    }

        //    return results;
        //}

        //public static void CreateDataExtensions(SoapClient soapClientIn, APIObject[] deArrayIn, APIObject[] deFieldsArrayIn)
        //{
        //    String requestID = "";
        //    String status = "";
        //    int ctr = 0;

        //    foreach (DataExtensionField def in deFieldsArrayIn)
        //    {
        //        while (ctr < 10)
        //        {
        //            Console.WriteLine(def.Name);
        //            Console.WriteLine(def.FieldType);
        //            Console.WriteLine(def.CustomerKey);
        //            ctr++;
        //        }
        //    }

        //    //foreach (DataExtension de in deArrayIn)
        //    //{
        //    //    DataExtension dataExt = de;
        //    //    Console.WriteLine(dataExt.Name);
        //    //}

        //    //for (int i = 0; i < deArrayIn.Length; i++)
        //    for (int i = 0; i < 15; i++)
        //    {
        //        DataExtension dataExtSrc = (DataExtension)deArrayIn[i];
        //        DataExtension dataExtDest = new DataExtension();
        //        DataExtensionField[] defArraySrc = new DataExtensionField[] { };
        //        defArraySrc = dataExtSrc.Fields.ToArray();
        //        DataExtensionField[] defArrayDest = { };

        //        if (!dataExtSrc.Name.StartsWith("_") && !dataExtSrc.Name.Equals("CloudPages_DataExtension") && !dataExtSrc.Name.Equals("SocialPages_DataExtension")) // cannot copy system tables -- system tables names begin with an underscore
        //        {
        //            int j = 0;
        //            Console.WriteLine(dataExtSrc.Name);

        //            // get columns from source DE
        //            foreach (DataExtensionField defSrc in defArraySrc)
        //            {
        //                Console.WriteLine(defArraySrc[j]);
        //                defArrayDest[j] = defArraySrc[j];
        //                defArrayDest[j].DataType = defSrc.DataType;
        //                j++;
        //            }

        //            // put columns into dest DE
        //            dataExtDest.Fields = defArraySrc;

        //            CreateResult[] aoResults = soapClientIn.Create(new CreateOptions(), new APIObject[] { dataExtDest }, out requestID, out status);
        //            Console.WriteLine("Status: " + status);
        //            Console.WriteLine("Request ID: " + requestID);
        //        }
        //    }
        //}

        //public static void CreateDataExtensionsByFolderName(SoapClient soapClientIn, APIObject[] deArrayIn, string folderNameIn)
        //{
        //    String requestID = "";
        //    String status = "";

        //    foreach (DataExtension de in deArrayIn)
        //    {
        //        if (de.CategoryID == 8455) // 8455 = CategoryID in Prod for Data Feeds folder
        //        {
        //            DataExtension dataExtSrc = de;
        //            DataExtension dataExtDest = new DataExtension();
        //            DataExtensionField[] defArraySrc = new DataExtensionField[] { };
        //            defArraySrc = dataExtSrc.Fields.ToArray();
        //            DataExtensionField[] defArrayDest = { };

        //            if (!dataExtSrc.Name.StartsWith("_") && !dataExtSrc.Name.Equals("CloudPages_DataExtension") && !dataExtSrc.Name.Equals("SocialPages_DataExtension")) // cannot copy system tables -- system tables names begin with an underscore
        //            {
        //                int j = 0;
        //                Console.WriteLine(dataExtSrc.Name);

        //                // get columns from source DE
        //                foreach (DataExtensionField defSrc in defArraySrc)
        //                {
        //                    Console.WriteLine(defArraySrc[j]);
        //                    defArrayDest[j] = defArraySrc[j];
        //                    defArrayDest[j].DataType = defSrc.DataType;
        //                    j++;
        //                }

        //                // put columns into dest DE
        //                dataExtDest.Fields = defArraySrc;

        //                CreateResult[] aoResults = soapClientIn.Create(new CreateOptions(), new APIObject[] { dataExtDest }, out requestID, out status);
        //                Console.WriteLine("Status: " + status);
        //                Console.WriteLine("Request ID: " + requestID);
        //            }
        //        }
        //    }
        //}

        public static void CreateDataExtensionsByParentFolderID(SoapClient soapClientIn, APIObject[] deArrayIn, int prodCatIdIn)
        {
            String requestID = "";
            String status = "";

            foreach (DataExtension de in deArrayIn)
            {
                if (de.CategoryID == prodCatIdIn)
                {
                    DataExtension dataExtSrc = de;
                    DataExtension dataExtDest = dataExtSrc;
                    dataExtDest.CategoryID = 102047;
                    dataExtDest.Client.ID = 7294703;


                    if (!dataExtSrc.Name.StartsWith("_") && !dataExtSrc.Name.Equals("CloudPages_DataExtension") && !dataExtSrc.Name.Equals("SocialPages_DataExtension")) // cannot copy system tables -- system tables names begin with an underscore
                    {
                        CreateResult[] results = soapClientIn.Create(new CreateOptions(), new APIObject[] { dataExtDest }, out requestID, out status);
                        Console.WriteLine("Status: " + status);
                        Console.WriteLine("Request ID: " + requestID);
                    }
                }
            }
        }

        public static void CreateDataExtensionFromExistingInProd(SoapClient soapClientIn, DataExtension deIn, int catIdIn)
        {
            Console.WriteLine("Entering CreateDataExtensionFromExistingInProd()...");
            String requestID;
            String status;

            DataExtension de = new DataExtension();
            //DataExtension de = deIn;
            de.CategoryID = catIdIn; // 102118 = Data Feeds folder in SBX; 99425 = DE folder in SBX;
            de.CategoryIDSpecified = true;
            //de.Client.ID = deIn.Client.ID;
            //de.Client.IDSpecified = deIn.Client.IDSpecified;
            de.Client = new ClientID();
            de.Client.ID = 7294703;
            de.CorrelationID = deIn.CorrelationID;
            de.CreatedDate = deIn.CreatedDate;
            de.CreatedDateSpecified = deIn.CreatedDateSpecified;
            de.CustomerKey = deIn.CustomerKey;
            de.DataRetentionPeriod = deIn.DataRetentionPeriod;
            de.DataRetentionPeriodLength = deIn.DataRetentionPeriodLength;
            de.DataRetentionPeriodLengthSpecified = deIn.DataRetentionPeriodLengthSpecified;
            de.DataRetentionPeriodUnitOfMeasure = deIn.DataRetentionPeriodUnitOfMeasure;
            de.DataRetentionPeriodUnitOfMeasureSpecified = deIn.DataRetentionPeriodUnitOfMeasureSpecified;
            de.DeleteAtEndOfRetentionPeriod = deIn.DeleteAtEndOfRetentionPeriod;
            de.DeleteAtEndOfRetentionPeriodSpecified = deIn.DeleteAtEndOfRetentionPeriodSpecified;
            de.Description = deIn.Description;
            de.Fields = deIn.Fields;
            //de.ID = deIn.ID; // Read-only
            de.IsSendable = deIn.IsSendable;
            de.IsSendableSpecified = deIn.IsSendableSpecified;
            de.IsTestable = de.IsTestable;
            de.IsTestableSpecified = deIn.IsTestableSpecified;
            de.ModifiedDate = deIn.ModifiedDate;
            de.ModifiedDateSpecified = deIn.ModifiedDateSpecified;
            de.Name = deIn.Name;
            //de.ObjectID = deIn.ObjectID; // Read-only, system-controlled
            de.ObjectState = deIn.ObjectState;
            de.PartnerKey = deIn.PartnerKey;
            de.PartnerProperties = deIn.PartnerProperties;
            de.ResetRetentionPeriodOnImport = deIn.ResetRetentionPeriodOnImport;
            de.ResetRetentionPeriodOnImportSpecified = deIn.ResetRetentionPeriodOnImportSpecified;
            de.RetainUntil = deIn.RetainUntil;
            de.RowBasedRetention = deIn.RowBasedRetention;
            de.RowBasedRetentionSpecified = deIn.RowBasedRetentionSpecified;
            de.SendableDataExtensionField = new DataExtensionField();
            de.SendableDataExtensionField = deIn.SendableDataExtensionField;
            if (de.IsSendable == true)
            {
                de.SendableSubscriberField = new ExportImport.PartnerAPI.Attribute();
                de.SendableSubscriberField.Compression = deIn.SendableSubscriberField.Compression;
                if (deIn.SendableSubscriberField.Name == "_SubscriberKey")
                {
                    de.SendableSubscriberField.Name = "Subscriber Key";
                }
                if (deIn.SendableSubscriberField.Name == "EmailAddress")
                {
                    de.SendableSubscriberField.Name = "Email Address";
                }
                de.SendableSubscriberField.Value = deIn.SendableSubscriberField.Value;
            }
            //de.Status = deIn.Status; // "none" is an invalid status
            de.Template = deIn.Template;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { de }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Data Extension Name: " + de.Name);
            Console.WriteLine("Exiting CreateDataExtensionFromExistingInProd()...\n");
        }
    }
}
