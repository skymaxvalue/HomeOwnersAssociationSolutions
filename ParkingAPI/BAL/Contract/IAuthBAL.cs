using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Contract
{
    public interface IAuthBAL
    {
        bool Authenticate(string username);
    }
}
