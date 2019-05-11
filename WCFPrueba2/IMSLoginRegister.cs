using GEN.DomainObjects;
using REL.DomainObjects;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFPrueba2
{
    [ServiceContract]
    public interface IMSLoginRegister
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/ValidarUsuario?usuario={usuario}&pass={pass}&plataforma={plataforma}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        UsuarioValidacion ValidarUsuario(string usuario, string pass, string plataforma);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertUsuario",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertUsuario(string usuario, string pass, int idPersona, bool esAdmin);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertPersona",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertPersona(string nombre, string apellido, decimal DNI, string fecNac, int idCompania, string usuarioAlta);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertCompania",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertCompania(string nombre, decimal CUIT, int tipoCompania, string usuarioAlta);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetPersonasForCombo?idCompania={idCompania}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<ItemForCombo> GetPersonasForCombo(int idCompania);
    }
}
