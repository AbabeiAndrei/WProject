using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace WProject.UiLibrary.Designer.Convertors
{
    public class CsvConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context,  CultureInfo culture, object value, Type destinationType)
        {
            return destinationType == typeof(string) && value is IEnumerable<string> 
                        ? string.Join(",", (IEnumerable<string>) value) 
                        : base.ConvertTo(context, culture, value, destinationType);
        }
    }
}