using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class ReplyMailUtil
    {
        public static void DescribeRMMConfiguration(SoapClient soapClientIn)
        {
            string requestID;
            ObjectDefinitionRequest objDefs = new ObjectDefinitionRequest();
            objDefs.ObjectType = "ReplyMailManagementConfiguration";

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

        public static APIObject[] GetAllRMMConfigs(SoapClient soapClientIn)
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

            rr.ObjectType = "ReplyMailManagementConfiguration";
            rr.Properties = new String[] { "ID", "Client.ID", "EmailDisplayName", "ReplySubdomain", "EmailReplyAddress",
                "CreatedDate", "ModifiedDate", "DNSRedirectComplete", "DeleteAutoReplies", "SupportUnsubscribes", "SupportUnsubKeyword",
                "SupportUnsubscribeKeyword", "SupportRemoveKeyword", "SupportOptOutKeyword", "SupportLeaveKeyword", "SupportMisspelledKeywords", "SendAutoReplies",
                "AutoReplySubject", "AutoReplyBody", "ForwardingAddress", "ConversationLifetimeDays", "ConversationLifetimeCycles", "AnonymousRuleSet.ObjectID",
                "AnonymousRuleSet.Name", "AnonymousRuleSet.CustomerKey", "AnonymousAckTriggeredSend.ObjectID", "AnonymousAckTriggeredSend.CustomerKey",
                "AnonymousAckTriggeredSend.Name", "AnonymousAckTriggeredSend.TriggeredSendStatus", "AnonymousForwardTriggeredSend.ObjectID",
                "AnonymousForwardTriggeredSend.CustomerKey", "AnonymousForwardTriggeredSend.Name", "AnonymousForwardTriggeredSend.TriggeredSendStatus",
                "ResponderConversationRuleSet.ObjectID", "ResponderConversationRuleSet.Name", "ResponderConversationRuleSet.CustomerKey",
                "ResponderConversationAckTriggeredSend.ObjectID", "ResponderConversationAckTriggeredSend.CustomerKey", "ResponderConversationAckTriggeredSend.Name",
                "ResponderConversationAckTriggeredSend.TriggeredSendStatus", "ResponderConversationForwardTriggeredSend.ObjectID",
                "ResponderConversationForwardTriggeredSend.CustomerKey", "ResponderConversationForwardTriggeredSend.Name",
                "ResponderConversationForwardTriggeredSend.TriggeredSendStatus", "InitiatorConversationRuleSet.ObjectID", "InitiatorConversationRuleSet.Name",
                "InitiatorConversationRuleSet.CustomerKey", "InitiatorConversationAckTriggeredSend.ObjectID", "InitiatorConversationAckTriggeredSend.CustomerKey",
                "InitiatorConversationAckTriggeredSend.Name", "InitiatorConversationAckTriggeredSend.TriggeredSendStatus", "InitiatorConversationForwardTriggeredSend.ObjectID", 
                "InitiatorConversationForwardTriggeredSend.CustomerKey", "InitiatorConversationForwardTriggeredSend.Name",
                "InitiatorConversationForwardTriggeredSend.TriggeredSendStatus", "ConversationExpirationTriggeredSend.ObjectID", "ConversationExpirationTriggeredSend.CustomerKey",
                "ConversationExpirationTriggeredSend.Name", "ConversationExpirationTriggeredSend.TriggeredSendStatus", "MultiUseViolationTriggeredSend.ObjectID", 
                "MultiUseViolationTriggeredSend.CustomerKey", "MultiUseViolationTriggeredSend.Name", "MultiUseViolationTriggeredSend.TriggeredSendStatus", "InboundAddressIsOneUse" };

            do
            {
                status = soapClientIn.Retrieve(rr, out requestID, out results);

                totalCount += results.Length;

                foreach (APIObject apiObject in results)
                {
                    totalResultsList.Add(apiObject);
                }

                Console.WriteLine(status);
                Console.WriteLine("Num RMM Configs: " + totalCount);

                rr = new RetrieveRequest();
                rr.ContinueRequest = requestID;
            } while (status.Equals("MoreDataAvailable"));

            totalResults = totalResultsList.ToArray<APIObject>();
            Console.WriteLine("Total RMM Configs: " + totalResults.Length);

            Console.ReadLine();
            return totalResults;
        }
    }
}
