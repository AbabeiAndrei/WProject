using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Interfaces;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.WebApiClasses.MessanginCenter
{
    public class GenericResponse : IMessangingCenterResponse
    {
        public object Date { get; set; }

        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
    }

    public class SimpleCacheResponse : IMessangingCenterResponse
    {
        public IDictionary<string, List<object>> Data { get; set; }

        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
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

    public class GetAllProjectsResponse : IMessangingCenterResponse
    {
        public IEnumerable<Project> Projects { get; set; }

        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion

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

    public class ExecuteLoginResonse : IMessangingCenterResponse
    {
        public User User { get; set; }

        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
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

    public class GetSpringsResponse : IMessangingCenterResponse
    {
        public IEnumerable<Spring> Springs { get; set; }

        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
    }

    public class GetAllBackLogsRequest
    {
        public int? SpringId { get; set; }

        public int? CategoryId { get; set; }
    }

    public class GetAllBackLogsResonse : IMessangingCenterResponse
    {
        public IEnumerable<Backlog> Backlogs { get; set; }
        
        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
    }

    public class RegisterTaskStateRequest 
    {
        public int TaskId { get; set; }
        public string NewStateCode { get; set; }
    }

    public class RegisterTaskStateResponse : IMessangingCenterResponse
    {
        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
    }

    public class RegisterBacklogStateRequest
    { 
        public int BacklogId { get; set; }
        public string NewStateCode { get; set; }
    }

    public class RegisterBacklogStateResponse : IMessangingCenterResponse
    {
        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
    }

    public class GetTaskRequest
    {
        public int TaskId { get; set; }
    }

    public class GetTaskResponse :IMessangingCenterResponse
    {
        public Task Task { get; set; }

        #region Implementation of IMessangingCenterResponse

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        #endregion
    }

}
