using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRO.Models
{
    [Table("Lanche")]
    public partial class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
       
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorBase { get; set; }

        public string ImagemCaminho { get; set; }

        [Required]

        public bool Ativo { get; set; }

    }
}
