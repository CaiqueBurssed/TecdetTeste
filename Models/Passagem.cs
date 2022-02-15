using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecdetTeste.Models
{
    class Passagem
    {
        [Key]
        [Required]
        [MaxLength(250)]
        public string Placa { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public DateTime Hora { get; set; }

        [Required]
        [MaxLength(250)]
        public string Equipamento { get; set; }

        [Required]
        [MaxLength(250)]
        public string Faixa { get; set; }
    }
}
