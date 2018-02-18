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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<IEnumerable<CountryViewModel>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return Mapper.Map<IEnumerable<Countries>, IEnumerable<CountryViewModel>>(countries);
        }
    }
}