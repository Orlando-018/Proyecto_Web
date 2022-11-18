using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("Tipo de pago")]
    public partial class TipoDePago
    {
        public TipoDePago()
        {
            Pagos = new HashSet<Pago>();
        }

        [Key]
        [Column("ID_Tipo_Pago")]
        public int IdTipoPago { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdTipoPagoNavigation")]
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
