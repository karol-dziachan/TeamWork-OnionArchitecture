using Microsoft.AspNetCore.Identity;
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
            .Include(p => p.Projects)
            .Include(p => p.WorkerProject)
            .Include(p => p.WorkerTask)
            .FirstOrDefault(u => u.Id == id);

        return user;
    }

    public string EditItem(AppUser appUser)
    {
        _context.AppUsers.Update(appUser);
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

    public string EditUserRole(string id, IdentityRole role)
    {
        
        var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == id);

        if (userRole != null)
        {
            userRole.RoleId = role.Id;
            return id;
        }
        
        return String.Empty;
    }

    public bool CheckRoleExists(IdentityRole role)
    {
        return _context.Roles.Contains(role);
    }

    public string AddRole(IdentityRole role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();

        return role.Id;
    }
}