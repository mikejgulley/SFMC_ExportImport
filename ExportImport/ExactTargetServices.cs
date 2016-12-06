using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;
using System.Diagnostics;
using System.Threading;
using System.Configuration;

namespace ExportImport
{
    class ExactTargetServices
    {
        #region Fields

        private static string status = string.Empty;
        private static string msg = string.Empty;
        private static string requestID = string.Empty;

        /// <summary>
        /// Gets top level ClientID in string array format
        /// </summary>
        /// <returns>Top Level ClientID</returns>
        private static ClientID[] GetClients()
        {
            ClientID client = new ClientID();

            client.ID = Convert.ToInt32(ConfigurationManager.AppSettings["MID"].ToString());
            client.IDSpecified = true;

            ClientID[] clients = new ClientID[1];

            clients[0] = client;

            return clients;
        }

        #endregion

        #region

        /// <summary>
        /// Initializes a new instance of the <see cref="ET" /> class.
        /// </summary>
        public ExactTargetServices()
        {
        }

        #endregion

        public static SoapClient ExactTargetBinding(string username, string password) 
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Name = "UserNameSoapBinding";
                binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.ReceiveTimeout = new TimeSpan(0, 15, 0);
                binding.CloseTimeout = new TimeSpan(0, 15, 0);
                binding.SendTimeout = new TimeSpan(0, 15, 0);
                binding.MaxReceivedMessageSize = 655360000;

                // Set the transport security to UsernameOverTransport for Plaintext usernames
                EndpointAddress endpoint = new EndpointAddress("https://webservice.s7.exacttarget.com/Service.asmx");

                // Create the SOAP Client (and pass in the endpoint in the binding)
                SoapClient et = new SoapClient(binding, endpoint);

                // Set the username and password
                et.ClientCredentials.UserName.UserName = username;
                et.ClientCredentials.UserName.Password = password;

                // Check the results
                SystemStatusResult[] results = et.GetSystemStatus(new SystemStatusOptions(), out status, out msg, out requestID);

                Console.WriteLine("\nExactTargetBinding\n\tstatus:\t{0}\n\tmsg:\t{1}\n\trequestid:\t{2}", status, msg, requestID);

                if (status != "OK")
                {
                    Console.WriteLine("\n\nExactTargetBinding FAILURE!!!");

                    return null;
                }
                else
                {
                    Console.WriteLine("\nExactTargetBinding Success!");

                    return et;
                }
            }
            catch (Exception e)
            {
                //EventLogWriter.WriteToEventLog("Unable to establish binding to ExactTarget soap client", EventLogEntryType.Warning, (int)Program.EventID.UnableToEstablishBinding);

                Console.WriteLine("\nExactTargetBinding FAILURE!!!\t{0}", e);

                return null;
            }
        } // ExactTargetBinding
    }
}
