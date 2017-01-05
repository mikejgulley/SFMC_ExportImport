using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;
using Newtonsoft.Json;

namespace ExportImport
{
    class DataFolderUtil
    {
        public static void DescribeDataFolders(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "DataFolder";

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

        public static APIObject[] GetAllDataFolders(SoapClient soapClientIn)
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

            rr.ObjectType = "DataFolder";
            rr.Properties = new String[] { "ID", "Client.ID", "ParentFolder.ID", "ParentFolder.CustomerKey", "ParentFolder.ObjectID", "ParentFolder.Name", 
                "ParentFolder.Description", "ParentFolder.ContentType", "ParentFolder.IsActive", "ParentFolder.IsEditable", "ParentFolder.AllowChildren", "Name",
                "Description", "ContentType", "IsActive", "IsEditable", "AllowChildren", "CreatedDate", "ModifiedDate", "Client.ModifiedBy", "ObjectID", "CustomerKey",
                "Client.EnterpriseID", "Client.CreatedBy" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Data Folders: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total Data Folders: " + totalResults.Length);

            Console.ReadLine();

            return totalResults;
        }

        public static APIObject[] GetDataFolderByName(SoapClient soapClientIn, string dataFolderNameIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            //APIObject result = new APIObject();

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "Name";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { dataFolderNameIn };

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "DataFolder";
            rr.Properties = new String[] { "Name", "Description", "ContentType", "ID", "ObjectID", "CustomerKey", 
                "ParentFolder.Name", "ParentFolder.Description", "ParentFolder.ContentType", "ParentFolder.ID", 
                "ParentFolder.ObjectID", "ParentFolder.CustomerKey" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Data Folders: " + results.Length);

            foreach (DataFolder df in results)
            {
                Console.WriteLine("Data Folder Name: " + df.Name);
                Console.WriteLine("Data Folder ID: " + df.ID);
                Console.WriteLine("Data Folder Parent Folder ID: " + df.ParentFolder.ID);
            }
            

            //int counter = 0;
            //foreach(APIObject apiObject in results)
            //{
            //    while (counter > 1) 
            //    {
            //        result = apiObject;
            //        counter++;
            //    }
                
            //}

            //rr = new RetrieveRequest();
            //rr.ContinueRequest = requestID;

            Console.ReadLine();

            return results;
        }

        public static APIObject[] GetAllDataFoldersByType(SoapClient soapClientIn, String typeIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "ContentType";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { typeIn };

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "DataFolder";
            rr.Properties = new String[] { "Name", "Description", "ContentType", "ID", "ObjectID", "CustomerKey", 
                "ParentFolder.Name", "ParentFolder.Description", "ParentFolder.ContentType", "ParentFolder.ID", 
                "ParentFolder.ObjectID", "ParentFolder.CustomerKey" };

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Data Folders of type: " + typeIn + " = " + results.Length);

            Console.ReadLine();

            return results;
        }

        public static APIObject[] GetDataFolderByDECategoryID
            (SoapClient soapClientIn, DataExtension deIn)
        {
            Console.WriteLine("Current DE Name: " + deIn.Name);

            String requestID;
            String status;
            APIObject[] results;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "ID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { deIn.CategoryID.ToString() };

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "DataFolder";
            rr.Properties = new String[] { "Name", "Description", "ContentType", "ID", "ObjectID", "CustomerKey", 
                "ParentFolder.Name", "ParentFolder.Description", "ParentFolder.ContentType", "ParentFolder.ID", 
                "ParentFolder.ObjectID", "ParentFolder.CustomerKey" };
            rr.Filter = sfp;

            status = soapClientIn.Retrieve(rr, out requestID, out results);
            Console.WriteLine(status);
            //Console.WriteLine("Num Data Folders: " + results.Length);

            foreach (DataFolder df in results)
            {
                Console.WriteLine("Data Folder Name: " + df.Name + "\n");
            }

            return results;
        }

        public static void CreateDataFolder(SoapClient soapClientIn)
        {
            String requestID;
            String status;

            DataFolder datafolder = new DataFolder();
            datafolder.Name = "API Created Folder 02";
            datafolder.Description = "API Created Folder 02";
            datafolder.ParentFolder = new DataFolder();
            datafolder.ParentFolder.ID = 99425; // This is the ID of the 'Data Extensions' folder that you can get from doing a retrieve 
            datafolder.ParentFolder.IDSpecified = true;
            datafolder.ContentType = "dataextension";
            datafolder.AllowChildren = true;
            datafolder.AllowChildrenSpecified = true;
            datafolder.IsEditable = true;
            datafolder.IsEditableSpecified = true;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { datafolder }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
        }

        public static void CreateDataFolderFromExistingInProd(SoapClient soapClientIn, DataFolder dataFolderIn)
        {
            String requestID;
            String status;

            DataFolder datafolder = new DataFolder();
            datafolder.Name = dataFolderIn.Name;
            datafolder.Description = dataFolderIn.Description;
            //datafolder.AllowChildren = dataFolderIn.AllowChildren;
            //datafolder.AllowChildrenSpecified = dataFolderIn.AllowChildrenSpecified;
            datafolder.AllowChildren = true;
            datafolder.AllowChildrenSpecified = true;
            datafolder.ContentType = dataFolderIn.ContentType;
            datafolder.ID = dataFolderIn.ID;
            datafolder.IsActive = dataFolderIn.IsActive;
            datafolder.IsActiveSpecified = dataFolderIn.IsActiveSpecified;
            //datafolder.IsEditable = dataFolderIn.IsEditable;
            //datafolder.IsEditableSpecified = dataFolderIn.IsEditableSpecified;
            datafolder.IsEditable = true;
            datafolder.IsEditableSpecified = true;
            datafolder.ParentFolder = dataFolderIn.ParentFolder;
            datafolder.ParentFolder.ID = 99425;
            datafolder.ParentFolder.IDSpecified = true;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { datafolder }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            //foreach (DataFolder df in cresults)
            //{
            //    Console.WriteLine("Creating Data Folder: " + df.Name);
            //    Console.WriteLine("Data Folder Content Type: " + df.ContentType);    
            //}

            Console.WriteLine(requestID + ": " + status);
        }

        public static void UpdateDataFolder(SoapClient soapClientIn, DataFolder dfIn) 
        {
            Console.WriteLine("Entering UpdateDataFolder()...");

            String requestID;
            String status;

            dfIn.AllowChildren = true;
            dfIn.AllowChildrenSpecified = true;
            dfIn.IsEditable = true;
            dfIn.IsEditableSpecified = true;

            UpdateResult[] cresults = soapClientIn.Update(new UpdateOptions(), new APIObject[] { dfIn }, out requestID, out status);
            foreach (UpdateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }
            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Exiting UpdateDataFolder()...");
        }

        public static void loadDataFolderFromJSON(string dfIn)
        {
            DataFolder df = (DataFolder)JsonConvert.DeserializeObject(dfIn);

            Console.WriteLine("DataFolder Name: " + df.Name);
            Console.WriteLine("DataFolder Parent Folder Name: " + df.ParentFolder.Name);
        }

        // CANNOT delete Data Folders via API
        //public static void DeleteDataFolder(SoapClient soapClientIn, string dataFolderNameIn)
        //{
        //    String requestID;
        //    String retrieveStatus;
        //    String deleteStatus;
        //    APIObject[] results;

        //    SimpleFilterPart sfp = new SimpleFilterPart();
        //    sfp.Property = "Name";
        //    sfp.SimpleOperator = SimpleOperators.equals;
        //    sfp.Value = new string[] { dataFolderNameIn };

        //    RetrieveRequest rr = new RetrieveRequest();

        //    rr.ObjectType = "DataFolder";
        //    rr.Properties = new String[] { "Name", "Description", "ContentType", "ID", "ObjectID", "CustomerKey", 
        //        "ParentFolder.Name", "ParentFolder.Description", "ParentFolder.ContentType", "ParentFolder.ID", 
        //        "ParentFolder.ObjectID", "ParentFolder.CustomerKey" };
        //    rr.Filter = sfp;

        //    retrieveStatus = soapClientIn.Retrieve(rr, out requestID, out results);

        //    foreach (DataFolder df in results)
        //    {
        //        if (df.Name.Equals(dataFolderNameIn))
        //        {
        //            DataFolder datafolder = new DataFolder();
        //            datafolder.Name = dataFolderNameIn;
        //            datafolder.ID = df.ID;

        //            DeleteResult[] dresults = soapClientIn.Delete(new DeleteOptions(), new APIObject[] { datafolder }, out requestID, out deleteStatus);

        //            foreach (DeleteResult result in dresults)
        //            {
        //                Console.WriteLine(result.StatusMessage);
        //            }

        //            Console.WriteLine(requestID + ": " + deleteStatus);
        //        }
        //    }
        //}
    }
}
