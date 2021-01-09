using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// The picture box which will let user to select image and able to set or return the base64 of the image
    /// </summary>
    [ToolboxBitmap(typeof(PictureBox))]
    [Description("The picture box which will let user to select image and able to set or return the base64 of the image")]
    public partial class MetroFrameworkPictureBox : PictureBox, MetroFrameworkControl
    {
        /// <summary>
        /// The Base64 string from image of this component
        /// </summary>
        [Browsable(false)]
        public string Base64
        {
            get
            {
                if (Image == null)
                {
                    return null;
                }
                try
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        Image.Save(m, Image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        return Convert.ToBase64String(imageBytes);
                    }
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return null;
                }
            }
            set
            {
                if(value == null)
                {
                    Image = null;
                    return;
                }
                try
                {
                    byte[] bytes = Convert.FromBase64String(value);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        Image = Image.FromStream(ms);
                    }
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Image = null;
                }

            }
        }

        public override string Text
        {
            get
            {
                return Base64;
            }
            set
            {
                Base64 = value;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();

        protected override void OnClick(EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Image = Image.FromFile(dialog.FileName);
            }
            base.OnClick(e);
        }
    }
}
