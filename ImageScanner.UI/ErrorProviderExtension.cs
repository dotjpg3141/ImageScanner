using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScanner.UI
{
    public static class ErrorProviderExtension
    {

        public static void RequiresNonEmptyText(this ErrorProvider source, Control control)
        {
            source.RequiresText(control, (text) => string.IsNullOrEmpty(text), "Text is empty");
        }

        public static void RequiresText(this ErrorProvider source, Control control, Func<string, bool> condition, string errorMessage)
        {
            control.TextChanged += Control_TextChanged;
            Control_TextChanged(null, null);

            void Control_TextChanged(object sender, EventArgs e)
            {
                source.SetError(control, condition(control.Text), errorMessage);
            }
        }

        public static void SetError(this ErrorProvider source, Control control, bool condition, string errorMessage)
        {
            if (condition)
            {
                source.SetError(control, string.IsNullOrEmpty(errorMessage) ? "Error" : errorMessage);
            }
            else
            {
                source.SetError(control, "");
            }
        }
    }
}
