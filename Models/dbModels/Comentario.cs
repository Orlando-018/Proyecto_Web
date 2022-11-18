using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Primeruso.Models.dbModels
{
    [Table("Comentario")]
    public partial class Comentario
    {
        [Key]
        [Column("ID_Comentario")]
        public int IdComentario { get; set; }
        [Column("ID_Usuario")]
        public int IdUsuario { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Contenido { get; set; } = null!;

        [ForeignKey("IdUsuario")]
        [InverseProperty("Comentarios")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
