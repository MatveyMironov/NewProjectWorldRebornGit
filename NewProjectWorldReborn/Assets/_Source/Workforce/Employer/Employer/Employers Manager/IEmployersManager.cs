using System;
using System.Collections.Generic;

namespace EmployerSystem
{
    public interface IEmployersManager
    {
        HashSet<IEmployer> Employers { get; }
        event Action<IEmployer> OnEmployerAdded;
        event Action<IEmployer> OnEmployerRemoved;

        bool TryAddEmployer(IEmployer employer);
        bool TryRemoveEmployer(IEmployer employer);
    }
}