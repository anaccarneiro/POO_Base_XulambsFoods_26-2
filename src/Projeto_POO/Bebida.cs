using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XulambsFoods.Sobremesa;

namespace XulambsFoods
{
    internal class Bebida : ItensPedidos
    {
        public enum TipoBebida
        {
            AguaDaCasa,
            AguaComGas,
            ChaComGas,
            Suco,
            Cerveja,
            TacaDeVinho
        }

        // Falta método de extensão

        private TipoSobremesa _opcao;

        public Bebida(string descricao, double precoBase)
            : base(descricao, precoBase)
        {
        }

        public override double CalcularValorFinal()
        {
            return _precoBase;
        }
    }
}
