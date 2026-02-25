using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDozero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class aula8Contralador : ControllerBase
    {

        [HttpGet("olaMundo")]

        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API, voce é um viado";
            return mensagem;

        }

        [HttpGet("olaMundoPersonalizado")]


        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá Mundo personalizado via api " + nome;
            return mensagem;

        }
        [HttpGet("somar")]

        
        public string somar(int primeiro,int segundo)
        {
            var resultado = primeiro + segundo;
            var mensagem ="Olá Mundo o resultado deu " + resultado;
            return mensagem;
        }

    }
}
