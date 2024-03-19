namespace notificacionesWeb.Shared.Models
{
    public class tb_empresas
    {
        public tb_empresas()
        {
        }

        public tb_empresas(int Idempresa, string Nom_Empresa, string Ruc_empresa, int Dias_gracia)
        {
            idempresa =Idempresa;
            nom_empresa = Nom_Empresa;
            ruc_empresa = Ruc_empresa;
            dias_gracia = Dias_gracia;
        }

        public int idempresa { get; set; } = 0;
        public string nom_empresa { get; set; } = "";
        public string ruc_empresa { get; set; } = "";
        public int dias_gracia { get; set; } = 0;
    }
}
