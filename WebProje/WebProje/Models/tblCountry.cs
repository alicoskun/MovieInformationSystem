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
    
    public partial class tblCountry
    {
        public tblCountry()
        {
            this.tblMovie = new HashSet<tblMovie>();
        }
    
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    
        public virtual ICollection<tblMovie> tblMovie { get; set; }
    }
}