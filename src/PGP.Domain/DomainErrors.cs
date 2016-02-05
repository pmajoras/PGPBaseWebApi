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
        // 901 - 999 Fields Errors
        [Description("The field is required.")]
        FieldIsRequired = 901,
        [Description("The field is required.")]
        FieldHasMinLength = 902,
        [Description("The field is required.")]
        FieldHasMaxLength = 903,

        // 1000 - 1050 Task Entity Errors
        [Description("The task does not have a task list.")]
        TaskDoesNotHaveTaskList = 1001,

        // 1051 - 1100 User Entity Errors
        [Description("The user does not have a valid password.")]
        UserDoesNotHaveValidPassword = 1051,
        [Description("The username of the user already exists.")]
        UserUsernameAlreadyExists = 1052
    }
}
