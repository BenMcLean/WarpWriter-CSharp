using System;
using WarpWriter.View.Color;

namespace WarpWriter.View.Render
{
    public class ByteArrayRenderer : IRectangleRenderer<ByteArrayRenderer>, ITriangleRenderer<ByteArrayRenderer>
    {
        public byte Transparency { get; set; } = 255;
        public IVoxelColor Color { get; set; }
        public bool FlipX { get; set; } = false;
        public bool FlipY { get; set; } = false;
        public int ScaleX { get; set; } = 1;
        public int ScaleY { get; set; } = 1;
        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;
        public byte[] Bytes { get; set; }
        public uint Width { get; set; } = 0;
        public uint Height
        {
            get
            {
                return Bytes == null ? 0 : (uint)Bytes.Length / (Width * 4);
            }
            set
            {
                if (value != Height)
                    Bytes = new byte[Width * value * 4];
            }
        }

        public ByteArrayRenderer DrawPixel(int x, int y, uint color)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                uint start = (uint)(y * Width + x) * 4;
                Bytes[start] = (byte)(color >> 24);
                Bytes[start + 1] = (byte)(color >> 16);
                Bytes[start + 2] = (byte)(color >> 8);
                Bytes[start + 3] = Transparency;
            }
            return this;
        }

        #region IRectangleRenderer
        public ByteArrayRenderer Rect(int x, int y, int sizeX, int sizeY, uint color)
        {
            x = ScaleX * (FlipX ? -x : x) + OffsetX;
            y = ScaleY * (FlipY ? -y : y) + OffsetY;
            int x2 = x + sizeX * ScaleX,
                y2 = y + sizeY * ScaleY,
                startX, startY, endX, endY;
            if (x <= x2)
            {
                startX = x; endX = x2;
            }
            else
            {
                startX = x2; endX = x;
            }
            if (y <= y2)
            {
                startY = y; endY = y2;
            }
            else
            {
                startY = y2; endY = y;
            }
            for (x = startX; x < endX; x++)
                for (y = startY; y < endY; y++)
                    DrawPixel(x, y, color);
            return this;
        }

        public ByteArrayRenderer RectLeft(int x, int y, int sizeX, int sizeY, byte voxel)
        {
            return Rect(x, y, sizeX, sizeY,
                    FlipX ?
                            Color.RightFace(voxel)
                            : Color.LeftFace(voxel)
            );
        }

        public ByteArrayRenderer RectLeft(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz)
        {
            return RectLeft(px, py, sizeX, sizeY, voxel);
        }

        public ByteArrayRenderer RectRight(int x, int y, int sizeX, int sizeY, byte voxel)
        {
            return Rect(x, y, sizeX, sizeY,
                    FlipX ?
                            Color.LeftFace(voxel)
                            : Color.RightFace(voxel)
            );
        }

        public ByteArrayRenderer RectRight(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz)
        {
            return RectRight(px, py, sizeX, sizeY, voxel);
        }

        public ByteArrayRenderer RectVertical(int x, int y, int sizeX, int sizeY, byte voxel)
        {
            return Rect(x, y, sizeX, sizeY, Color.VerticalFace(voxel));
        }

        public ByteArrayRenderer RectVertical(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz)
        {
            return RectVertical(px, py, sizeX, sizeY, voxel);
        }
        #endregion

        #region ITriangleRenderer
        public ByteArrayRenderer DrawLeftTriangle(int x, int y, uint color)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawLeftTriangleLeftFace(int x, int y, byte voxel, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawLeftTriangleLeftFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawLeftTriangleRightFace(int x, int y, byte voxel, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawLeftTriangleRightFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawLeftTriangleVerticalFace(int x, int y, byte voxel, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawLeftTriangleVerticalFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangle(int x, int y, uint color)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangleLeftFace(int x, int y, byte voxel, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangleLeftFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangleRightFace(int x, int y, byte voxel, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangleRightFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangleVerticalFace(int x, int y, byte voxel, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer DrawRightTriangleVerticalFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
