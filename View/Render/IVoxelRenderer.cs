namespace WarpWriter.View.Render
{
    interface IVoxelRenderer<T> where T : IVoxelRenderer<T>
    {
        /// <param name="transparency">Anything from 0 for fully transparency to 255 for fully opaque.</param>
        /// <returns>this</returns>
        T SetTransparency(byte transparency);

        byte Transparency();
    }
}
