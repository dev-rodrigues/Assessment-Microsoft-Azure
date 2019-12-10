using Application.Models.Counts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Counts {
    public interface ICount {
        Task<Count> Sum();
    }
}
