using System;
using WarpWriter.Model.Extra;

namespace WarpWriter.View.Color
{
    public class PaletteReducer
    {
        public readonly byte[] PaletteMapping = new byte[0x8000];
        public readonly uint[] PaletteArray = new uint[256];
        public int PaletteLength;

        public static readonly uint[] RELAXED_ROLL = {
            0x00000000, 0x100818ff, 0x181818ff, 0x314a6bff, 0x396b7bff, 0x4a9494ff, 0xa5b5adff, 0xb5e7e7ff,
            0xf7efefff, 0x6b1831ff, 0xbd5242ff, 0xef6b4aff, 0xef9c9cff, 0xf7c6deff, 0x6b3921ff, 0xbd8421ff,
            0xefa531ff, 0xe7ce42ff, 0xefd6a5ff, 0x292921ff, 0x7b5231ff, 0x8c7339ff, 0xb59473ff, 0xcec6a5ff,
            0x316b31ff, 0xadbd42ff, 0xefef39ff, 0xeff79cff, 0xe7f7deff, 0x215a21ff, 0x52bd39ff, 0x84e731ff,
            0xb5ef42ff, 0xbdef9cff, 0x295221ff, 0x29ad29ff, 0x31e729ff, 0x39ef7bff, 0x52f7b5ff, 0x214221ff,
            0x318439ff, 0x42ad84ff, 0x4aceadff, 0x5ae7e7ff, 0x180842ff, 0x3118a5ff, 0x3921deff, 0x428cc6ff,
            0x42bde7ff, 0x293163ff, 0x4a63b5ff, 0x5a84efff, 0x9ca5e7ff, 0xced6efff, 0x211073ff, 0x5a3194ff,
            0x8431d6ff, 0xb573b5ff, 0xc6bde7ff, 0x421039ff, 0xa5214aff, 0xde2152ff, 0xde31ceff, 0xe784deff,
        };

