using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.UiLibrary.Properties;
using WProject.UiLibrary.Style;

namespace WProject.UiLibrary.Theme
{
    public static class WpThemeReader
    {
        private static Dictionary<string, UiStyle> _styles;

        public static UiStyle GetUiStyle(string key)
        {
            if (_styles == null)
                LoadStyles();

            if (_styles == null)
                return null;

            return _styles.ContainsKey(key) ? _styles[key].Clone() : null;
        }

        public static void LoadStyles()
        {
            try
            {
                string md = File.ReadAllText(Settings.Default.StylePath);

                if(md.IsNullOrEmpty())
                    return;

                _styles = JsonConvert.DeserializeObject<Dictionary<string, UiStyle>>(md);
            }
            catch
            {
                _styles = GetLocalStyle();
            }
        }

        private static Dictionary<string, UiStyle> GetLocalStyle()
        {
            return new Dictionary<string, UiStyle>
            {
                {
                    WpThemeConstants.WPSTYLE_DROPDOWN_LIST,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 15f),
                            BackColor = WpThemeColors.Purple,
                            ForeColor = Color.White
                        },
                        HoverStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 15f),
                            BackColor = WpThemeColors.LightPurple,
                            ForeColor = Color.White
                        },
                        ClickStyle = null
                    }
                }, 
                {
                    WpThemeConstants.WPSTYLE_DROPDOWN_LIST_ITEM,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 15f),
                            BackColor = Color.White,
                            ForeColor = Color.Black
                        },
                        HoverStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 15f),
                            BackColor = Color.White,
                            ForeColor = WpThemeColors.Teal
                        },
                        ClickStyle = null
                    }
                },
                {
                    WpThemeConstants.WPSTYLE_DROPDOWN_LIST_BACK_PANEL,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            BackColor = Color.White,
                            Padding = new Padding(1),
                            BorderColor = WpThemeColors.Teal,
                            BorderWidth = 1f
                        },
                        HoverStyle = null,
                        ClickStyle = null
                    }
                },
                {
                    WpThemeConstants.WPSTYLE_DEFAULT_USER_CONTROL,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 12f),
                            BackColor = Color.Transparent,
                            ForeColor = Color.Black
                        },
                        HoverStyle = null,
                        ClickStyle = null
                    }
                },
                {
                    WpThemeConstants.WPSTYLE_HEADER,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 14f),
                            BackColor = WpThemeColors.Blue,
                            ForeColor = Color.White
                        },
                        HoverStyle = null,
                        ClickStyle = null
                    }
                },
                {
                    WpThemeConstants.WPSTYLE_HEADER_TOP,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 14f),
                            BackColor = WpThemeColors.Purple,
                            ForeColor = Color.White
                        }
                    }
                },
                {
                    WpThemeConstants.WPSTYLE_DEFAULT_STYLE,
                    UiStyle.DefaultStyle
                },
                {
                    WpThemeConstants.WPSTYLE_PICTURE_BOX_STYLE,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            BackColor = Color.Transparent,
                            ForeColor = Color.White
                        },
                        HoverStyle = null,
                        ClickStyle = null
                    }
                },
                {
                    WpThemeConstants.TOP_HEADER_LABEL,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI_SEMI_BOLD, 12f),
                            BackColor = Color.Transparent,
                            ForeColor = WpThemeColors.Yellow,
                            Cursor = Cursors.Hand
                        }
                    }
                },
                {
                    WpThemeConstants.WPSTYLE_BUTTON,
                    new UiStyle
                    {
                        NormalStyle = new Style.Style
                        {
                            Font = new Font(WpThemeFonts.SEGOE_UI, 12f),
                            BackColor = WpThemeColors.Blue,
                            ForeColor = WpThemeColors.White
                        }
                    }
                }
            };
        }
    }

    public static class WpThemeConstants
    {
        public const string TOP_HEADER_LABEL = "TOP_HEADER_LABEL";
        public const string WPSTYLE_DEFAULT_STYLE = "WPSTYLE_DEFAULT_STYLE";
        public const string WPSTYLE_DEFAULT_USER_CONTROL = "WPSTYLE_DEFAULT_USER_CONTROL";

        public const string WPSTYLE_PICTURE_BOX_STYLE = "WPSTYLE_PICTURE_BOX_STYLE";
        public const string WPSTYLE_DROPDOWN_LIST = "WPSTYLE_DROPDOWN_LIST";
        public const string WPSTYLE_DROPDOWN_LIST_ITEM = "WPSTYLE_DROPDOWN_LIST_ITEM";
        public const string WPSTYLE_DROPDOWN_LIST_BACK_PANEL = "WPSTYLE_DROPDOWN_LIST_BACK_PANEL";

        public const string WPSTYLE_HEADER = "WPSTYLE_HEADER";
        public const string WPSTYLE_HEADER_TOP = "WPSTYLE_HEADER_TOP";
        public const string WPSTYLE_BUTTON = "WPSTYLE_BUTTON";
    }

    public static class WpThemeColors
    {
        public static readonly Color Yellow = Color.FromArgb(255, 235, 50);
        public static readonly Color Orange = Color.FromArgb(0xFF, 0x98, 0x00); 
        public static readonly Color Amber = Color.FromArgb(0xFF, 0xC1, 0x07);
        public static readonly Color LightYellow = Color.FromArgb(255, 252, 242);
        public static readonly Color Purple = Color.FromArgb(156, 39, 176);
        public static readonly Color LightPurple = Color.FromArgb(156, 79, 176);
        public static readonly Color Blue = Color.FromArgb(33, 150, 243);
        public static readonly Color Teal = Color.FromArgb(0, 150, 136);
        public static readonly Color Shadow = Color.FromArgb(20, 20, 20);
        public static readonly Color DisableControl = Color.FromArgb(220, 220, 220);
        public static readonly Color White = Color.FromArgb(255, 255, 255);
        public static readonly Color Red = Color.FromArgb(239, 83, 80);//ef5350
        public static readonly Color Black = Color.FromArgb(0, 0, 0);
        public static readonly Color Gray = Color.FromArgb(87, 87, 87);
        public static readonly Color LightGray = Color.FromArgb(246, 246, 246);
    }

    public class WpThemeFonts
    {
        public const string SEGOE_UI = "Segoe UI";
        public const string SEGOE_UI_SEMI_BOLD = "Segoe UI SemiBold";
        public const string SEGOE_UI_LIGHT = "Segoe UI Light";

        public static Font DefaultSearchFont { get; set; }
        public static Font DefaultBackLogNameFont { get; set; }

        public static StringFormat VerticalTextAlign { get; }
        public static Font DefaultBackLogFont { get; set; }
        public static Font DefaultBackLogTasksInfo { get; set; }

        public static Font DefaultTaskNameFont{ get; set; }

        static WpThemeFonts()
        {
            DefaultSearchFont = new Font(SEGOE_UI, 12f);

            DefaultBackLogFont = new Font(SEGOE_UI_LIGHT, 8f);
            DefaultBackLogNameFont = new Font(SEGOE_UI_LIGHT, 16f);
            DefaultBackLogTasksInfo = new Font(SEGOE_UI_LIGHT, 8f);

            DefaultTaskNameFont = new Font(SEGOE_UI_LIGHT, 16f);

            VerticalTextAlign = new StringFormat(StringFormatFlags.DirectionVertical);
        }
    }
}
