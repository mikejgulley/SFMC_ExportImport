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
                Console.WriteLine("Num Data Extensiones: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Data Extensions: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }


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

        public static void CreateDataExtensions(SoapClient soapClientIn, APIObject[] deArrayIn, APIObject[] deFieldsArrayIn)
        {
            String requestID = "";
            String status = "";
            int ctr = 0;

            foreach (DataExtensionField def in deFieldsArrayIn)
            {
                while (ctr < 10)
                {
                    Console.WriteLine(def.Name);
                    Console.WriteLine(def.FieldType);
                    Console.WriteLine(def.CustomerKey);
                    ctr++;
                }
            }

            //foreach (DataExtension de in deArrayIn)
            //{
            //    DataExtension dataExt = de;
            //    Console.WriteLine(dataExt.Name);
            //}

            //for (int i = 0; i < deArrayIn.Length; i++)
            for (int i = 0; i < 15; i++)
            {
                DataExtension dataExtSrc = (DataExtension) deArrayIn[i];
                DataExtension dataExtDest = new DataExtension();
                DataExtensionField[] defArraySrc = new DataExtensionField[] {};
                defArraySrc = dataExtSrc.Fields.ToArray();
                DataExtensionField[] defArrayDest = {};

                if (!dataExtSrc.Name.StartsWith("_") && !dataExtSrc.Name.Equals("CloudPages_DataExtension") && !dataExtSrc.Name.Equals("SocialPages_DataExtension")) // cannot copy system tables -- system tables names begin with an underscore
                {
                    int j = 0;
                    Console.WriteLine(dataExtSrc.Name);

                    // get columns from source DE
                    foreach (DataExtensionField defSrc in defArraySrc)
                    {
                        Console.WriteLine(defArraySrc[j]);
                        defArrayDest[j] = defArraySrc[j];
                        defArrayDest[j].DataType = defSrc.DataType;
                        j++;
                    }

                    // put columns into dest DE
                    dataExtDest.Fields = defArraySrc;

                    CreateResult[] aoResults = soapClientIn.Create(new CreateOptions(), new APIObject[] { dataExtDest }, out requestID, out status);
                    Console.WriteLine("Status: " + status);
                    Console.WriteLine("Request ID: " + requestID);
                }
            }
        }
    }
}
