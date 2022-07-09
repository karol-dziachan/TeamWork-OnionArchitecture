using AutoMapper;
using AutoMapper.QueryableExtensions;
using TeamWorkMVC.Application.DTOs.Projects;
using TeamWorkMVC.Application.InterfacesServices;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;

namespace TeamWorkMVC.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    
    public int AddProject(ProjectCreateDTO model)
    {
        var project = _mapper.Map<Project>(model);
        var id = _projectRepository.AddItem(project);

        return id;
    }

    public IQueryable<ProjectForListDTO> GetAllProjectsForList()
    {
        var projects = _projectRepository.GetAllItems();
        var projectDTO = projects.ProjectTo<ProjectForListDTO>(_mapper.ConfigurationProvider);

        return projectDTO;
    }

    public ProjectDetailsDTO GetProjectById(int id)
    {
        var project = _projectRepository.GetItemById(id);
        var projectDTO = _mapper.Map<ProjectDetailsDTO>(project);

        return projectDTO;
    }

    public ProjectUpdateDTO GetProjectForEdit(int id)
    {
        var project = _projectRepository.GetItemById(id);
        var projectDTO = _mapper.Map<ProjectUpdateDTO>(project);

        return projectDTO;
    }

    public int EditProject(ProjectUpdateDTO model)
    {
        var project = _mapper.Map<Project>(model);
        var projectID = _projectRepository.EditItem(project);

        return projectID;
    }

    public int DeleteProject(int id)
    {
        var projectID = _projectRepository.DeleteItem(id);

        return projectID;
    }
}