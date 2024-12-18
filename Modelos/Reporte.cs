﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Reporte
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateOnly FechaCreacion { get; set; }

        public bool Estado {  get; set; }

    }
}
