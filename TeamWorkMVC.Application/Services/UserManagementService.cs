using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeamWorkMVC.Application.DTOs.AppUsers;
using TeamWorkMVC.Application.InterfacesServices;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.Services;

public class UserManagementService : UserManager<AppUser>, IUserManagementService
{
    private readonly IUserManagementRepository _userManagementRepository;
    private readonly IMapper _mapper;

    public UserManagementService(
        IUserManagementRepository userManagementRepository, 
        IMapper mapper,
        IUserStore<AppUser> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<AppUser> passwordHasher,
        IEnumerable<IUserValidator<AppUser>> userValidators,
        IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<AppUser>> logger) 
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _userManagementRepository = userManagementRepository;
        _mapper = mapper;
    }

    public UserUpdateDTO GetUserForEdit(string id)
    {
        var user = _userManagementRepository.GetUserById(id);
        var userDTO = _mapper.Map<UserUpdateDTO>(user);

        return userDTO;
    }
    
    public string EditUser(UserUpdateDTO model)
    {
        var user = _mapper.Map<AppUser>(model);
        _userManagementRepository.EditItem(user);

        return user.Id;
    }

    public string EditUserRole(string id, RoleDTO role)
    {
        var checkRole = CheckRoleExists(role);

        if (checkRole)
        {
            var roleDTO = _mapper.Map<IdentityRole>(role);
            _userManagementRepository.EditUserRole(id, roleDTO);

            return id;
        }
        
        return String.Empty;
    }

    public bool CheckRoleExists(RoleDTO model)
    {
        var roleDTO = _mapper.Map<IdentityRole>(model);
        bool checkRoleResult = _userManagementRepository.CheckRoleExists(roleDTO);

        return checkRoleResult;
    }

    public IQueryable<UserForListDTO> GetAllUsers()
    {
        var users = _userManagementRepository.GetAllItems();
        var usersDTO = users.ProjectTo<UserForListDTO>(_mapper.ConfigurationProvider);

        return usersDTO;
    }

    public UserDetailsDTO GetUserById(string id)
    {
        var user = _userManagementRepository.GetUserById(id);
        var userDTO = _mapper.Map<UserDetailsDTO>(user);

        return userDTO;
    }

    public string DeleteUser(string id)
    {
        var userId = _userManagementRepository.DeleteItem(id);

        return userId;
    }

    public string AddRole(RoleDTO model)
    {
        var roleDTO = _mapper.Map<IdentityRole>(model);
        var res = _userManagementRepository.AddRole(roleDTO);

        return res;
    }
}