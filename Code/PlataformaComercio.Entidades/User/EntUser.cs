using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.User
{
    public class EntUser
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberExtension { get; set; }
        public string MobileNumber { get; set; }
        public bool Sex { get; set; }
        public bool SendInfo { get; set; }
        public bool ShareInfo { get; set; }
        public string PasswordConfirm { get; set; }

        public string EmailAddressConfirm { get; set; }
    }
}
