using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRO.Models
{
    [Table("Pedido")]
    public partial class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        
        public int LancheId { get; set; }

        //public virtual Lanche Lanches { get; set; }

        public bool Combo { get; set; }

     
        public int Status { get; set; }

        [ForeignKey(nameof(LancheId))]
       
        [Display(Name = "Lanche")]
        public virtual Lanche Lanches { get; set; }
    }

    public enum Status
    {
        Aberto = 1,
        Modificado = 2,
        EmProcessamento = 3,
        Entregue = 4,
        Devolvido = 5
    }

}
