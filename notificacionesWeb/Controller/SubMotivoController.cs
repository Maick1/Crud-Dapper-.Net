using Microsoft.AspNetCore.Mvc;
using notificacionesWeb.Data;
using notificacionesWeb.entity.Models;

namespace notificacionesWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMotivoController : ControllerBase
    {
        TbSubMotivoData _data = new TbSubMotivoData();

        [HttpGet("Lista")]
        public async Task<List<Tb_Sub_Motivos>> getSubMotivo()
        {
            return await _data.getSubMotivo();
        }

        [HttpPost("Guardar")]
        public async Task<Tb_Sub_Motivos> insertSubMotivo(Tb_Sub_Motivos info)
        {
            return await _data.insertSubMotivo(info);
        }

        [HttpPut("update")]
        public async Task<Tb_Sub_Motivos> updateSubMotivo(Tb_Sub_Motivos info)
        {
            return await _data.updateSubMotivo(info);
        }

        [HttpDelete("delete")]
        public async Task<bool> deleteSubMotivo(Tb_Sub_Motivos info)
        {
            return await _data.deleteSubMotivo(info);
        }

    }
}
