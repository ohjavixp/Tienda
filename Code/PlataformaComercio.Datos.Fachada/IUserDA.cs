using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.User;

namespace PlataformaComercio.Datos.Fachada
{
    public interface IUserDA
    {
        void Add(EntUser entUser);
        int AddAddress(EntUserAddress entUserAddress);
        bool UpdateAddress(EntUserAddress entUserAddress);
        EntUser GetByID(Guid userID);
        EntUser GetByEmail(string email);
        EntUser GetByUserName(string userName);
        EntUserAddress GetAddressByID(Guid userID, int addressID);
    }
}
