namespace STOCKW.Models.Identidade
{
    public class Permissao
    {
        public int ID_Permissao { get; set; }
        public string? GrupoPermissao { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
    }


}
