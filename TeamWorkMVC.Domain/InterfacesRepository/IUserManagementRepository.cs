using Microsoft.AspNetCore.Identity;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Domain.InterfacesRepository;

public interface IUserManagementRepository
{
    IQueryable<AppUser> GetAllItems();

    AppUser GetUserById(string id);

    string EditItem(AppUser appUser);

    string DeleteItem(string id);

    string EditUserRole(string id, IdentityRole role);
    
    bool CheckRoleExists(IdentityRole role);

    string AddRole(IdentityRole role);
}