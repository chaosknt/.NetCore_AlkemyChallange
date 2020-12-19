using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public static class ValidationMessages
    {
        public const string
            Required = "El campo {0} es requerido",
            Range = "El campo {0} debe estar entre {1} y {2}",
            MinLength = "El campo {0} debe tener por lo menos {1} caracteres",
            MaxLength = "El campo {0} debe tener como máximo {1} caracteres",
            DniExists = "Ya existe una persona asignada con ese DNI";
    }

}
