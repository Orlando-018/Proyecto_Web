using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Primeruso.Models.dbModels
{
    public class ApplicationUser:IdentityUser<int>
    {
        public ApplicationUser()
        {
            Comentarios = new HashSet<Comentario>();
            Reservacions = new HashSet<Reservacion>();
        }

        [StringLength(20)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Apellido { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? Direccion { get; set; }
        [Column("Fecha_Nacimient", TypeName = "datetime")]
        public DateTime? FechaNacimient { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Comentario> Comentarios { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
