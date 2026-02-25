namespace ProgramacaoDozero.entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public Guid UsuarioGuid { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string genero { get; set; }
        public string senha { get; set; }

    }
}
