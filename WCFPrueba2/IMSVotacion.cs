using GEN.DomainObjects;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFPrueba2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMSVotacion
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetValoresByFilter?campo={campo}&valor={valor}&descripcion={descripcion}&claveEntidad={claveEntidad}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<TipoValor> GetValoresByFilter(string campo, string valor, string descripcion, string claveEntidad);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertVoto",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertVoto(int idPersona, int idPuntuacion, string comentario, string usuarioAlta);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetListByFilter?idPersona={idPersona}&puntuacion={puntuacion}&comentario={comentario}&fechaAltaFrom={fechaAltaFrom}&fechaAltaTo={fechaAltaTo}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<Voto> GetListByFilter(string idPersona, string puntuacion, string comentario, string fechaAltaFrom, string fechaAltaTo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetVotoById?idPersona={idPersona}&fechaVoto={fechaVoto}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        Voto GetVotoById(int idPersona, string fechaVoto);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetDatosCrudosByFilter?idCompania={idCompania}&nombre={nombre}&apellido={apellido}&idPuntuacion={idPuntuacion}&comentario={comentario}&fechaAltaFrom={fechaAltaFrom}&fechaAltaTo={fechaAltaTo}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<DatoCrudo> GetDatosCrudosByFilter(string idCompania, string nombre, string apellido, string idPuntuacion, string comentario, string fechaAltaFrom, string fechaAltaTo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetResumen?idCompania={idCompania}&fechaAlta={fechaAlta}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<DatoResumen> GetResumen(int idCompania, string fechaAlta);
    }
}
