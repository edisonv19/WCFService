using System;
using System.Collections.Generic;
using System.Data;

namespace REL.DomainObjects
{
    public class DatoResumen
    {
        public int IdValores { get; set; }
        public string Puntuacion { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }

        #region METODOS

        /// <summary>
        /// Retorna una "DatoResumen" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 02/12/2017
        /// Última modificación: 02/12/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>DatoResumen construido en función de la información dada como parámetro</returns>
        public static DatoResumen GetFromDataRow(DataRow row)
        {
            DatoResumen oDatoResumen = new DatoResumen()
            {
                IdValores = Convert.ToInt32(row["IdValores"]),
                Puntuacion = Convert.ToString(row["Puntuacion"]),
                Cantidad = Convert.ToInt32(row["Cantidad"]),
                Imagen = Convert.ToString(row["Imagen"])
            };

            return oDatoResumen;
        }

        /// <summary>
        /// Retorna una lista de "DatoResumen", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 02/12/2017
        /// Última modificación: 02/12/2017
        /// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<CriteriosAsignacion> construida en función de la información dada como párametro</returns>
        public static List<DatoResumen> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<DatoResumen> retList = new List<DatoResumen>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }
        #endregion
    }
}
