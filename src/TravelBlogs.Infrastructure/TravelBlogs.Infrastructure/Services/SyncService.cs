using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Interfaces.Integrates;
using TravelBlogs.Core.Application.Interfaces.Services;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Infrastructure.Services;

public class SyncService(IExternalEnpointClient externalEnpointClient, IUnitOfWork unitOfWork)
    : ISyncService
{
    private readonly IWriteRepository<Country> _countryRepository = unitOfWork.GetRepository<Country>();

    public async Task SyncCountriesData(CancellationToken cancellationToken = default)
    {
        var countries = await externalEnpointClient.GetAllCountries();

        foreach (var country in countries.Values)
        {
            var existingCountry = await _countryRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == country.Id);
            if (existingCountry == null)
            {
                await _countryRepository.InsertAsync(Country.Create(country.Name), cancellationToken);
            }
            else
            {
                existingCountry.Name = country.Name;
                _countryRepository.Update(existingCountry);
            }
        }

        await unitOfWork.SaveChangesAsync();
    }
}