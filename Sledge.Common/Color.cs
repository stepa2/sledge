using System;
using System.Drawing;

namespace Sledge.Common
{
    /// <summary>
    /// Common extension methods for colours
    /// </summary>
    public static class Color
    {
        private static readonly Random Rand;

        static Color()
        {
            Rand = new Random();
        }

        /// <summary>
        /// Get a completely random opaque colour
        /// </summary>
        /// <returns>A random colour</returns>
        public static System.Drawing.Color GetRandomColour()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(0, 256), Rand.Next(0, 256), Rand.Next(0, 256));
        }

        /// <summary>
        /// Get a random brush colour. Brush colours only vary from shades of green and blue.
        /// </summary>
        /// <returns>A random brush colour</returns>
        public static System.Drawing.Color GetRandomBrushColour()
        {
            return System.Drawing.Color.FromArgb(255, 0, Rand.Next(128, 256), Rand.Next(128, 256));
        }

        /// <summary>
        /// Get a random group colour. Group colours only vary from shades of green and red
        /// </summary>
        /// <returns>A random group colour</returns>
        public static System.Drawing.Color GetRandomGroupColour()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(128, 256), Rand.Next(128, 256), 0);
        }

        /// <summary>
        /// Get a random light colour
        /// </summary>
        /// <returns>A random light colour</returns>
        public static System.Drawing.Color GetRandomLightColour()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(128, 256), Rand.Next(128, 256), Rand.Next(128, 256));
        }

        /// <summary>
        /// Get a random dark colour
        /// </summary>
        /// <returns>A random dark colour</returns>
        public static System.Drawing.Color GetRandomDarkColour()
        {
            return System.Drawing.Color.FromArgb(255, Rand.Next(0, 128), Rand.Next(0, 128), Rand.Next(0, 128));
        }

        /// <summary>
        /// Get the default entity colour (magenta)
        /// </summary>
        /// <returns>The default entity colour</returns>
        public static System.Drawing.Color GetDefaultEntityColour()
        {
            return System.Drawing.Color.FromArgb(255, 255, 0, 255);
        }

        /// <summary>
        /// Randomly change this colour by a small amount
        /// </summary>
        /// <param name="color">The colour</param>
        /// <param name="by">The maximum amount to vary by</param>
        /// <returns>A (probably) slightly different colour</returns>
        public static System.Drawing.Color Vary(this System.Drawing.Color color, int by = 10)
        {
            by = Rand.Next(-by, by);
            return System.Drawing.Color.FromArgb(color.A, Math.Min(255, Math.Max(0, color.R + by)), Math.Min(255, Math.Max(0, color.G + by)), Math.Min(255, Math.Max(0, color.B + by)));
        }

        /// <summary>
        /// Make a colour darker
        /// </summary>
        /// <param name="color">The colour</param>
        /// <param name="by">The amount to darken by</param>
        /// <returns>A darker colour</returns>
        public static System.Drawing.Color Darken(this System.Drawing.Color color, int by = 20)
        {
            return System.Drawing.Color.FromArgb(color.A, Math.Max(0, color.R - by), Math.Max(0, color.G - by), Math.Max(0, color.B - by));
        }

        /// <summary>
        /// Make a colour lighter
        /// </summary>
        /// <param name="color">The colour</param>
        /// <param name="by">The amount to lighten by</param>
        /// <returns>A lighter colour</returns>
        public static System.Drawing.Color Lighten(this System.Drawing.Color color, int by = 20)
        {
            return System.Drawing.Color.FromArgb(color.A, Math.Min(255, color.R + by), Math.Min(255, color.G + by), Math.Min(255, color.B + by));
        }

        /// <summary>
        /// Blend two colours
        /// </summary>
        /// <param name="color">The first colour</param>
        /// <param name="other">The second colour</param>
        /// <returns>A blend of the two colours</returns>
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
        /// Get an ideal foreground colour (white or black) if this colour was the background
        /// </summary>
        /// <param name="color">The background colour</param>
        /// <returns>White for dark backgrounds, black for light backgrounds</returns>
        public static System.Drawing.Color GetIdealForegroundColour(this System.Drawing.Color color)
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
