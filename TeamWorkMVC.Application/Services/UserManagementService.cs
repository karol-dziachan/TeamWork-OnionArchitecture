using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeamWorkMVC.Application.DTOs.AppUsers;
using TeamWorkMVC.Application.InterfacesServices;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;
using System.Security.Claims;


namespace TeamWorkMVC.Application.Services;

public class UserManagementService : UserManager<AppUser>, IUserManagementService
{
    private readonly IUserManagementRepository _userManagementRepository;
    private readonly IMapper _mapper;
    private readonly SignInManager<AppUser> _signInManager;

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
        ILogger<UserManager<AppUser>> logger, 
        SignInManager<AppUser> signInManager) 
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _userManagementRepository = userManagementRepository;
        _mapper = mapper;
        _signInManager = signInManager;
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

    public string EditUserRole(UserRoleDTO model)
    {
        var checkRole = _userManagementRepository.CheckRoleExists(model.RoleId);
        var checkHasRole = _userManagementRepository.CheckUserHasRole(model.UserId);
        var user =_userManagementRepository.GetUserById(model.UserId);
        

        if (checkRole)
        {
            var res =_userManagementRepository.EditUserRole(model.UserId, model.RoleId);
            return res;
        }
        return String.Empty;
    }

    public bool CheckRoleExists(string id)
    {
      
        bool checkRoleResult = _userManagementRepository.CheckRoleExists(id);

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

    public UserRoleDTO GetUserForEditRole(string id)
    {
        var user = _userManagementRepository.GetUserById(id);
        var userDto = _mapper.Map<UserRoleDTO>(user);

        var userRoleId = _userManagementRepository.GetUserRole(id);

        if (userRoleId == String.Empty)
        {
            userRoleId = "";
        }

        userDto.RoleId = userRoleId;

        return userDto;
    }

    
}