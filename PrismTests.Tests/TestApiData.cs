using PrismTests.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismTests.Tests
{
    public class TestApiData
    {
        public List<AppUserDto> AppUsers { get; set; }

        public TestApiData()
        {
            SetupTestData();
        }

        private void SetupTestData()
        {
            AppUsers = new List<AppUserDto>
            {
                // Create one concrete user to execute test cases
                CreateAppUserDto(new Guid("84291c0e-4b8d-42f5-8a19-b48ceb4d9a34"), "Sienna", "Mae", "zero@example.org", true),
                CreateAppUserDto(),
                CreateAppUserDto(),
                CreateAppUserDto(),
                CreateAppUserDto()
            };
        }

        public AppUserDto CreateAppUserDto(Guid id = new Guid(), string firstName = null, string lastName = null, string email = null, bool? toc = null)
        {
            var firsts = GetFirstNames();
            var lasts = GetLastNames();
            var emails = GetEmailAddresses();

            return new AppUserDto
            {
                Id = id != Guid.Empty ? id : Guid.NewGuid(),
                FirstName = string.IsNullOrEmpty(firstName) ? firsts[new Random().Next(0, firsts.Count)] : firstName,
                LastName = string.IsNullOrEmpty(lastName) ? lasts[new Random().Next(0, lasts.Count)] : lastName,
                Email = string.IsNullOrEmpty(email) ? emails[new Random().Next(0, emails.Count)] : email,
                AcceptsTermsAndConditions = toc is null ? new Random().Next(0, 2) == 1 ? true : false : (bool)toc
            };
        }

        private List<string> GetFirstNames()
        {
            return new List<string>
            {
                "Erik","Ethan","Michael","Max","Josh","Bella","Marcella","Julie","MiKenna","MiKayla","Brooklyn"
            };
        }

        private List<string> GetLastNames()
        {
            return new List<string>
            {
                "Jones","Smith","Michaels","Roberts","Jameson","Woodford","Powers","Beam","Jackson","Cohiba","Nub"
            };
        }

        private List<string> GetEmailAddresses()
        {
            return new List<string>
            {
                "one@two.com","two@three.com","three@four.com","four@five.com","five@six.com","six@seven.com","seven@eight.com","eight@nine.com","nine@ten.com","ten@eleven.com","eleven@twelve.com"
            };
        }
    }
}
