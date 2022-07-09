using Maqta.API.Controllers;
using Maqta.API.Data;
using Maqta.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;

namespace Maqta.API.Tests
{
    public class EmployeesControllerTests
    {

        [Fact]
        public void Get_AllEmployees()
        {
            //arrange
            var dbContextMock = new Mock<MaqtaDbContext>();
            IList<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 1,Name="firstEmp",Department="firstDep"},
                 new Employee(){Id = 2,Name="secondEmp",Department="secondDep"},
                  new Employee(){Id = 3,Name="thirdEmp",Department="ThirdDep"}
            };

            dbContextMock.SetupGet(x => x.Employees).ReturnsDbSet(employees);

            EmployeesController employeesController = new EmployeesController(dbContextMock.Object);

            //act
            var result = employeesController.GetEmployees().Result;
            List<Employee> value = result.Value as List<Employee>;

            //assert
            Assert.Equal(3, value.Count);
        }

        [Fact]
        public void GetById_returns_correctResult()
        {
            //arrange
            var dbContextMock = new Mock<MaqtaDbContext>();
            IList<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 1,Name="firstEmp",Department="firstDep"},
                 new Employee(){Id = 2,Name="secondEmp",Department="secondDep"},
                  new Employee(){Id = 3,Name="thirdEmp",Department="ThirdDep"}
            };

            dbContextMock.SetupGet(x => x.Employees).ReturnsDbSet(employees);


            EmployeesController employeesController = new EmployeesController(dbContextMock.Object);

            //act
            var result = employeesController.GetEmployee(1).Result;
            var value = result.Value;


            //assert
            Assert.IsType<Employee>(value);
            Assert.Equal(1, value.Id);
        }

        [Fact]
        public void Put_saveChange()
        {
            //arrange
            var dbContextMock = new Mock<MaqtaDbContext>();
            IList<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 1,Name="firstEmp",Department="firstDep"},
                 new Employee(){Id = 2,Name="secondEmp",Department="secondDep"},
                  new Employee(){Id = 3,Name="thirdEmp",Department="ThirdDep"}
            };

            dbContextMock.SetupGet(x => x.Employees).ReturnsDbSet(employees);

            var empToUpdate = dbContextMock.Object.Employees.ToList()[0];
            empToUpdate.Name = "updatedName";
            int id = 1;

            EmployeesController employeesController = new EmployeesController(dbContextMock.Object);

            //act
            var result = employeesController.PutEmployee(id, empToUpdate);
            var updatedEmp = dbContextMock.Object.Employees.Where(a => a.Id.Equals(id)).ToList()[0];

            //assert
            Assert.Equal(empToUpdate, updatedEmp);

        }

       

    }
}