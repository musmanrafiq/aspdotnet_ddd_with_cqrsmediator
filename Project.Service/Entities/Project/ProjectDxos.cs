using AutoMapper;
using Project.Domain.Dtos;

namespace Project.Service.Dxos
{
    public class ProjectDxos : IProjectDxos
    {
        private readonly IMapper _mapper;

        public ProjectDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Models.Project, Domain.Dtos.ProjectDto>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.Age))
                    .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            });

            _mapper = config.CreateMapper();
        }
        
        public ProjectDto MapProjectDto(Domain.Models.Project Project)
        {
            return _mapper.Map<Domain.Models.Project, Domain.Dtos.ProjectDto>(Project);
        }
    }
}