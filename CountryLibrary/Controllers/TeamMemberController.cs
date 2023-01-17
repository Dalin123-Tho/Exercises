using CountryLibrary.Models;
using CountryLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CountryLibrary.Services.Interfaces.ITeamMemberService;

namespace CountryLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamMemberService _service;
        public TeamController(ITeamMemberService service)
        {
            _service = service;
        }
        
        [HttpGet("GetTeamMembers")]
        public List<TeamMember> GetTeamMembers()
        {
            return _service.GetTeamMembers();
        }
    }
}
