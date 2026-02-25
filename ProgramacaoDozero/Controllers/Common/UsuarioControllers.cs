using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using ProgramacaoDozero.Models;
using ProgramacaoDozero.Repositories;
using ProgramacaoDozero.Services;
namespace ProgramacaoDozero.Common
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "E-mail ou senha inválidos";
                return Ok(result);
            }

            var connectionString = _configuration.GetConnectionString("programacaoDoZero");
            var usuarioService = new UsuarioService(connectionString);
            result = usuarioService.Login(request.email, request.senha);

            return Ok(result);
        }

        [HttpPost("cadastro")]
        public IActionResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();
            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";
                return Ok(result);

            }


            var connectionString = _configuration.GetConnectionString("programacaoDoZero");
            var usuarioService = new UsuarioService(connectionString);
            result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.genero, request.email, request.senha);
            return Ok(result);




        }

        [HttpPost("esqueceu-senha")]

        public IActionResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();
            if (request == null ||
                string.IsNullOrEmpty(request.email))
            {
                result.sucesso = false;
                result.mensagem = "Email obrigatório";
                return Ok(result);
            }

            var connectionString = _configuration.GetConnectionString("programacaoDoZero");
            var usuarioService = new UsuarioService(connectionString);
            result = usuarioService.EsqueceuSenha(request.email);

            return Ok(result);


        }

        [HttpGet("obterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {

            var result = new ObterUsuarioResult();

            if (usuarioGuid == Guid.Empty)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZero");
                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);
                if(usuario == null)
                {
                    result.mensagem = "Usuário não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.nome;
                }
            }
            return result;
        }
    }
}

