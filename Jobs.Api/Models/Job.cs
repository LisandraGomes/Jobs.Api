using Jobs.Api.Request;
using Jobs.Api.Returns;

namespace Jobs.Api.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }

        internal Job RequestJobToInsert(JobsRequest? request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            var job = new Job
            {
                Description = request.Description,
                Title = request.Title,
                Location = request.Location,
                Salary = request.Salary
            };
            return job;
        }
        internal Job RequestJobToUpdate(int id, JobsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var job = new Job
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Salary = request.Salary
            };
            return job;
        }
        internal IEnumerable<JobsResponse> ConvertListResponse(IEnumerable<Job> jobs)
        {
            List<JobsResponse> result = new List<JobsResponse>();
            foreach(var job in jobs)
            {
                var jobList = new JobsResponse
                {
                    Id = job.Id,
                    Description = job.Description,
                    Title = job.Title,
                    Location = job.Location,
                    Salary = job.Salary
                };
                result.Add(jobList);
            }
            return result;
        }
    }  
}
