using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("Pago")]
    public partial class Pago
    {
        [Key]
        [Column("ID_Pago")]
        public int IdPago { get; set; }
        [Column("Costo_Habitacion", TypeName = "money")]
        public decimal CostoHabitacion { get; set; }
        [Column("ID_Reservacion")]
        public int IdReservacion { get; set; }
        [Column("ID_Tipo_Pago")]
        public int IdTipoPago { get; set; }

        [ForeignKey("IdReservacion")]
        [InverseProperty("Pagos")]
        public virtual Reservacion IdReservacionNavigation { get; set; } = null!;
        [ForeignKey("IdTipoPago")]
        [InverseProperty("Pagos")]
        public virtual TipoDePago IdTipoPagoNavigation { get; set; } = null!;
    }
}
