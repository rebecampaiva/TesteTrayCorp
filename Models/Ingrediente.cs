using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRO.Models
{
    [Table("Ingrediente")]
    public partial class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
       
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

     
        [Required]
        public bool Ativo { get; set; }

        public DateTime DataIncAlt { get; set; }

    }
}
