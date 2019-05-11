using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using REL.DomainObjects;

namespace REL.DataAccess
{
    public class UsuarioDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "REL_Usuario";

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
        public DataSet GetByID(Usuario oUsuario)
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

                        oComm.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oUsuario.User));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oUsuario.RowId));

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
        public Usuario Insert(Usuario oUsuario)
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

                    oComm.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oUsuario.User));
                    oComm.Parameters.Add(new SqlParameter("@Pass", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oUsuario.Pass));
                    oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oUsuario.IdPersona));
                    oComm.Parameters.Add(new SqlParameter("@EsAdmin", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oUsuario.EsAdmin));

                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oUsuario.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oUsuario.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oUsuario.User = (string)oComm.Parameters["@Usuario"].Value;
                    oUsuario.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

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

            return oUsuario;
        }
    }
}
