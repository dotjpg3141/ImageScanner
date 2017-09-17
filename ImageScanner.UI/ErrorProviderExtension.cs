using System;
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
            control.Validating += Control_Validating;
            void Control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                var hasError = condition(control.Text);
                source.SetError(control, hasError, errorMessage);
                e.Cancel = hasError;
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
