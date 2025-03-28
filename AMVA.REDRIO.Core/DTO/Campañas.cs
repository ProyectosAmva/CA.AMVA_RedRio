using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace AMVA.REDRIO.Core.DTO;

     /// <summary>
    /// modelo de campaña que tiene un nombre, una descripción, fechas de inicio y fin, 
    /// una fase asociada y un usuario responsable.
    /// </summary>
      [Table("CAMPAÑAS")]
    public class Campaña
    {
        [Key]
        [JsonProperty("ID_CAMPAÑA")]
        [Column("ID_CAMPAÑA")]
        public int IdCampaña { get; set; }

        [JsonProperty("NOMBRE_CAMPAÑA")]
        [Column("NOMBRE_CAMPAÑA")]
        public string? NombreCampaña { get; set; }

        [Required]
        [JsonProperty("DESCRIPCION")]
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Required]
        [JsonProperty("FECHA_INICIAL")]
        [Column("FECHA_INICIAL")]
        public DateTime Fecha_inicial { get; set; }

        [Required]
        [JsonProperty("FECHA_FINAL")]
        [Column("FECHA_FINAL")]
        public DateTime Fecha_final { get; set; }

        [Required]
        [JsonProperty("ID_FASE")]
        [Column("ID_FASE")]
        public int IdFase { get; set; }

        [JsonProperty("ID_USUARIO")]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        [JsonProperty("FECHA_CREACION")]
        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; set; }

        [JsonProperty("FECHA_ACTUALIZACION")]
        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; set; }

        public Fase? Fase { get; set; }
        public UsuariosDTO Usuario { get; set; }
    }
