
namespace WinFormsIstCool.Controls
{
    public class MyButton : Button
    {
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);

            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.ForestGreen, ClientRectangle);

            var sf =new StringFormat() { Alignment = StringAlignment.Center, LineAlignment=StringAlignment.Center };
            pevent.Graphics.DrawString(Text, SystemFonts.CaptionFont, Brushes.Black, ClientRectangle, sf);
        }
        
    }
}
