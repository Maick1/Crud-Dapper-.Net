using Microsoft.AspNetCore.Mvc;
using notificacionesWeb.Data;
using notificacionesWeb.Shared.Models;

namespace notificacionesWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        tb_empresasData _data = new tb_empresasData();

        [HttpGet("Lista")]
        public async Task<List<tb_empresas>> getEmpresas()
        {
            return await _data.getEmpresas();
        }

        [HttpPost("Guardar")]
        public async Task<tb_empresas> insertEmpresa(tb_empresas info)
        {
            return await _data.insertEmpresa(info);
        }

        [HttpPut("update")]
        public async Task<tb_empresas> updateEmpresa(tb_empresas info)
        {
            return await _data.updateEmpresa(info);
        }

        [HttpDelete("delete")]
        public async Task<bool> deleteEmpresa(tb_empresas info)
        {
            return await _data.deleteEmpresa(info);
        }
    }
}
