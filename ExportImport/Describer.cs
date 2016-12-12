using ExportImport.PartnerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    class Describer
    {
        public static void DescribeAPIObjects(SoapClient soapClientIn)
        {
            //Describe APIObjects
            //DataExtensionUtil.DescribeDataExtensions(soapClientIn);
            //DataFolderUtil.DescribeDataFolders(soapClientIn);
            //QueryDefinitionUtil.DescribeQuery(soapClientIn);
            //ImportDefinitionUtil.DescribeImport(soapClientIn);
            //RoleUtil.DescribeRole(soapClientIn);
            //BusinessUnitUtil.DescribeBusinessUnit(soapClientIn);
            //AccountUtil.DescribeAccount(soapClientIn);
            //AccountUserUtil.DescribeAccountUser(soapClientIn);
            //RoleUtil.DescribeRole(soapClientIn);
            //EmailUtil.DescribeEmail(soapClientIn);
            //EmailUtil.DescribeEmailSendDefinition(soapClientIn);
            //PortfolioUtil.DescribePortfolioItem(soapClientIn);
            //ContentAreaUtil.DescribeContentArea(soapClientIn);
            //ListsUtil.DescribeLists(soapClientIn);
            //SuppressionListUtil.DescribeSuppressionLists(soapClientIn);
            //PublicationListUtil.DescribePublicationLists(soapClientIn);
            //TemplateUtil.DescribeTemplate(soapClientIn);
            TriggeredSendDefinitionUtil.DescribeSendDefinition(soapClientIn);
        }
    }
}
