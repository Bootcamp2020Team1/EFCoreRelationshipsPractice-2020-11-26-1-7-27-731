using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entities
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {
        }

        public CompanyEntity(CompanyDto companyDto)
        {
            Name = companyDto.Name;
            Profile = new ProfileEntity(companyDto.Profile);
            Employees = companyDto.Employees.
                Select(employeeDto => new EmployeeEntity(employeeDto)).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ProfileEntity Profile { get; set; }
        public List<EmployeeEntity> Employees { get; set; }
    }

    public class ProfileEntity
    {
        public ProfileEntity()
        {
        }

        public ProfileEntity(ProfileDto profileDto)
        {
            RegisteredCapital = profileDto.RegisteredCapital;
            CertId = profileDto.CertId;
        }

        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }

    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
        }

        public EmployeeEntity(EmployeeDto employeeDto)
        {
            Name = employeeDto.Name;
            Age = employeeDto.Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public CompanyEntity Company { get; set; }
        [ForeignKey("CompanyIdForeignKey")]
        public int CompanyId { get; set; }
    }
}
