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
        }

        public static APIObject[] GetAllImportDefinitions(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "ImportDefinition";
            rr.Properties = new String[] { "Name", "ObjectID", "CustomerKey", "Description", "Client.ClientID1", 
                "FileSpec", "AllowErrors", "FieldMappingType", "FileType", "UpdateType", "MaxFileAge", 
                "MaxFileAgeScheduleOffset", "MaxImportFrequency", "DestinationObject.ID", "DestinationObject.ObjectID",
                "Notification.ResponseType", "Notification.ResponseAddress", "RetrieveFileTransferLocation.ObjectID", 
                "Delimiter", "HeaderLines", "EndOfLineRepresentation", "NullRepresentation", "StandardQuotedStrings",
                "DateFormattingLocale.LocaleCode"}; // Client.ClientID1 lets associate with BU

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Import Definitions: " + results.Length);

            Console.ReadLine();

            return results;
        }
    }
}
