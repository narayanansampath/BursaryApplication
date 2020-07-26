using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampathNarayananAssignment1.Models
{
    public interface Repository
    {
        private static List<FormResponse> responses = new List<FormResponse>();

        public IQueryable<FormResponse> Responses { get; } //=> responses.AsQueryable<FormResponse>();

        void AddResponse(FormResponse response);    
    }
}
