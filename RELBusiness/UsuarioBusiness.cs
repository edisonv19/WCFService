using REL.DataAccess;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace REL.Business
{
    /// <summary>
    /// Business de la tabla Usuario
    /// </summary>
    public class UsuarioBusiness : IDisposable
    {
        private const string WEB = "W";

        public void Dispose()
        {
        }

        public Usuario GetUsuarioById(Usuario oUsuario)
        {
            using (UsuarioDataAccess tDataAccess = new UsuarioDataAccess())
            {
                DataSet ds = tDataAccess.GetByID(oUsuario);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return Usuario.GetFromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public Usuario InsertUsuario(Usuario oUsuario)
        {
            // Busco si existe la persona - Si no existe, creo Excepcion
            using (PersonaBusiness oPersonaBusiness = new PersonaBusiness())
            {
                if (oPersonaBusiness.GetPersonaById(new Persona() { IdPersona = oUsuario.IdPersona }) == null)
                {
                    throw new Exception(string.Format("La persona con id {0} no existe", oUsuario.IdPersona));
                }
            }

            // Busco si ya existe el usuario - Si existe, creo Excepcion
            if (this.GetUsuarioById(oUsuario) != null)
            {
                throw new Exception(string.Format("El usuario {0} ya existe", oUsuario.User));
            }

            // Inserto el usuario
            using (UsuarioDataAccess tDataAccess = new UsuarioDataAccess())
            {
                // Encripto el pass + SALT
                oUsuario.Pass = EncriptarSHA256(oUsuario.Pass + oUsuario.User);

                tDataAccess.Insert(oUsuario);
            }

            return this.GetUsuarioById(oUsuario);
        }

        /// <summary>
        /// Función para incriptar una entrada
        /// </summary>
        /// <param name="oTipoValorFilter"></param>
        /// <returns></returns>
        public string EncriptarSHA256(string randomString)
        {
            byte[] crypto;

            using (SHA256Managed oCryp = new SHA256Managed())
            {
                crypto = oCryp.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0, Encoding.UTF8.GetByteCount(randomString));
            }

            StringBuilder hash = new StringBuilder();
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

        /// <summary>
        /// Validar usuario con contraseña
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="supuestoPass"></param>
        /// <returns></returns>
        public UsuarioValidacion ValidarUsuario(string usuario, string supuestoPass, string plataforma)
        {
            UsuarioValidacion oUsuarioValidacion = new UsuarioValidacion();

            // Obtengo el usuario
            Usuario user = this.GetUsuarioById(new Usuario() { User = usuario });

            if (user == null)
            {
                oUsuarioValidacion.Result = "El usuario no existe";
                return oUsuarioValidacion;
            }

            // Si no es admin, no puede loguearse a la aplicación web
            if (plataforma.Equals(WEB) && !user.EsAdmin)
            {
                oUsuarioValidacion.Result = "No posee los permisos suficientes para acceder";
                return oUsuarioValidacion;
            }

            // Obtengo el supuesto HASH
            string supuestoHash = EncriptarSHA256(supuestoPass+usuario);

            // Comparo si los HASH son iguales => Si son iguales, el PASS es el correcto
            oUsuarioValidacion.Result = supuestoHash.Equals(user.Pass) ? "OK" : "Contraseña incorrecta";

            // Si no es válido, no necesito el id
            if (oUsuarioValidacion.Result.Equals("OK"))
            {
                oUsuarioValidacion.IdPersona = user.IdPersona;

                // Obtengo datos de la persona
                using (PersonaBusiness oPersonaBusiness = new PersonaBusiness())
                {
                    Persona oPersona = oPersonaBusiness.GetPersonaById(new Persona() { IdPersona = user.IdPersona });
                    oUsuarioValidacion.Nombre = oPersona.Nombre;
                    oUsuarioValidacion.Apellido = oPersona.Apellido;
                    oUsuarioValidacion.IdCompania = oPersona.IdCompania;
                }
            }

            return oUsuarioValidacion;
        }
    }
}
