
using System.Linq;
using HotChocolate;
using ConferencePlanner5._0.Data;

namespace ConferencePlanner5._0
{
    public class Query
    {
        public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) =>
            context.Speakers;
    }
}