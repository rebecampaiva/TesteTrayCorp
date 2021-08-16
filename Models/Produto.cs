using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRO.Models
{
    [Table("Produto")]
    public partial class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required]
        
        public int Estoque { get; set; }
        [Column(TypeName = "decimal(17, 2)")]
        public decimal Valor { get; set; }
      
    }
}
