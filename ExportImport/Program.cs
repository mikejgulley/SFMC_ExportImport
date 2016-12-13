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
            using (SoapClient soapProd = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsername, ConfigSettings.ETPassword))
            {
                // soapProd.Close(); -- when using 'using' - no need to use soapProd.Close()
                Console.WriteLine("Env: Prod\n");

                //Describe APIObjects
                Describer.DescribeAPIObjects(soapProd);

                // Perform Export
                ExportFromProd.PerformExport(soapProd);
            }

            using (SoapClient soapSbx = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsernameSbx, ConfigSettings.ETPasswordSbx))
            {
                Console.WriteLine("Env: Sbx\n");
                //DataExtensionUtil.CreateDataExtensions(soapSbx, dataExts, dataExtFields);
                //APIObject[] dfArray = DataFolderUtil.GetAllDataFoldersByType(soapSbx, "dataextension");

                //foreach (DataFolder df in dfArray)
                //{
                //    Console.WriteLine("Data Folder Name: " + df.Name);
                //    Console.WriteLine("Data Folder ID: " + df.ID);
                //}

                //Console.ReadLine();

                //DataFolderUtil.CreateDataFolder(soapSbx);

                //int counter = 0;

                //foreach (DataFolder df in dataFolders)
                //{
                //    while (counter < 10)
                //    {
                //        Console.WriteLine("Creating Data Folder: " + df.Name);
                //        DataFolderUtil.CreateDataFolderFromExistingInProd(soapSbx, df);
                //        counter++;
                //    }
                //}

                
            }
            
        }
    }
}
