using notificacionesWeb.entity.Models;
using System.Data.SqlClient;
using Dapper;



namespace notificacionesWeb.Data
{
    public class TbSubMotivoData
    {
        public TbSubMotivoData() 
        { 
        }

        public async Task<List<Tb_Sub_Motivos>> getSubMotivo()
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sql = @"select * from tb_sub_motivos";

                var lisTemp = await conection.QueryAsync<Tb_Sub_Motivos>(sql);
                return lisTemp.ToList();

            }
            catch (Exception ex)
            {
                return new List<Tb_Sub_Motivos>();
            }
        }


        public async Task<Tb_Sub_Motivos> insertSubMotivo(Tb_Sub_Motivos info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlMax = "select isnull(max(id_sub_motivo),0) from tb_sub_motivos";

                var id = await conection.QueryAsync<int>(sqlMax);
                info.id_sub_motivo = id.FirstOrDefault() + 1;

                string sqlInser = "INSERT INTO tb_sub_motivos (id_sub_motivo,id_motivo,nom_sub_motivo,estado)" +
                    "VALUES(@idsub,@idmo,@nomsub,@estad)";


                var newpara = new
                {
                    idsub = info.id_sub_motivo,
                    idmo = info.motivoEm.idmotivo,
                    nomsub = info.nom_sub_motivo,
                    estad = info.estado,
                 
                };


                await conection.QueryAsync(sqlInser, newpara);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Tb_Sub_Motivos> updateSubMotivo(Tb_Sub_Motivos info)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlUpdate = "UPDATE tb_sub_motivos SET nom_motivo = @nom_motivo, estado = @estado WHERE id_sub_motivo = @id_sub_motivo";

                await conection.ExecuteAsync(sqlUpdate, info);

                return info;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> deleteSubMotivo(int id)
        {
            try
            {
                var conection = new SqlConnection(connectionDB.CadenaConnection);

                string sqlDelete = "DELETE FROM tb_sub_motivos WHERE id_sub_motivo = @id_sub_motivo";

                await conection.ExecuteAsync(sqlDelete, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal async Task<bool> deleteSubMotivo(Tb_Sub_Motivos info)
        {
            throw new NotImplementedException();
        }



    }
}
