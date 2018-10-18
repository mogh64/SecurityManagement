using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
    public class AccessToken
    {
        public AccessToken()
        {
            Claims = new List<Claim>();
            Operations = new List<OperationDto>();
            
        }
        [DataMember]
        public SecurityResourceDto Resource { get; set; }
        [DataMember]
        public List<Claim> Claims { get; set; }
        public List<OperationDto> Operations { get; set; }
        [DataMember]
        public ScopeDto Scopes { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int LifeTimeMinute { get; set; }
        [DataMember]
        public DateTime CreationTime { get; internal set; }
        public string ClaimValue(string claimType)
        {

            return Claims.Where(x => x.Type == claimType).Select(x => x.Value).SingleOrDefault() ?? string.Empty;

        }
        public bool this[string operationName]
        {
            get
            {
                var op =Operations.Where(it => it.OperationName.ToLower().Equals(operationName.ToLower())).FirstOrDefault();
                return op != null;
            }
        }
        public bool this[int operationId]
        {
            get
            {
                var op= Operations.Where(it => it.OperationId==operationId).FirstOrDefault();
                return op != null;
            }
        }
        public string SubjectId
        {
            get { return Claims.Where(x => x.Type == ClaimTypes.Subject).Select(x => x.Value).SingleOrDefault(); }
        }
        public override string ToString()
        {
            string text = UserName;
            foreach (var claim in Claims)
            {
                text += claim.ToString();
                text += ",";
            }
            foreach (var operation in Operations)
            {
                text += operation.OperationId;
                text += ",";
            }
            return text;
        }
    }
}
