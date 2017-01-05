using System;
using PaintDotNet;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace TIPic
{
    public class MyFileType : FileType
    {
        public MyFileType()
            : base("Text Document",
                FileTypeFlags.SupportsLoading | FileTypeFlags.SupportsSaving,
                new String[] { ".txt" })
        {
        }

        protected override Document OnLoad(Stream input)
        {
            try
            {
                Bitmap b = new Bitmap(500, 500);

                return Document.FromImage(b);
            }
            catch
            {
                MessageBox.Show("Problem Importing File");

                Bitmap b = new Bitmap(500, 500);
                return Document.FromImage(b);
            }
        }

        protected override void OnSave(Document input, Stream output, SaveConfigToken token,
            Surface scratchSurface, ProgressEventHandler callback)
        {
            RenderArgs ra = new RenderArgs(new Surface(input.Size));
            input.Render(ra, true);

            ra.Bitmap.Save(output, ImageFormat.Bmp);
        }
    }

    public class MyFileTypeFactory : IFileTypeFactory
    {
        public FileType[] GetFileTypeInstances()
        {
            return new FileType[] { new MyFileType() };
        }
    }
}
