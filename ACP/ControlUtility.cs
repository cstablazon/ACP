using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ACP
{
    class ControlUtility
    { //for comment
        // Static method to apply red border
        public static void ApplyRedBorder(Control control, string errorKey)
        {
            // Check if the red border (panel) already exists before adding it
            if (control.Parent.Controls.Find(errorKey, false).Length == 0)
            {
                Panel panel = new Panel();
                panel.Name = errorKey;
                panel.Size = new Size(control.Size.Width + 4, control.Size.Height + 4);
                panel.Location = new Point(control.Location.X - 2, control.Location.Y - 2);
                panel.BackColor = Color.Crimson;
                panel.BorderStyle = BorderStyle.None;
                control.Parent.Controls.Add(panel); // Add red border panel to parent container

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.FlatStyle = FlatStyle.Flat; // Set ComboBox style to indicate error
                }
            }
        }

        // Static method to remove red border
        public static void ClearRedBorder(Control control, string errorKey)
        {
            // Find and remove the red border panel with the given errorKey
            var existingPanels = control.Parent.Controls.Find(errorKey, false);
            if (existingPanels.Length > 0)
            {
                control.Parent.Controls.Remove(existingPanels[0]); // Remove the first found panel with the errorKey
            }

            if (control is ComboBox)
            {
                ComboBox comboBox = (ComboBox)control;
                comboBox.FlatStyle = FlatStyle.Standard; // Reset ComboBox style
            }
            else if (control is TextBox)
            {
                TextBox textBox = (TextBox)control;
                textBox.BorderStyle = BorderStyle.FixedSingle; // Reset TextBox style
            }
        }
    }
}
