using System.ComponentModel;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// Just used to define the control is from MetroFrameworkControl
    /// </summary>
    public interface MetroFrameworkControl
    {
        /// <summary>
        /// Check if control is required to have text
        /// </summary>
        [Description("Check if control is required to have text")]
        bool Required { get; set; }
        /// <summary>
        /// Used to alert if <see cref="Required"/> is <see cref="true"/>
        /// </summary>
        [Browsable(false)]
        ErrorProvider ErrorProvider { get; set; }

    }
}
