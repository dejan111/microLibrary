using AutoMapper;
using MicroLibrary.Infrastructure.Context;

namespace MicroLibrary.Service.Services
{
    public abstract class ServiceBase
    {
        public readonly MicroLibraryContext microLibraryContext;
        public readonly IMapper mapper;

        protected ServiceBase(MicroLibraryContext microLibraryContext, IMapper mapper)
        {
            this.microLibraryContext = microLibraryContext;
            this.mapper = mapper;
        }
    }
}
