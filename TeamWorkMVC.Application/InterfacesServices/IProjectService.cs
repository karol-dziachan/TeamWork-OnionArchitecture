using TeamWorkMVC.Application.DTOs.Projects;

namespace TeamWorkMVC.Application.InterfacesServices;

public interface IProjectService
{
    int AddProject(ProjectCreateDTO model);
    
    IQueryable<ProjectForListDTO> GetAllProjectsForList();
    
    ProjectDetailsDTO GetProjectById(int id);
    
    ProjectUpdateDTO GetProjectForEdit(int id);
    
    int EditProject(ProjectUpdateDTO model);
    
    int DeleteProject(int id);
}