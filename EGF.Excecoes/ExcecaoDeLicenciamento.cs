
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EGF.Excecoes
{
    public class ExcecaoDeLicenciamento : Exception
    {
        public ExcecaoDeLicenciamento() : base("Erro ao validar licenciamento.")
        {
        }

        public ExcecaoDeLicenciamento(string message) : base(message)
        {
        }

        public ExcecaoDeLicenciamento(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExcecaoDeLicenciamento(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
