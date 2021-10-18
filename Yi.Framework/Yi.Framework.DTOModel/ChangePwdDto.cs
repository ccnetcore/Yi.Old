using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.DTOModel
{
    public class ChangePwdDto:user
    {
        public string newPassword { get; set; }
    }
}
