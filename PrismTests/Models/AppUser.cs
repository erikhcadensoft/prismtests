using System;
using PrismTests.Helpers;
using PrismTests.Interfaces;

namespace PrismTests.Models
{
    public class AppUser : ObservableObject, IAppUser
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// First Name of User.
        /// </summary>
        string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value, () => FirstName);
            }
        }

        /// <summary>
        /// Last Name of User.
        /// </summary>
        string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value, () => LastName);
            }
        }

        /// <summary>
        /// Email of User.
        /// </summary>
        string _email;
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value, () => Email);
            }
        }

        /// <summary>
        /// Password for User.
        /// </summary>
        string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value, () => Password);
            }
        }

        /// <summary>
        /// Verified Password.
        /// </summary>
        string _verifyPassword;
        public string VerifyPassword
        {
            get => _verifyPassword;
            set
            {
                SetProperty(ref _verifyPassword, value, () => VerifyPassword);
            }
        }

        /// <summary>
        /// User accepts Terms & Conditions
        /// </summary>
        bool _acceptsTermsAndConditions;
        public bool AcceptsTermsAndConditions
        {
            get => _acceptsTermsAndConditions;
            set
            {
                SetProperty(ref _acceptsTermsAndConditions, value, () => AcceptsTermsAndConditions);
            }
        }

        /// <summary>
        /// Boolean for whether the profile is valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Boolean for whether the security profile is valid.
        /// </summary>
        public bool IsSecurityValid { get; }
    }
}
