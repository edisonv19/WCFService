using REL.DomainObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace REL.DataAccess
{
    public class GrupoDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "REL_Grupo";

        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Obtiene un registro de REL_GRupo por un id
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public DataSet GetByID(Grupo oGrupo)
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

                        oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdGrupo));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.RowId));

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
        /// Inserta un registro en REL_Grupo
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public Grupo Insert(Grupo oGrupo)
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

                    oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdGrupo));
                    oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.Nombre));
                    oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.Descripcion));
                    oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdCompania));

                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupo.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oGrupo.IdGrupo = (int)oComm.Parameters["@IdGrupo"].Value;
                    oGrupo.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception("Hubo un error al insertar un grupo en la base de datos.");
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oGrupo;
        }

        public Grupo Insert(SqlConnection oConn, SqlTransaction oTran, Grupo oGrupo)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.StoredProcedure;
                oComm.CommandText = ObjectName + "_Insert";

                oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdGrupo));
                oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.Nombre));
                oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.Descripcion));
                oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdCompania));

                oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.UsuarioAlta));
                oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oGrupo.RowId));

                int rowsAffected = oComm.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                }

                oGrupo.IdGrupo = (int)oComm.Parameters["@IdGrupo"].Value;
                oGrupo.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;
            }

            return oGrupo;
        }

        public Grupo Update(SqlConnection oConn, SqlTransaction oTran, Grupo oGrupo)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.StoredProcedure;
                oComm.CommandText = ObjectName + "_Update";

                oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdGrupo));
                oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.Nombre));
                oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.Descripcion));

                oComm.Parameters.Add(new SqlParameter("@UsuarioUltModif", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.UsuarioUltModif));
                oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.RowId));

                int rowsAffected = oComm.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No se actualizó ningún registro. Por favor, reintente la operación.");
                }

                oGrupo.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;
            }

            return oGrupo;
        }

        public Grupo Delete(SqlConnection oConn, SqlTransaction oTran, Grupo oGrupo)
        {
            using (SqlCommand oComm = new SqlCommand())
            {
                oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                oComm.Transaction = oTran;

                oComm.CommandType = CommandType.StoredProcedure;
                oComm.CommandText = ObjectName + "_Delete";

                oComm.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.IdGrupo));
                oComm.Parameters.Add(new SqlParameter("@UsuarioUltModif", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupo.UsuarioUltModif));

                oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oGrupo.RowId));

                int rowsAffected = oComm.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No se eliminó ningún registro. Por favor, reintente la operación.");
                }
            }

            return oGrupo;
        }

        /// <summary>
        /// Obtiene grupos a través de un filtro
        /// </summary>
        /// <param name="oGrupoFilter"></param>
        /// <returns></returns>
        public DataSet GetListByFilter(GrupoFilter oGrupoFilter)
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

                        oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoFilter.IdCompania));
                        oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoFilter.Nombre));
                        oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoFilter.Descripcion));
                        oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoFilter.IdPersona));
                        oComm.Parameters.Add(new SqlParameter("@FechaAltaFrom", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoFilter.FechaAltaFrom));
                        oComm.Parameters.Add(new SqlParameter("@FechaAltaTo", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oGrupoFilter.FechaAltaTo));

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
