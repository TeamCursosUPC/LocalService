using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class Local
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string nombre_contacto { get; set; }

        [DataMember]
        public string telefono_contacto { get; set; }

        [DataMember]
        public string distrito { get; set; }

        [DataMember]
        public string direccion { get; set; }
    }
}