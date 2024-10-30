using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
    [Table("ESTACION")]
    public class Estacion
    {
        [Key]
        [Column("ID_ESTACION")]
        public int IdEstacion { get; set; }

        [Required]
        [Column("CODIGO")]
        public string codigo { get; set; }

        [Required]
        [Column("NOMBRE_ESTACION")]
        public string nombreEstacion {get; set;}

        [Required]
        [Column("ID_MUNI")]
        public int IdMunicipio {get; set;}

        [Column("ID_TIPO_FUENTE")]
        public int IdTipoFuente {get; set;}

        [Column("ELEVACION")]
        public int? Elevacion {get; set;}

        [Column("GRADOS_LATITUD")]
        public int? Grados_latitud {get; set;}

        [Column("MINUTOS_LATITUD")]
        public int? Minutos_latitud {get; set;}

        [Column("SEGUNDOS_LATITUD")]
        public int? Segundos_latitud {get; set;}

        [Column("GRADOS_LOGITUD")]
        public int? Grados_longitud {get; set;}

        [Column("MINUTOS_LOGITUD")]
        public int? Minutos_longitud {get; set;}

        [Column("SEGUNDOS_LONGITUD")]
        public int? Segundos_longitud {get; set;}

        // [Column("S_LOGIN")]
        // public int S_login {get; set;}

        [Column("FECHA_CREACION")]
        public DateTime? Fecha_creacion { get; internal set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? Fecha_actualizacion { get; internal set; }


        public Municipio? Municipio { get; set; }

        public TipoFuente? TipoFuente { get; set; }
    }
}
