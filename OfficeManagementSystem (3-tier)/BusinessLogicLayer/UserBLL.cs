using System.Data;
using AppProps;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        UserDAL DAL = new UserDAL();

        public bool InsertUserBLL(User U)
        {
            return DAL.InsertUserDAL(U);
        }

        public bool DeleteUserBLL(User U)
        {
            return DAL.DeleteUserDAL(U);
        }

        public bool UpdateUserBLL(User U)
        {
            return DAL.UpdateUserDAL(U);
        }

        public DataTable UserSearchBLL(User U)
        {
            return DAL.UserSearchDAL(U);
        }

        public DataTable GetUsersBLL()
        {
            return DAL.GetUsersDAL();
        }
    }
}