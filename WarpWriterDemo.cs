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
    private VoxelSeq seq;
    private ByteArrayRenderer renderer;
    private Image image;
    private ImageTexture imageTexture;
    private Color Clear = Color.Color8(0, 0, 0, 0);
    private int Rotation = 0;
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

        seq = new VoxelSeq().PutModel(model);
        
        renderer = new ByteArrayRenderer()
        {
            Width = (uint)Math.Max(seq.SizeX, seq.SizeY) * 8 + 5,
            Height = PixelCubeDraw.IsoHeight(model),
            //Width = PixelCubeDraw.IsoWidth(model) * 2,
            //Height = PixelCubeDraw.IsoHeight(model),
            OffsetY = 4,
            Color = new ShadedVoxelColor()
            {
                //Palette = new Colorizer(PaletteReducer.RELAXED_ROLL, false),
                Palette = new Colorizer(palette, true),
            },
            //ScaleX = 2,
        }.PixelCubeIso(seq);
        //Console.WriteLine("palette[30]: {0:X}", palette[30]);
        image = new Image();
        imageTexture = new ImageTexture();
        image.CreateFromData((int)renderer.Width, (int)renderer.Height, false, Image.Format.Rgba8, renderer.Bytes);
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
    public override void _Process(float delta)
    {
        int old = Rotation;
        Rotation = (int)(System.DateTime.Now.ToBinary() >> 21 & 7);
        if(old != Rotation)
        {
            seq.Rotation = Rotation >> 1;
            Array.Clear(renderer.Bytes, 0, renderer.Bytes.Length);
            if (1 == (Rotation & 1))
                renderer.PixelCubeIso(seq);
            else
                renderer.PixelCubeAbove(seq);
            //image.Fill(Colors.Black);
            image.CreateFromData((int)renderer.Width, (int)renderer.Height, false, Image.Format.Rgba8, renderer.Bytes);
            imageTexture.CreateFromImage(image, 7);
        }
    }
}
