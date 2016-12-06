﻿using System;
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

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "DataFolder";
            rr.Properties = new String[] { "Name", "ObjectID", "CustomerKey" };

            status = soapClientIn.Retrieve(rr, out requestID, out results);

            Console.WriteLine(status);
            Console.WriteLine("Num Data Folders: " + results.Length);

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
            rr.Properties = new String[] { "Name", "ObjectID", "ContentType" };

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

            //deIn.CategoryIDSpecified = true;

            String requestID;
            String status;
            APIObject[] results;

            SimpleFilterPart sfp = new SimpleFilterPart();
            sfp.Property = "ID";
            sfp.SimpleOperator = SimpleOperators.equals;
            sfp.Value = new String[] { deIn.CategoryID.ToString() };

            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "DataFolder";
            rr.Properties = new String[] { "Name", "ObjectID", "CustomerKey", "ID" };
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

        //public static APIObject[] GetDataFoldersByDECustomerKey(SoapClient soapClientIn, DataExtension deIn)
        //{
        //    String requestID;
        //    String status;
        //    APIObject[] results;

        //    SimpleFilterPart sfp = new SimpleFilterPart();
        //    sfp.Property = "ParentFolder.CustomerKey";
        //    sfp.SimpleOperator = SimpleOperators.equals;
        //    sfp.Value = new String[] { deIn.CustomerKey };

        //    RetrieveRequest rr = new RetrieveRequest();

        //    rr.ObjectType = "DataFolder";
        //    rr.Properties = new String[] { "Name", "ObjectID", "ContentType" };

        //    status = soapClientIn.Retrieve(rr, out requestID, out results);

        //    Console.WriteLine(status);
        //    Console.WriteLine("Num Data Folders for Parent Folder Customer Key: " + deIn.Name + " = " + results.Length);

        //    Console.ReadLine();

        //    return results;
        //}
    }
}
