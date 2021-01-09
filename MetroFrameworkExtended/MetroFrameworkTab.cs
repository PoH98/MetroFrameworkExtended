using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    public class MetroFrameworkTab : TabControl, MetroFrameworkControl, IMetroControl
    {
        public bool Required { get; set; }
        public ErrorProvider ErrorProvider { get; set; }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }
        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        private HorizontalAlignment textAlignment = HorizontalAlignment.Center;

        public HorizontalAlignment TextAlignment
        {
            get => textAlignment;
            set
            {
                textAlignment = value;
                Invalidate();
            }
        }

        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private Font font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular);
        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                base.Font = font;
            }
        }

        public MetroFrameworkTab()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            ItemSize = new Size(40, 200);
            DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;

                if (!useCustomBackColor)
                {
                    backColor = MetroPaint.BackColor.Form(Theme);
                }

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);

                OnCustomPaintBackground(new MetroPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                OnCustomPaint(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));


                OnPaintForeground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            e.Graphics.Clear(MetroPaint.BackColor.Form(Theme));
            Color foreColor;
            if (!Enabled)
            {
                foreColor = MetroPaint.ForeColor.Label.Disabled(Theme);
            }
            else
            {
                if (useCustomForeColor)
                {
                    foreColor = DefaultForeColor;
                }
                else
                {
                    foreColor = !useStyleColors ? MetroPaint.ForeColor.TabControl.Normal(Theme) : MetroPaint.GetStyleColor(Style);
                }
            }

            for (int index = 0; index <= TabCount - 1; index++)
            {
                Rectangle TabRect = new Rectangle(GetTabRect(index).Location.X - 2, GetTabRect(index).Location.Y - 2, ItemSize.Height + 4, ItemSize.Width);
                SizeF sf = e.Graphics.MeasureString(TabPages[index].Text, Font);
                int textLeft = 4 + 6 + 4 + (ImageList?.ImageSize.Width ?? 0);
                if (TextAlignment == HorizontalAlignment.Right)
                    textLeft = (int)(TabRect.Width - 4 - sf.Width);
                if (TextAlignment == HorizontalAlignment.Center)
                    textLeft = textLeft + (int)((TabRect.Width - textLeft - sf.Width) / 2.0f);

                if (index == SelectedIndex)
                {
                    // 绘制Tab选中背景色
                    e.Graphics.FillRectangle(new SolidBrush(MetroPaint.BorderColor.TabControl.Normal(Theme)), TabRect.X, TabRect.Y, TabRect.Width, TabRect.Height + 4);

                    // 绘制Tab选中高亮
                    e.Graphics.FillRectangle(new SolidBrush(MetroPaint.GetStyleColor(Style)), TabRect.X, TabRect.Y, 4, TabRect.Height + 3);
                }

                // 绘制标题
                Color textColor = index == SelectedIndex ? MetroPaint.GetStyleColor(Style) : foreColor;
                e.Graphics.DrawString(TabPages[index].Text, Font, new SolidBrush(textColor), textLeft, TabRect.Top + 2 + (TabRect.Height - sf.Height) / 2.0f);

                // 绘制图标
                if (ImageList != null)
                {
                    int imageIndex = TabPages[index].ImageIndex;
                    if (imageIndex >= 0 && imageIndex < ImageList.Images.Count)
                    {
                        e.Graphics.DrawImage(ImageList.Images[imageIndex], TabRect.X + 4 + 6, TabRect.Y + 2 + (TabRect.Height - ImageList.ImageSize.Height) / 2.0f, ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                    }
                }
            }
        }
    }
}
