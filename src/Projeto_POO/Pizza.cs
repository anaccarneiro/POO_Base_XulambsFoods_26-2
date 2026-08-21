using System;


namespace XulambsFoods {    
    public class Pizza {

        private int _maxIngredientes;
        private double _precoBase;
        private int _quantIngredientes;
        private double _valorPorAdicional;
        private string _descricao;

        private void Init(int adicionais)
        {
            _descricao = "Pizza";
            _maxIngredientes = 8;
            _precoBase = 29d;
            AdicionarIngredientes(adicionais);
            _valorPorAdicional = 5d;
        }
      
        public Pizza() {
            Init(0);
        }

        public Pizza(int adicionais) 
        {
            Init(adicionais);
        }
       

        #region métodos privados
        private double ValorAdicionais() 
        {
            return _quantIngredientes * _valorPorAdicional;
        }

        private void ModificarDescricao() {
            _descricao = $"Pizza com {_quantIngredientes} adicionais";
        }

        private bool PodeAdicionar(int quantos) 
        {
            if (_quantIngredientes + quantos <= _maxIngredientes && quantos >= 0)
            {
                return true;
            }

            return false;

        }
        #endregion

        #region métodos públicos
        public double CalcularValorFinal() {
            return _precoBase + ValorAdicionais();
        }

        public int AdicionarIngredientes(int quantos) {
            if (PodeAdicionar(quantos)) {
                _quantIngredientes = _quantIngredientes + quantos;
                ModificarDescricao();
            }
            return _quantIngredientes;
        }

        public string GerarCupom() 
        {
            return $"{_descricao}\n Valor: {CalcularValorFinal():C2}";
        }
        #endregion

    }
}