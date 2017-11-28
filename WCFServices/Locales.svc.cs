using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Persistencia;

namespace WCFServices
{
    [ServiceBehavior]
    public class Locales : ILocales
    {
        private LocalDAO localDAO = new LocalDAO();

        public List<Local> ListarLocal()
        {
            return localDAO.Listar();
        }
    }
}
