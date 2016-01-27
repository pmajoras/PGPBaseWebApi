using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain
{
    public enum DomainErrors : int
    {
        [Description("The task does not have a task list")]
        TaskDoesNotHaveTaskList = 1001
    }
}
