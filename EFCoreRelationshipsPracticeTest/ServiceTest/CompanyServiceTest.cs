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
    [Collection("IntegrationTest")]
    public class CompanyServiceTest : TestBase
    {
        private CompanyDbContext context;
        public CompanyServiceTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            context = scopedServices.GetRequiredService<CompanyDbContext>();
        }

        [Fact]
        public async Task Should_Create_Company_Success_Via_Company_Service()
        {
            //var scope = Factory.Services.CreateScope();
            //var scopedServices = scope.ServiceProvider;

            //var context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyDto = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 20,
                },
            },

                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };

            var companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async Task Should_Get_Company_Success_Via_Company_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyDto = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 20,
                },
            },

                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };
            var companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);
            var allCompanies = await companyService.GetAll();
            Assert.Single(allCompanies);
        }

        [Fact]
        public async Task Should_Delete_Company_Via_Company_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyDto1 = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 20,
                },
            },

                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };
            var companyDto2 = new CompanyDto
            {
                Name = "sab",
                Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "NewName",
                    Age = 20,
                },
            },

                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };
            var companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto2);
            await companyService.AddCompany(companyDto1);
            await companyService.DeleteCompany(1);
            Assert.Equal(1, context.Companies.Count());
        }
    }
}
