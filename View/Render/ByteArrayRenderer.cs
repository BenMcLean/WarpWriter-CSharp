using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpWriter.View.Render
{
    class ByteArrayRenderer : IRectangleRenderer<ByteArrayRenderer>, ITriangleRenderer<ByteArrayRenderer>
    {
        #region IRectangleRenderer
        public ByteArrayRenderer Rect(int x, int y, int sizeX, int sizeY, uint color)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer RectLeft(int x, int y, int sizeX, int sizeY, byte voxel)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer RectLeft(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer RectRight(int x, int y, int sizeX, int sizeY, byte voxel)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer RectRight(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer RectVertical(int x, int y, int sizeX, int sizeY, byte voxel)
        {
            throw new NotImplementedException();
        }

        public ByteArrayRenderer RectVertical(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz)
        {
            throw new NotImplementedException();
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

        #region IVoxelRenderer
        public ByteArrayRenderer SetTransparency(byte transparency)
        {
            throw new NotImplementedException();
        }

        public byte Transparency()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
