using NotificationSystem.Data.Concretes;
using NotificationSystem.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.DTO.Services
{
    public class RegistrationService
    {
        public void AddUser(Employee employee)
        {
            Registration registration = new Registration(); 
            if (registration.IsUserExists(employee.EmployeeId))
            {
                throw new Exception("User Already Exists");
            }
            else
            {
                Data.Entities.Employee emp = new Data.Entities.Employee()
                {
                    EmployeeId=employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    Email = employee.Email,
                    Password = employee.Password,
                    Phone = employee.Phone
                };
                registration.AddUser(emp);
            }


        }
    }
}
