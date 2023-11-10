namespace TP1_SergioCeline.DefineName
{
    public class WindowsNameDefiner : INameDefiner
    {

        public string DefineName()
        {
            string imageName = null;

            Form popup = CreateMyPopup();
            popup.Text = "Define the name of the new image";

            // Create the field
            TextBox textBox = new TextBox();

            Button okButton = CreateMyButton();
            okButton.Click += (sender, e) => { popup.Close(); };

            // Add the controls to the popup
            popup.Controls.Add(textBox);
            popup.Controls.Add(okButton);

            //Display the popup
            return popup.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public string SelectName(List<string> files)
        {
            string selectedImage = null;

            Form popup = CreateMyPopup();
            popup.Text = "Select an image";

            // Create the dropdown list
            ComboBox comboBox = new ComboBox
            {
                DataSource = files,
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Event handler, assign the filename when clicking on ok and close the popup
            Button okButton = CreateMyButton();
            okButton.Click += (sender, e) =>
            {
                selectedImage = comboBox.SelectedItem as string;
                popup.Close();
            };

            // Add the controls to the popup
            popup.Controls.Add(comboBox);
            popup.Controls.Add(okButton);

            //Display the popup
            return popup.ShowDialog() == DialogResult.OK ? comboBox.SelectedItem as string : "";
        }

        private Form CreateMyPopup()
        {

            // Popup, common for both methods
            return new Form
            {
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
            };
        }

        private Button CreateMyButton()
        {

            // Popup, common for both methods
            return new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom
            };
        }
    }
}
