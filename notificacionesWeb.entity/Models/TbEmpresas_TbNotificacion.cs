using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notificacionesWeb.entity.Models
{
    public class TbEmpresas_TbNotificacion
    {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string NombreEmpresa { get; set; }
    }
}
