using REL.Business;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WCFPrueba2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MSGrupos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MSGrupos.svc o MSGrupos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MSGrupos : IMSGrupos
    {
        public string InsertGrupo(string nombre, string descripcion, int idCompania, string usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre.Trim()))
                {
                    throw new Exception("El nombre del grupo es obligatorio");
                }

                Grupo oGrupo = new Grupo()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    IdCompania = idCompania,
                    UsuarioAlta = usuario
                };

                using (GrupoBusiness oGrupoBusiness = new GrupoBusiness())
                {
                    oGrupo = oGrupoBusiness.InsertGrupo(oGrupo);
                }

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string InsertGrupoPersona(List<int> personas, int idGrupo, string usuario)
        {
            try
            {
                // Obtengo los objetos de las personas
                List<GrupoPersona> oListGrupoPersona = this.GetGrupoPersonas(personas, idGrupo, usuario);

                using (GrupoPersonaBusiness oGrupoBusiness = new GrupoPersonaBusiness())
                {
                    oGrupoBusiness.InsertGrupoPersona(oListGrupoPersona, idGrupo);
                }

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<GrupoConsulta> GetListByFilter(int idCompania, string nombre, string descripcion, string idPersona, string fechaAltaFrom, string fechaAltaTo)
        {
            try
            {
                int? idPersonaInt = null;
                DateTime? fechaAltaFromDate = null;
                DateTime? fechaAltaToDate = null;

                // Pregunto sobre los valores para no cargar null
                if (!string.IsNullOrEmpty(idPersona))
                {
                    idPersonaInt = Int32.Parse(idPersona);
                }

                if (!string.IsNullOrEmpty(fechaAltaFrom))
                {
                    fechaAltaFromDate = DateTime.Parse(fechaAltaFrom);
                }

                if (!string.IsNullOrEmpty(fechaAltaTo))
                {
                    fechaAltaToDate = DateTime.Parse(fechaAltaTo);
                }

                GrupoFilter oGrupoFilter = new GrupoFilter()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    IdPersona = idPersonaInt,
                    IdCompania = idCompania,
                    FechaAltaFrom = fechaAltaFromDate,
                    FechaAltaTo = fechaAltaToDate
                };

                using (GrupoBusiness oGrupoBusiness = new GrupoBusiness())
                {
                    return oGrupoBusiness.GetListByFilter(oGrupoFilter);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string InsertGrupoFull(string nombre, string descripcion, int idCompania, List<int> personas, string usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre.Trim()))
                {
                    throw new Exception("El nombre del grupo es obligatorio");
                }

                Grupo oGrupo = new Grupo()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    IdCompania = idCompania,
                    UsuarioAlta = usuario
                };

                using (GrupoBusiness oGrupoBusiness = new GrupoBusiness())
                {
                    oGrupo = oGrupoBusiness.InsertGrupoFull(oGrupo, personas);
                }

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateGrupoFull(int idGrupo, string nombre, string descripcion, List<int> personas, string usuario, string rowId)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre.Trim()))
                {
                    throw new Exception("El nombre del grupo es obligatorio");
                }

                Grupo oGrupo = new Grupo()
                {
                    IdGrupo = idGrupo,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    UsuarioUltModif = usuario,
                    RowId = Convert.FromBase64String(rowId)
                };

                using (GrupoBusiness oGrupoBusiness = new GrupoBusiness())
                {
                    oGrupo = oGrupoBusiness.UpdateGrupoFull(oGrupo, personas);
                }

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteGrupoFull(int idGrupo, string usuario, string rowId)
        {
            try
            {

                Grupo oGrupo = new Grupo()
                {
                    IdGrupo = idGrupo,
                    UsuarioUltModif = usuario,
                    RowId = Convert.FromBase64String(rowId)
            };

                using (GrupoBusiness oGrupoBusiness = new GrupoBusiness())
                {
                    oGrupoBusiness.DeleteGrupoFull(oGrupo);
                }

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        #region METODOS PRIVADOS

        private List<GrupoPersona> GetGrupoPersonas(List<int> personas, int? idGrupo, string usuario)
        {
            List<GrupoPersona> result = new List<GrupoPersona>();

            foreach (int p in personas)
            {
                GrupoPersona oGrupo = new GrupoPersona()
                {
                    IdPersona = p,
                    IdGrupo = idGrupo,
                    UsuarioAlta = usuario
                };

                result.Add(oGrupo);
            }

            return result;
        }

        #endregion
    }
}
