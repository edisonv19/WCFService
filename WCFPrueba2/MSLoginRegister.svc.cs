using GEN.DomainObjects;
using REL.Business;
using REL.DomainObjects;
using System;
using System.Collections.Generic;

namespace WCFPrueba2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service2" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service2.svc o Service2.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MSLoginRegister : IMSLoginRegister
    {
        #region CONSTANTES

        private const string MOBILE = "M";
        
        #endregion

        public UsuarioValidacion ValidarUsuario(string usuario, string pass, string plataforma)
        {
            try
            {
                using (UsuarioBusiness oVotacionBusiness = new UsuarioBusiness())
                {
                    return oVotacionBusiness.ValidarUsuario(usuario, pass, plataforma == null ? MOBILE : plataforma);
                }
            }
            catch (Exception e)
            {
                return new UsuarioValidacion() { Result = e.Message };
            }
        }

        public string InsertUsuario(string usuario, string pass, int idPersona, bool esAdmin)
        {
            try
            {
                using (UsuarioBusiness oUsuarioBusiness = new UsuarioBusiness())
                {
                    Usuario oUsuario = new Usuario()
                    {
                        User = usuario,
                        Pass = pass,
                        IdPersona = idPersona,
                        UsuarioAlta = usuario,
                        EsAdmin = esAdmin
                    };

                    oUsuarioBusiness.InsertUsuario(oUsuario);

                    return "OK";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string InsertPersona(string nombre, string apellido, decimal DNI, string fecNac, int idCompania, string usuarioAlta)
        {
            try
            {
                DateTime fecNacDate = DateTime.Parse(fecNac);

                using (PersonaBusiness oPersonaBusiness = new PersonaBusiness())
                {
                    Persona oPersona = new Persona()
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        DNI = DNI,
                        FecNac = fecNacDate,
                        IdCompania = idCompania,
                        UsuarioAlta = usuarioAlta
                    };

                    oPersonaBusiness.InsertPersona(oPersona);

                    return "OK";
                }
            }
            catch (Exception)
            {
                return "Error al insertar la persona";
            }
        }

        public string InsertCompania(string nombre, decimal CUIT, int tipoCompania, string usuarioAlta)
        {
            try
            {
                using (CompaniaBusiness oCompaniaBusiness = new CompaniaBusiness())
                {
                    Compania oCompania = new Compania()
                    {
                        Nombre = nombre,
                        CUIT = CUIT,
                        TipoCompania = tipoCompania,
                        UsuarioAlta = usuarioAlta
                    };

                    oCompaniaBusiness.InsertCompania(oCompania);

                    return "OK";
                }
            }
            catch (Exception)
            {
                return "Error al agregar compania";
            }
        }

        public List<ItemForCombo> GetPersonasForCombo(int idCompania)
        {
            try
            {
                using (PersonaBusiness oVotacionBusiness = new PersonaBusiness())
                {
                    return oVotacionBusiness.GetPersonaForCombo(idCompania);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
