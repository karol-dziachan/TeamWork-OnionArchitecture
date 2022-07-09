using TeamWorkMVC.Application.DTOs.AppUsers;

namespace TeamWorkMVC.Application.InterfacesServices;

public interface IUserManagementService
{
    UserUpdateDTO GetUserForEdit(string id);
    
    string EditUser(UserUpdateDTO model);

    string EditUserRole(string id, RoleDTO role);

    bool CheckRoleExists(RoleDTO model);

    IQueryable<UserForListDTO> GetAllUsers();

    UserDetailsDTO GetUserById(string id);

    string DeleteUser(string id);

    string AddRole(RoleDTO role);
}