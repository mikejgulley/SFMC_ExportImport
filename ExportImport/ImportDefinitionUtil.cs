using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class ImportDefinitionUtil
    {
        public static void DescribeImport(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "ImportDefinition";

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

        public static APIObject[] GetAllImportDefinitions(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;
            List<APIObject> filteredResults = new List<APIObject>();

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "ImportDefinition";
            rr.Properties = new String[] { "Name", "ObjectID", "CustomerKey", "Description", "Client.ClientID1", 
                "FileSpec", "AllowErrors", "FieldMappingType", "FileType", "UpdateType", "MaxFileAge", 
                "MaxFileAgeScheduleOffset", "MaxImportFrequency", "DestinationObject.ID", "DestinationObject.ObjectID",
                "Notification.ResponseType", "Notification.ResponseAddress", "RetrieveFileTransferLocation.ObjectID", 
                "Delimiter", "HeaderLines", "EndOfLineRepresentation", "NullRepresentation", "StandardQuotedStrings",
                "DateFormattingLocale.LocaleCode" }; // Client.ClientID1 lets associate with BU // "FieldMap"/"Field Maps" not retrievable -> throws error

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Import Definitions: " + results.Length);

            foreach (ImportDefinition iDef in results)
            {
                Guid guidOutput;
                bool isGuid = Guid.TryParse(iDef.Name, out guidOutput);
                if (!isGuid)
                {
                    filteredResults.Add(iDef);
                }
            }

            results = filteredResults.ToArray();

            Console.WriteLine("Num Filtered Import Definitions: " + results.Length);

            Console.ReadLine();

            return results;
        }

        // This will never work since we cannot retrieve Field Maps from the Import Definition object. API limitation.
        public static void CreateImportDefFromExisting(SoapClient soapClientIn, ImportDefinition iDefIn)
        {
            Console.WriteLine("Entering CreateImportDefinitionFromExisting()...\n");

            String requestID;
            String status;

            ImportDefinition id = new ImportDefinition();
            id.Name = iDefIn.Name;
            id.CustomerKey = iDefIn.CustomerKey;
            //Optional
            id.AllowErrors = iDefIn.AllowErrors;
            id.AllowErrorsSpecified = iDefIn.AllowErrorsSpecified;

            //Associate Data-Extension to Import-Defintion   
            //DataExtension de = new DataExtension();
            //de.CustomerKey = "810f461c-231a-440a-8543-837460be6c7a";//required //The External Key of the Data Extension to import into
            //de = (DataExtension) iDefIn.DestinationObject;
            id.DestinationObject = iDefIn.DestinationObject;
            id.DestinationObject.ID = iDefIn.DestinationObject.ID;
            id.DestinationObject.IDSpecified = iDefIn.DestinationObject.IDSpecified;

            //Specify the notification type //optional
            id.Notification = new AsyncResponse();
            id.Notification = iDefIn.Notification;
            id.Notification.ResponseType = iDefIn.Notification.ResponseType;
            id.Notification.ResponseAddress = iDefIn.Notification.ResponseAddress;

            //Specify the File Transfer Location
            id.RetrieveFileTransferLocation = new FileTransferLocation();
            id.RetrieveFileTransferLocation = iDefIn.RetrieveFileTransferLocation;
            id.RetrieveFileTransferLocation.CustomerKey = iDefIn.RetrieveFileTransferLocation.CustomerKey;//required

            //Optional
            id.UpdateType = iDefIn.UpdateType;
            id.UpdateTypeSpecified = iDefIn.UpdateTypeSpecified;

            //Map fields
            id.FieldMappingType = iDefIn.FieldMappingType;//required
            id.FieldMappingTypeSpecified = iDefIn.FieldMappingTypeSpecified;
            FieldMap[] fMap = { };
            id.FieldMaps = fMap;

            if (iDefIn.FieldMaps != null)
            {
                id.FieldMaps = iDefIn.FieldMaps;

                for (int i = 0; i < iDefIn.FieldMaps.Length; i++)
                {
                    id.FieldMaps[i] = new FieldMap();
                    id.FieldMaps[i].DestinationName = iDefIn.FieldMaps[i].DestinationName;
                    id.FieldMaps[i].Item = iDefIn.FieldMaps[i].Item;
                }
            } else {
                id.FieldMaps = null;
            }

            //Specify the File naming Specifications
            id.FileSpec = iDefIn.FileSpec;

            //Specify the FileType
            id.FileType = iDefIn.FileType;//required
            id.FileTypeSpecified = iDefIn.FileTypeSpecified;

            CreateResult[] cResults = soapClientIn.Create(new CreateOptions(), new APIObject[] { id }, out requestID, out status);

            foreach (CreateResult result in cResults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
            Console.WriteLine("Import Definition: " + id.Name);
            Console.WriteLine("Exiting CreateImportDefinitionFromExisting()...\n");
        }
    }
}
