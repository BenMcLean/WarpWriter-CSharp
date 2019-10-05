using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using WarpWriter.Model.Fetch;
using WarpWriter.Model.IO;
using WarpWriter.View;
using WarpWriter.View.Color;
using WarpWriter.View.Render;

namespace WarpWriterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ArrayModel model;
            uint[] palette;
            using (FileStream file = new FileStream(@"..\..\..\Artillery.vox", FileMode.Open))
                VoxIO.ReadVox(file, out model, out palette);

            ByteArrayRenderer renderer = new ByteArrayRenderer()
            {
                Width = PixelCubeDraw.IsoWidth(model),
                Height = PixelCubeDraw.IsoHeight(model),
                Color = new FlatVoxelColor()
                {
                    Palette = palette,
                }
            }.PixelCubeIso(model);
            Assert.IsTrue(renderer.Bytes.Sum(b => b) > 0);
        }
    }
}
