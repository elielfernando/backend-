
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using ProgramacaoDozero.entities;

namespace ProgramacaoDozero.Repositories
{
    public class UsuarioRepository
    {
        private string _connectionString;
        //conecta com o banco de dados
        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Inserir(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand
            {
                Connection = cnn,
                CommandText = @"insert into usuario(nome,sobrenome,telefone,email,genero,senha,usuarioGuid) 
                values(@nome,@sobrenome,@telefone,@email,@genero,@senha,@usuarioGuid);"
            };

            cmd.Parameters.AddWithValue("nome", usuario.nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.telefone);
            cmd.Parameters.AddWithValue("email", usuario.email);
            cmd.Parameters.AddWithValue("genero", usuario.genero);
            cmd.Parameters.AddWithValue("senha", usuario.senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.UsuarioGuid.ToString());

            cnn.Open();

            var affectdRows = cmd.ExecuteNonQuery();
            cnn.Close();
            return affectdRows;


        }
        public Usuario? ObterPorEmail(string email)
        {
            Usuario? usuario = null;

            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand
            {
                Connection = cnn,
                CommandText = @"
               SELECT id, nome, sobrenome, telefone, email, senha, genero, usuarioGuid
               FROM usuario
               WHERE email = @email"
            };
            cmd.Parameters.AddWithValue("email", email);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usuario = new Usuario
                {
                    Id = Convert.ToInt32(reader["id"]),
                    nome = reader["nome"].ToString()!,
                    sobrenome = reader["sobrenome"].ToString()!,
                    telefone = reader["telefone"].ToString()!,
                    email = reader["email"].ToString()!,
                    senha = reader["senha"].ToString()!,
                    UsuarioGuid = new Guid(reader["UsuarioGuid"].ToString())
                };

                if (Guid.TryParse(reader["usuarioGuid"]?.ToString(), out var guid))
                {
                    usuario.UsuarioGuid = guid;
                }
                else
                {
                    throw new Exception("usuarioGuid inválido no banco");
                }

                if (reader["genero"] != DBNull.Value)
                {
                    usuario.genero = reader["genero"].ToString();
                }
            }

            cnn.Close();
            return usuario;
        }
        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cnn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario
                {
                    Id = Convert.ToInt32(reader["id"]),
                    nome = reader["nome"].ToString()!,
                    sobrenome = reader["sobrenome"].ToString()!,
                    telefone = reader["telefone"].ToString()!,
                    email = reader["email"].ToString()!,
                    senha = reader["senha"].ToString()!,

                    UsuarioGuid = new Guid(reader["UsuarioGuid"].ToString())
                };
            }
            cnn.Close();

            return usuario;
        }
    }
}
