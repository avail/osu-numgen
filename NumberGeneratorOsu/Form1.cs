using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using SharpFont;
using System.Runtime.InteropServices;
using System.IO;


namespace NumberGeneratorOsu
{
    public partial class Form1 : Form
    {
        string file = "";
        bool isScore = false;

        public void generateStuff(int size = 24, bool _2x = false)
        {
            Library font = new Library();
            Face face = font.NewFace(file, 0);
            //Stroker stroke = new Stroker(font);

            int height = 0;
            char averageCh = 'A';
            double fontScale = 1;
            string[] characters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            if (isScore)
                characters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", ",", "%", "x" };

            var entries = new List<FontEntry>();

            face.SetCharSize(0, size << 6, 0, 96);
            face.SetTransform(new FTMatrix(3 << 16, 0, 0, 3 << 16), FTVector.Unit(0)); // thicknesssss

            //stroke.Set(1, StrokerLineCap.Round, StrokerLineJoin.Round, 0);

            face.LoadGlyph(face.GetCharIndex(averageCh), LoadFlags.Default, LoadTarget.Normal);
            height = (int)face.Glyph.Metrics.HorizontalBearingY >> 6;

            // then fill the fontentry array
            foreach (var ch in characters)
            {
                face.LoadGlyph(face.GetCharIndex(ch[0]), LoadFlags.Default, LoadTarget.Normal);
                face.Glyph.RenderGlyph(RenderMode.Normal);

                Bitmap bitmap;

                if (face.Glyph.Bitmap.Width == 0)
                {
                    bitmap = new Bitmap(1, 1);
                }
                else
                {
                    bitmap = new Bitmap(face.Glyph.Bitmap.Width + 4, face.Glyph.Bitmap.Rows + 4);

                    var gg = Graphics.FromImage(bitmap);
                    gg.Clear(Color.Transparent);

                    var data = bitmap.LockBits(new Rectangle(2, 2, bitmap.Width - 4, bitmap.Height - 4), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                    byte[] pixelAlphas = new byte[face.Glyph.Bitmap.Width * face.Glyph.Bitmap.Rows];
                    Marshal.Copy(face.Glyph.Bitmap.Buffer, pixelAlphas, 0, pixelAlphas.Length);

                    for (int j = 0; j < pixelAlphas.Length; j++)
                    {
                        int pixelOffset = (j / data.Width) * data.Stride + (j % data.Width * 4);
                        Marshal.WriteByte(data.Scan0, pixelOffset + 0, colorDialog1.Color.R);
                        Marshal.WriteByte(data.Scan0, pixelOffset + 1, colorDialog1.Color.G);
                        Marshal.WriteByte(data.Scan0, pixelOffset + 2, colorDialog1.Color.B);
                        Marshal.WriteByte(data.Scan0, pixelOffset + 3, pixelAlphas[j]);
                    }

                    bitmap.UnlockBits(data);
                }

                var entry = new FontEntry();
                entry.Character = ch[0];
                entry.Bitmap = bitmap;
                entry.AdvanceX = (int)(((face.Glyph.Metrics.HorizontalAdvance >> 6)) * fontScale);
                entry.PreX = (int)(((face.Glyph.Metrics.HorizontalBearingX >> 6)) * fontScale);
                entry.Width = (int)((face.Glyph.Metrics.Width >> 6) * fontScale);
                entry.Height = (int)((face.Glyph.Metrics.Height >> 6) * fontScale);
                entry.PreY = (int)((face.Glyph.Metrics.HorizontalBearingY >> 6) * -fontScale);

                if (entry.Width < 2)
                {
                    entry.Width = 2;
                }

                entries.Add(entry);
            }

            foreach (var entry in entries)
            {
                Bitmap bitmap = entry.Bitmap;
  
                var fontpath = file.Split('\\').Last().Replace(".ttf", "");

                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "generated\\" + fontpath)))
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "generated\\" + fontpath));

                string name = "";

                switch (entry.Character.ToString())
                {
                    case ".":
                        name = "dot";
                        break;

                    case ",":
                        name = "comma";
                        break;

                    case "%":
                        name = "percent";
                        break;

                    default:
                        name = entry.Character.ToString();
                        break;
                }

                bitmap.Save(@"generated\\" + fontpath + "\\" + ((isScore) ? "score-" : "default-") + name + ((_2x) ? "@2x" : "") + ".png", ImageFormat.Png);
            }
        }

        public Form1()
        {
            InitializeComponent();
            _comboBoxType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(file))
                MessageBox.Show("No font file specified", "Shit happened, aboooort");

            if (_comboBoxType.SelectedIndex == 1)
                isScore = true;

            generateStuff();

            if (_checkBox2x.Checked)
                generateStuff(42, true);

            MessageBox.Show("The files are waiting for you in the generated/ directory.", "Completed!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Font file|*.ttf";

            DialogResult OpenFile = openFileDialog1.ShowDialog();
            if (OpenFile == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                _fontTextBox.Text = openFileDialog1.FileName.Split('\\').Last().Replace(".ttf", "");
            }
            else
            {
                Environment.Exit(1);
            }
        }

        class FontEntry
        {
            public char Character { get; set; }
            public Bitmap Bitmap { get; set; }
            public int AdvanceX { get; set; }
            public int PreY { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int PreX { get; set; }

            public RectangleF UV { get; set; }

            public override string ToString()
            {
                return Character.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