        public static readonly uint[] LAZY_ROLL = {
            0x00000000, 0x000000ff, 0x100810ff, 0x081821ff, 0x292929ff, 0x394242ff, 0x4a4a4aff, 0x5a635aff,
            0x6b736bff, 0x737b7bff, 0x8c8c84ff, 0x9c9494ff, 0xada5adff, 0xbdb5b5ff, 0xc6cebdff, 0xdeded6ff,
            0xefe7e7ff, 0xfff7f7ff, 0x421829ff, 0x6b3931ff, 0x944a5aff, 0xce5273ff, 0xef5a7bff, 0xef8c94ff,
            0xefa5adff, 0xf7b5b5ff, 0xf7c6ceff, 0xf7d6efff, 0xad6b9cff, 0x8c6b8cff, 0x9c4a94ff, 0xad3173ff,
            0x422908ff, 0x735210ff, 0x947310ff, 0xc68c18ff, 0xf7ad10ff, 0xf7bd31ff, 0xf7ce52ff, 0xf7d673ff,
            0xf7de94ff, 0xffe7ceff, 0xbd9463ff, 0xa59c63ff, 0xa58c39ff, 0xad7310ff, 0x421808ff, 0x6b2910ff,
            0x943910ff, 0xbd4218ff, 0xe74221ff, 0xef7321ff, 0xef8c4aff, 0xf7a573ff, 0xf7bd8cff, 0xf7d6b5ff,
            0x9c6342ff, 0x7b634aff, 0x843921ff, 0xa52118ff, 0x211808ff, 0x423129ff, 0x5a5a18ff, 0x735242ff,
            0x947b4aff, 0xa5736bff, 0xb59c8cff, 0xce8c9cff, 0xcebda5ff, 0xded6b5ff, 0x6b634aff, 0x5a5a42ff,
            0x524a31ff, 0x523118ff, 0x312910ff, 0x634210ff, 0x8c5a29ff, 0xb56b42ff, 0xd68442ff, 0xdea54aff,
            0xdeb57bff, 0xe7c694ff, 0xe7de94ff, 0xefe7bdff, 0x9c846bff, 0x847b63ff, 0x847b29ff, 0x9c5218ff,
            0x394a10ff, 0x6b7318ff, 0x949c18ff, 0xcece21ff, 0xe7ef18ff, 0xefef42ff, 0xeff763ff, 0xf7f784ff,
            0xf7f7a5ff, 0xf7ffc6ff, 0xced66bff, 0xbdc684ff, 0xb5bd52ff, 0xadb518ff, 0x214208ff, 0x426b10ff,
            0x5a8c18ff, 0x6bc621ff, 0x73e718ff, 0xa5ef21ff, 0xb5ef52ff, 0xc6ef73ff, 0xcef78cff, 0xdef7adff,
            0x84b54aff, 0x84945aff, 0x739c31ff, 0x52ad18ff, 0x083908ff, 0x187310ff, 0x219c21ff, 0x21c629ff,
            0x21ef29ff, 0x31e76bff, 0x63ef73ff, 0x8cef84ff, 0xa5f7a5ff, 0xbdffbdff, 0x4a9c52ff, 0x527b4aff,
            0x318429ff, 0x089410ff, 0x294229ff, 0x526b52ff, 0x6b947bff, 0x8cce6bff, 0xade7a5ff, 0xc6e7adff,
            0xceefceff, 0xcef7deff, 0xdef7d6ff, 0xeff7efff, 0xa5c6b5ff, 0xa5b59cff, 0x94ad84ff, 0x6bad84ff,
            0x082918ff, 0x104a29ff, 0x106b39ff, 0x18845aff, 0x10ad63ff, 0x39b56bff, 0x4ac69cff, 0x73ceadff,
            0x94d6b5ff, 0xbdd6d6ff, 0x316b4aff, 0x315242ff, 0x10524aff, 0x105a18ff, 0x083939ff, 0x106b6bff,
            0x107b8cff, 0x18bdadff, 0x10e7c6ff, 0x31e7deff, 0x52efceff, 0x73f7d6ff, 0x94f7e7ff, 0xb5f7efff,
            0x429c9cff, 0x4a8473ff, 0x298c84ff, 0x10949cff, 0x213139ff, 0x39636bff, 0x5a8494ff, 0x5aa5c6ff,
            0x73d6e7ff, 0x9cded6ff, 0xade7efff, 0xbde7deff, 0xceeff7ff, 0xdeeff7ff, 0x8cadbdff, 0x8c94a5ff,
            0x7394a5ff, 0x527bb5ff, 0x102142ff, 0x10426bff, 0x215aadff, 0x2173ceff, 0x188cefff, 0x42a5efff,
            0x6bb5efff, 0x8cbdefff, 0xa5c6f7ff, 0xc6d6f7ff, 0x4a6394ff, 0x425273ff, 0x215284ff, 0x084294ff,
            0x100842ff, 0x18216bff, 0x392194ff, 0x2921bdff, 0x2929efff, 0x6342e7ff, 0x7b6befff, 0x948cefff,
            0xada5efff, 0xc6bdf7ff, 0x313173ff, 0x182952ff, 0x10086bff, 0x101094ff, 0x211831ff, 0x393152ff,
            0x5a3984ff, 0x734a94ff, 0x7b4ab5ff, 0x8c73c6ff, 0xad8cc6ff, 0xb5a5ceff, 0xceb5d6ff, 0xdecee7ff,
            0x6b5273ff, 0x5a4a63ff, 0x4a3963ff, 0x422163ff, 0x290821ff, 0x31084aff, 0x6b107bff, 0x7b10a5ff,
            0x8c10deff, 0xbd18bdff, 0xbd4ad6ff, 0xc673deff, 0xd694ceff, 0xd69cefff, 0x632163ff, 0x4a2142ff,
            0x52084aff, 0x420873ff, 0x420818ff, 0x630821ff, 0x94105aff, 0xbd104aff, 0xe7104aff, 0xef18c6ff,
            0xef4ad6ff, 0xef73d6ff, 0xf794deff, 0xf7b5efff, 0x84316bff, 0x6b314aff, 0x7b1039ff, 0x8c0818ff,
        };

        public PaletteReducer()
        {
            Exact(null);
        }

        public PaletteReducer(uint[] palette)
        {
            Exact(palette);
        }

        public void Exact(uint[] rgbaPalette)
        {
            if (rgbaPalette == null || rgbaPalette.Length < 2)
            {
                rgbaPalette = new uint[RELAXED_ROLL.Length];
                for(int i = 0; i < RELAXED_ROLL.Length; i++)
                {
                    uint clr = RELAXED_ROLL[i];
                    rgbaPalette[i] = clr << 24 | (clr << 8 & 0xFF0000u) | (clr >> 8 & 0xFF00u) | clr >> 24;
                }
            }
            Array.Clear(PaletteArray, 0, 256);
            Array.Clear(PaletteMapping, 0, 0x8000);
            PaletteLength = Math.Min(256, rgbaPalette.Length);
            uint color, c2;
            double dist;
            for (int i = 0; i < PaletteLength; i++)
            {
                color = rgbaPalette[i];
                
                PaletteArray[i] = color;
                PaletteMapping[(color >> 17 & 0x7C00) | (color >> 14 & 0x3E0) | (color >> 11 & 0x1F)] = (byte)i;
            }
            uint rr, gg, bb;
            for (uint r = 0; r < 32; r++)
            {
                rr = (r << 3 | r >> 2);
                for (uint g = 0; g < 32; g++)
                {
                    gg = (g << 3 | g >> 2);
                    for (uint b = 0; b < 32; b++)
                    {
                        c2 = r << 10 | g << 5 | b;
                        if (PaletteMapping[c2] == 0)
                        {
                            bb = (b << 3 | b >> 2);
                            dist = 0x7FFFFFFFU;
                            for (int i = 1; i < PaletteLength; i++)
                            {
                                if (dist > (dist = Math.Min(dist, Difference(PaletteArray[i], rr, gg, bb))))
                                    PaletteMapping[c2] = (byte)i;
                            }
                        }
                    }
                }
            }
        }

