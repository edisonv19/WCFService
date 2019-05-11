using GEN.Business;
using GEN.DomainObjects;
using System.Collections.Generic;
using System.ServiceModel.Web;
using REL.DomainObjects;
using System;
using REL.Business;
using System.Net;

namespace WCFPrueba2
{
    public class MSVotacion : IMSVotacion
    {
        public List<TipoValor> GetValoresByFilter(string campo, string valor, string descripcion, string claveEntidad)
        {
            try
            {
                TipoValorFilter oTipoValorFilter = new TipoValorFilter()
                {
                    Campo = campo,
                    ClaveEntidad = claveEntidad,
                    Valor = valor,
                    Descripcion = descripcion
                };

                using (ValoresBusiness oValoresBusiness = new ValoresBusiness())
                {
                    return oValoresBusiness.GetValoresByFilter(oTipoValorFilter);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Voto> GetListByFilter(string idPersona, string puntuacion, string comentario, string fechaAltaFrom, string fechaAltaTo)
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

                VotoFilter oVoto = new VotoFilter()
                {
                    IdPersona = idPersonaInt,
                    Puntuacion = puntuacion,
                    Comentario = comentario,
                    FechaAltaFrom = fechaAltaFromDate,
                    FechaAltaTo = fechaAltaToDate
                };

                using (VotoBusiness oVotoBusiness = new VotoBusiness())
                {
                    return oVotoBusiness.GetValoresByFilter(oVoto);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string InsertVoto(int idPersona, int idPuntuacion, string comentario, string usuarioAlta)
        {
            try
            {
                Voto oVoto = new Voto()
                {
                    IdPersona = idPersona,
                    IdPuntuacion = idPuntuacion,
                    Comentario = comentario,
                    UsuarioAlta = usuarioAlta,
                    FechaAlta = DateTime.Today
                };

                using (VotoBusiness oVotoBusiness = new VotoBusiness())
                {
                    oVotoBusiness.InsertVoto(oVoto);
                }

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Voto GetVotoById(int idPersona, string fechaVoto)
        {
            try
            {
                Voto oVoto = new Voto()
                {
                    IdPersona = idPersona,
                    FechaAlta = DateTime.Parse(fechaVoto)
                };

                using (VotoBusiness oVotoBusiness = new VotoBusiness())
                {
                    return oVotoBusiness.GetVotoById(oVoto);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DatoCrudo> GetDatosCrudosByFilter(string idCompania, string nombre, string apellido, string idPuntuacion, string comentario, string fechaAltaFrom, string fechaAltaTo)
        {
            try
            {
                int? idCompaniaInt = null;
                int? idPuntuacionInt = null;
                DateTime? fechaAltaFromDate = null;
                DateTime? fechaAltaToDate = null;

                // Pregunto sobre los valores para no cargar null
                if (!string.IsNullOrEmpty(idCompania))
                {
                    idCompaniaInt = Int32.Parse(idCompania);
                }

                if (!string.IsNullOrEmpty(idPuntuacion))
                {
                    idPuntuacionInt = Int32.Parse(idPuntuacion);
                }

                if (!string.IsNullOrEmpty(fechaAltaFrom))
                {
                    fechaAltaFromDate = DateTime.Parse(fechaAltaFrom);
                }

                if (!string.IsNullOrEmpty(fechaAltaTo))
                {
                    fechaAltaToDate = DateTime.Parse(fechaAltaTo);
                }

                DatoCrudoFilter oDatoCrudoFilter = new DatoCrudoFilter()
                {
                    IdCompania = idCompaniaInt,
                    Nombre = nombre == string.Empty ? null : nombre,
                    Apellido = apellido == string.Empty ? null : apellido,
                    IdPuntuacion = idPuntuacionInt,
                    Comentario = comentario == string.Empty ? null : comentario,
                    FechaAltaFrom = fechaAltaFromDate,
                    FechaAltaTo = fechaAltaToDate
                };

                using (VotoBusiness oVotoBusiness = new VotoBusiness())
                {
                    return oVotoBusiness.GetDatosCrudosByFilter(oDatoCrudoFilter);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DatoResumen> GetResumen(int idCompania, string fechaAlta)
        {
            try
            {
                DateTime? fechaAltaDate = null;

                // Pregunto sobre los valores para no cargar null
                if (!string.IsNullOrEmpty(fechaAlta))
                {
                    fechaAltaDate = DateTime.Parse(fechaAlta);
                }

                using (VotoBusiness oVotoBusiness = new VotoBusiness())
                {
                    return oVotoBusiness.GetResumen(new DatoResumenFilter() { IdCompania = idCompania, FechaAlta = fechaAltaDate });
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
