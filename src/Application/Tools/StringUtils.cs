namespace Application.Tools;

public static class StringUtils
{
    public static string TrimToLower(this string value)
    {
        return value.Trim().ToLower();
    }
}