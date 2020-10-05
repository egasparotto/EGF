using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Processos.Interfaces
{
    public interface IGerenciadorDeExecutoresDeProcessos
    {
        public IDictionary<string, Type> ObterExecutores();
    }
}
