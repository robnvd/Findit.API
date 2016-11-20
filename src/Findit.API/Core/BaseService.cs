using AutoMapper;

namespace Findit.API.Core
{
    public class BaseService
    {
        protected readonly IMapper Mapper;

        protected BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}