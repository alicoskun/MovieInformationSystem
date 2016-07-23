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
    
    public partial class tblMember
    {
        public tblMember()
        {
            this.tblComment = new HashSet<tblComment>();
            this.tblMovieFavList = new HashSet<tblMovieFavList>();
            this.tblMovieRating = new HashSet<tblMovieRating>();
            this.tblPeopleFavList = new HashSet<tblPeopleFavList>();
        }
    
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPassword { get; set; }
        public Nullable<System.DateTime> MemberDOB { get; set; }
        public int MemberGroupID { get; set; }
        public int MemberReputationID { get; set; }
        public Nullable<System.DateTime> MemberRegisterDate { get; set; }
        public byte[] MemberPhoto { get; set; }
    
        public virtual ICollection<tblComment> tblComment { get; set; }
        public virtual tblMemberGroup tblMemberGroup { get; set; }
        public virtual tblMemberReputation tblMemberReputation { get; set; }
        public virtual ICollection<tblMovieFavList> tblMovieFavList { get; set; }
        public virtual ICollection<tblMovieRating> tblMovieRating { get; set; }
        public virtual ICollection<tblPeopleFavList> tblPeopleFavList { get; set; }
    }
}