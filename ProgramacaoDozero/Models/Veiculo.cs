
namespace ProgramacaoDozero.Models
{
    public class Veiculo
    {    //construtor
        public Veiculo()
        {
            TanqueCombustivel = 40;
        }

        //atributos ou propriedades
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int TanqueCombustivel { get; set; }
       
        //métodos
        
        public virtual void  Acelerar()
        {
            TanqueCombustivel = TanqueCombustivel - 1;
        }
        public void Frear()
        {
            InjetarCombustivel(4);
        }

        private void InjetarCombustivel(int quantidadedeCombustivel)
        {
            TanqueCombustivel -= quantidadedeCombustivel;

        }
    }


}
