using SampathNarayananAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BursaryApplication.Models
{
    public class EFRepository : Repository
    {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<FormResponse> Responses => context.responses;

        public void AddResponse(FormResponse response)
        {
            if (response.Id == 0)
            {
                context.responses.Add(response);
            } else
            {
                FormResponse dbEntry = context.responses.FirstOrDefault(p => p.Id == response.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = response.Name;
                    dbEntry.Email = response.Email;
                    dbEntry.Phone = response.Phone;
                    dbEntry.IsInternationalStudent = response.IsInternationalStudent;
                }
            }
            context.SaveChanges();
        }

        public FormResponse DeleteResponse(int reponseId)
        {
            FormResponse dbEntry = context.responses.FirstOrDefault(p => p.Id == reponseId);

            if (dbEntry != null)
            {
                context.responses.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

    }
}
