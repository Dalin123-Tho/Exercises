using CountryLibrary.Models;
using CountryLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using static CountryLibrary.Services.Interfaces.ITeamMemberService;

namespace CountryLibrary.Services
{
    public class TeamMembersService : ITeamMemberService
    {
        public List<TeamMember> GetTeamMembers()
        {
            //TODO
            return new List<TeamMember>()
            {
                new TeamMember()
                {
                    Name = "Leo CSU",
                    Gender = "Male",
                    Age = 27,
                    Address = "Phnom Penh",
                    Email = "leo@techbodia.com"
                },
                 new TeamMember()
                {
                    Name = "Dalin Tho",
                    Gender = "Male",
                    Age = 21,
                    Address = "Phnom Penh",
                    Email = "dalin.tho@techbodia.com"
                },
                 new TeamMember()
                {
                    Name = "Meng Chhiv",
                    Gender = "Male",
                    Age = 21,
                    Address = "Phnom Penh",
                    Email = "mengchhiv@techbodia.com"
                }
                 ,
                 new TeamMember()
                {
                    Name = "Orng",
                    Gender = "Male",
                    Age = 24,
                    Address = "Phnom Penh",
                    Email = "orng@techbodia.com"
                }
            };

        }
    }
}
