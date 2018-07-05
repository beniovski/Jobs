using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using JobsPortal.Models;
using JobsPortal.Repositories;
using JobsPortal.ViewModels;

namespace JobsPortal.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public async Task<IList<StateViewModel>> GetAllStatesAsync()
        {
            var states = await _stateRepository.GetAllStates();
            return Mapper.Map<IList<State>, IList<StateViewModel>>(states);
        }
    }
}