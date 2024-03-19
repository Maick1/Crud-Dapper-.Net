using Microsoft.AspNetCore.Mvc;
using notificacionesWeb.Data;
using notificacionesWeb.entity.Models;


namespace notificacionesWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        notificacionData _data = new notificacionData();

        [HttpGet("Lista")]
        public async Task<List<Notificaciones>> getnotificaciones()
        {
            return await _data.getNotificaciones();
        }


        [HttpPost("Guardar")]
        public async Task<Notificaciones> insertNotification(Notificaciones info)
        {
            return await _data.insertNotificacion(info);
        }

        [HttpPost("update")]
        public async Task<Notificaciones> updateNotification(Notificaciones info)
        {
            return await _data.updateNotificacion(info);
        }

        [HttpPost("delete")]
        public async Task<bool> deleteNotification(Notificaciones info)
        {
            return await _data.deleteNotificacion(info);
        }
    }
}
