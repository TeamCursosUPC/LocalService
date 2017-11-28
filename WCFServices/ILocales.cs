using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServices.Dominio;

namespace WCFServices
{
    [ServiceContract]
    public interface ILocales
    {
        [OperationContract]
        [WebGet]
        List<Local> ListarLocal();
    }
}
