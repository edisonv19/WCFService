using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace REL.DataAccess
{
    public class GrupoPersonaDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "REL_GrupoPersona";

        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Obtiene un registro de GEN_Valores por un id
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public DataSet GetByID(GrupoPersona oGrupoPersona)
        {
            // Creo la conexión y la transacción
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            DataSet ds = new DataSet();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand oComm = new SqlCommand())
                    {
                        oComm.Connection = oTran != null ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = ObjectName + "_GetByID";

                        oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdGrupo));
                        oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdPersona));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoPersona.RowId));

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);

                        oTran.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw e;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return ds;
        }

        /// <summary>
        /// Inserta un registro en GEN_Valores
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public GrupoPersona Insert(GrupoPersona oGrupoPersona)
        {
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            try
            {
                using (SqlCommand oComm = new SqlCommand())
                {
                    oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                    oComm.Transaction = oTran;

                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.CommandText = ObjectName + "_Insert";

                    oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdGrupo));
                    oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdPersona));

                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoPersona.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oGrupoPersona.IdGrupo = (int)oComm.Parameters["@IdGrupo"].Value;
                    oGrupoPersona.IdPersona = (int)oComm.Parameters["@IdPersona"].Value;
                    oGrupoPersona.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception("Hubo un error al insertar una Persona a un grupo en la base de datos.");
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oGrupoPersona;
        }

        /// <summary>
        /// Inserta un registro en GEN_Valores
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public GrupoPersona Insert(SqlConnection oConn, SqlTransaction oTran, GrupoPersona oGrupoPersona)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.StoredProcedure;
                oComm.CommandText = ObjectName + "_Insert";

                oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdGrupo));
                oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdPersona));

                oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoPersona.UsuarioAlta));
                oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.RowId));

                int rowsAffected = oComm.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                }

                oGrupoPersona.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;
            }

            return oGrupoPersona;
        }

        /// <summary>
        /// Inserta un registro en GEN_Valores
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public void Delete(SqlConnection oConn, SqlTransaction oTran, GrupoPersona oGrupoPersona)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.StoredProcedure;
                oComm.CommandText = ObjectName + "_Delete";

                oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdGrupo));
                oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdPersona));

                oComm.ExecuteNonQuery();
            }
        }

        public void InsertGrupoPersona(List<GrupoPersona> oListGrupoPersona, int idGrupo)
        {
            // Creo la comunicación y la transaccion
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            try
            {
                this.InsertGrupoPersona(oConn, oTran, oListGrupoPersona, idGrupo);

                oTran.Commit();
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }
        }

        public void InsertGrupoPersona(SqlConnection oConn, SqlTransaction oTran, List<GrupoPersona> oListGrupoPersona, int idGrupo)
        {
            // Agrego todas las personas una por una
            foreach (GrupoPersona oGrupoPersona in oListGrupoPersona)
            {
                this.Insert(oConn, oTran, oGrupoPersona);
            }
        }

        public void UpdateGrupoPersona(SqlConnection oConn, SqlTransaction oTran, List<GrupoPersona> oListGrupoPersona, int idGrupo)
        {
            // Elimino todas las personas del grupo
            this.Delete(oConn, oTran, new GrupoPersona() { IdGrupo = idGrupo });

            // Agrego todas las personas una por una
            foreach (GrupoPersona oGrupoPersona in oListGrupoPersona)
            {
                this.Insert(oConn, oTran, oGrupoPersona);
            }
        }

        public DataSet GetListByFilter(GrupoPersona oGrupoPersona)
        {
            // Creo la conexión y la transacción
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            DataSet ds = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand oComm = new SqlCommand())
                    {
                        oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = ObjectName + "_GetListByFilter";

                        oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdGrupo));
                        oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoPersona.IdPersona));

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw e;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return ds;
        }
    }
}
