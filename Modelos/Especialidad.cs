﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [Required]
        public string NombreEspecialidad { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}