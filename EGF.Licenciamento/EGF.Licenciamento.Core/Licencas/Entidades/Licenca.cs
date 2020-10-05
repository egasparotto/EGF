
using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Licenciamento.Core.Licencas.Entidades
{
    public class Licenca
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public string ServidorBanco { get; set; }
        public string UsuarioBanco { get; set; }
        public string SenhaBanco { get; set; }
        public string NomeBanco { get; set; }
        public string ServidorKafka { get; set; }
    }
}
