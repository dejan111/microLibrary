using AutoMapper;
using MicroLibrary.Infrastructure.Context;

namespace MicroLibrary.Service
{
    public abstract class ServiceBase
    {
        public readonly MicroLibraryContext _microLibraryContext;
        public readonly IMapper _mapper;

        protected ServiceBase(MicroLibraryContext microLibraryContext, IMapper mapper)
        {
            _microLibraryContext = microLibraryContext;
            _mapper = mapper;
        }
    }
}
