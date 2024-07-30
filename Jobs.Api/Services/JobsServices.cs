using Jobs.Api.Interfaces;
using Jobs.Api.Request;
using Jobs.Api.Returns;

namespace Jobs.Api.Services
{
    public class JobsServices : IJobsService
    {
        public IEnumerable<JobsResponse> List()
        {
            try
            {
                var response = new IEnumerable<JobsResponse>();
                return response;
            }
            catch
            {
                throw new Exception("Algo deu errado.");
            }
        }
        public JobsResponse Consult(int id)
        {
            return new JobsResponse { };
        }
        public JobsResponse CreateJobs(JobsRequest request)
        {
            return true;
        }

        public JobsResponse UpdateJob(int id, JobsRequest request)
        {
            return new JobsResponse { };
        }

        public bool DeleteJob(int id)
        {
            return true;
        }
    }
}
