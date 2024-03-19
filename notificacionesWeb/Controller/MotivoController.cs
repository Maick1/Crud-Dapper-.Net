using Microsoft.AspNetCore.Mvc;
using notificacionesWeb.Data;
using notificacionesWeb.Shared.Models;

namespace notificacionesWeb.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class MotivoController : ControllerBase
    {
        Tb_motivoData _data = new Tb_motivoData();

        [HttpGet("Lista")]
        public async Task<List<Tb_Motivo>> getMotivo()
        {
            return await _data.getMotivo();
        }

        [HttpPost("Guardar")]
        public async Task<Tb_Motivo> insertMotivo(Tb_Motivo info)
        {
            return await _data.insertMotivo(info);
        }

        [HttpPut("update")]
        public async Task<Tb_Motivo> updateMotivo(Tb_Motivo info)
        {
            return await _data.updateMotivo(info);
        }

        [HttpDelete("delete")]
        public async Task<bool> deleteMotivo(Tb_Motivo info)
        {
            return await _data.deleteMotivo(info);
        }

    }
}
