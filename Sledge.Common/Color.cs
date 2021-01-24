using System;
using System.Drawing;

namespace Sledge.Common
{
    /// <summary>
    /// Common extension methods for colors
    /// </summary>
    public static class Color
    {
        private static readonly Random Rand;

        static Color()
        {
            Rand = new Random();
        }

        /// <summary>
        /// Get a completely random opaque color
        /// </summary>
        /// <returns>A random color</returns>
        public static System.Drawing.Color GetRandomColor()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(0, 256), Rand.Next(0, 256), Rand.Next(0, 256));
        }

        /// <summary>
        /// Get a random brush color. Brush colors only vary from shades of green and blue.
        /// </summary>
        /// <returns>A random brush color</returns>
        public static System.Drawing.Color GetRandomBrushColor()
        {
            return System.Drawing.Color.FromArgb(255, 0, Rand.Next(128, 256), Rand.Next(128, 256));
        }

        /// <summary>
        /// Get a random group color. Group colors only vary from shades of green and red
        /// </summary>
        /// <returns>A random group color</returns>
        public static System.Drawing.Color GetRandomGroupColor()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(128, 256), Rand.Next(128, 256), 0);
        }

        /// <summary>
        /// Get a random light color
        /// </summary>
        /// <returns>A random light color</returns>
        public static System.Drawing.Color GetRandomLightColor()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(128, 256), Rand.Next(128, 256), Rand.Next(128, 256));
        }

        /// <summary>
        /// Get a random dark color
        /// </summary>
        /// <returns>A random dark color</returns>
        public static System.Drawing.Color GetRandomDarkColor()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(0, 128), Rand.Next(0, 128), Rand.Next(0, 128));
        }

        /// <summary>
        /// Get the default entity color (magenta)
        /// </summary>
        /// <returns>The default entity color</returns>
        public static System.Drawing.Color GetDefaultEntityColor()
        {
            return System.Drawing.Color.FromArgb(255, 255, 0, 255);
        }

        /// <summary>
        /// Randomly change this color by a small amount
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="by">The maximum amount to vary by</param>
        /// <returns>A (probably) slightly different color</returns>
        public static System.Drawing.Color Vary(this System.Drawing.Color color, int by = 10)
        {
            by = Rand.Next(-by, by);
            return System.Drawing.Color.FromArgb(color.A, Math.Min(255, Math.Max(0, color.R + by)), Math.Min(255, Math.Max(0, color.G + by)), Math.Min(255, Math.Max(0, color.B + by)));
        }

        /// <summary>
        /// Make a color darker
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="by">The amount to darken by</param>
        /// <returns>A darker color</returns>
        public static System.Drawing.Color Darken(this System.Drawing.Color color, int by = 20)
        {
            return System.Drawing.Color.FromArgb(color.A, Math.Max(0, color.R - by), Math.Max(0, color.G - by), Math.Max(0, color.B - by));
        }

        /// <summary>
        /// Make a color lighter
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="by">The amount to lighten by</param>
        /// <returns>A lighter color</returns>
        public static System.Drawing.Color Lighten(this System.Drawing.Color color, int by = 20)
        {
            return System.Drawing.Color.FromArgb(color.A, Math.Min(255, color.R + by), Math.Min(255, color.G + by), Math.Min(255, color.B + by));
        }

        /// <summary>
        /// Blend two colors
        /// </summary>
        /// <param name="color">The first color</param>
        /// <param name="other">The second color</param>
        /// <returns>A blend of the two colors</returns>
        public static System.Drawing.Color Blend(this System.Drawing.Color color, System.Drawing.Color other)
        {
            return System.Drawing.Color.FromArgb(
                (byte) ((color.A) / 255f * (other.A / 255f) * 255),
                (byte) ((color.R) / 255f * (other.R / 255f) * 255),
                (byte) ((color.G) / 255f * (other.G / 255f) * 255),
                (byte) ((color.B) / 255f * (other.B / 255f) * 255)
            );
        }

        /// <summary>
        /// Get an ideal foreground color (white or black) if this color was the background
        /// </summary>
        /// <param name="color">The background color</param>
        /// <returns>White for dark backgrounds, black for light backgrounds</returns>
        public static System.Drawing.Color GetIdealForegroundColor(this System.Drawing.Color color)
        {
            // https://stackoverflow.com/a/1855903
            var luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminance > 0.5 ? System.Drawing.Color.Black : System.Drawing.Color.White;
        }

        public static uint ToImGuiColor(this System.Drawing.Color color)
        {
            unchecked
            {
                return (uint) (
                           color.R << 0 |
                           color.G << 8 |
                           color.B << 16 |
                           color.A << 24
                       ) & 0xffffffff;
            }
        }
    }
}
