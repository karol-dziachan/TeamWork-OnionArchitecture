using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;
using TeamWorkMVC.Infrastructure.Abstract;

namespace TeamWorkMVC.Infrastructure.Repositores;

public class UserManagementRepository : BaseRepository, IUserManagementRepository
{
    public UserManagementRepository(Context context) : base(context)
    {
    }

    public IQueryable<AppUser> GetAllItems()
    {
        return _context.AppUsers;
    }

    public AppUser GetUserById(string id)
    {
        var user = _context.AppUsers
            .Include(p => p.Address)
            .Include(p => p.Projects)
            .Include(p => p.WorkerProject)
            .Include(p => p.WorkerTask)
            .FirstOrDefault(u => u.Id == id);

        return user;
    }

    public string EditItem(AppUser appUser)
    {
        var searchUser = _context.AppUsers.FirstOrDefault(i => i.Id == appUser.Id);
 

        _context.AppUsers.Remove(searchUser);
        _context.AppUsers.Add(appUser);

        
        _context.SaveChanges();
        
        return appUser.Id;
    }

    public string DeleteItem(string id)
    {
        var user = _context.AppUsers.FirstOrDefault(u => u.Id == id);

        if (user != null)
        {
            _context.AppUsers.Remove(user);
            _context.SaveChanges();
            return user.Id;
        }
        
        return String.Empty;
    }

    public string EditUserRole(string userId, string roleId)
    {
        var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);


        if (userRole != null)
        {
         
            /*_context.UserRoles.ToList().RemoveAll( a=> a.RoleId == userRole.RoleId && a.UserId == userRole.UserId);*/

            _context.UserRoles.Remove(userRole);
            
            _context.SaveChanges();
            
            userRole.RoleId = roleId;
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return roleId;
        }

        var userForNewRole = _context.AppUsers.FirstOrDefault(u => u.Id == userId);

        if (userForNewRole != null)
        {
            var newUserRole = new IdentityUserRole<string>
            {
                RoleId = roleId, 
                UserId = userId
            };
            
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();

            return roleId;
        }
        
        
        return String.Empty;
    }
    

    public bool CheckRoleExists(string id)
    {
        var role = _context.Roles.FirstOrDefault(i => i.Id == id);

        return role != null;
    }

    public bool CheckUserHasRole(string id)
    {
        var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == id);
        ;
        return userRole != null;
    }

    public string AddRole(IdentityRole role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();

        return role.Id;
    }

    public string GetUserRole(string id)
    {
        var role = _context.UserRoles.FirstOrDefault(i => i.UserId == id);

        if (role != null)
        {
            var roleId = role.RoleId;
            return roleId;
        }

        return String.Empty;
    }


}