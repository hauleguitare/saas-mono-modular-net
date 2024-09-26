using System.Globalization;
using System.Text;

namespace SharedKernel.Common.Extension;

public static class StringExtension
{
    /// <summary>
    /// Convert string to snake case.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToSnakeCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        var builder = new StringBuilder(value.Length + Math.Min(2, value.Length / 5));
        var previousCategory = default(UnicodeCategory?);

        for (var currentIndex = 0; currentIndex < value.Length; currentIndex++)
        {
            var currentChar = value[currentIndex];
            if (currentChar == '_')
            {
                builder.Append('_');
                previousCategory = null;
                continue;
            }

            var currentCategory = char.GetUnicodeCategory(currentChar);
            switch (currentCategory)
            {
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.TitlecaseLetter:
                    if (previousCategory == UnicodeCategory.SpaceSeparator ||
                        previousCategory == UnicodeCategory.LowercaseLetter ||
                        previousCategory != UnicodeCategory.DecimalDigitNumber &&
                        previousCategory != null &&
                        currentIndex > 0 &&
                        currentIndex + 1 < value.Length &&
                        char.IsLower(value[currentIndex + 1]))
                    {
                        builder.Append('_');
                    }

                    currentChar = char.ToLower(currentChar);
                    break;

                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.DecimalDigitNumber:
                    if (previousCategory == UnicodeCategory.SpaceSeparator)
                        builder.Append('_');
                    break;

                default:
                    if (previousCategory != null)
                        previousCategory = UnicodeCategory.SpaceSeparator;
                    continue;
            }

            builder.Append(currentChar);
            previousCategory = currentCategory;
        }

        return builder.ToString();
    }

    /// <summary>
    /// Convert string to hyphen case.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToHyphenCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        var builder = new StringBuilder(value.Length + Math.Min(2, value.Length / 5));
        var previousCategory = default(UnicodeCategory?);
        
        for (var currentIndex = 0; currentIndex < value.Length; currentIndex++)
        {
            var currentChar = value[currentIndex];
            if (currentChar == '-')
            {
                builder.Append('-');
                previousCategory = null;
                continue;
            }

            var currentCategory = char.GetUnicodeCategory(currentChar);
            switch (currentCategory)
            {
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.TitlecaseLetter:
                    if (previousCategory == UnicodeCategory.SpaceSeparator ||
                        previousCategory == UnicodeCategory.LowercaseLetter ||
                        previousCategory != UnicodeCategory.DecimalDigitNumber &&
                        previousCategory != null &&
                        currentIndex > 0 &&
                        currentIndex + 1 < value.Length &&
                        char.IsLower(value[currentIndex + 1]))
                    {
                        builder.Append('-');
                    }

                    currentChar = char.ToLower(currentChar);
                    break;

                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.DecimalDigitNumber:
                    if (previousCategory == UnicodeCategory.SpaceSeparator)
                        builder.Append('-');
                    break;

                default:
                    if (previousCategory != null)
                        previousCategory = UnicodeCategory.SpaceSeparator;
                    continue;
            }

            builder.Append(currentChar);
            previousCategory = currentCategory;
        }

        return builder.ToString();
    }

}