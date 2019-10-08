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
            Voxels = new Dictionary<ulong, byte>(capacity);
            Full = new List<ulong>(capacity);
            Order = new List<ulong>(capacity);
            SizeX = 64;
            SizeY = 64;
            SizeZ = 64;
        }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
        public Dictionary<ulong, byte> Voxels { get; set; }
        public List<ulong> Full { get; set; }
        public List<ulong> Order { get; set; }
        /**
 * Combines 3 ulong components x, y, and z, each between 0 and 2097151 inclusive, into one ulong that can be used as a key
 * in this HashMap3D. 63 of the 64 bits in the returned ulong have the potential to be used, allowing about nine million
 * million million (9223372036854775808) possible keys that never produce garbage or need garbage collection (at least
 * for themselves).
 *
 * @param x the x component, between 0 and 2097151; this can be extracted with {@link #extractX(ulong)}
 * @param y the y component, between 0 and 2097151; this can be extracted with {@link #extractY(ulong)}
 * @param z the z component, between 0 and 2097151; this can be extracted with {@link #extractZ(ulong)}
 * @return a fused XYZ index that can be used as one key; will be unique for any (x,y,z) triple within range
 */
        public static ulong Fuse(ulong x, ulong y, ulong z)
        {
            return (z & 0x1FFFFFUL) << 42 | (y & 0x1FFFFFUL) << 21 | (x & 0x1FFFFFUL);
        }

        /**
         * Given a fused XYZ index as produced by {@link #fuse(ulong, ulong, ulong)}, this gets the x component back out of it.
         *
         * @param fused a fused XYZ index as produced by {@link #fuse(ulong, ulong, ulong)}
         * @return the x component stored in fused
         */
        public static ulong ExtractX(ulong fused)
        {
            return fused & 0x1FFFFFUL;
        }

        /**
         * Given a fused XYZ index as produced by {@link #fuse(ulong, ulong, ulong)}, this gets the y component back out of it.
         *
         * @param fused a fused XYZ index as produced by {@link #fuse(ulong, ulong, ulong)}
         * @return the y component stored in fused
         */
        public static ulong ExtractY(ulong fused)
        {
            return fused >> 21 & 0x1FFFFFUL;
        }

        /**
         * Given a fused XYZ index as produced by {@link #fuse(ulong, ulong, ulong)}, this gets the z component back out of it.
         *
         * @param fused a fused XYZ index as produced by {@link #fuse(ulong, ulong, ulong)}
         * @return the z component stored in fused
         */
        public static ulong ExtractZ(ulong fused)
        {
            return fused >> 42 & 0x1FFFFFUL;
        }



    }
}
