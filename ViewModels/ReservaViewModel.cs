using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Primeruso.ViewModels
{
    public class ReservaViewModel
    {
        [Required(ErrorMessage ="Este campo es obligatorio")]
        [DisplayName("Numero de reservacion")]
        public int NumeroReservacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Selecciona el Hotel de tu preferencia")]
        public int Hotel { get; set; }
        public List<SelectListItem> ListaHoteles { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Dinos que habitacion te gustaria")]
        public int NumeroHabitacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Dinos que tipo de habitacion te gustaria")]
        public int TipoHabitacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Costo { get; set; }

    }
}
