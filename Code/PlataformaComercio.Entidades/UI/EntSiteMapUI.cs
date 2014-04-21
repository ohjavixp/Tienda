using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.UI
{
    public class EntSiteMapUI
    {
        /// <summary>
        /// Url a mostrar
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Fecha con la ultima modificación
        /// </summary>
        public DateTime LasMod { get; set; }
        /// <summary>
        /// Origen de la información
        /// </summary>
        public int Source { get; set; }

    }
}
