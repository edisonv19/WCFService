using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DomainObjects
{
    public class Usuario
    {
        #region PROPIEDADES
        public string User { get; set; }
        public string Pass { get; set; }
        public int? IdPersona { get; set; }
        public bool EsAdmin { get; set; }

        public bool? Borrado { get; set; }
        public DateTime? FechaUltModif { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string UsuarioUltModif { get; set; }
        public string UsuarioAlta { get; set; }

        public byte[] RowId { get; set; }
        #endregion

        #region METODOS

        /// <summary>
        /// Retorna una "persona" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 02/06/2017
        /// Última modificación: 02/06/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>Persona construido en función de la información dada como parámetro</returns>
        public static Usuario GetFromDataRow(DataRow row)
        {
            Usuario oUsuario = new Usuario()
            {
                User = Convert.ToString(row["Usuario"]),
                Pass = Convert.ToString(row["Pass"]),
                IdPersona = Convert.ToInt32(row["IdPersona"]),
                EsAdmin = Convert.ToBoolean(row["EsAdmin"]),
                Borrado = Convert.ToBoolean(row["Borrado"])
            };

            if (row.Table.Columns.Contains("Borrado"))
                oUsuario.Borrado = Convert.ToBoolean(row["Borrado"]);
            if (row.Table.Columns.Contains("FechaAlta"))
                oUsuario.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
            if (row.Table.Columns.Contains("UsuarioAlta"))
                oUsuario.UsuarioAlta = Convert.ToString(row["UsuarioAlta"]);
            if (row.Table.Columns.Contains("FechaUltModif"))
                oUsuario.FechaUltModif = Convert.ToDateTime(row["FechaUltModif"]);
            if (row.Table.Columns.Contains("UsuarioUltModif"))
                oUsuario.UsuarioUltModif = Convert.ToString(row["UsuarioUltModif"]);
            if (row.Table.Columns.Contains("RowId"))
                oUsuario.RowId = (Byte[])row["RowId"];

            return oUsuario;
        }

        /// <summary>
        /// Retorna una lista de "CriteriosAsignacion", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 04/06/2017
		/// Última modificación: 04/06/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<CriteriosAsignacion> construida en función de la información dada como párametro</returns>
        public static List<Usuario> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<Usuario> retList = new List<Usuario>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }

        #endregion
    }
}
