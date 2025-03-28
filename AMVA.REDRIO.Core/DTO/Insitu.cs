using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AMVA.REDRIO.Core.DTO
{
    [Table("INSITU")]
    public class Insitu
    {
        [Key]
        [JsonProperty("ID_INSITU")]
        [Column("ID_INSITU")]
        public int IdInsitu { get; set; }

        [JsonProperty("ORP")]
        [Column("ORP")]
        public decimal? OrpInsitu { get; set; }

        [JsonProperty("OXIGENO_DISUELTO")]
        [Column("OXIGENO_DISUELTO")]
        public decimal? Oxigeno_disuelto { get; set; }

        [JsonProperty("TURBIEDAD")]
        [Column("TURBIEDAD")]
        public decimal? Turbiedad { get; set; }

        [JsonProperty("TEMP_AGUA")]
        [Column("TEMP_AGUA")]
        public decimal? Tem_agua { get; set; }

        [JsonProperty("TEMP_AMBIENTE")]
        [Column("TEMP_AMBIENTE")]
        public decimal? Temp_ambiente { get; set; }

        [JsonProperty("CONDUCTIVIDAD_ELECTRICA")]
        [Column("CONDUCTIVIDAD_ELECTRICA")]
        public decimal? Conductiviidad_electrica { get; set; }

        [JsonProperty("PH")]
        [Column("PH")]
        public decimal? PhInsitu { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        [JsonProperty("FECHA_MUESTRA")]
        [Column("FECHA_MUESTRA")]
        public DateTime? Fecha_Muestra { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
    }
}
