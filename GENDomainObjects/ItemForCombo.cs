using System;
using System.Collections.Generic;
using System.Data;

namespace GEN.DomainObjects
{
    public class ItemForCombo
    {
        #region PROPERTIES

        public string Description { get; set; }
        public string Value { get; set; }

        #endregion

        #region METHODS

        /// <summary>
        /// Retorna una "ItemForCombo" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 22/10/2017
        /// Última modificación: 22/10/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>ItemForCombo construido en función de la información dada como parámetro</returns>
        public static ItemForCombo GetFromDataRow(DataRow row)
        {
            ItemForCombo oItemForCombo = new ItemForCombo()
            {
                Description = Convert.ToString(row["Description"]),
                Value = Convert.ToString(row["Value"])
            };

            return oItemForCombo;
        }

        /// <summary>
        /// Retorna una lista de "ItemForCombo", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 22/10/2017
		/// Última modificación: 22/10/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<ItemForCombo> construida en función de la información dada como párametro</returns>
        public static List<ItemForCombo> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<ItemForCombo> retList = new List<ItemForCombo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }
        #endregion

    }
}
