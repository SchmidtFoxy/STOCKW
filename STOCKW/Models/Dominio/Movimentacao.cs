using STOCKW.Models.Identidade;
using STOCKW.Models.Dominio;
using System.ComponentModel.DataAnnotations;

namespace STOCKW.Models.Dominio
{
    public class Movimentacao
    {
        public int ID_Movimentacao { get; set; }

        [Required(ErrorMessage = "Informe o Item")]
        public int ID_Item { get; set; }
        public Item? Item { get; set; }

        [Required(ErrorMessage = "Informe o cliente ou fornecedor")]
        public int ID_Pessoa { get; set; }
        public Pessoa? Pessoa { get; set; }
        
        [Required(ErrorMessage = "Informe o tipo da movimentacao")]
        public int ID_TipoMovimentacao { get; set; }
        public TipoMovimentacao? TipoMovimentacao { get; set; }
        
        [Required(ErrorMessage = "Informe o Usuário")]
        public int ID_Usuario { get; set; }
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Informe a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe a quantidade movimentada")]
        public int QuantidadeMovimentada { get; set; }

    }

}
