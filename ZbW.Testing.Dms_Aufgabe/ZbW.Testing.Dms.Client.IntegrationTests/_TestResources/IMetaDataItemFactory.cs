using System;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.IntegrationTests._TestResources
{
    internal class IMetaDataItemFactory
    {
        public IMetadataItem GetMetadataItem()
        {
            var stubMetadataItem = A.Fake<IMetadataItem>();
            stubMetadataItem.Bezeichnung = "KPT";
            stubMetadataItem.Typ = "Vertrag";
            stubMetadataItem.ContentFileExtension = ".pdf";
            stubMetadataItem.ContentFilename = "_content.pdf";
            stubMetadataItem.MetadataFilename = "_metadata.xml";
            stubMetadataItem.DocumentId = new Guid("f53a8091-2987-4213-a736-2c80672e76f9");
            stubMetadataItem.OrginalPath = @"C:\Temp\OrginalPath";
            stubMetadataItem.PathInRepo = @"C:\Temp\Repo";
            stubMetadataItem.Stichwoerter = "KPT Vertrag";
            stubMetadataItem.ValutaDatum = new DateTime(2018, 09, 30);
            stubMetadataItem.ValutaYear = stubMetadataItem.ValutaDatum.Year.ToString();
            return stubMetadataItem;
        }
    }
}