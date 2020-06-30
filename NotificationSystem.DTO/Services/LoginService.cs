using NotificationSystem.DTO.Models;

namespace NotificationSystem.DTO.Services
{
    public class LoginService
    {
        public Employee ValidateUser(Employee employee)
        {
            var login1 =new Data.Concretes.Login();

            Data.Entities.Employee employeeEntity = new Data.Entities.Employee
            {
                Email=employee.Email,
                Password = employee.Password
            };

            var result = login1.ValidateUser(employeeEntity);
            Employee employee1 = new Employee()
            {
                Email=result.Email,
                EmployeeId=result.EmployeeId,
                EmployeeName=result.EmployeeName,
                Phone=result.Phone
            };

            return employee1;
        }
    }
}
