using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Domain.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        try
        {
            return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName() ?? value.ToString();
        }
        catch (Exception ex)
        {
            return value.ToString();
        }
    }
}
