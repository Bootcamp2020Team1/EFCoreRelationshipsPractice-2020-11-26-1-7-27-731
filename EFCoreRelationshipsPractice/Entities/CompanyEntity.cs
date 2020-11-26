using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Entities
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileEntity Profile { get; set; }

        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}