using notificacionesWeb.Shared.Models;
using System.ComponentModel.DataAnnotations;


namespace notificacionesWeb.entity.Models
{
    public class Tb_Sub_Motivos
    { 
        public Tb_Sub_Motivos()
        {
            motivoEm = new Tb_Motivo();
        }

        public Tb_Sub_Motivos( int Id_sub_motivo, int Idmotivo, string Nom_sub_motivo, string Estado)
        {
            id_sub_motivo = Id_sub_motivo;
            id_motivo = Idmotivo;
            nom_sub_motivo = Nom_sub_motivo;
            estado = Estado;    
            motivoEm = new Tb_Motivo();

        }

        public int id_sub_motivo { get; set; } = 0;

        public int id_motivo { get; set; } = 0;

        [Required(ErrorMessage = "Ingrese Descripcion")]
        public string nom_sub_motivo { get; set; } = "";

        public string estado { get; set; } = "";
        public Tb_Motivo motivoEm { get; set; }
    }
}
