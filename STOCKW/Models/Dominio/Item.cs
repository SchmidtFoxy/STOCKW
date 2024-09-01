using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace STOCKW.Models.Dominio
{
    public class Item
    {
        public int ID_Item { get; set; }

        [Required]
        [StringLength(100)]  // Defina um comprimento máximo se desejar
        public string? Nome { get; set; }

        [StringLength(500)]  // Defina um comprimento máximo se desejar
        public string? Descricao { get; set; }

        [StringLength(100)]  // Defina um comprimento máximo se desejar
        public string? Material { get; set; }

        [StringLength(50)]  // Defina um comprimento máximo se desejar
        public string? Dimensao { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public double Preco { get; set; }

        [StringLength(250)]  // Defina um comprimento máximo se desejar
        public string? Caracteristica { get; set; }

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
    }
}
