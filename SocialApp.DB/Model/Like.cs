//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialApp.DB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Like
    {
        public int LikeID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> PostID { get; set; }
        public Nullable<int> LikeBy { get; set; }
    
        public virtual LikeStatu LikeStatu { get; set; }
        public virtual Post Post { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
