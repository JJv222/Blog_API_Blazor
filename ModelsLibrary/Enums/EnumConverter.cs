using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Enums
{
    public class EnumConverter
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
    }
}
