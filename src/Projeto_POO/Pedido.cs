using System.Text;

namespace XulambsFoods {
    public abstract class Pedido {
        private List<ItensPedidos> _itens;
        private static int s_ultimoPedido=0;
        private int _idPedido;
        private DateOnly _data;
        private bool _aberto;

        public Pedido() {
            _itens = new List<ItensPedidos>();
            _aberto = true;
            _data =  DateOnly.FromDateTime(DateTime.Now);
            s_ultimoPedido++;
            _idPedido = _data.Day*100 + s_ultimoPedido;
        }

        protected virtual void PodeAdicionar() {
            if (!_aberto)
                throw new PedidoFechadoException();
        } //virtual: autorização para ser sobrescrito.

        public int Adicionar(ItensPedidos item) {
            if (item == null)
                throw new ArgumentNullException("Pizza não foi criada");
            
            PodeAdicionar();
            _itens.Add(item);
            return _itens.Count;
        }

        public void FecharPedido() {
            _aberto = false;
        }

        public abstract double PrecoAPagar();
        
        protected double ValorItens(){
            double preco = 0d;
            foreach (ItensPedidos item in _itens) {
                preco += item.CalcularValorFinal();
            }
            return preco;
        }

        protected string CabecalhoPedido()
        {
            StringBuilder relat = new StringBuilder($"Pedido nº{_idPedido} - {_data}\n");
            string estado = "fechado";
            if (_aberto)
                estado = "aberto";
            relat.AppendLine($"Pedido {estado}.");
            int i = 0;
            foreach (Pizza pizza in _pizzas)
            {
                relat.AppendLine($"{++i:D2} {pizza.ToString()}");
            }
            return relat.ToString();
        }

        protected virtual string RodapePedido()
        {
            return $"\nTOTAL DO PEDIDO: {PrecoAPagar():C2}";
        }

        
        public override string ToString() {
            return $"{CabecalhoPedido()}\n{RodapePedido()}";
        }

        public override bool Equals(object? obj) {
            Pedido outro = obj as Pedido;
            return this._idPedido == outro._idPedido;
        }

        public override int GetHashCode() {
            return _idPedido;
        }
    }
}
