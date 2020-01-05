using System;
namespace PrismTests.Dtos
{
    public class AppUserDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// First Name of User.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name of User.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email of User.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User accepts Terms & Conditions
        /// </summary>
        public bool AcceptsTermsAndConditions { get; set; }
    }
}
