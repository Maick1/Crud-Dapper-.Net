using notificacionesWeb.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace notificacionesWeb.entity.Models
{
    public class Notificaciones
    {

        public Notificaciones()
        {
            empresa = new tb_empresas();
            Mo_motivo =  new Tb_Motivo();
            Sub_Motivos = new Tb_Sub_Motivos();
        }

        public Notificaciones(int Idnotificacion,int IdMotivo,int IdSubMotivo,int Idempresa, string titulo, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime fechaRegistro)
        {
            idnotificacion = Idnotificacion;
            id_empresa = Idempresa;
            id_Motivo = IdMotivo;
            id_Sub_Motivo= IdSubMotivo;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            FechaRegistro = fechaRegistro;
            empresa = new tb_empresas();
        }

        public int idnotificacion { get; set; }
        
        public int id_empresa {  get; set; }   
        
        public int id_Motivo { get; set; }

        public int id_Sub_Motivo { get; set; }

        [Required(ErrorMessage = "Ingrese Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Ingrese Descripcion")]
        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public DateTime FechaRegistro { get; set; }

        public tb_empresas empresa { get; set; }

        public Tb_Motivo Mo_motivo { get; set; }

        public Tb_Sub_Motivos Sub_Motivos { get; set; } 
}
}
