using System;
using System.Collections.Generic;
using System.Data;

namespace REL.DomainObjects
{
    public class GrupoConsulta
    {
        public int? IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdCompania { get; set; }

        public DateTime FechaAlta { get; set; }
        public string FechaAltaString { get; set; }

        public byte[] RowId { get; set; }

        public List<int> Personas { get; set; }

        #region METODOS

        /// <summary>
        /// Retorna una "Grupo" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 07/11/2017
        /// Última modificación: 07/11/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>GrupoConsulta construido en función de la información dada como parámetro</returns>
        public static GrupoConsulta GetFromDataRow(DataRow row)
        {
            GrupoConsulta oGrupoConsulta = new GrupoConsulta()
            {
                IdGrupo = Convert.ToInt32(row["IdGrupo"]),
                Nombre = Convert.ToString(row["Nombre"]),
                Descripcion = Convert.ToString(row["Descripcion"]),
                IdCompania = Convert.ToInt32(row["IdCompania"]),
                FechaAlta = Convert.ToDateTime(row["FechaAlta"])
            };

            oGrupoConsulta.FechaAltaString = oGrupoConsulta.FechaAlta.ToString("dd/MM/yyyy");

            if (row.Table.Columns.Contains("RowId"))
                oGrupoConsulta.RowId = (Byte[])row["RowId"];

            return oGrupoConsulta;
        }

        /// <summary>
        /// Retorna una lista de "Grupo", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 07/11/2017
        /// Última modificación: 07/11/2017
        /// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<CriteriosAsignacion> construida en función de la información dada como párametro</returns>
        public static List<GrupoConsulta> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<GrupoConsulta> retList = new List<GrupoConsulta>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }
        #endregion
    }
}
