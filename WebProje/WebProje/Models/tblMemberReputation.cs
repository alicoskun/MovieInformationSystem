//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMemberReputation
    {
        public tblMemberReputation()
        {
            this.tblMember = new HashSet<tblMember>();
        }
    
        public int MemberReputationID { get; set; }
        public string MemberLevelName { get; set; }
    
        public virtual ICollection<tblMember> tblMember { get; set; }
    }
}
