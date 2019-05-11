using GEN.DomainObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GEN.DataAccess
{
    public class ValoresDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "GEN_Valores";

        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public DataSet GetListByFilter(TipoValorFilter oTipoValorFilter)
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

                        oComm.Parameters.Add(new SqlParameter("@Valor", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValorFilter.Valor));
                        oComm.Parameters.Add(new SqlParameter("@Campo", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValorFilter.Campo));
                        oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValorFilter.Descripcion));
                        oComm.Parameters.Add(new SqlParameter("@ClaveEntidad", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValorFilter.ClaveEntidad));

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

        /// <summary>
        /// Obtiene un registro de GEN_Valores por un id
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public DataSet GetByID(TipoValor oTipoValor)
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

                        oComm.Parameters.Add(new SqlParameter("@IdValores", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.IdValores));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oTipoValor.RowId));

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
        public TipoValor Insert(TipoValor oTipoValor)
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

                    oComm.Parameters.Add(new SqlParameter("@IdValores", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oTipoValor.IdValores));
                    oComm.Parameters.Add(new SqlParameter("@Campo", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.Campo));
                    oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.Descripcion));
                    oComm.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.Valor));
                    oComm.Parameters.Add(new SqlParameter("@ClaveEntidad", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.ClaveEntidad));

                    oComm.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oTipoValor.FechaAlta));
                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oTipoValor.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oTipoValor.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oTipoValor.IdValores = (int)oComm.Parameters["@IdValor"].Value;
                    oTipoValor.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oTipoValor;
        }

        /// <summary>
        /// Actualiza un registro en GEN_Valores
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public TipoValor Update(TipoValor oTipoValor)
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
                    oComm.CommandText = ObjectName + "_Update";

                    oComm.Parameters.Add(new SqlParameter("@IdValores", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.IdValores));
                    oComm.Parameters.Add(new SqlParameter("@Campo", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.Campo));
                    oComm.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.Descripcion));
                    oComm.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.Valor));
                    oComm.Parameters.Add(new SqlParameter("@ClaveEntidad", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.ClaveEntidad));

                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oTipoValor.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    oTipoValor.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oTipoValor;
        }

        /// <summary>
        /// Elimina un registro en GEN_Valores
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public TipoValor Delete(TipoValor oTipoValor)
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
                    oComm.CommandText = ObjectName + "_Delete";

                    oComm.Parameters.Add(new SqlParameter("@IdValores", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oTipoValor.IdValores));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oTipoValor.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    oTipoValor.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch
            {
                oTran.Rollback();
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oTipoValor;
        }
    }
}
