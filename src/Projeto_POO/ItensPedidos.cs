using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XulambsFoods
{
    public abstract class ItensPedidos
    {
        public string _descricao;
        public double _precoBase;

        protected ItensPedidos(string descricao, double precoBase)
        {
            _descricao = descricao;
            _precoBase = precoBase;
        }

        public abstract double CalcularValorFinal();
    }
}
