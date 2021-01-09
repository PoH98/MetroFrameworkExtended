using MetroFramework.Controls;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    public class MetroFrameworkDateTimePicker : MetroDateTime, MetroFrameworkControl
    {
        /// <summary>
        /// <inheritdoc/>. Cannot used with <see cref="Nullable"/> at the same time
        /// </summary>
        public bool Required { 
            get
            {
                return _Required;
            }
            set
            {
                _Required = value;
                if (ShowCheckBox && _Required)
                {
                    ShowCheckBox = false;
                    try
                    {
                        ValueChanged -= MetroFrameworkDateTimePicker_ValueChanged;
                    }
                    catch
                    {

                    }
                }
            }
        }

        private bool _Required;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();

        private DateTimePickerFormat BufferedFormat;
        /// <summary>
        /// To define if Value is nullable. Cannot used with <see cref="Required"/> at the same time
        /// </summary>
        public bool Nullable
        {
            get
            {
                return ShowCheckBox;
            }
            set
            {
                ShowCheckBox = value;
                if (ShowCheckBox && _Required)
                {
                    _Required = false;
                }
                if (ShowCheckBox)
                {
                    ValueChanged += MetroFrameworkDateTimePicker_ValueChanged;
                }
                else
                {
                    ValueChanged -= MetroFrameworkDateTimePicker_ValueChanged;
                }
            }
        }

        private void MetroFrameworkDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (ShowCheckBox)
                {
                    if (Checked)
                    {
                        Format = BufferedFormat;
                    }
                    else
                    {
                        BufferedFormat = Format;
                        Format = DateTimePickerFormat.Custom;
                        CustomFormat = " ";
                    }
                }
            }
        }

        public MetroFrameworkDateTimePicker()
        {
            if(!DesignMode)
            StyleManager = MetroFrameworkBuffer.Instance.Manager;
        }
    }
}
