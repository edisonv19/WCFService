using System;
using System.Collections.Generic;
using System.Data;

namespace GEN.DomainObjects
{
    public class TipoValor
    {
        #region PROPIEDADES

        public int? IdValores { get; set; }
        public string Campo { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public bool? Borrado { get; set; }
        public int? IdEntidad { get; set; }
        public DateTime? FechaUltModif { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string UsuarioUltModif { get; set; }
        public string UsuarioAlta { get; set; }
        public byte[] RowId { get; set; }

        public string ClaveEntidad { get; set; }

        #endregion

        #region METODOS

        /// <summary>
        /// Retorna una "TipoValor" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 02/06/2017
        /// Última modificación: 02/06/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>TipoValor construido en función de la información dada como parámetro</returns>
        public static TipoValor GetFromDataRow(DataRow row)
        {
            TipoValor oTipoValor = new TipoValor()
            {
                IdValores = Convert.ToInt32(row["IdValores"]),
                Campo = Convert.ToString(row["Campo"]),
                Valor = Convert.ToString(row["Valor"]),
                Descripcion = Convert.ToString(row["Descripcion"]),
                IdEntidad = Convert.ToInt32(row["IdEntidad"])
            };

            if (row.Table.Columns.Contains("Borrado"))
                oTipoValor.Borrado = Convert.ToBoolean(row["Borrado"]);
            if (row.Table.Columns.Contains("FechaAlta"))
                oTipoValor.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
            if (row.Table.Columns.Contains("UsuarioAlta"))
                oTipoValor.UsuarioAlta = Convert.ToString(row["UsuarioAlta"]);
            if (row.Table.Columns.Contains("FechaUltModif"))
                oTipoValor.FechaUltModif = Convert.ToDateTime(row["FechaUltModif"]);
            if (row.Table.Columns.Contains("UsuarioUltModif"))
                oTipoValor.UsuarioUltModif = Convert.ToString(row["UsuarioUltModif"]);
            if (row.Table.Columns.Contains("RowId"))
                oTipoValor.RowId = (Byte[])row["RowId"];

            return oTipoValor;
        }

        /// <summary>
        /// Retorna una lista de "TipoValor", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 04/06/2017
		/// Última modificación: 04/06/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<TipoValor> construida en función de la información dada como párametro</returns>
        public static List<TipoValor> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<TipoValor> retList = new List<TipoValor>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }

        #endregion
    }
}
