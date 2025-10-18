using System.Data;
using AppProps;

namespace DataAccessLayer
{
    public class UserDAL
    {
        DbCon Con = new DbCon();

        public bool InsertUserDAL(User U)
        {
            return Con.UDI("INSERT INTO Users (Name, Email, Address) VALUES ('" + U.Name + "', '" + U.Email + "', '" + U.Address + "')");
        }

        public bool UpdateUserDAL(User U)
        {
            return Con.UDI("UPDATE Users SET Name='" + U.Name + "', Email='" + U.Email + "', Address='" + U.Address + "' WHERE Id=" + U.Id);
        }

        public bool DeleteUserDAL(User U)
        {
            return Con.UDI("DELETE FROM Users WHERE Id=" + U.Id);
        }

        public DataTable UserSearchDAL(User U)
        {
            return Con.Search("SELECT * FROM Users WHERE Id=" + U.Id);
        }

        public DataTable GetUsersDAL()
        {
            return Con.Search("SELECT * FROM Users");
        }
    }
}