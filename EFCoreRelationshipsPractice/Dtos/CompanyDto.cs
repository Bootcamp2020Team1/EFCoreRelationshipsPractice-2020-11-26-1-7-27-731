using System.Collections.Generic;
using System.Linq;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto(Entities.CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            Profile = companyEntity.Profile == null ?
                null : new ProfileDto(companyEntity.Profile);
            Employees = companyEntity.Employees?.Select(e => new EmployeeDto(e)).ToList();
        }

        public CompanyDto()
        {
        }

        public string Name { get; set; }

        public ProfileDto Profile { get; set; }

        public List<EmployeeDto> Employees { get; set; }
    }
}