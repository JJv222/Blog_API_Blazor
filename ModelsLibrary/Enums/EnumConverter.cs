using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Enums
{
    public static class EnumConverter
    {
        public static string EnumToString(Enum enumValue)
        {
            switch (enumValue)
            {
                case Role.Admin:
                    return "Admin";
                case Role.User:
                    return "User";
                case Role.Moderator:
                    return "Moderator";
                default:
                    return "None";
            }
        }
        public static Role StringToEnum(string role)
        {
            switch (role)
            {
                case "Admin":
                    return Role.Admin;
                case "User":
                    return Role.User;
                case "Moderator":
                    return Role.Moderator;
                default:
                    return Role.None;
            }
        }   
        public static bool IsAdmin(Role role) { return role == StringToEnum("Admin"); }
        public static bool IsModerator(Role role) { return role == StringToEnum("Moderator"); }
    }
}
