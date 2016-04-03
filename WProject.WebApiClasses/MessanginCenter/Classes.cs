using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Classes;

namespace WProject.WebApiClasses.MessanginCenter
{
    public class SimpleCacheResponse
    {
        public IDictionary<string, List<object>> Data { get; set; } 
    }

    public class GetAllProjectsRequest
    {
        public int? OwnerId { get; set; }

        public int? UserId { get; set; }

        public bool OnlyActive { get; set; }

        public string Name { get; set; }

        public GetAllProjectsRequest()
        {
            OnlyActive = true;
        }
    }

    public class GetAllProjectsResponse
    {
        public IEnumerable<Project> Projects { get; set; }

        public Exception Exception { get; set; }

        public bool Error { get; set; }

        public GetAllProjectsResponse()
        {
            Projects = Enumerable.Empty<Project>();
        }
    }

    public class ExecuteLoginRequest
    {
        public string Name { get; set; }

        public string Pass { get; set; }
    }

    public class ExecuteLoginResonse
    {
        public User User { get; set; }

        public Exception Exception { get; set; }

        public bool Error { get; set; }
    }

    public class GetSpringsRequest
    { 
        public int? ProjectId { get; set; }

        public int? UserId { get; set; }
        
        public int? OwnerId { get; set; }

        public bool OnlyActive { get; set; }

        public string Name { get; set; }

        public GetSpringsRequest()
        {
            OnlyActive = true;
        }
    }

    public class GetSpringsResponse
    {
        public IEnumerable<Spring> Springs { get; set; }

        public Exception Exception { get; set; }

        public bool Error { get; set; }
    }

    public class GetAllBackLogsRequest
    {
        public int? SpringId { get; set; }

        public int? CategoryId { get; set; }
    }

    public class GetAllBackLogsResonse
    {
        public IEnumerable<Backlog> Backlogs { get; set; }

        public Exception Exception { get; set; }

        public bool Error { get; set; }
    }
    
}
