using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// A picturebox which will fix the image inside it
    /// </summary>
    [Description("A picturebox which will fix the image inside it")]
    [ToolboxBitmap(typeof(PictureBox))]
    public partial class MetroFrameworkFixedPictureBox : MetroFrameworkPictureBox
    {
        /// <summary>
        /// A picturebox which will fix the image inside it
        /// </summary>
        public MetroFrameworkFixedPictureBox()
        {
            SetStyle(ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Opaque | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image == null)
                e.Graphics.Clear(BackColor);
            else
            {
                Size sourceSize = Image.Size, targetSize = ClientSize;
                float scale = Math.Min((float)targetSize.Width / sourceSize.Width, (float)targetSize.Height / sourceSize.Height);
                var rect = new RectangleF();
                rect.Width = scale * sourceSize.Width;
                rect.Height = scale * sourceSize.Height;
                rect.X = (targetSize.Width - rect.Width) / 2;
                rect.Y = (targetSize.Height - rect.Height) / 2;
                e.Graphics.FillRectangle(Brushes.Black, ClientRectangle);
                e.Graphics.DrawImage(Image, rect);
            }
        }
    }
}
