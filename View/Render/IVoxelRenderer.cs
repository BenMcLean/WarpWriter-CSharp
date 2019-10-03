namespace WarpWriter.View.Render
{
    interface IVoxelRenderer
    {
        /// <param name="transparency">Anything from 0 for fully transparency to 255 for fully opaque.</param>
        /// <returns>this</returns>
        IVoxelRenderer SetTransparency(byte transparency);

        byte Transparency();
    }
}
