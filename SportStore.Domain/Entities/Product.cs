using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Entities
{
    public class Product
    {
        [Required]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [Required(ErrorMessage="Proszę podać cenę dla towaru")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }
    }
}
