using System.Collections.Generic;
using System.Linq;
using EFCoreRelationshipsPractice.Entities;
namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            Profile = companyEntity.Profile == null ? null : new ProfileDto(companyEntity.Profile);
            Employees = companyEntity.Employees?.Select(employee => new EmployeeDto(employee)).ToList();
        }

        public string Name { get; set; }

        public ProfileDto Profile { get; set; }

        public List<EmployeeDto> Employees { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var companyDto = (CompanyDto)obj;
            return Name == companyDto.Name && Profile.Equals(companyDto.Profile) && Employees.All(companyDto.Employees.Contains);
        }
    }
}