using NotificationSystem.Data.Entities;
using System;
using System.Linq;

namespace NotificationSystem.Data.Concretes
{
    public class Login
    {
        public NotificationContext _context = new NotificationContext();
        public Employee ValidateUser(Employee employee)
        {
            try
            {
                var validate = (from user in _context.Employees
                                where user.Email==employee.Email && user.Password == employee.Password
                                select user).SingleOrDefault();

                if (validate != null)
                {
                    return validate;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
