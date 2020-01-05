using System;
using System.Collections.Generic;
using PrismTests.Interfaces;
using PrismTests.Models;

namespace PrismTests.ViewModels
{
    public class ViewModelManager : IViewModelManager
    {
        #region Properties

        public ISettings Settings { get; set; }

        public IAppUser CurrentUser { get; set; }

        #endregion

        public ViewModelManager(ISettings settings)
        {
            try
            {
                Settings = settings;
            }
            catch(Exception ex)
            {

            }
        }

        #region Public Methods

        public IAppUser UpdateOrCreatetUser(IAppUser appUser)
        {
            try
            {
                var users = new List<IAppUser>(); // TODO: Add Local Repo _userRepository.ReadAllItems();
                if (users?.Count > 0)
                {
                    CurrentUser = users[0];
                }
                else
                {
                    CurrentUser = (IAppUser)new AppUser
                    {
                        Id = new Guid(),
                        FirstName = "Erik",
                        LastName = "Rockstar",
                        Email = "1@2.com",
                        AcceptsTermsAndConditions = true,
                        Password = "123456",
                        VerifyPassword = "123456"
                    };
                    // TODO: Add Local Repo
                    // _userRepository.CreateItem(CurrentUser);
                }
            }
            catch (Exception ex)
            {
                // TODO: Add Utility Logging class
                // Logger.LogError(ex);
            }
            return CurrentUser;
        }

        #endregion
    }
}