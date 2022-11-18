using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("Habitacion")]
    public partial class Habitacion
    {
        public Habitacion()
        {
            Reservacions = new HashSet<Reservacion>();
        }

        [Key]
        [Column("ID_Habitacion")]
        public int IdHabitacion { get; set; }
        [Column("ID_HOTEL")]
        public int IdHotel { get; set; }
        [Column("Num_Habitacion")]
        public byte NumHabitacion { get; set; }
        [Column("Costo_Habitacion", TypeName = "money")]
        public decimal CostoHabitacion { get; set; }
        [Column("ID_Tipo_Habitacion")]
        public int IdTipoHabitacion { get; set; }

        [ForeignKey("IdHotel")]
        [InverseProperty("Habitacions")]
        public virtual Hotel IdHotelNavigation { get; set; } = null!;
        [ForeignKey("IdTipoHabitacion")]
        [InverseProperty("Habitacions")]
        public virtual TipoDeHabitacione IdTipoHabitacionNavigation { get; set; } = null!;
        [InverseProperty("IdHabitacionNavigation")]
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
