﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Autentificacion.Model
{
    public class Credenciales
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }
        public bool RefrescarToken { get; set; }
    }
}