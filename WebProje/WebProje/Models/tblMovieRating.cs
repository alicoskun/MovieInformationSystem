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
    
    public partial class tblMovieRating
    {
        public int MovieRating_MovieID { get; set; }
        public int MovieRating_MemberID { get; set; }
        public Nullable<int> MovieRatingByMember { get; set; }
    
        public virtual tblMember tblMember { get; set; }
        public virtual tblMovie tblMovie { get; set; }
    }
}
