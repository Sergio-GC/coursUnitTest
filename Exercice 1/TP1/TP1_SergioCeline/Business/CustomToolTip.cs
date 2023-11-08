namespace TP1_SergioCeline.Business
{
    public class CustomToolTip : ToolTip
    {

        public int SIZE_X = 500;
        public int SIZE_Y = 50;

        public CustomToolTip()
        {
            OwnerDraw = true;
            Popup += new PopupEventHandler(OnPopup!);
            Draw += new DrawToolTipEventHandler(OnDraw!);
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(SIZE_X, SIZE_Y);
        }


        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            // Customize the tooltip

            Graphics g = e.Graphics;

            // Make the rectangle where the text will be displayed
            SolidBrush brush = new SolidBrush(Color.WhiteSmoke);
            g.FillRectangle(brush, e.Bounds);

            // Make the border of the rectangle
            g.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));

            // Draw the text at the center of the tooltip
            System.Drawing.Size toolTipTextSize = TextRenderer.MeasureText(e.ToolTipText, e.Font);
            g.DrawString(e.ToolTipText, new Font(e.Font!, FontStyle.Bold), Brushes.Black,
                new PointF((SIZE_X - toolTipTextSize.Width) / 2, (SIZE_Y - toolTipTextSize.Height) / 2));

            brush.Dispose();
        }
    }
}
