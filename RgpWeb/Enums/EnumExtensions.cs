using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RgpWeb.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(PropertyStatus enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();

            if (string.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }

            return displayName;
        }
    }
}
