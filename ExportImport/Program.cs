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
            APIObject[] dataFolders = { };
            APIObject[] dataExts = { };
            APIObject[] dataExtensionFields = { };

            using (SoapClient soapProd = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsername, ConfigSettings.ETPassword))
            {
                // soapProd.Close(); -- when using 'using' - no need to use soapProd.Close()
                Console.WriteLine("Env: Prod\n");

                //Describe APIObjects
                //Describer.DescribeAPIObjects(soapProd);

                // Perform Export
                //ExportFromProd.PerformExport(soapProd);

                //----------------------------------------------------------------------------------
                
                // Data Folders
                //dataFolders = DataFolderUtil.GetAllDataFolders(soapProd);

                //foreach (DataFolder df in dataFolders)
                //{
                //    JSONUtil.saveDataFolderToJSON(df);
                //}

                //Console.WriteLine("...");
                //Console.ReadLine();

                //---------------------------------------------------------------------------------
                // Data Extensions
                //DataFolderUtil.GetDataFolderByName(soapProd, "Data Views");
                dataExts = DataExtensionUtil.GetAllDataExtensionsByID(soapProd, 82914); // 8455 = Data Feeds; 82914 = Data Views
                Console.WriteLine("Num DE's: " + dataExts.Length);

                foreach (DataExtension de in dataExts)
                {
                    de.Fields = (DataExtensionField[])DataExtensionFieldsUtil.GetDataExtensionFieldsByDECustomerKey(soapProd, de);
                }

                //Console.WriteLine("...");
                //Console.ReadLine();
            }

            using (SoapClient soapSbx = ExactTargetServices.ExactTargetBinding(ConfigSettings.ETUsernameSbx, ConfigSettings.ETPasswordSbx))
            {
                Console.WriteLine("Env: Sbx\n");
                //--------------------------------------------------------------------------------------------

                //DataFolder df = new DataFolder();

                //foreach(DataFolder df2 in DataFolderUtil.GetDataFolderByName(soapSbx, "API Created Folder"))
                //{
                //    df = df2;
                //}

                //DataFolderUtil.UpdateDataFolder(soapSbx, df);

                //--------------------------------------------------------------------------------------------
                // Creating Data Feeds folder in SBX based on same folder in Prod
                //int counter = 0;
                //int fileCounter = 1;

                //foreach (DataFolder df in dataFolders)
                //{
                //    Console.WriteLine("File Count: " + fileCounter);
                //    //while (counter < 3)
                //    //{
                //    //if (df.ParentFolder.ID != 0)
                //    //if (!df.Name.StartsWith("_") && df.Client.ID == 7237980 && df.ParentFolder.ID != 0)
                //    if (df.Name.Equals("Data Feeds") && df.ID == 8455)
                //    {
                //        Console.WriteLine("Creating Data Folder: " + df.Name);
                //        Console.WriteLine("Data Folder Content Type: " + df.ContentType);
                //        DataFolderUtil.CreateDataFolderFromExistingInProd(soapSbx, df);
                //        counter++;
                //    }
                //    //}

                //    fileCounter++;
                //}

                //--------------------------------------------------------------------------------------------
                // Creating Data Extensions in Data Feeds folder based on DE's in Prod
                //DataFolderUtil.GetDataFolderByName(soapSbx, "Data Views");
                //DataExtensionUtil.CreateDataExtensionsByParentFolderID(soapSbx, dataExts, 8455);
                //DataExtensionUtil.GetDataExtensionByName(soapSbx, "RPAreaOfInterest");

                Console.WriteLine("Creating Data Extensions...");
                Console.ReadLine();
                foreach (DataExtension de in dataExts)
                {
                    DataExtensionUtil.CreateDataExtensionFromExistingInProd(soapSbx, de, 102133); // 102133 = Data View; 102118 = Data Feeds; 99425 = DE folder;
                }
            }
            
        }
    }
}
