using EFCoreRelationshipsPractice.Entities;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(EmployeeEntity employeeEntity)
        {
            Name = employeeEntity.Name;
            Age = employeeEntity.Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var employeeDto = (EmployeeDto)obj;
            return Name == employeeDto.Name && Age == employeeDto.Age;
        }
    }
}