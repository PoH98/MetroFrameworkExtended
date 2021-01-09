using MetroFramework.Controls;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// <seealso cref="MetroFrameworkControl"/> TextBox written by MetroFramework PoH98 
    /// </summary>
    [Description("TextBox written by MetroFramework PoH98")]
    public class MetroFrameworkTextBox: TextBox, MetroFrameworkControl
    {
        /// <summary>
        /// Masked Textbox with specific type, which will handle when Text getting inputted
        /// </summary>
        [Description("Masked Textbox with specific type, which will handle when Text getting inputted")]
        public MaskType Mask { get; set; } = MaskType.None;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();

        private ToolTip toolTip = new ToolTip();

        private string oldText;
        protected override void OnTextChanged(EventArgs e)
        {
            switch (Mask)
            {
                case MaskType.Email:
                    try
                    {
                        MailAddress m = new MailAddress(Text);
                        toolTip.Hide(this);
                    }
                    catch
                    {
                        toolTip.Show("Invalid Email!", this);
                    }
                    break;
                case MaskType.Phone:
                    Regex regex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
                    if (!regex.Match(Text).Success)
                    {
                        toolTip.Show("Invalid Phone Number!", this);
                    }
                    else
                    {
                        toolTip.Hide(this);
                    }
                    break;
                case MaskType.NumbersOnly:
                    regex = new Regex(@" ^\d$");
                    if (!regex.Match(Text).Success)
                    {
                        toolTip.Show("Numbers only are allowed here!", this);
                        Text = oldText;
                    }
                    else
                    {
                        toolTip.Hide(this);
                        oldText = Text;
                    }
                    break;
                case MaskType.TextOnly:
                    regex = new Regex(@"^[a-zA-Z]+$");
                    if (!regex.Match(Text).Success)
                    {
                        toolTip.Show("Letters only are allowed here!", this);
                        Text = oldText;
                    }
                    else
                    {
                        toolTip.Hide(this);
                        oldText = Text;
                    }
                    break;
                case MaskType.NumberTextOnly:
                    regex = new Regex(@"^[a-zA-Z0-9]+$");
                    if (!regex.Match(Text).Success)
                    {
                        toolTip.Show("Numbers and Letters only are allowed here!", this);
                        Text = oldText;
                    }
                    else
                    {
                        toolTip.Hide(this);
                        oldText = Text;
                    }
                    break;
            }
            base.OnTextChanged(e);
        }
    }
}
