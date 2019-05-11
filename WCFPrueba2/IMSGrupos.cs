using REL.DomainObjects;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFPrueba2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMSGrupos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMSGrupos
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertGrupo",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertGrupo(string nombre, string descripcion, int idCompania, string usuario);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertGrupoFull",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertGrupoFull(string nombre, string descripcion, int idCompania, List<int> personas, string usuario);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/UpdateGrupoFull",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string UpdateGrupoFull(int idGrupo, string nombre, string descripcion, List<int> personas, string usuario, string rowId);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/DeleteGrupoFull",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DeleteGrupoFull(int idGrupo, string usuario, string rowId);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/InsertGrupoPersona",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string InsertGrupoPersona(List<int> personas, int idGrupo, string usuario);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/GetListByFilter?idCompania={idCompania}&nombre={nombre}&descripcion={descripcion}&idPersona={idPersona}&fechaAltaFrom={fechaAltaFrom}&fechaAltaTo={fechaAltaTo}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<GrupoConsulta> GetListByFilter(int idCompania, string nombre, string descripcion, string idPersona, string fechaAltaFrom, string fechaAltaTo);
    }
}
