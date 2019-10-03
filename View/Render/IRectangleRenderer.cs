namespace WarpWriter.View.Render
{
    /// <summary>
    /// An IRectangleRenderer understands how to draw rectangles representing the three visible faces of a voxel cube.
    /// </summary>
    interface IRectangleRenderer : IVoxelRenderer
    {
        IRectangleRenderer Rect(int x, int y, int sizeX, int sizeY, uint color);

        IRectangleRenderer RectVertical(int x, int y, int sizeX, int sizeY, byte voxel);

        IRectangleRenderer RectLeft(int x, int y, int sizeX, int sizeY, byte voxel);

        IRectangleRenderer RectRight(int x, int y, int sizeX, int sizeY, byte voxel);

        IRectangleRenderer RectVertical(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz);

        IRectangleRenderer RectLeft(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz);

        IRectangleRenderer RectRight(int px, int py, int sizeX, int sizeY, byte voxel, int depth, int vx, int vy, int vz);
    }
}
