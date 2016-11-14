﻿using AutoMapper;

namespace Findit.API.Services
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