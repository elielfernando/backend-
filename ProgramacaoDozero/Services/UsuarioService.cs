using Microsoft.AspNetCore.Identity.UI.Services;
using ProgramacaoDozero.entities;
using ProgramacaoDozero.Models;
using ProgramacaoDozero.Repositories;
using ProgramacaoDozero.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ProgramacaoDozero.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioExistente = new UsuarioRepository(_connectionString)
                .ObterPorEmail(email);

            // usuário não existe
            if (usuarioExistente == null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
                return result;
            }

            // usuário existe, valida senha
            if (usuarioExistente.senha == senha)
            {
                result.sucesso = true;
                result.UsuarioGuid = usuarioExistente.UsuarioGuid;
            }
            else
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string genero, string email, string senha)
        {
            var result = new CadastroResult();
            var repositorio = new UsuarioRepository(_connectionString);
            var usuarioExistente = repositorio.ObterPorEmail(email);

            if (usuarioExistente != null)
            {
                //usuario já existe
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                //usuario nao existe
                Usuario usuario = new()
                {
                    nome = nome,
                    sobrenome = sobrenome,
                    telefone = telefone,
                    email = email,
                    genero = genero,
                    senha = senha,
                    UsuarioGuid = Guid.NewGuid()
                };

                var affectedRows = repositorio.Inserir(usuario);
                if (affectedRows > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Não foi possivel inserir o usuário";
                }



            }
            return result;

        }
        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();
            var usuarioRepository = new UsuarioRepository(_connectionString);
            var usuario = usuarioRepository.ObterPorEmail(email);

            if (usuario == null)
            {
                //não existe
                result.sucesso = false;
                result.mensagem = "Não foi localizado nenhum usuário com o e-mail informado.";
                return result;
            }
            else
            {
                var emailSender = new EmailSender();
                var assunto = "Recuperação de Senha";
                var corpo = $@"
                             <p>Olá {usuario.nome}, tudo bem?</p>
                             <p>Sua senha: <b>{usuario.senha}</b></p>";

                emailSender.Enviar(assunto, corpo, usuario.email);

                result.sucesso = true;
                result.mensagem = "E-mail enviado com sucesso";

            }
            return result;
        }
        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);
            return usuario;
        }
    }
}