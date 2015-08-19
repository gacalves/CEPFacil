using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CEP_Fácil
{
    [DataContract]
    public class EstadoInfo
    {
        [DataMember]
        public string area_km2 { get; set; }
        [DataMember]
        public string codigo_ibge { get; set; }
        [DataMember]
        public string nome { get; set; }
    }

    [DataContract]
    public class CidadeInfo
    {
        [DataMember]
        public string area_km2 { get; set; }
        [DataMember]
        public string codigo_ibge { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string bairro { get; set; }
        [DataMember]
        public string cidade { get; set; }
        [DataMember]
        public string cep { get; set; }
        [DataMember]
        public string logradouro { get; set; }
        [DataMember]
        public EstadoInfo estado_info { get; set; }
        [DataMember]
        public CidadeInfo cidade_info { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}
