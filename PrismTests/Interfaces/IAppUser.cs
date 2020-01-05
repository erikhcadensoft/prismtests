using System;
namespace PrismTests.Interfaces
{
    public interface IAppUser
    {
        /// <summary>
        /// User Id.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// First Name of User.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Last Name of User.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Email of User.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Password for User.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Verified Password.
        /// </summary>
        string VerifyPassword { get; set; }

        /// <summary>
        /// User accepts Terms & Conditions
        /// </summary>
        bool AcceptsTermsAndConditions { get; set; }

        /// <summary>
        /// Boolean for whether the profile is valid.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Boolean for whether the security profile is valid.
        /// </summary>
        bool IsSecurityValid { get; }
    }
}
