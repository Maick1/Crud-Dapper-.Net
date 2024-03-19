using Dapper;
using notificacionesWeb.entity.Models;
using System.Data.SqlClient;

namespace notificacionesWeb.Data
{
    public class notificacionData
    {
        public notificacionData()
        {

        }

        public async Task<List<Notificaciones>> getNotificaciones()
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sql = @"
               SELECT 
                        noti.idnotificacion, 
                        noti.id_empresa, 
	                    sub.id_sub_motivo, 
                        sub.id_motivo, 
	                    moti.idmotivo,
	                    emp.idempresa, 
                        noti.titulo, 
                        noti.descripcion, 
                        noti.fechaInicio, 
                        noti.fechaFin, 
                        noti.fechaRegistro, 
                        emp.nom_empresa, 
                        emp.ruc_empresa, 
                        emp.dias_gracia,
                        moti.nom_motivo, 
                        moti.estado, 
                        sub.nom_sub_motivo,
                        sub.estado
                    FROM 
                        dbo.tb_notificacion AS noti
                    INNER JOIN 
                        dbo.tb_motivo AS moti ON moti.idmotivo = moti.idmotivo
                    INNER JOIN 
                        dbo.tb_sub_motivos AS sub ON sub.id_motivo = moti.idmotivo
                    INNER JOIN 
                        dbo.tb_empresas AS emp ON noti.id_empresa = emp.idempresa;";

                var lisTemp = await conection.QueryAsync<Notificaciones>(sql);
                return lisTemp.ToList();

            }
            catch (Exception ex)
            {
                return new List<Notificaciones>();
            }
        }


        public async Task<Notificaciones> insertNotificacion(Notificaciones info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlMax = "select isnull(max(idnotificacion),0) from tb_notificacion";

                var id = await conection.QueryAsync<int>(sqlMax);
                info.idnotificacion = id.FirstOrDefault() + 1;

                string sqlInser = "INSERT INTO tb_notificacion (idnotificacion,id_motivo_N,id_sub_motivo_N,id_empresa,titulo,descripcion,fechaInicio,fechaFin,fechaRegistro)" +
                    "VALUES(@idnot,@idmot,@idSubmo,@idem,@titl,@descrip,@fechai,@fechaf,@fechar)";


                var para = new {
                    idnot = info.idnotificacion,
                    idem= info.empresa.idempresa,
                    idmot = info.Mo_motivo.idmotivo,
                    idSubmo = info.Sub_Motivos.id_sub_motivo,
                    titl=info.Titulo,
                    descrip=info.Descripcion,
                    fechai= info.FechaInicio,
                    fechaf = info.FechaFin,
                    fechar= info.FechaRegistro,
                };


                await conection.QueryAsync(sqlInser, para);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Notificaciones> updateNotificacion(Notificaciones info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlUpdate = "UPDATE tb_notificacion SET titulo = @Titulo, descripcion = @Descripcion, fechaInicio = @FechaInicio, fechaFin = @FechaFin, fechaRegistro = @FechaRegistro" +
                    " WHERE idnotificacion = @idnotificacion";

                await conection.ExecuteAsync(sqlUpdate, info);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> deleteNotificacion(int id)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlDelete = "DELETE FROM tb_notificacion WHERE idnotificacion = @Id";

                await conection.ExecuteAsync(sqlDelete, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal async Task<bool> deleteNotificacion(Notificaciones info)
        {
            throw new NotImplementedException();
        }
    }
}
