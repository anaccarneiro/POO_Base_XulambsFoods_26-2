using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XulambsFoods
{
    internal class Sobremesa : ItensPedidos
    {
        public enum TipoSobremesa
        {
            Brigadeiro,
            Pudim,
            DoceDeLeite 
        }

        private TipoSobremesa _opcao;

        public Sobremesa(string descricao, double precoBase, TipoSobremesa opcao)
            : base(descricao, precoBase)
        {
            _opcao = opcao;
        }

        public override double CalcularValorFinal()
        {
            return _precoBase;
        }
    }
}
