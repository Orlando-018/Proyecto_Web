using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("Tipo de Habitaciones")]
    public partial class TipoDeHabitacione
    {
        public TipoDeHabitacione()
        {
            Habitacions = new HashSet<Habitacion>();
        }

        [Key]
        [Column("ID_Tipo_Habitacion")]
        public int IdTipoHabitacion { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdTipoHabitacionNavigation")]
        public virtual ICollection<Habitacion> Habitacions { get; set; }
    }
}
