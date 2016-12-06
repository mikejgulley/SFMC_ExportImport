using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportImport.PartnerAPI;

namespace ExportImport
{
    class Program
    {
        static void Main(string[] args)
        {
            APIObject[] dataExts = {};
            APIObject[] dataExtFields = {};
            APIObject[] dataFolders = {};
            APIObject[] dataFoldersByDE = {};

            using (SoapClient soapProd = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsername, ConfigSettings.ETPassword))
            {
                // soapProd.Close(); -- when using 'using' - no need to use soapProd.Close()
                Console.WriteLine("Env: Prod\n");

                //DataExtensionUtil.DescribeDataExtensions(soapProd);
                //DataFolderUtil.DescribeDataFolders(soapProd);

                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);
                //dataFolders = DataFolderUtil.GetAllDataFoldersByType(soapProd, "email");

                dataExts = DataExtensionUtil.GetAllDataExtensions(soapProd);

                //foreach (DataExtension de in dataExts)
                //{
                //    dataExtFields = DataExtensionUtil.GetDataExtensionFieldsByDECustomerKey(soapProd, de);
                //}

                Console.WriteLine("...");
                Console.ReadLine();

                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);

                foreach (DataExtension de in dataExts)
                {
                    //dataFoldersByDE = DataFolderUtil.GetDataFoldersByDECustomerKey(soapProd, de);
                    dataFoldersByDE = DataFolderUtil.GetDataFolderByDECategoryID(soapProd, de);
                    JSONUtil.saveDEToJSON(de);
                }
                
            }

            using (SoapClient soapSbx = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsernameSbx, ConfigSettings.ETPasswordSbx))
            {
                Console.WriteLine("Env: Sbx\n");
                //DataExtensionUtil.CreateDataExtensions(soapSbx, dataExts, dataExtFields);
            }
            
        }
    }
}
