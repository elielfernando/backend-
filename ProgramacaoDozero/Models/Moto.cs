namespace ProgramacaoDozero.Models
{
    public class Moto: Veiculo
    {
        public Moto()
        {
            QuantidadeRodas = 2;
            TanqueCombustivel = 15;
        }
        public override void Acelerar()
        {
            InjetarCombustível(4);
            base.Acelerar();
        }
        
       

        
        private void InjetarCombustível(int quantidadedeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadedeCombustivel;

        }
        public int QuantidadeRodas { get; set; }
    }
}
