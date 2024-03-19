

namespace notificacionesWeb.Shared.Models
{
    public class Tb_Motivo
    {
        public Tb_Motivo()
        {

        }

        public Tb_Motivo(int IdMotivo, string Nom_motivo, string Estado)
        {
            idmotivo = IdMotivo;
            nom_motivo = Nom_motivo;
            estado = Estado;
        }

        public int idmotivo { get; set; }
        public string nom_motivo { get; set; } = "";
        public string estado { get; set; } = "";
    }
}

