﻿using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Common.DTO;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class ScopeBussiness : BussinessBase<Scope, ScopeDto>
    {
        public ScopeBussiness()
        {
            this.dataAccess = new ScopeTDataAccess();
        }
        
    }
}
