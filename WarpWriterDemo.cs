using Godot;
using System;
using System.IO;
using WarpWriter.Model.Fetch;
using WarpWriter.Model.IO;
using WarpWriter.Model.Seq;
using WarpWriter.View;
using WarpWriter.View.Color;
using WarpWriter.View.Render;

public class WarpWriterDemo : Camera2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //uint[] palette = new uint[256];
        //for (uint i = 1; i < palette.Length; i++)
        //    palette[i] = uint.MaxValue;
        //FetchModel model = new FetchModel()
        //{
        //    Fetch = ColorFetch.Get(255),
        //    SizeX = 50,
        //    SizeY = 50,
        //    SizeZ = 50,
        //};

        ArrayModel model;
        uint[] palette;
        using (FileStream file = new FileStream("Artillery.vox", FileMode.Open))
            VoxIO.ReadVox(file, out model, out palette);

        VoxelSeq seq = new VoxelSeq().PutModel(model);
        seq.ClockZ().ClockZ();
        ByteArrayRenderer renderer = new ByteArrayRenderer()
        {
            Width = (uint)Math.Max(seq.SizeX, seq.SizeY) * 8 + 5,
            Height = PixelCubeDraw.IsoHeight(model),
            //Width = PixelCubeDraw.IsoWidth(model) * 2,
            //Height = PixelCubeDraw.IsoHeight(model),
            OffsetY = 4,
            Color = new ShadedVoxelColor()
            {
                Palette = new Colorizer(palette),
            },
            ScaleX = 2,
        }.PixelCubeIso(seq);

        Godot.Image image = new Image();
        image.CreateFromData((int)renderer.Width, (int)renderer.Height, false, Image.Format.Rgba8, renderer.Bytes);
        ImageTexture imageTexture = new ImageTexture();
        imageTexture.CreateFromImage(image, 0); //(int)Texture.FlagsEnum.ConvertToLinear);

        Sprite sprite = new Sprite
        {
            Name = "Sprite",
            Texture = imageTexture,
            Position = new Vector2(600, 200),
            //Scale = new Vector2(5, 5)
        };
        AddChild(sprite);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
