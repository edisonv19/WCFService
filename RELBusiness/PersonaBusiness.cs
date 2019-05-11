using GEN.DomainObjects;
using REL.DataAccess;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;

namespace REL.Business
{
    public class PersonaBusiness : IDisposable
    {
        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {
            
        }

        public Persona GetPersonaById(Persona oPersona)
        {
            using (PersonaDataAccess tDataAccess = new PersonaDataAccess())
            {
                DataSet ds = tDataAccess.GetByID(oPersona);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Persona.GetFromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public Persona InsertPersona(Persona oPersona)
        {
            using (PersonaDataAccess tDataAccess = new PersonaDataAccess())
            {
                tDataAccess.Insert(oPersona);
            }

            return this.GetPersonaById(oPersona);
        }

        public List<ItemForCombo> GetPersonaForCombo(int IdCompania)
        {
            using (PersonaDataAccess oPersonaDataAccess = new PersonaDataAccess())
            {
                DataSet ds = oPersonaDataAccess.GetPersonaForCombo(IdCompania);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ItemForCombo.GetFromDS(ds);
                }
            }
            return null;
        }
    }
}
