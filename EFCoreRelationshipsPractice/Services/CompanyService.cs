using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Entities;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companies = await this.companyDbContext.Companies.ToListAsync();
            return companies.Select(companyEntity => new CompanyDto(companyEntity)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var company = await this.companyDbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);

            return company == null ? null : new CompanyDto(company);
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            var companyEntity = new CompanyEntity()
            {
                Name = companyDto.Name,
                Profile = new ProfileEntity(companyDto.Profile),
                Employees = companyDto.Employees.Select(employee => new EmployeeEntity(employee)).ToList(),
            };
            await this.companyDbContext.AddAsync(companyEntity);
            await this.companyDbContext.SaveChangesAsync();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}