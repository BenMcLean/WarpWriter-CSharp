namespace WarpWriter.Model.Fetch
{
    public interface IModel : IFetch
    {
        /// <summary>
        /// Gets the x size of the IModel, with requests for x limited between 0 (inclusive) to sizeX() (exclusive).
        /// </summary>
        /// <returns>the size of the x dimension of the IModel</returns>
        uint SizeX();

        /// <summary>
        /// Gets the y size of the IModel, with requests for y limited between 0 (inclusive) to SizeY() (exclusive).
        /// </summary>
        /// <returns>the size of the y dimension of the IModel</returns>
        uint SizeY();

        /// <summary>
        /// Gets the z size of the IModel, with requests for z limited between 0 (inclusive) to sizeZ() (exclusive).
        /// </summary>
        /// <returns>the size of the z dimension of the IModel</returns>
        uint SizeZ();

        /// <summary>
        /// Recommended (but not required) implementation:
        /// public boolean inside(int x, int y, int z) { return !outside(x, y, z); }
        /// </summary>
        /// <returns>True if the given coordinate is inside the intended range</returns>
        bool Inside(int x, int y, int z);

        /// <summary>
        /// Recommended (but not required) implementation:
        /// {@code public boolean outside(int x, int y, int z) { return x < 0 || y < 0 || z < 0 || x >= sizeX() || y >= sizeY() || z >= sizeZ(); } }
        /// </summary>
        /// <returns>True if the given coordinate is outside the intended range</returns>
        bool Outside(int x, int y, int z);
    }
}
