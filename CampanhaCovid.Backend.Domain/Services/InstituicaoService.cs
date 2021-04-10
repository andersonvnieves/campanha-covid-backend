using AutoMapper;
using CampanhaCovid.Backend.Domain.Interfaces;
using CampanhaCovid.Backend.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaCovid.Backend.Domain.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private IMapper mapper;
        private readonly IUnitOfWork _uow;
        public InstituicaoService(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this._uow = uow;
        }

    }
}
