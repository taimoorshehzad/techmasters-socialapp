using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using SocialApp.BL;

namespace SocialApp.Utility
{
    public static class IdentityExtensions
    {
        public static int GetUserProfileID(this IIdentity identity)
        {
            if (identity.GetUserId() != "")
            {
                var userProfile = new UserProfileBL().GetProfileByUserIdentity(identity.GetUserId());
                if (userProfile != null)
                {
                    return userProfile.UserProfileID;
                }
                return 0;
            }
            return 0;
        }
        public static string GetUserFullName(this IIdentity identity)
        {
            if (identity.GetUserId() != "")
            {
                var userProfile = new UserProfileBL().GetProfileByUserIdentity(identity.GetUserId());
                if (userProfile != null)
                {
                    return userProfile.FirstName + " " + userProfile.LastName;
                }
                return "";
            }
            return "";
        }
    }
}