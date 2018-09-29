using System;

namespace ZbW.Testing.Dms.Client.Model
{
    public interface IMetadataItem
    {
        DateTime ValutaDatum { get; set; }
        string ContentFileExtension { get; set; }
        string OriginalPath { get; set; }
        string ContentFilename { get; set; }
        string MetadataFilename { get; set; }
        Guid DocumentId { get; set; }
        string ValutaYear { get; set; }
        string Typ { get; set; }
        string Bezeichnung { get; set; }
        string Stichwoerter { get; set; }
        string PathInRepo { get; set; }
    }
}