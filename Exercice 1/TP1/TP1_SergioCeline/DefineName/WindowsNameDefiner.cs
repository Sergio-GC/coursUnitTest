using Microsoft.Identity.Client;

namespace TP1_SergioCeline.DefineName
{
    public class WindowsNameDefiner : INameDefiner
    {
        // Popup, common for both methods
        Form popup = new Form
        {
            Size = new Size(500, 300),
            StartPosition = FormStartPosition.CenterParent,
        };

        // Ok button, common for both methods
        Button okButton = new Button
        {
            Text = "OK",
            DialogResult = DialogResult.OK,
            Dock = DockStyle.Bottom
        };

    public string DefineName()
        {
            string imageName = null;
            popup.Text = "Define the name of the new image";

            // Create the field
            TextBox textBox = new TextBox();

            // Event handler, assign the filename when clicking on ok and close the popup
            /*
            okButton.Click += (sender, e) =>
            {
                imageName = textBox.Text;
                popup.Close();
            };
            */

            okButton.Click += (sender, e) => { popup.Close(); };

            // Add the controls to the popup
            popup.Controls.Add(textBox);
            popup.Controls.Add(okButton);

            //Display the popup
            popup.Show();

            return popup.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        public string SelectName(List<string> files)
        {
            string selectedImage = null;
            popup.Text = "Select an image";

            // Create the dropdown list
            ComboBox comboBox = new ComboBox
            {
                DataSource = files,
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Event handler, assign the filename when clicking on ok and close the popup
            okButton.Click += (sender, e) =>
            {
                selectedImage = comboBox.SelectedItem as string;
                popup.Close();
            };

            // Add the controls to the popup
            popup.Controls.Add(comboBox);
            popup.Controls.Add(okButton);

            //Display the popup
            popup.Show();

            return selectedImage;
        }
    }
}
