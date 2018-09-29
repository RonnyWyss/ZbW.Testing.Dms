using System;

namespace ZbW.Testing.Dms.Client.Model
{
    public interface IMetadataItem
    {
        string Bezeichnung { get; set; }
        string ContentFileExtension { get; set; }
        string ContentFilename { get; set; }
        string MetadataFilename { get; set; }
        string OrginalPath { get; set; }
        string Stichwoerter { get; set; }
        string Typ { get; set; }
        string PathInRepo { get; set; }
        string ValutaYear { get; set; }
        Guid DocumentId { get; set; }
        DateTime ValutaDatum { get; set; }
    }
}