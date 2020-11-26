using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Xunit;

namespace EFCoreRelationshipsPracticeTest
{
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_Create_Company_Success_Via_Company_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 20
                }
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100"
            };

            CompanyService companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async Task Should_Get_Company_Success_Via_Company_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 20
                }
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100"
            };
            CompanyService companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);
            var allCompanies = await companyService.GetAll();
            Assert.Equal(1, allCompanies.Count);
        }

        [Fact]
        public async Task Should_Delete_Company_Via_Company_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            CompanyDto companyDto1 = new CompanyDto();
            companyDto1.Name = "IBM";
            companyDto1.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 20
                }
            };

            companyDto1.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100"
            };
            CompanyDto companyDto2 = new CompanyDto();
            companyDto2.Name = "sab";
            companyDto2.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "NewName",
                    Age = 20
                }
            };

            companyDto2.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100"
            };
            CompanyService companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto2);
            await companyService.AddCompany(companyDto1);
            await companyService.DeleteCompany(1);
            Assert.Equal(1, context.Companies.Count());
        }
    }
}
