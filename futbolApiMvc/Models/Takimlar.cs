//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace futbolApiMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Takimlar
    {
        public int TakimId { get; set; }
        public string TakimAdi { get; set; }
        public string TakimSehri { get; set; }
        public string TakimUlkesi { get; set; }
        public Nullable<int> TakimGalibiyet { get; set; }
        public Nullable<int> TakimMalubiyet { get; set; }
        public Nullable<int> TakimBeraberlik { get; set; }
    }
}