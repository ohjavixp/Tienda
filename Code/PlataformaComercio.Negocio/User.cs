using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.User;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.FrameWork.Exceptions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;



namespace PlataformaComercio.Business
{
    public class User : Base
    {
        IUserDA iUserDA;
        public User()
            : base()
        {
         
            iUserDA = dataContainer.Resolve<IUserDA>();
        }

        private void Validate(EntUser entUser)
        { 
            if(string.IsNullOrEmpty( entUser.UserName))
                throw new UserException("Debe proporcionar un nombre de usuario");

            if (string.IsNullOrEmpty(entUser.Password))
                throw new UserException("Debe proporcionar el password");

            if (string.IsNullOrEmpty(entUser.Name))
                throw new UserException("Debe proporcionar su nombre");

            if (string.IsNullOrEmpty(entUser.LastName))
                throw new UserException("Debe proporcionar sus apellidos");

            if (string.IsNullOrEmpty(entUser.EmailAddress))
                throw new UserException("Debe proporcionar su correo electronico");

            if (string.IsNullOrEmpty(entUser.PhoneNumber))
                throw new UserException("Debe proporcionar número de teléfono");

            if(!entUser.Password.Equals(entUser.PasswordConfirm))
                throw new UserException("Las contraseñas no coinciden");

            if (!entUser.EmailAddress.Equals(entUser.EmailAddressConfirm))
                throw new UserException("La confirmación del correo electronico no coincide");

        }

        private void ValidateUserAddress(EntUserAddress entUserAddress)
        {
            if(string.IsNullOrEmpty(entUserAddress.ZipCode))
                throw new UserException("El código postal no puede estar vacio");

            if (string.IsNullOrEmpty(entUserAddress.Street))
                throw new UserException("Debe proporcionar la calle");

            if (string.IsNullOrEmpty(entUserAddress.StreetBetween))
                throw new UserException("Debe proporcionar entre que calles se encuentra su dirección");

            if (string.IsNullOrEmpty(entUserAddress.TelephoneContact))
                throw new UserException("Debe proporcionar un teléfono de contacto");
        }

        public Guid Add(EntUser entUser)
        {
            Validate(entUser);

            Guid userID = Guid.NewGuid();

            if (GetByEmail(entUser.EmailAddress) != null)
                throw new UserException("Ya existe un usuario con la dirección de correo electronico");

            if (GetByUserName(entUser.UserName) != null)
                throw new UserException("Ya existe ese nombre de usuario");

            entUser.UserID = userID;

            iUserDA.Add(entUser);

            return userID;            
        }


        public int AddAddress(EntUserAddress entUserAddress)
        {
            ValidateUserAddress(entUserAddress);
            return iUserDA.AddAddress(entUserAddress);
        }

        public bool UpdateAddress(EntUserAddress entUserAddress)
        {
            ValidateUserAddress(entUserAddress);
            return iUserDA.UpdateAddress(entUserAddress);
        }

        public EntUserAddress GetAddressByID(Guid userID, int addressID)
        {
            return iUserDA.GetAddressByID(userID, addressID);
        }
        

        public EntUser GetByID(Guid userID)
        {
            return iUserDA.GetByID(userID);
        }

        public EntUser GetByEmail(string email)
        {
            return iUserDA.GetByEmail(email);
        }    

        public EntUser GetByUserName(string userName)
        {
            return iUserDA.GetByUserName(userName);
        }
    }
}
