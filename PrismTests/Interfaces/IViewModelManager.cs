using System;
namespace PrismTests.Interfaces
{
    public interface IViewModelManager
    {
        IAppUser UpdateOrCreatetUser(IAppUser appUser);

        ISettings Settings { get; set; }

        IAppUser CurrentUser { get; set; }
    }
}
