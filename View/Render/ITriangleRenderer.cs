namespace WarpWriter.View.Render
{
    interface ITriangleRenderer : IVoxelRenderer
    {
        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangle(int x, int y, uint color);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangle(int x, int y, uint color);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left, representing the visible vertical face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangleVerticalFace(int x, int y, byte voxel, int vx, int vy, int vz);


        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left, representing the left face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangleLeftFace(int x, int y, byte voxel, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left, representing the right face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangleRightFace(int x, int y, byte voxel, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right representing the visible vertical face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangleVerticalFace(int x, int y, byte voxel, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right representing the left face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangleLeftFace(int x, int y, byte voxel, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right representing the right face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangleRightFace(int x, int y, byte voxel, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left, representing the visible vertical face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangleVerticalFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left, representing the left face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangleLeftFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing left, representing the right face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawLeftTriangleRightFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right representing the visible vertical face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangleVerticalFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right representing the left face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangleLeftFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz);

        /// <summary>
        /// Draws a triangle 3 high and 2 wide pointing right representing the right face of voxel
        /// </summary>
        /// <returns>this</returns>
        ITriangleRenderer DrawRightTriangleRightFace(int x, int y, byte voxel, int depth, int vx, int vy, int vz);
    }
}
