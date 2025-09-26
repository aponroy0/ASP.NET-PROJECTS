using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public interface IdeleteCandidate<Id>
    {
        bool DeleteCandidate(Id id_e,Id id_c);
    }
}
