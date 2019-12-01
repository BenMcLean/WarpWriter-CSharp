using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpWriter.View.Render
{
    public interface IBlittable
    {
        byte[] Blit(int threshold, uint pixelWidth, uint pixelHeight);
    }
}
