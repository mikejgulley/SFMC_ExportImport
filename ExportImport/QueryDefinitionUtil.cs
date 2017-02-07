using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class QueryDefinitionUtil
    {
        public static void DescribeQuery(SoapClient soapClientIn)
        {
            string requestID;

            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "QueryDefinition";

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

        public static APIObject[] GetAllQueries(SoapClient soapClientIn)
        {
            String requestID;
            String status;
            APIObject[] results;

            RetrieveRequest rr = new RetrieveRequest();

            ClientID clientID = new ClientID();
            clientID.ID = 7237980;
            clientID.IDSpecified = true;
            ClientID[] targetClientIDs = { clientID };
            rr.ClientIDs = targetClientIDs;
            rr.QueryAllAccounts = true;
            rr.QueryAllAccountsSpecified = true;

            rr.ObjectType = "QueryDefinition";
            rr.Properties = new String[] { "ObjectID", "Client.ID", "Name", "CustomerKey", 
                "Description", "QueryText", "TargetType", "DataExtensionTarget.Name", "DataExtensionTarget.CustomerKey", 
                "DataExtensionTarget.Description", "TargetUpdateType", "FileType", "FileSpec", "Status",
                "CreatedDate", "ModifiedDate", "CategoryID"};

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Queries: " + results.Length);

            Console.ReadLine();

            return results;
        }

        public static void CreateQuery(SoapClient soapClientIn)
        {
            String requestID;
            String status;

            QueryDefinition qd = new QueryDefinition();
            qd.Name = "API Created Query";
            qd.CustomerKey = "New Query Key32";
            qd.Description = "Some Description";
            qd.TargetUpdateType = "Overwrite";
            qd.TargetType = "DE";
            qd.QueryText = "Select * from [SocialPages_DataExtension]";

            InteractionBaseObject ibo = new InteractionBaseObject();
            ibo.CustomerKey = "FIRST SEND";
            ibo.Name = "First Send";
            
            qd.DataExtensionTarget = ibo;

            CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { qd }, out requestID, out status);

            foreach (CreateResult result in cresults)
            {
                Console.WriteLine(result.StatusMessage);
            }

            Console.WriteLine(requestID + ": " + status);
        }

        public static void CreateQueries(SoapClient soapClientIn, APIObject[] queryArrayIn)
        {
            String requestID;
            String status;

            foreach (QueryDefinition qdefIn in queryArrayIn)
            {
                QueryDefinition qd = new QueryDefinition();
                qd.Name = qdefIn.Name;
                qd.CustomerKey = qdefIn.CustomerKey;
                qd.Description = qdefIn.Description;
                qd.TargetUpdateType = qdefIn.TargetUpdateType;
                qd.TargetType = qdefIn.TargetType;
                qd.QueryText = qdefIn.QueryText;
                qd.DataExtensionTarget = qdefIn.DataExtensionTarget;
                qd.DataExtensionTarget.CustomerKey = qdefIn.DataExtensionTarget.CustomerKey;
                qd.DataExtensionTarget.Description = qdefIn.DataExtensionTarget.Description;
                qd.FileType = qdefIn.FileType;
                qd.FileSpec = qdefIn.FileSpec;
                //qd.CategoryID = qdefIn.CategoryID; // logic to adjust catId since diff between prod and sbx
                switch (qdefIn.CategoryID)
                {
                    case 833:
                        qd.CategoryID = 99428;
                        break;
                    case 83902:
                        qd.CategoryID = 103810;
                        break;
                    case 93590:
                        qd.CategoryID = 103811;
                        break;
                    case 88862:
                        qd.CategoryID = 103812;
                        break;
                    case 83572:
                        qd.CategoryID = 103813;
                        break;
                    case 9202:
                        qd.CategoryID = 103814;
                        break;
                    case 82915:
                        qd.CategoryID = 103815;
                        break;
                    case 9588:
                        qd.CategoryID = 103816;
                        break;
                    case 82929:
                        qd.CategoryID = 103817;
                        break;
                    case 82919:
                        qd.CategoryID = 103818;
                        break;
                    case 83624:
                        qd.CategoryID = 103837;
                        break;
                    case 83633:
                        qd.CategoryID = 103853;
                        break;
                    case 86030:
                        qd.CategoryID = 103854;
                        break;
                    case 83431:
                        qd.CategoryID = 103855;
                        break;
                    case 99372:
                        qd.CategoryID = 103856;
                        break;
                    case 103128:
                        qd.CategoryID = 103857;
                        break;
                    case 101940:
                        qd.CategoryID = 103858;
                        break;
                    case 95760:
                        qd.CategoryID = 103859;
                        break;
                    case 93048:
                        qd.CategoryID = 103860;
                        break;
                    case 83438:
                        qd.CategoryID = 103861;
                        break;
                    case 83456:
                        qd.CategoryID = 103862;
                        break;
                    case 83212:
                        qd.CategoryID = 103863;
                        break;
                    case 83223:
                        qd.CategoryID = 103864;
                        break;
                    case 83440:
                        qd.CategoryID = 103865;
                        break;
                    case 83450:
                        qd.CategoryID = 103866;
                        break;
                    case 83527:
                        qd.CategoryID = 103867;
                        break;
                    case 84582:
                        qd.CategoryID = 103868;
                        break;
                    case 9596:
                        qd.CategoryID = 103819;
                        break;
                    case 9597:
                        qd.CategoryID = 103824;
                        break;
                    case 10612:
                        qd.CategoryID = 103825;
                        break;
                    case 84056:
                        qd.CategoryID = 103829;
                        break;
                    case 82809:
                        qd.CategoryID = 103830;
                        break;
                    case 82908:
                        qd.CategoryID = 103831;
                        break;
                    case 88861:
                        qd.CategoryID = 103826;
                        break;
                    case 9598:
                        qd.CategoryID = 103827;
                        break;
                    case 9605:
                        qd.CategoryID = 103832;
                        break;
                    case 9606:
                        qd.CategoryID = 103833;
                        break;
                    case 83384:
                        qd.CategoryID = 103828;
                        break;
                    case 83385:
                        qd.CategoryID = 103834;
                        break;
                    case 83386:
                        qd.CategoryID = 103836;
                        break;
                    case 97686:
                        qd.CategoryID = 103821;
                        break;
                    case 88897:
                        qd.CategoryID = 103822;
                        break;
                    case 88898:
                        qd.CategoryID = 103823;
                        break;
                    default:
                        qd.CategoryID = 99428;
                        break;
                }
                qd.CategoryIDSpecified = true;

                CreateResult[] cresults = soapClientIn.Create(new CreateOptions(), new APIObject[] { qd }, out requestID, out status);

                foreach (CreateResult result in cresults)
                {
                    Console.WriteLine(result.StatusMessage);
                }

                Console.WriteLine(requestID + ": " + status);
            }
            
        }
    }
}
