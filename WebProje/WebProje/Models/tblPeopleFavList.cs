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
    
    public partial class tblPeopleFavList
    {
        public int PeopleFavList_PeopleID { get; set; }
        public int PeopleFavList_MemberID { get; set; }
        public string PeopleFavListName { get; set; }
        public Nullable<bool> PeopleFavListIsPublic { get; set; }
    
        public virtual tblMember tblMember { get; set; }
        public virtual tblPeople tblPeople { get; set; }
    }
}
