using Dapper;
using notificacionesWeb.Shared.Models;
using System.Data.SqlClient;

namespace notificacionesWeb.Data
{
    public class Tb_motivoData
    {
        public async Task<List<Tb_Motivo>> getMotivo()
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);


                string sql = "select * from tb_motivo";

                var lisTemp = await conection.QueryAsync<Tb_Motivo>(sql);
                return lisTemp.ToList();

            }
            catch (Exception ex)
            {
                return new List<Tb_Motivo>();
            }
        }
        public async Task<Tb_Motivo> insertMotivo(Tb_Motivo info)
        {
            try
            {
                using var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlMax = "select isnull(max(idmotivo),0) from tb_motivo";

                var id = await conection.QueryAsync<int>(sqlMax);
                info.idmotivo = id.FirstOrDefault() + 1;

                string sqlInsert = "INSERT INTO tb_motivo (idmotivo,nom_motivo,estado) VALUES(@idmotivo,@nom_motivo,@estado)";


                await conection.QueryAsync(sqlInsert, info);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Update Enterprise
        public async Task<Tb_Motivo> updateMotivo(Tb_Motivo info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlInser = "UPDATE tb_motivo SET nom_motivo = @nom_motivo, estado = @estado, WHERE idmotivo = @idmotivo";



                await conection.QueryAsync(sqlInser, info);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> deleteMotivo(Tb_Motivo info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlInser = "DELETE FROM tb_motivo WHERE idmotivo = @idmotivo";

                await conection.QueryAsync(sqlInser, info);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
