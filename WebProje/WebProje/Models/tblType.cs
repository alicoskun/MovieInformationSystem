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
    
    public partial class tblType
    {
        public tblType()
        {
            this.tblMovieType = new HashSet<tblMovieType>();
        }
    
        public int TypeID { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<tblMovieType> tblMovieType { get; set; }
    }
}
