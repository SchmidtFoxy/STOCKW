namespace STOCKW.Models.Dominio
{
    public class TipoMovimentacao
    {
        public int ID_TipoMovimentacao { get; set; }
        public string? Descricao { get; set; }

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
    }

}
