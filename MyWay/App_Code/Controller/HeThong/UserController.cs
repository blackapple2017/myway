using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftCore;
using DAL;
using SoftCore.User;

/// <summary>
/// Summary description for UserController
/// </summary>
public class UserController : LinqProvider
{
    public UserController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public User CheckLogin(string userName, string password)
    {
        return (from t in dataContext.Users
                where t.UserName.Equals(userName) && t.Password.Equals(Hash.GetSHA256(password))
                && t.IsLock == false
                select t).FirstOrDefault();
    }

    /// <summary>
    /// Kiểm tra xem User có tồn tại trong đơn vị hay không ? 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public bool CheckUserInDonVi(string userName, string MaDonVI)
    {
        return dataContext.DONVI_Users.Where(t => t.User.UserName == userName && t.DonViID == MaDonVI).Count() > 0;
    }
   
    public List<DM_DONVI> GetDonViByUserID(int userID)
    {
        var rs = (from t in dataContext.DONVI_Users
                  where t.UserID == userID
                  select t.DM_DONVI).OrderBy(dv => dv.ORDER).ToList();
        return rs;
    }

    public DAL.User GetUserNameById(int userID)
    {
        var rs = from t in dataContext.Users
                 where t.ID == userID
                 select t;
        return rs.FirstOrDefault();
    }

    /// <summary>
    /// Lấy danh sách user để hiện ở form quản trị người dùng
    /// </summary>
    /// <param name="MaDonVi"></param>
    /// <param name="SearchKey"></param>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<SoftCore.User.UserInfo> GetUsersListByMaDonVi(string MaDonVi, string SearchKey, int start, int limit, out int count, int roleID)
    {
        var rs = from t in dataContext.Users
                 join dv in dataContext.DONVI_Users
                 on t.ID equals dv.UserID into u1
                 from u2 in u1.DefaultIfEmpty()
                 where// dv.DonViID == MaDonVi && 
                 (System.Data.Linq.SqlClient.SqlMethods.Like(t.DisplayName, SearchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.UserName, SearchKey) || string.IsNullOrEmpty(SearchKey))
                 && (t.Users_Roles.Where(r => r.RoleID == roleID).Count() != 0 || roleID == -1)
                 select new UserInfo
                 {
                     Gender = t.Gender,
                     LastName = t.LastName,
                     IsLock = t.IsLock,
                     Phone = t.Phone,
                     UserName = t.UserName,
                     FirstName = t.FirstName,
                     CreatedOn = t.CreatedOn,
                     DisplayName = t.DisplayName,
                     Address = t.Address,
                     Birthday = t.Birthday,
                     Email = t.Email,
                     ID = t.ID, 
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit).ToList();
    }
     
    /*
     * Kiểm tra user dựa vào username và email
     */
    public bool CheckUserResetPassword(string userName, string email, ref string maDonVi)
    {
        DAL.User user = dataContext.Users.Where(t => t.UserName == userName && t.Email == email).FirstOrDefault();
        bool hasUser = user != null;
        if (hasUser)
        {
            //lấy mã đơn vị của người đăng nhập vào
            maDonVi = (from t in dataContext.DONVI_Users
                       where t.UserID == user.ID
                       select t.DonViID).FirstOrDefault();
        }
        return hasUser;
    }
}