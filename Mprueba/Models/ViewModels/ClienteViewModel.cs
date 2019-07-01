using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mprueba.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int ID_CLIENTE { get; set; }
        [Required]
        [Display(Name ="NOMBRE DE CLIENTE")]
        public string NOMBRE_CLIENTE { get; set; }
        public bool ESTADO { get; set; }
    }
}