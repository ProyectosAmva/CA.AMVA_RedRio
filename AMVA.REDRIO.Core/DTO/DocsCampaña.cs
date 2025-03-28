using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("DOCS_CAMPANAS")]
    public class DocsCampaña
    {
        [Key]
        [JsonProperty("ID_DOC_CAMPAÑA")]
        [Column("ID_DOC_CAMPAÑA")]
        public int Id_DocsCampaña { get; set; }

        [JsonProperty("ID_CAMPAÑA")]
        [Column("ID_CAMPAÑA")]
        public int? IdCampaña { get; set; }

        [JsonProperty("ID_DOCUMENTO")]
        [Column("ID_DOCUMENTO")]
        public int Id_Documento { get; set; }

        [JsonProperty("FECHA_CARGUE")]
        [Column("FECHA_CARGUE")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("ESTADO")]
        [Column("ESTADO")]
        public string? Estado { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        public Campaña? Campaña { get; set; }
        public Documento? Documento { get; set; }
    }
}
