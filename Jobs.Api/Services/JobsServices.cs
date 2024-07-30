using Jobs.Api.Interfaces;
using Jobs.Api.Models;
using Jobs.Api.Persistence;
using Jobs.Api.Request;
using Jobs.Api.Returns;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Api.Services
{
    public class JobsServices : IJobsService
    {
        private readonly JobDbContext _context;
        public JobsServices(JobDbContext context)
        {
            _context = context;
        }
        public IEnumerable<JobsResponse> List()
        {
            try
            {
                var list = _context.Jobs.AsNoTracking().ToList();
                Job job = new Job { };
                var response = job.ConvertListResponse(list);
                return response;
            }
            catch
            {
                throw new Exception("Algo deu errado.");
            }
        }
        public JobsResponse Consult(int id)
        {
            var consult = _context.Jobs.AsNoTracking().SingleOrDefault(j => j.Id == id);
            if (consult != null)
            {
                var response = new JobsResponse 
                { 
                    Id = consult.Id, 
                    Description = consult.Description, 
                    Location = consult.Location, 
                    Salary = consult.Salary,
                    Title = consult.Title 
                };
                return response;
            }

            return null;
        }
        public JobsResponse CreateJobs(JobsRequest request)
        {
            Job job = new Job { };
            job = job.RequestJobToInsert(request);
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return Consult(job.Id);
        }
        public JobsResponse UpdateJob(int id, JobsRequest request)
        {
            var consult = _context.Jobs.AsNoTracking().SingleOrDefault(j => j.Id == id);
            if (consult == null)
                return null;

            var job = consult.RequestJobToUpdate(id, request);

            _context.Jobs.Update(job);
            _context.SaveChanges();

            return Consult(id);
        }
        public bool DeleteJob(int id)
        {
            var consult = _context.Jobs.AsNoTracking().SingleOrDefault(j => j.Id == id);
            if(consult == null)
                return false;

            _context.Jobs.Remove(consult);
            _context.SaveChanges();

            return true;
        }
    }
}
