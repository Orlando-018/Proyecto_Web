using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("Reservacion")]
    public partial class Reservacion
    {
        public Reservacion()
        {
            Pagos = new HashSet<Pago>();
        }

        [Key]
        [Column("ID_Reservacion")]
        public int IdReservacion { get; set; }
        [Column("ID_Habitacion")]
        public int IdHabitacion { get; set; }
        [Column("ID_Usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdHabitacion")]
        [InverseProperty("Reservacions")]
        public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Reservacions")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdReservacionNavigation")]
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
