using PaintDotNet;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;
using System.Text;
using TIPicLib;

namespace PdnTIPicFileType
{
    public class TIPicFileType : FileType
    {
        public TIPicFileType() : base("TI Calculator Picture", FileTypeFlags.SupportsLoading, new string[] { ".73i", ".82i", ".83i", ".8xi", ".8ca", ".8ci", ".85i", ".86i", ".89i", ".92i", ".9xi", ".v2i" })
        {
        }

        protected override Document OnLoad(Stream input)
        {
            TIPicFile t = new TIPicFile(input);
            Bitmap b = new Bitmap(500, 500);

            return Document.FromImage(b);
        }

        //protected override void OnSave(Document input, Stream output, SaveConfigToken token, Surface scratchSurface, ProgressEventHandler callback)
        //{
        //    RenderArgs ra = new RenderArgs(new Surface(input.Size));
        //    input.Render(ra, true);

        //    ra.Bitmap.Save(output, ImageFormat.Bmp);
        //}
    }

    public class TIPicFileTypeFactory : IFileTypeFactory
    {
        public FileType[] GetFileTypeInstances()
        {
            return new FileType[] { new TIPicFileType() };
        }
    }
}
