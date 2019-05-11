using System;
using System.Collections.Generic;
using System.Data;

namespace REL.DomainObjects
{
    public class Grupo
    {
        public int? IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdCompania { get; set; }

        public bool? Borrado { get; set; }
        public DateTime? FechaUltModif { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string UsuarioUltModif { get; set; }
        public string UsuarioAlta { get; set; }

        public byte[] RowId { get; set; }

        #region METODOS

        /// <summary>
        /// Retorna una "Grupo" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 05/11/2017
        /// Última modificación: 05/11/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>Grupo construido en función de la información dada como parámetro</returns>
        public static Grupo GetFromDataRow(DataRow row)
        {
            Grupo oGrupo = new Grupo()
            {
                IdGrupo = Convert.ToInt32(row["IdGrupo"]),
                Nombre = Convert.ToString(row["Nombre"]),
                Descripcion = Convert.ToString(row["Descripcion"]),
                IdCompania = Convert.ToInt32(row["IdCompania"])
            };

            if (row.Table.Columns.Contains("Borrado"))
                oGrupo.Borrado = Convert.ToBoolean(row["Borrado"]);
            if (row.Table.Columns.Contains("FechaAlta"))
                oGrupo.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
            if (row.Table.Columns.Contains("UsuarioAlta"))
                oGrupo.UsuarioAlta = Convert.ToString(row["UsuarioAlta"]);
            if (row.Table.Columns.Contains("FechaUltModif"))
                oGrupo.FechaUltModif = Convert.ToDateTime(row["FechaUltModif"]);
            if (row.Table.Columns.Contains("UsuarioUltModif"))
                oGrupo.UsuarioUltModif = Convert.ToString(row["UsuarioUltModif"]);
            if (row.Table.Columns.Contains("RowId"))
                oGrupo.RowId = (Byte[])row["RowId"];

            return oGrupo;
        }

        /// <summary>
        /// Retorna una lista de "Grupo", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 05/11/2017
        /// Última modificación: 05/11/2017
        /// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<CriteriosAsignacion> construida en función de la información dada como párametro</returns>
        public static List<Grupo> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<Grupo> retList = new List<Grupo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }
        #endregion
    }
}