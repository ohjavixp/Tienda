using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities;
using System.Data.SqlClient;

namespace PlataformaComercio.Datos.Fachada
{
    public interface IMailAddressDA
    {
        /// <summary>
        /// Obtiene todas las propiedades de un email
        /// </summary>
        /// <param name="id">Id del Email</param>
        /// <returns>EntMailAddress</returns>
        EntMailAddress GetMailAddressByID(int id);

        /// <summary>
        /// Obtiene una direccion de email mediante su id.
        /// </summary>
        /// <param name="Id">Id del registro.</param>
        /// <returns>Entidad Audit con los datos.</returns>
        string GetUserNameByID(int Id);
    }
}
