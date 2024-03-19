using Dapper;
using notificacionesWeb.Shared.Models;
using System.Data.SqlClient;

namespace notificacionesWeb.Data
{
    public class tb_empresasData
    {
        
        public async Task<List<tb_empresas>> getEmpresas()
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);


                string sql = "select * from tb_empresas";

                var lisTemp = await conection.QueryAsync<tb_empresas>(sql);
                return lisTemp.ToList();

            }
            catch (Exception ex)
            {
                return new List<tb_empresas>();
            }
        }
        public async Task<tb_empresas> insertEmpresa(tb_empresas info)
        {
            try
            {
                using var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlMax = "select isnull(max(idempresa),0) from tb_empresas";

                var id = await conection.QueryAsync<int>(sqlMax);
                info.idempresa = id.FirstOrDefault() + 1;

                string sqlInsert = "INSERT INTO tb_empresas (idempresa,nom_empresa,ruc_empresa,dias_gracia) VALUES(@idempresa,@nom_empresa,@ruc_empresa,@dias_gracia)";


                await conection.QueryAsync(sqlInsert, info);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Update Enterprise
        public async Task<tb_empresas> updateEmpresa(tb_empresas info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlInser = "UPDATE tb_empresas SET nom_empresa = @nom_empresa, ruc_empresa = @ruc_empresa, dias_gracia = @dias_gracia" +
                    " WHERE idempresa = @idempresa";



                await conection.QueryAsync(sqlInser, info);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> deleteEmpresa(tb_empresas info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlInser = "DELETE FROM tb_empresas WHERE idempresa = @idempresa";

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
