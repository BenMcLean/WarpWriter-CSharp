using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WarpWriter.Model.Seq
{
    public class VoxelSeq
    {
        public VoxelSeq() : this(64) { }
        public VoxelSeq(int capacity)
        {
            Voxels = new Dictionary<uint, byte>(capacity);
            Full = new List<uint>(capacity);
            Order = new List<uint>(capacity);
            SizeX = 64;
            SizeY = 64;
            SizeZ = 64;
        }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
        public Dictionary<uint, byte> Voxels { get; set; }
        public List<uint> Full { get; set; }
        public List<uint> Order { get; set; }
        /**
 * Combines 3 uint components x, y, and z, each between 0 and 1023 inclusive, into one uint that can be used as a key
 * in this HashMap3D. 30 of the 32 bits in the returned uint have the potential to be used, allowing about a
 * billion possible keys that never produce garbage or need garbage collection (at least for themselves).
 *
 * @param x the x component, between 0 and 1023; this can be extracted with {@link #extractX(uint)}
 * @param y the y component, between 0 and 1023; this can be extracted with {@link #extractY(uint)}
 * @param z the z component, between 0 and 1023; this can be extracted with {@link #extractZ(uint)}
 * @return a fused XYZ index that can be used as one key; will be unique for any (x,y,z) triple within range
 */
        public static uint Fuse(uint x, uint y, uint z)
        {
            return (z << 20 & 0x3FF00000) | (y << 10 & 0x000FFC00) | (x & 0x000003FF);
        }

        /**
         * Given a fused XYZ index as produced by {@link #fuse(uint, uint, uint)}, this gets the x component back out of it.
         *
         * @param fused a fused XYZ index as produced by {@link #fuse(uint, uint, uint)}
         * @return the x component stored in fused
         */
        public static uint ExtractX(uint fused)
        {
            return fused & 0x000003FF;
        }

        /**
         * Given a fused XYZ index as produced by {@link #fuse(uint, uint, uint)}, this gets the y component back out of it.
         *
         * @param fused a fused XYZ index as produced by {@link #fuse(uint, uint, uint)}
         * @return the y component stored in fused
         */
        public static uint ExtractY(uint fused)
        {
            return fused >> 10 & 0x000003FF;
        }

        /**
         * Given a fused XYZ index as produced by {@link #fuse(uint, uint, uint)}, this gets the z component back out of it.
         *
         * @param fused a fused XYZ index as produced by {@link #fuse(uint, uint, uint)}
         * @return the z component stored in fused
         */
        public static uint ExtractZ(uint fused)
        {
            return fused >> 20 & 0x000003FF;
        }



    }
}
