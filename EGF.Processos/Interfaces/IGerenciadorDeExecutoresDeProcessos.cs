using System;
using System.Collections.Generic;

namespace EGF.Processos.Interfaces
{
    public interface IGerenciadorDeExecutoresDeProcessos
    {
        public IDictionary<string, Type> ObterExecutores();
    }
}
