﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BELogin : BEEntidad
    {
        #region "Propiedades"
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        #endregion
    }
}
