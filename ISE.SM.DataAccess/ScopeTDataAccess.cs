using ISE.Framework.Server.Core.DataAccessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.DataAccess
{
    public class ScopeTDataAccess : TDataAccess<Scope, ScopeDto, ScopeRepository>
    {
        public ScopeTDataAccess()
            : base(new ScopeRepository())
        {
        }
        public List<ScopeDto> GetUserScopes(long resourceId, int userId)
        {
            List<ScopeDto> scopeList = new List<ScopeDto>();
            var scopes = this.Repository.Context.UserResourceScopes.Where(it => it.ResourceId == resourceId && it.UserId == userId).Select(it=>it.Scope);
            foreach (var scope in scopes)
            {
                var dto = ScopeRepository.GetDto(scope);
                scopeList.Add(dto);
            }
            return scopeList;
        }
    }
}
