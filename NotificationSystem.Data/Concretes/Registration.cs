using NotificationSystem.Data.Entities;
using System.Linq;

namespace NotificationSystem.Data.Concretes
{
    public class Registration
    {
        NotificationContext _context = new NotificationContext();

        public void AddUser(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

        }
        
        public bool IsUserExists(int UserId)

        {
            var user = _context.Employees.
                    Where(e => e.EmployeeId==UserId).FirstOrDefault();
            return user != null;
        }
    }
}
