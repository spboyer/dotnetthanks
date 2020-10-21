using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dotnetthanks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepoController : ControllerBase
    {
        private readonly ILogger<RepoController> logger;
        private readonly IConfiguration config;

        private readonly IRepos repos;

        public RepoController(IConfiguration config, ILogger<RepoController> logger, IRepos repos)
        {
            this.config = config;
            this.logger = logger;
            this.repos  = repos;
        }

        [HttpGet("{repo}")]
        public Repo Get(string repo)
        {
            logger.LogDebug($"Getting data for repo {repo}");

            return repos.Items.Find(r => r.Name == repo);

        }
    }
}