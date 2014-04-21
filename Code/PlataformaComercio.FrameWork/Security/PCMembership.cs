using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Data.SqlClient;
using PlataformaComercio.FrameWork.DataAccess;
using PlataformaComercio.FrameWork.Exceptions;

namespace PlataformaComercio.FrameWork.Security
{
    public class PCMembership : MembershipProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT Password FROM Usuario WHERE UserName=@UserName";
            comando.Parameters.AddWithValue("@UserName", username);

            DBSqlServer db = new DBSqlServer();
            string password;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    password = reader.GetString(0);
                }
                else
                    throw new UserException("No existe el usuario");
            }

            return password;
        }

        
        
        

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT UserID,EmailAddress FROM Usuario WHERE UserName=@UserName";
            comando.Parameters.AddWithValue("@UserName", username);

            DBSqlServer db = new DBSqlServer();
            MembershipUser user = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    user = new MembershipUser("PCProvider", username, reader.GetGuid(0), reader.GetString(1),
                        string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);

                }
            }

            return user;  

            
        }


        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();          
        }

        public override string GetUserNameByEmail(string email)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT UserName FROM Usuario WHERE EmailAddress=@email";
            comando.Parameters.AddWithValue("@email", email);

            DBSqlServer db = new DBSqlServer();
            string userName;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    userName = reader.GetString(0);
                }
                else
                    throw new UserException("No existe ningún usuario registrado con está dirección de correo electronico");
            }

            return userName;       
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT Password FROM Usuario WHERE UserName=@UserName";
            comando.Parameters.AddWithValue("@UserName", username);            

            DBSqlServer db = new DBSqlServer();
            bool result = false;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    //TODO: Encriptar información
                    if (password.Equals(reader.GetString(0)))
                        return true;
                }
            }

            return result;       
              
        }
    }
}
