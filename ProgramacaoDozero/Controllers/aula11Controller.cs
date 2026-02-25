
using Microsoft.AspNetCore.Mvc;
using ProgramacaoDozero.Models;

namespace ProgramacaoDozero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "marrom";
            meuVeiculo.Marca = "chevollet";
            meuVeiculo.Modelo = "suv";
            meuVeiculo.Placa = "eliel";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();



            return meuVeiculo;

        }

        [HttpGet("obterCarro")]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Placa = "Dtr-2354";
            meuCarro.Cor = "AZUL";

            return meuCarro;
        }
        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "YAMARRA";
            minhaMoto.Modelo = "faize";
            minhaMoto.Cor = "azul";
            minhaMoto.Placa = "eded-212";

            return minhaMoto;
        }

    }
}
