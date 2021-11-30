using MerchandiseService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation
{
    public class Employee : Entity,IAggregateRoot
    {
        public Employee(PersonName name, Email email, ClothingSize size)
        {
            Name = name;
            Email = email;
            Size = size;

        }

        public PersonName Name { get; }

        public Email Email { get; private set; }

        public ClothingSize Size { get; }

        public PhoneNumber PhoneNumber { get; }

        public void ChangeEmail(string newEmail)
            => Email = Email.Parse(newEmail);

        public void ChangeEmail(Email newEmail, IEmployeeRepository repository)
        {
            var existingEmployee = repository.FindByEmailAsync(newEmail.Value);

            if (existingEmployee != null && existingEmployee.Id != Id)
            {
                throw new Exception("Email is already taken");
            }

            Email = newEmail;
        }

        public void ChangeEmail(Email newEmail, ICollection<Employee> employees)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Email == newEmail);

            if (existingEmployee != null && existingEmployee.Id != Id)
            {
                throw new Exception("Email is already taken");
            }

            Email = newEmail;
        }
    }

}