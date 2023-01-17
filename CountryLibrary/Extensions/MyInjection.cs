using CountryLibrary.Services.Interfaces;
using CountryLibrary.Services;

namespace CountryLibrary.Extensions
{
    public static class MyInjection
    {
        public static IServiceCollection AddMyInjection(this IServiceCollection service)
        {
            service.AddSingleton<ITeamMemberService, TeamMembersService>();
            service.AddSingleton<ICountryService, CountriesInfoService>();
            return service;
        }
    }
}
