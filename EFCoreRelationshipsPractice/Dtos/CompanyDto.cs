﻿using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto(Entities.CompanyEntity c)
        {
            Name = c.Name;
        }

        public CompanyDto()
        {
        }

        public string Name { get; set; }

        public ProfileDto Profile { get; set; }

        public List<EmployeeDto> Employees { get; set; }
    }
}