namespace CRUD.Dto
{
    public class UsuarioModels
    {
        public UsuarioModels()
        {
            Usuarios = new List<Usuario>();
        }
        
        public class Usuario
        {
            
            public int UsuarioId { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public int Telefono { get; set; }
        }

        public List<Usuario> Usuarios { get; set; }
       
        

    }
}
