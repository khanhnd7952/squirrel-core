using UnityEngine;

namespace Squirrel.Extension
{
    public static class ColorExtension
    {
        public static Color GetColorFromHex(string colorCode)
        {
            ColorUtility.TryParseHtmlString(colorCode, out var c);
            return c;
        }
    }
}