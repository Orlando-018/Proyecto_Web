using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("HOTEL")]
    public partial class Hotel
    {
        public Hotel()
        {
            Habitacions = new HashSet<Habitacion>();
        }

        [Key]
        [Column("ID_HOTEL")]
        public int IdHotel { get; set; }
        [Column("Nombre_Hotel")]
        [StringLength(20)]
        [Unicode(false)]
        public string NombreHotel { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Direccion { get; set; } = null!;

        [InverseProperty("IdHotelNavigation")]
        public virtual ICollection<Habitacion> Habitacions { get; set; }
    }
}
