using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Games.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Erro guy")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Erro guy")]
        public string Studio { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Wrong price")]
        public double Price { get; set; }

    }
}
