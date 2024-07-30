using Jobs.Api.Request;
using Jobs.Api.Returns;

namespace Jobs.Api.Interfaces
{
    public interface IJobsService
    {
        IEnumerable<JobsResponse> List();
        JobsResponse Consult(int id);
        JobsResponse CreateJobs(JobsRequest request);
        JobsResponse UpdateJob(int id, JobsRequest request);
        bool DeleteJob(int id);
    }
}
