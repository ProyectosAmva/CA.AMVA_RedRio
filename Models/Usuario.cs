using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMVA.REDRIO.Models
{
     public class UsuariosDTO
    {
         [Key]
        public int ID_USUARIO { get; set; }
        public string GRUPO { get; set; }
        public string S_LOGIN { get; set; }
        public string NOMBRE { get; set; }
        public string FUNCIONARIO { get; set; }
        public DateTime? VENCE { get; set; }
        public string ESTADO { get; set; }


    }

}
