using System;
using System.Collections.Generic;
using System.Text;

namespace SideyUtils.Drawing
{
    /// <summary>
    /// Represents the position of a region.
    /// </summary>
    public struct RegionPosition
    {
        /// <summary>
        /// The X-position of the region.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y-position of the region.
        /// </summary>
        public int Y;

        /// <summary>
        /// A RegionPosition at the specified X-position and Y-position.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public RegionPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj is RegionPosition);
        }

        /// <summary>
        /// Checks whether this instance and the specified comparison are equal.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public bool Equals(RegionPosition comp)
        {
            return comp.X == this.X && comp.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        public static bool operator ==(RegionPosition l, RegionPosition r)
        {
            return l.Equals(r);
        }

        public static bool operator !=(RegionPosition l, RegionPosition r)
        {
            return !l.Equals(r);
        }
    }

    /// <summary>
    /// Represents the size of a region.
    /// </summary>
    public struct RegionSize
    {
        /// <summary>
        /// The width of the region.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the region.
        /// </summary>
        public int Height;

        /// <summary>
        /// A RegionSize with the specified width and height.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public RegionSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj is RegionSize);
        }

        /// <summary>
        /// Checks whether this instance and the specified comparison are equal.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public bool Equals(RegionSize comp)
        {
            return comp.Width == this.Width && comp.Height == this.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Width, this.Height);
        }

        public static bool operator ==(RegionSize l, RegionSize r)
        {
            return l.Equals(r);
        }

        public static bool operator !=(RegionSize l, RegionSize r)
        {
            return !l.Equals(r);
        }
    }

    public struct Region
    {
        /// <summary>
        /// The X-position of the region.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y-position of the region.
        /// </summary>
        public int Y;

        /// <summary>
        /// The width of the region.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the region.
        /// </summary>
        public int Height;

        /// <summary>
        /// A region at the specified X-position and Y-position with the specified width and height.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Region(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Region(RegionPosition position, RegionSize size)
        {
            X = position.X;
            Y = position.Y;
            Width = size.Width;
            Height = size.Height;
        }

        /// <summary>
        /// The position of the region.
        /// </summary>
        public RegionPosition Position => new RegionPosition(X, Y);

        /// <summary>
        /// The size of the region.
        /// </summary>
        public RegionSize Size => new RegionSize(Width, Height);

        /// <summary>
        /// Checks whether this instance and the specified comparison are equal.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public bool Equals(Region comp)
        {
            return this.Position == comp.Position && this.Size == comp.Size;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj is Region);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y, this.Width, this.Height);
        }

        public static bool operator ==(Region l, Region r)
        {
            return l.Equals(r);
        }

        public static bool operator !=(Region l, Region r)
        {
            return !l.Equals(r);
        }

        /// <summary>
        /// Checks if the given coordinates are within bounds of the region.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>true if the coordinates are in bounds.</returns>
        public bool IsInBounds(int x, int y)
        {
            return !(x < X || x >= X + Width || y < Y || y >= Y + Height);
        }
    }
}
