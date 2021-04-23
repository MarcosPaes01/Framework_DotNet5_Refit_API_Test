using NUnit.Framework;

using Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.ApiClient;

using System.Threading.Tasks;
using System;
using System.Net;

namespace Super.EWalletCore.PersonDataManagement.Application.IntegratedTests
{
    [TestFixture]
    public class CreatePersonTest
    {
        private PersonService personService;

        public CreatePersonTest()
        {
            personService = GetService<EmbossingService>();
        }

        //Test Case 18922: Happy Path 1.0 (BU: 1 - Role1 - Category 1)
        [TestCase]
        public async Task PersonIdIsCreated()
        {
            //Arrange
            CreatePersonRequest localBody = GenerateBody();

            //Act
            var (status, response) = await personService.RunCreatePerson(CreatePersonRequest request, int country);
            Assert.AreEqual(HttpStatusCode.OK, status);

            //Assert
            var sucessResponse = response as CreatePersonResponse_Success;
            Assert.NotNull(sucessResponse.PersonId);

        }

        //Test Case 27447: Happy Path 1.1 (BU: 2 - Role2 - Category 1)
        [TestCase]
        public async Task PersonIdIsCreated_BU()
        {
            //Arrange
            CreatePersonRequest localBody = GenerateBody();
            localBody.Roles.BusinessUnitID = "2";
            localBody.Roles.RoleType = "2";

            //Act
            var (status, response) = await personService.RunCreatePerson(CreatePersonRequest request, int country);
            Assert.AreEqual(HttpStatusCode.OK, status);

            //Assert
            var sucessResponse = response as CreatePersonResponse_Success;
            Assert.NotNull(sucessResponse.PersonId);
        }

        //Test Case 18923: 14634 - Alternative Scenario 01 - Return is not OK - Some mandatory parameter not received
        [TestCase]
        public async Task SomeMandatoryParameterNotReceived()
        {
            //Arrange
            CreatePersonRequest localBody = GenerateBody();
            localBody.PersonId = null;
            localBody.CategoryId = null;
            localBody.Roles.RoleType = null;
            localBody.Roles.BusinessUnitID = null;

            //Act
            var (status, response) = await personService.RunCreatePerson(CreatePersonRequest request, int country);
            Assert.AreEqual(HttpStatusCode.OK, status);

            //Assert
            var sucessResponse = response as CreatePersonResponse_Success;
            Assert.NotNull(sucessResponse.PersonId);
        }

        public CreatePersonRequest GenerateBody()
        {
            CreatePersonRequest body = new CreatePersonRequest
            {
                PersonId = Person,
                CategoryId = 1,
                UifObligatedSubject = true,
                Alias = "test",
                Roles = new Roles
                {
                    RoleType = 1,
                    BusinessUnitID = 1, 
                    ValidFrom = DateTime.Now.AddYears(-1)
                },

                NaturalPerson = new NaturalPerson
                {
                    FirstName = "Test_Person",
                    LastName = "AutomatedRun",
                    BirthDate = "1996-09-19",
                    Gender = "1",
                    BirthCountry = "10"
                },

                Email = new Email
                {
                    EmailAdress = "@superdigital.com.br",
                    EmailAddressValidated = true
                },

                IdentificationDocuments = new IdentificationDocuments
                {
                    CountryID = "10",
                    DocumentTypeCode = "DNI",
                    DocumentNumber = "123456789"
                },
                
                Phones = new Phones
                {
                    PhoneType = "1",
                    CountryCallingCode = "+55",
                    AreaCode = "011",
                    PhoneNumber = GenerateRandom(),
                }
            }

            public string GenerateRandom()
            {
                Random rnd = new Random();
                int month  = rnd.Next(1, 13);

                return rnd;
            }
            
            return body;
        };
    }
}
