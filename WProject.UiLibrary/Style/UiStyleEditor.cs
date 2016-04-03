using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WProject.UiLibrary.Style
{
    public class StyleEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            Style ms = value as Style;

            if (ms == null)
                return value; // can also replace the wrapper object here

            using (FontDialog mfd = new FontDialog
            {
                Font = ms.Font,
                Color = ms.ForeColor,
                ShowColor = true,
                ShowEffects = true,
                FontMustExist = true
            })
                if (mfd.ShowDialog() == DialogResult.OK)
                {
                    ms.Font = mfd.Font;
                    ms.ForeColor = mfd.Color;
                }

            return ms; // can also replace the wrapper object here
        }
    }

    public class UiStyleEditorTypeConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type t) => t == typeof(string) || base.CanConvertFrom(context, t);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo info, object value)
        {
            if (!(value is string))
                return base.ConvertFrom(context, info, value);
            try
            {
                return (string)value;
            }
            catch
            {
                throw new ArgumentException("Can not convert '" + (string)value + "' to type string");
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context,CultureInfo culture,object value,Type destType)
        {
            if (destType != typeof (string) || !(value is UiStyle))
                return base.ConvertTo(context, culture, value, destType);
            
            return ((UiStyle)value).ToString();
        }
    }
}
