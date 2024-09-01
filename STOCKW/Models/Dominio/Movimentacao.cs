using STOCKW.Models.Identidade;

namespace STOCKW.Models.Dominio
{
    public class Movimentacao
    {
        public int ID_Movimentacao { get; set; }
        public int ID_Item { get; set; }
        public Item Item { get; set; }

        public int ID_Entidade { get; set; }
        public Pessoa Entidade { get; set; }

        public int ID_TipoMovimentacao { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public int ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Data { get; set; }
        public int QuantidadeMovimentada { get; set; }
    }

}
