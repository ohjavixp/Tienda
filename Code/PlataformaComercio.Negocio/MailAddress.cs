using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace PlataformaComercio.Business
{
    public class MailAddress : Base, IMailAddressDA
    {

        /// <summary>
        /// Interfaz de acceso a datos AuditDA
        /// </summary>
        private IMailAddressDA iMailAddressDA;

        public MailAddress():base()
        {
            iMailAddressDA = dataContainer.Resolve<IMailAddressDA>();
        }

        /// <summary>
        /// Obtiene un registro mediante su id.
        /// </summary>
        /// <param name="Id">Id del registro.</param>
        /// <returns>Entidad Audit con los datos.</returns>
        public EntMailAddress GetMailAddressByID(int Id)
        {
            return this.iMailAddressDA.GetMailAddressByID(Id);
        }

        /// <summary>
        /// Obtiene una direccion de email mediante su id.
        /// </summary>
        /// <param name="Id">Id del registro.</param>
        /// <returns>Entidad Audit con los datos.</returns>
        public string GetUserNameByID(int Id)
        {
            return this.iMailAddressDA.GetUserNameByID(Id);
        }
    }
}
