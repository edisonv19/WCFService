using REL.DomainObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace REL.DataAccess
{
    public class CompaniaDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "REL_Compania";

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
        public DataSet GetByID(Compania oCompania)
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

                        oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oCompania.IdCompania));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oCompania.RowId));

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
        public Compania Insert(Compania oCompania)
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

                    oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oCompania.IdCompania));
                    oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oCompania.Nombre));
                    oComm.Parameters.Add(new SqlParameter("@CUIT", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oCompania.CUIT));
                    oComm.Parameters.Add(new SqlParameter("@TipoCompania", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oCompania.TipoCompania));

                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oCompania.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oCompania.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oCompania.IdCompania = (int)oComm.Parameters["@IdCompania"].Value;
                    oCompania.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception("Hubo un error al insertar a una compañia en la base de datos.");
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oCompania;
        }
    }
}
