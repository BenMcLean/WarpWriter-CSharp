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
            SizeX = 64UL;
            SizeY = 64UL;
            SizeZ = 64UL;
        }
        public ulong SizeX { get; set; }
        public ulong SizeY { get; set; }
        public ulong SizeZ { get; set; }
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

        public ulong Rotate(ulong k, int rotation)
        {
            switch (rotation)
            {
                // 0-3 have z pointing towards z+ and the voxels rotating on that axis
                case 0: return k;
                case 1: return (k & 0x7FFFFC0000000000UL) | SizeX - (k & 0x00000000001FFFFFUL) << 21 | (k >> 21 & 0x00000000001FFFFFUL);
                case 2: return (k & 0x7FFFFC0000000000UL) | (SizeY << 21) - (k & 0x000003FFFFE00000UL) | SizeX - (k & 0x00000000001FFFFFUL);
                case 3: return (k & 0x7FFFFC0000000000UL) | (k & 0x00000000001FFFFFUL) << 21 | (SizeY - (k >> 21 & 0x00000000001FFFFFUL));
                // 4-7 have z pointing towards y+ and the voxels rotating on that axis
                case 4: return (k >> 21 & 0x000003FFFFE00000UL) | (SizeY << 21) - (k & 0x000003FFFFE00000UL) << 21 | (k & 0x00000000001FFFFFUL);
                case 5: return (k >> 21 & 0x000003FFFFE00000UL) | (k & 0x00000000001FFFFFUL) << 42 | (k >> 21 & 0x00000000001FFFFFUL);
                case 6: return (k >> 21 & 0x000003FFFFE00000UL) | (k & 0x000003FFFFE00000UL) << 21 | SizeX - (k & 0x00000000001FFFFFUL);
                case 7: return (k >> 21 & 0x000003FFFFE00000UL) | (SizeX - (k & 0x00000000001FFFFFUL) << 42) | SizeY - (k >> 21 & 0x00000000001FFFFFUL);
                // 8-11 have z pointing towards z-
                case 8: return (SizeZ << 42) - (k & 0x7FFFFC0000000000UL) | (k & 0x000003FFFFE00000UL) | (k & 0x00000000001FFFFFUL);
                case 9: return (SizeZ << 42) - (k & 0x7FFFFC0000000000UL) | (SizeY) - (k >> 21 & 0x00000000001FFFFFUL) | (k & 0x00000000001FFFFFUL) << 21;
                case 10: return (SizeZ << 42) - (k & 0x7FFFFC0000000000UL) | (SizeY << 21) - (k & 0x000003FFFFE00000UL) | SizeX - (k & 0x00000000001FFFFFUL);
                case 11: return (SizeZ << 42) - (k & 0x7FFFFC0000000000UL) | (k >> 21 & 0x00000000001FFFFFUL) | SizeX - (k & 0x00000000001FFFFFUL) << 21;
                // 12-15 have z pointing towards y-
                case 12: return (SizeZ << 21) - (k >> 21 & 0x000003FFFFE00000UL) | (k & 0x000003FFFFE00000UL) << 21 | (k & 0x00000000001FFFFFUL);
                case 13: return (SizeZ << 21) - (k >> 21 & 0x000003FFFFE00000UL) | SizeX - (k & 0x00000000001FFFFFUL) << 42 | (k >> 21 & 0x00000000001FFFFFUL);
                case 14: return (SizeZ << 21) - (k >> 21 & 0x000003FFFFE00000UL) | (SizeY << 42) - (k << 21 & 0x7FFFFC0000000000UL) | SizeX - (k & 0x00000000001FFFFFUL);
                case 15: return (SizeZ << 21) - (k >> 21 & 0x000003FFFFE00000UL) | (k & 0x00000000001FFFFFUL) << 42 | SizeY - (k >> 21 & 0x00000000001FFFFFUL);
                // 16-19 have z pointing towards x+ and the voxels rotating on that axis
                case 16: return (k >> 42 & 0x00000000001FFFFFUL) | (k & 0x000003FFFFE00000UL) | (k << 42 & 0x7FFFFC0000000000UL);
                case 17: return (k >> 42 & 0x00000000001FFFFFUL) | (k << 21 & 0x7FFFFC0000000000UL) | (SizeX - (k & 0x00000000001FFFFFUL) << 21);
                case 18: return (k >> 42 & 0x00000000001FFFFFUL) | (SizeY << 21) - (k & 0x000003FFFFE00000UL) | (SizeX - (k & 0x00000000001FFFFFUL)) << 42;
                case 19: return (k >> 42 & 0x00000000001FFFFFUL) | (SizeY << 42) - (k << 21 & 0x7FFFFC0000000000UL) | (k << 21 & 0x000003FFFFE00000UL);
                // 20-23 have z pointing towards x- and the voxels rotating on that axis
                case 20: return SizeZ - (k >> 42 & 0x00000000001FFFFFUL) | (k & 0x000003FFFFE00000UL) | (k << 42 & 0x7FFFFC0000000000UL);
                case 21: return SizeZ - (k >> 42 & 0x00000000001FFFFFUL) | (k << 21 & 0x7FFFFC0000000000UL) | (SizeX - (k & 0x00000000001FFFFFUL) << 21);
                case 22: return SizeZ - (k >> 42 & 0x00000000001FFFFFUL) | (SizeY << 21) - (k & 0x000003FFFFE00000UL) | (SizeX - (k & 0x00000000001FFFFFUL)) << 42;
                case 23: return SizeZ - (k >> 42 & 0x00000000001FFFFFUL) | (SizeY << 42) - (k << 21 & 0x7FFFFC0000000000UL) | (k << 21 & 0x000003FFFFE00000UL);
                default:
                    throw new ArgumentException("This shouldn't be happening! The rotation " + rotation + " was bad.");
            }
        }

    }
}
