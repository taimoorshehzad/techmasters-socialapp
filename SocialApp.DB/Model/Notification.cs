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
    
    public partial class Notification
    {
        public int NotificationID { get; set; }
        public Nullable<int> UserProfileID { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
    }
}