        public double Difference(uint rgba1, uint r2, uint g2, uint b2)
        {
            if ((rgba1 & 0x80) == 0) return Double.PositiveInfinity;
            return Difference((rgba1 >> 24), (rgba1 >> 16 & 0xFF), (rgba1 >> 8 & 0xFF), r2, g2, b2);
        }

        public double Difference(uint r1, uint g1, uint b1, uint r2, uint g2, uint b2)
        {
            double rmean = (r1 + r2),
                r = r1 - r2, g = (g1 - g2) * 2.0, b = b1 - b2,
                y = Math.Max(r1, Math.Max(g1, b1)) - Math.Max(r2, Math.Max(g2, b2));
            return (((1024 + rmean) * r * r) / 128.0) + g * g * 12 + (((1534 - rmean) * b * b) / 256.0) + y * y * 14;

            //double x, y, z, r, g, b;

            //r = r1 / 255.0;
            //g = g1 / 255.0;
            //b = b1 / 255.0;

            //r = Math.Pow((r + 0.055) / 1.055, 2.4);
            //g = Math.Pow((g + 0.055) / 1.055, 2.4);
            //b = Math.Pow((b + 0.055) / 1.055, 2.4);

            //x = (r * 0.4124 + g * 0.3576 + b * 0.1805);
            //y = (r * 0.2126 + g * 0.7152 + b * 0.0722);
            //z = (r * 0.0193 + g * 0.1192 + b * 0.9505);

            //x = Math.Sqrt(x);
            //y = Math.Pow(y, 0.333333333);
            //z = Math.Sqrt(z);

            //double L = 100 * y;
            //double A = 500.0 * (x - y);
            //double B = 200.0 * (y - z);

            //r = r2 / 255.0;
            //g = g2 / 255.0;
            //b = b2 / 255.0;

            //r = Math.Pow((r + 0.055) / 1.055, 2.4);
            //g = Math.Pow((g + 0.055) / 1.055, 2.4);
            //b = Math.Pow((b + 0.055) / 1.055, 2.4);

            //x = (r * 0.4124 + g * 0.3576 + b * 0.1805);
            //y = (r * 0.2126 + g * 0.7152 + b * 0.0722);
            //z = (r * 0.0193 + g * 0.1192 + b * 0.9505);

            //x = Math.Sqrt(x);
            //y = Math.Pow(y, 0.333333333);
            //z = Math.Sqrt(z);

            //L -= 100.0 * y;
            //A -= 500.0 * (x - y);
            //B -= 200.0 * (y - z);

            //return L * L * 350.0 + A * A * 25.0 + B * B * 10.0;
        }

        public byte RandomColorIndex(RNG random)
        {
            return PaletteMapping[random.Next(15)];
        }

        /**
         * Retrieves a random non-transparent color from the palette this would reduce to, with a higher likelihood for
         * colors that are used more often in reductions (those with few similar colors). The color is returned as an
         * RGBA8888 int; you can assign one of these into a Color with {@link Color#rgba8888ToColor(Color, int)} or
         * {@link Color#set(int)}.
         * @param random a Random instance, which may be seeded
         * @return a randomly selected color from this palette with a non-uniform distribution
         */
        public uint RandomColor(RNG random)
        {
            return PaletteArray[PaletteMapping[random.Next(15)] & 255];
        }

        /**
         * Looks up {@code color} as if it was part of an image being color-reduced and finds the closest color to it in the
         * palette this holds. Both the parameter and the returned color are RGBA8888 ints.
         * @param color an RGBA8888 int that represents a color this should try to find a similar color for in its palette
         * @return an RGBA8888 int representing a color from this palette, or 0 if color is mostly transparent
         * (0 is often but not always in the palette)
         */
        public uint ReduceSingle(uint color)
        {
            if ((color & 0x80) == 0) // less visible than half-transparent
                return 0; // transparent
            return PaletteArray[PaletteMapping[
                    (color >> 17 & 0x7C00)
                            | (color >> 14 & 0x3E0)
                            | (color >> 11 & 0x1F)] & 0xFF];
        }

        /**
         * Looks up {@code color} as if it was part of an image being color-reduced and finds the closest color to it in the
         * palette this holds. The parameter is a RGBA8888 int, the returned color is a byte index into the
         * {@link #paletteArray} (mask it like: {@code paletteArray[reduceIndex(color) & 0xFF]}).
         * @param color an RGBA8888 int that represents a color this should try to find a similar color for in its palette
         * @return a byte index that can be used to look up a color from the {@link #paletteArray}
         */
        public byte ReduceIndex(uint color)
        {
            if ((color & 0x80) == 0) // less visible than half-transparent
                return 0; // transparent
            return PaletteMapping[
                    (color >> 17 & 0x7C00)
                            | (color >> 14 & 0x3E0)
                            | (color >> 11 & 0x1F)];
        }

    }
}
