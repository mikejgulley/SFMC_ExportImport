using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class SendDefintionUtil
    {
        // Apparently Send Definition is not a valid object type

        //public static void DescribeSendDefintion(SoapClient soapClientIn)
        //{
        //    string requestID;
        //    ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
        //    objDefs.ObjectType = "SendDefinition";

        //    ObjectDefinition[] definitions = soapClientIn.Describe(new ObjectDefinitionRequest[] { objDefs }, out requestID);

        //    foreach (ObjectDefinition od in definitions)
        //    {
        //        Console.WriteLine("***Object Name: " + od.ObjectType + "****");

        //        foreach (PropertyDefinition pd in od.Properties)
        //        {
        //            Console.WriteLine("  Property Name: " + pd.Name);
        //            Console.WriteLine("  IsRetrievable: " + pd.IsRetrievable.ToString() + "\n");
        //        }
        //        Console.WriteLine("");
        //    }

        //    Console.ReadLine();
        //}

        //public static APIObject[] GetAllSendDefinitions(SoapClient soapClientIn)
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

        //    rr.ObjectType = "SendDefinition";
        //    rr.Properties = new String[] { "FilterDefinition", "IsTestObject", "SalesForceObjectID", "Name", "Parameters",
        //        "List.ID", "SendDefinitionListType", "CustomObjectID", "DataSourceTypeID",
        //        "Client.ID", "PartnerKey", "PartnerKey", "CreatedDate", "ModifiedDate" };

        //    do
        //    {
        //        status = soapClientIn.Retrieve(rr, out requestID, out results);

        //        totalCount += results.Length;

        //        foreach (APIObject apiObject in results)
        //        {
        //            totalResultsList.Add(apiObject);
        //        }

        //        Console.WriteLine(status);
        //        Console.WriteLine("Num Send Definitions: " + totalCount);

        //        rr = new RetrieveRequest();
        //        rr.ContinueRequest = requestID;
        //    } while (status.Equals("MoreDataAvailable"));

        //    totalResults = totalResultsList.ToArray<APIObject>();
        //    Console.WriteLine("Total Send Definitions: " + totalResults.Length);

        //    Console.ReadLine();
        //    return totalResults;
        //}

        //public static SendDefinition GetSendDefinitionByID(SoapClient soapClientIn, string objectIDIn)
        //{
        //    String requestID;
        //    String status;
        //    APIObject[] results;
        //    SendDefinition sendDefinitionResult = new SendDefinition();

        //    SimpleFilterPart sfp = new SimpleFilterPart();
        //    sfp.Property = "SendDefinition.ObjectID";
        //    sfp.SimpleOperator = SimpleOperators.equals;
        //    sfp.Value = new String[] { objectIDIn };

        //    RetrieveRequest rr = new RetrieveRequest();

        //    ClientID clientID = new ClientID();
        //    clientID.ID = 7237980;
        //    clientID.IDSpecified = true;
        //    ClientID[] targetClientIDs = { clientID };
        //    rr.ClientIDs = targetClientIDs;
        //    rr.QueryAllAccounts = true;
        //    rr.QueryAllAccountsSpecified = true;

        //    rr.ObjectType = "SendDefinition";
        //    rr.Properties = new String[] { "FilterDefinition", "Name", "Parameters", "List", "SendDefinitionListType", "CustomerKey", "Client" };
        //    rr.Filter = sfp;

        //    status = soapClientIn.Retrieve(rr, out requestID, out results);
        //    Console.WriteLine(status);

        //    foreach (SendDefinition sDef in results)
        //    {
        //        Console.WriteLine("Send Definition Name: " + sDef.Name);
        //        sendDefinitionResult = sDef;
        //    }

        //    return sendDefinitionResult;
        //}

    }
}
