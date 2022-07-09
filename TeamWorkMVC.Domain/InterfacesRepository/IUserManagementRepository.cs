using Microsoft.AspNetCore.Identity;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Domain.InterfacesRepository;

public interface IUserManagementRepository
{
    IQueryable<AppUser> GetAllItems();

    AppUser GetUserById(string id);

    string EditItem(AppUser appUser);

    string DeleteItem(string id);

    string EditUserRole(string userId, string roleId);
    
    bool CheckRoleExists(string id);

    string AddRole(IdentityRole role);

    string GetUserRole(string id);

    bool CheckUserHasRole(string id);

}