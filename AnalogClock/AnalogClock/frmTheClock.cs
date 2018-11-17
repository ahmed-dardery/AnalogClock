using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class frmTheClock
{
    private Drawing2D.Blend Clk_Gradient = new Drawing2D.Blend();
    private Bitmap Bitmap = new Bitmap(200, 200, Imaging.PixelFormat.Format64bppPArgb);

    internal int X, Y;
    internal bool ShownCompleted = false;
    internal bool HideName;
    internal bool Square = false;

    struct One
    {
        public static int X;
        public static int Y;
    }

    struct Two
    {
        public static int X;
        public static int Y;
    }

    struct Three
    {
        public static int X;
        public static int Y;
    }

    struct Four
    {
        public static int X;
        public static int Y;
    }

    struct Five
    {
        public static int X;
        public static int Y;
    }

    struct Six
    {
        public static int X;
        public static int Y;
    }

    struct Seven
    {
        public static int X;
        public static int Y;
    }

    struct Eight
    {
        public static int X;
        public static int Y;
    }

    struct Nine
    {
        public static int X;
        public static int Y;
    }

    struct Ten
    {
        public static int X;
        public static int Y;
    }

    struct Eleven
    {
        public static int X;
        public static int Y;
    }

    struct Twelve
    {
        public static int X;
        public static int Y;
    }



    private void DrawClock(Bitmap Bitmap, bool DrawHands = true)
    {
        Graphics Graphic = Graphics.FromImage(Bitmap);
        Font Clock_Font = frmOptions.P3.Font;
        // For Perfect Picture (Not Important)
        if (frmOptions.rdbHigh.Checked == true)
        {
            Graphic.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality;
            Graphic.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Graphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic;
            Graphic.SmoothingMode = Drawing2D.SmoothingMode.HighQuality;
            Graphic.CompositingQuality = Drawing2D.CompositingQuality.AssumeLinear;
        }

        // Adjusting the gradient location points.
        Clk_Gradient.Positions = new[] { 0.0F, 0.1F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 1.0F };
        // Adjusting the gradient colors through 9 points, where 0.0F is the first color entirly, and 1.0F is the second color.
        Clk_Gradient.Factors = new[] { 0.0F, 0.2F, 0.5F, 0.7F, 1.0F, 0.7F, 0.5F, 0.2F, 0.0F };
        // ---------------------------------------------------------------------------
        // Draw Analog Clock Background

        // This should be possible to change later
        Rectangle rect = new Rectangle(0, 0, 200, 200);

        // Defines the brush to drow the gradient
        Drawing2D.LinearGradientBrush lgb;
        // Sets the gradient angle.
        Console.WriteLine(frmOptions.Mode.ToString);
        if (frmOptions.rdbAngle.Checked)
            lgb = new Drawing2D.LinearGradientBrush(rect, Used_Color.Analog_Color1, Used_Color.Analog_Color2, frmOptions.Angle.Value);
        else
            lgb = new Drawing2D.LinearGradientBrush(rect, Used_Color.Analog_Color1, Used_Color.Analog_Color2, frmOptions.Mode);
        lgb.Blend = Clk_Gradient;

        // fills the outer part of the clock
        if (Square)
            Graphic.FillRectangle(lgb, rect);
        else
            Graphic.FillEllipse(lgb, rect);

        rect = new Rectangle(10, 10, 180, 180);

        // fills the inverted part of the clock (the part that appears to 'pop' out)
        lgb.LinearColors = new Color[] { Used_Color.Analog_Color2, Used_Color.Analog_Color1 };
        if (Square)
            Graphic.FillRectangle(lgb, rect);
        else
            Graphic.FillEllipse(lgb, rect);


        // Uses some calculators to return something similar to (13,13,174,174)
        rect.X += 3; rect.Y += 3; rect.Width -= 2 * 3; rect.Height -= 2 * 3;
        // fills the rest of the clock
        lgb.LinearColors = new Color[] { Used_Color.Analog_Color1, Used_Color.Analog_Color2 };
        if (Square)
            Graphic.FillRectangle(lgb, rect);
        else
            Graphic.FillEllipse(lgb, rect);

        // ---------------------------------------------------------------------------

        // Draw Analog Clock Numbers Background

        Drawing2D.GraphicsPath path = new Drawing2D.GraphicsPath();

        // Uses some calculators to return something similar to (20,20,160,160)
        Rectangle a = new Rectangle(20, 20, 160, 160);
        // Uses some calculators to return something similar to (40,40,120,120)
        Rectangle b = new Rectangle(40, 40, 120, 120);
        if (Square)
        {
            path.AddRectangle(a);
            path.AddRectangle(b);
        }
        else
        {
            path.AddEllipse(a);
            path.AddEllipse(b);
        }


        Graphic.FillPath(new SolidBrush(Color.FromArgb(frmOptions.Alpha.Value, Used_Color.Analog_NumberBackColor)), path);
        // ---------------------------------------------------------------------------

        // Draw Numbers

        SolidBrush sbW = new SolidBrush(Used_Color.Analog_NumberColor);
        if (HideName == false)
        {
            using (Font TheFont = new Font("Arial", 9.0F, FontStyle.Bold))
            {
                Graphic.DrawString("Megadardery", TheFont, sbW, 62, 130);
            }
        }
        if (Square)
        {
            if (frmOptions.rdb1st.Checked)
            {
                Graphic.DrawString("1", Clock_Font, sbW, (130 + X + One.X), (20 + Y + One.Y));
                Graphic.DrawString("2", Clock_Font, sbW, (161 + X + Two.X), (55 + Y + Two.Y));
                Graphic.DrawString("3", Clock_Font, sbW, (162 + X + Three.X), (90 + Y + Three.Y));
                Graphic.DrawString("4", Clock_Font, sbW, (161 + X + Four.X), (125 + Y + Four.Y));
                Graphic.DrawString("5", Clock_Font, sbW, (130 + X + Five.X), (157 + Y + Five.Y));
                Graphic.DrawString("6", Clock_Font, sbW, (93 + X + Six.X), (160 + Y + Six.Y));
                Graphic.DrawString("7", Clock_Font, sbW, (55 + X + Seven.X), (157 + Y + Seven.Y));
                Graphic.DrawString("8", Clock_Font, sbW, (23 + X + Eight.X), (125 + Y + Eight.Y));
                Graphic.DrawString("9", Clock_Font, sbW, (23 + X + Nine.X), (90 + Y + Nine.Y));
                Graphic.DrawString("10", Clock_Font, sbW, (20 + X + Ten.X), (55 + Y + Ten.Y));
                Graphic.DrawString("11", Clock_Font, sbW, (55 + X + Eleven.X), (20 + Y + Eleven.Y));
                Graphic.DrawString("12", Clock_Font, sbW, (89 + X + Twelve.X), (20 + Y + Twelve.Y));
            }
            else if (frmOptions.rdb2nd.Checked)
            {
                Font Clock_Font_Other = new Font("Bodoni MT Poster Compressed", 11.0F, FontStyle.Bold);
                Graphic.DrawString("I", Clock_Font_Other, sbW, (133 + X + One.X), (20 + Y + One.Y));
                Graphic.DrawString("II", Clock_Font_Other, sbW, (164 + X + Two.X), (55 + Y + Two.Y));
                Graphic.DrawString("III", Clock_Font_Other, sbW, (165 + X + Three.X), (90 + Y + Three.Y));
                Graphic.DrawString("IV", Clock_Font_Other, sbW, (164 + X + Four.X), (125 + Y + Four.Y));
                Graphic.DrawString("V", Clock_Font_Other, sbW, (133 + X + Five.X), (160 + Y + Five.Y));
                Graphic.DrawString("VI", Clock_Font_Other, sbW, (96 + X + Six.X), (160 + Y + Six.Y));
                Graphic.DrawString("VII", Clock_Font_Other, sbW, (58 + X + Seven.X), (159 + Y + Seven.Y));
                Graphic.DrawString("VIII", Clock_Font_Other, sbW, (21 + X + Eight.X), (125 + Y + Eight.Y));
                Graphic.DrawString("IX", Clock_Font_Other, sbW, (25 + X + Nine.X), (90 + Y + Nine.Y));
                Graphic.DrawString("X", Clock_Font_Other, sbW, (25 + X + Ten.X), (55 + Y + Ten.Y));
                Graphic.DrawString("XI", Clock_Font_Other, sbW, (58 + X + Eleven.X), (20 + Y + Eleven.Y));
                Graphic.DrawString("XII", Clock_Font_Other, sbW, (92 + X + Twelve.X), (20 + Y + Twelve.Y));
            }
            else
            {
                Graphic.DrawString("_", Clock_Font, sbW, (162 + X + Three.X), (85 + Y + Three.Y));
                Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Six.X), (160 + Y + Six.Y));
                Graphic.DrawString("_", Clock_Font, sbW, (23 + X + Nine.X), (85 + Y + Nine.Y));
                Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Twelve.X), (20 + Y + Twelve.Y));
            }
        }
        else if (frmOptions.rdb1st.Checked)
        {
            Graphic.DrawString("1", Clock_Font, sbW, (130 + X + One.X), (30 + Y + One.Y));
            Graphic.DrawString("2", Clock_Font, sbW, (153 + X + Two.X), (55 + Y + Two.Y));
            Graphic.DrawString("3", Clock_Font, sbW, (162 + X + Three.X), (90 + Y + Three.Y));
            Graphic.DrawString("4", Clock_Font, sbW, (153 + X + Four.X), (125 + Y + Four.Y));
            Graphic.DrawString("5", Clock_Font, sbW, (130 + X + Five.X), (150 + Y + Five.Y));
            Graphic.DrawString("6", Clock_Font, sbW, (93 + X + Six.X), (160 + Y + Six.Y));
            Graphic.DrawString("7", Clock_Font, sbW, (55 + X + Seven.X), (150 + Y + Seven.Y));
            Graphic.DrawString("8", Clock_Font, sbW, (32 + X + Eight.X), (125 + Y + Eight.Y));
            Graphic.DrawString("9", Clock_Font, sbW, (23 + X + Nine.X), (90 + Y + Nine.Y));
            Graphic.DrawString("10", Clock_Font, sbW, (27 + X + Ten.X), (55 + Y + Ten.Y));
            Graphic.DrawString("11", Clock_Font, sbW, (55 + X + Eleven.X), (30 + Y + Eleven.Y));
            Graphic.DrawString("12", Clock_Font, sbW, (89 + X + Twelve.X), (20 + Y + Twelve.Y));
        }
        else if (frmOptions.rdb2nd.Checked)
        {
            Font Clock_Font_Other = new Font("Bodoni MT Poster Compressed", 11.0F, FontStyle.Bold);
            Graphic.DrawString("I", Clock_Font_Other, sbW, (133 + X + One.X), (30 + Y + One.Y));
            Graphic.DrawString("II", Clock_Font_Other, sbW, (156 + X + Two.X), (55 + Y + Two.Y));
            Graphic.DrawString("III", Clock_Font_Other, sbW, (165 + X + Three.X), (90 + Y + Three.Y));
            Graphic.DrawString("IV", Clock_Font_Other, sbW, (156 + X + Four.X), (125 + Y + Four.Y));
            Graphic.DrawString("V", Clock_Font_Other, sbW, (133 + X + Five.X), (150 + Y + Five.Y));
            Graphic.DrawString("VI", Clock_Font_Other, sbW, (96 + X + Six.X), (160 + Y + Six.Y));
            Graphic.DrawString("VII", Clock_Font_Other, sbW, (58 + X + Seven.X), (150 + Y + Seven.Y));
            Graphic.DrawString("VIII", Clock_Font_Other, sbW, (30 + X + Eight.X), (125 + Y + Eight.Y));
            Graphic.DrawString("IX", Clock_Font_Other, sbW, (26 + X + Nine.X), (90 + Y + Nine.Y));
            Graphic.DrawString("X", Clock_Font_Other, sbW, (30 + X + Ten.X), (55 + Y + Ten.Y));
            Graphic.DrawString("XI", Clock_Font_Other, sbW, (58 + X + Eleven.X), (30 + Y + Eleven.Y));
            Graphic.DrawString("XII", Clock_Font_Other, sbW, (92 + X + Twelve.X), (20 + Y + Twelve.Y));
        }
        else
        {
            Graphic.DrawString("_", Clock_Font, sbW, (162 + X + Three.X), (85 + Y + Three.Y));
            Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Six.X), (160 + Y + Six.Y));
            Graphic.DrawString("_", Clock_Font, sbW, (23 + X + Nine.X), (85 + Y + Nine.Y));
            Graphic.DrawString("|", Clock_Font, sbW, (95 + X + Twelve.X), (20 + Y + Twelve.Y));
        }

        if (DrawHands == true)
        {
            // This code basically sets the center of the drawing, so it acts similar to actual geographic.

            Graphic.TranslateTransform(100, 100, Drawing2D.MatrixOrder.Append);
            // ---------------------------------------------------------------------------

            // Create The Angle Of Each Hand (note that 0 is looking straight up)

            // Basically, 2 * PI is a full turn, we want any value that is 1 to face upwards.

            // gets the ratio of the hours hand rotation (this also adds the little fraction of additional movement due to the minutes hand)
            double hAngle = 2.0 * Math.PI * (DateTime.Now.Hour + (DateTime.Now.Minute / 60.0)) / 12.0; // m_Hours
            // gets the ratio of the minutes hand rotation (this also adds the little fraction of additional movement due to the seconds hand)
            double mAngle = 2.0 * Math.PI * (DateTime.Now.Minute + DateTime.Now.Second / 60.0) / 60.0; // minute
            // gets the ratio of the seconds hand rotation
            double sAngle = 2.0 * Math.PI * (DateTime.Now.Second) / 60.0; // seconds

            // ---------------------------------------------------------------------------


            // Draw Hours Hand


            // The point where the hours hand should end
            Point hourEnd = new Point(System.Convert.ToInt32(50 * Math.Sin(hAngle)), System.Convert.ToInt32(-50 * Math.Cos(hAngle)));
            // The two points away 5pts from the start point, they are perpendicular on the hours hand.
            // Since they are perpendicular, the cos and the sin are switched.
            Point hourStart1 = new Point(System.Convert.ToInt32(5 * Math.Cos(hAngle)), System.Convert.ToInt32(5 * Math.Sin(hAngle)));
            Point hourStart2 = new Point(System.Convert.ToInt32(-5 * Math.Cos(hAngle)), System.Convert.ToInt32(-5 * Math.Sin(hAngle)));

            Point[] HourArrow = new[] { hourEnd, hourStart2, hourStart1, hourEnd };
            Drawing2D.GraphicsPath PathHours = new Drawing2D.GraphicsPath();
            PathHours.AddPolygon(HourArrow);

            Drawing2D.LinearGradientBrush hourBrush = new Drawing2D.LinearGradientBrush(PathHours.GetBounds(), Used_Color.Hour_Color1, Used_Color.Hour_Color2, hAngle, false);
            hourBrush.Blend = Clk_Gradient;

            Graphic.FillPath(hourBrush, PathHours);

            // fills a circle around the center of the clock
            Graphic.FillEllipse(hourBrush, -5, -5, 10, 10);
            // ---------------------------------------------------------------------------

            // Draw Minute Hand
            // The point where the minutes hand should end
            Point minEnd = new Point(System.Convert.ToInt32(65 * Math.Sin(mAngle)), System.Convert.ToInt32(-65 * Math.Cos(mAngle)));
            // The two points away 5pts from the start point, they are perpendicular on the minutes hand.
            Point minStart1 = new Point(System.Convert.ToInt32(5 * Math.Cos(mAngle)), System.Convert.ToInt32(5 * Math.Sin(mAngle)));
            Point minStart2 = new Point(System.Convert.ToInt32(-5 * Math.Cos(mAngle)), System.Convert.ToInt32(-5 * Math.Sin(mAngle)));

            Point[] MinArrow = new[] { minEnd, minStart1, minStart2, minEnd };
            Drawing2D.GraphicsPath PathMins = new Drawing2D.GraphicsPath();
            PathMins.AddPolygon(MinArrow);

            Drawing2D.LinearGradientBrush minBrush = new Drawing2D.LinearGradientBrush(PathMins.GetBounds(), Used_Color.Minute_Color1, Used_Color.Minute_Color2, mAngle, false);
            minBrush.Blend = Clk_Gradient;

            Graphic.FillPath(minBrush, PathMins);

            // fills a circle around the center of the clock
            Graphic.FillEllipse(minBrush, -5, -5, 10, 10);
            // ---------------------------------------------------------------------------


            if (!frmOptions.chkHide.Checked)
            {
                // Draw Second Hand      
                Pen secondPen = new Pen(Used_Color.Second_Color, 1.5);

                Point SecEnd = new Point(System.Convert.ToInt32(70 * Math.Sin(sAngle)), System.Convert.ToInt32(-70 * Math.Cos(sAngle)));



                if (frmOptions.CheckBox1.Checked)
                {
                    Point SecRectEnd = new Point(new Point(System.Convert.ToInt32(-13 * Math.Sin(sAngle)), System.Convert.ToInt32(13 * Math.Cos(sAngle))));
                    Point SecRectStart = new Point(new Point(System.Convert.ToInt32(-33 * Math.Sin(sAngle)), System.Convert.ToInt32(33 * Math.Cos(sAngle))));

                    Graphic.DrawLine(secondPen, SecRectEnd, SecEnd);
                    secondPen.Width = 5;
                    Graphic.DrawLine(secondPen, SecRectStart, SecRectEnd);

                    Graphic.FillEllipse(secondPen.Brush, -4, -4, 8, 8);
                }
                else
                {
                    Graphic.DrawLine(secondPen, new Point(0, 0), SecEnd);
                    Graphic.FillEllipse(minBrush, -5, -5, 10, 10);
                }
            }
        }
    }

    internal void Redraw(Imaging.PixelFormat PixelFormat)
    {
        if (ShownCompleted == true)
            Bitmap = new Bitmap(200, 200, PixelFormat);
    }


    private Point MouseOffset;
    private bool IsLeftButtonDown = false;

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        int xOffset;
        int yOffset;
        if (e.Button == MouseButtons.Left)
        {
            xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
            yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
            MouseOffset = new Point(xOffset, yOffset);
            IsLeftButtonDown = true;
        }
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsLeftButtonDown)
        {
            Point MousePosition = Control.MousePosition;
            MousePosition.Offset(MouseOffset.X, MouseOffset.Y);
            Location = MousePosition;
        }
    }

    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            IsLeftButtonDown = false;
    }


    struct Used_Color
    {
        public static Color Analog_Color1 = Color.Black;
        public static Color Analog_Color2 = Color.White;
        public static Color Analog_NumberBackColor = Color.White;
        public static Color Analog_NumberColor = Color.LightGray;
        public static Color Hour_Color1 = Color.Black;
        public static Color Hour_Color2 = Color.White;
        public static Color Minute_Color1 = Color.Black;
        public static Color Minute_Color2 = Color.White;
        public static Color Second_Color = Color.Black;
    }

    private void TheAnalogClock_DoubleClick(object sender, System.EventArgs e)
    {
        frmOptions.ShowDialog();
    }

    private void PictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        e.Graphics.DrawImage(Bitmap, 0, 0, 200, 200);
    }

    internal void Save(Imaging.PixelFormat PixelFormat)
    {
        Bitmap SavedBitmap = new Bitmap(200, 200, PixelFormat);

        try
        {
            Imaging.ImageFormat Type = Imaging.ImageFormat.Bmp;
            if ((SaveFileDialog1.ShowDialog == Windows.Forms.DialogResult.OK) == false)
                return;
            switch (SaveFileDialog1.FilterIndex)
            {
                case 1:
                {
                    Type = Imaging.ImageFormat.Bmp;
                    break;
                }

                case 2:
                {
                    Type = Imaging.ImageFormat.Gif;
                    break;
                }

                case 3:
                {
                    Type = Imaging.ImageFormat.Jpeg;
                    break;
                }

                case 4:
                {
                    Type = Imaging.ImageFormat.Tiff;
                    break;
                }
            }

            DrawClock(SavedBitmap, frmOptions.chkShowHands.Checked);

            SavedBitmap.Save(SaveFileDialog1.FileName, Type);
        }
        catch (Exception ex)
        {
            if (MessageBox.Show(string.Format("Unhandled Error Has Occurred Please E-mail Me At {0} With The Following Message {1}{1}{2}{1}{1} Continue?", new[] { "Megadardery@yahoo.com", Constants.vbCrLf, ex.ToString() }), "Unhandled Error", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == Windows.Forms.DialogResult.Yes)
                return;
            Application.ExitThread();
            return;
        }
        finally
        {
            this.Timer1.Enabled = true;
            SavedBitmap.Dispose();
        }
        Process.Start(SaveFileDialog1.FileName);

        SaveFileDialog1.FileName = "";
    }

    private void TheClock_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
        frmOptions.Dialog1_FormClosed(null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */);
        Application.ExitThread();
    }

    private void DateAndTime_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        for (double counter = 1.0#; counter >= 0.0#; counter += -0.02#)
        {
            this.Opacity = counter;
            this.Refresh();
            System.Threading.Thread.Sleep(10);
        }
    }

    private void TheClock_Shown(object sender, System.EventArgs e)
    {
        for (double counter = 0.0#; counter <= 1.0#; counter += 0.02#)
        {
            this.Opacity = counter;
            this.Refresh();
            System.Threading.Thread.Sleep(10);
        }
        ShownCompleted = true;
    }

    private void Timer1_Tick(System.Object sender, System.EventArgs e)
    {
        DrawClock(Bitmap, true);
        this.Refresh();
    }

    private void TheClock_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
            Interaction.MsgBox("Double Click On The Clock(Or Press Alt + O) To Show Options", MsgBoxStyle.Information);
    }

    private void TheClock_Load(object sender, System.EventArgs e)
    {
        DrawClock(Bitmap, true);
    }

    internal void LoadOptions()
    {
        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 21488
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        On Error Resume Next

 */
        string[] Text = Split(My.Computer.Registry.CurrentUser.OpenSubKey(@"Software\Analog Clock").GetValue("Data"), "|");
        // 
        frmOptions.CC1.BackColor = Color.FromArgb(Text[0]);
        Used_Color.Analog_Color1 = Color.FromArgb(Text[0]);
        // 
        // 
        frmOptions.CC2.BackColor = Color.FromArgb(Text[1]);
        Used_Color.Analog_Color2 = Color.FromArgb(Text[1]);
        // 
        // 
        frmOptions.P3.Font = new Font(Text[2], 11.0F, FontStyle.Bold);
        // 
        // 
        frmOptions.P3.ForeColor = Color.FromArgb(Text[3]);
        Used_Color.Analog_NumberColor = Color.FromArgb(Text[3]);
        // 
        // 
        frmOptions.P3.BackColor = Color.FromArgb(frmOptions.Alpha.Value, Color.FromArgb(Text[4]));
        Used_Color.Analog_NumberBackColor = Color.FromArgb(Text[4]);
        // 
        // 
        frmOptions.HC1.BackColor = Color.FromArgb(Text[5]);
        Used_Color.Hour_Color1 = Color.FromArgb(Text[5]);
        // 
        // 
        frmOptions.HC2.BackColor = Color.FromArgb(Text[6]);
        Used_Color.Hour_Color2 = Color.FromArgb(Text[6]);
        // 
        // 
        frmOptions.MC1.BackColor = Color.FromArgb(Text[7]);
        Used_Color.Minute_Color1 = Color.FromArgb(Text[7]);
        // 
        // 
        frmOptions.MC2.BackColor = Color.FromArgb(Text[8]);
        Used_Color.Minute_Color2 = Color.FromArgb(Text[8]);
        // 
        // 
        frmOptions.SC.BackColor = Color.FromArgb(Text[9]);
        Used_Color.Second_Color = Color.FromArgb(Text[9]);
        // 
        // 
        frmOptions.rdbSquare.Checked = !System.Convert.ToBoolean(Text[10]);
        // 
        // 
        frmOptions.rdbLow.Checked = !System.Convert.ToBoolean(Text[11]);
        // 
        // 
        frmOptions.chkTransparent.Checked = System.Convert.ToBoolean(Text[12]);
        // 
        // 
        if (Conversion.Val(Text[13]) == 1)
            frmOptions.rdbAngle.Checked = true;
        else
            frmOptions.rdbType.Checked = true;
        // 
        // 
        frmOptions.chkShowHands.Checked = System.Convert.ToBoolean(Text[14]);
        // 
        // 
        frmOptions.chkHide.Checked = System.Convert.ToBoolean(Text[15]);
        // 
        // 
        switch (Conversion.Val(Text[16]))
        {
            case 1:
            {
                frmOptions.rdb1st.Checked = true;
                break;
            }

            case 2:
            {
                frmOptions.rdb2nd.Checked = true;
                break;
            }

            case 3:
            {
                frmOptions.rdb3rd.Checked = true;
                break;
            }
        }
        // 
        // 
        frmOptions.chkStartWithWindows.Checked = System.Convert.ToBoolean(Text[17]);
        // 
        // 
        if (Text[18] == null & Text[19] == null)
        {
        }
        else
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Text[18], Text[19]);
        }
        // 
        // 
        if (frmOptions.rdbAngle.Checked == true)
            frmOptions.Angle.Value = Text[20];
        else
            frmOptions.Type.SelectedIndex = Text[20];
        // 
        // 
        frmOptions.Alpha.Value = Conversion.Val(Text[21]);
        // 
        // 
        X = Text[22]; Y = Text[23];
        One.X = Text[24]; One.Y = Text[25];
        Two.X = Text[26]; Two.Y = Text[27];
        Three.X = Text[28]; Three.Y = Text[29];
        Four.X = Text[30]; Four.Y = Text[31];
        Five.X = Text[32]; Five.Y = Text[33];
        Six.X = Text[34]; Six.Y = Text[35];
        Seven.X = Text[36]; Seven.Y = Text[37];
        Eight.X = Text[38]; Eight.Y = Text[39];
        Nine.X = Text[40]; Nine.Y = Text[41];
        Ten.X = Text[42]; Ten.Y = Text[43];
        Eleven.X = Text[44]; Eleven.Y = Text[45];
        Twelve.X = Text[46]; Twelve.Y = Text[47];
        // 
        // 
        frmOptions.chkSplash.Checked = Text[48];
        // 
        HideName = !System.Convert.ToBoolean(Text[49]);
        // 
        frmOptions.CheckBox1.Checked = System.Convert.ToBoolean(Text[50]);
    }

    private void TheAnalogClock_Click(System.Object sender, System.EventArgs e)
    {
    }

    private void TheClock_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   at ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   at ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   at ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__15.MoveNext()
   at System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   at Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   at ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst)
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static Cheat As Integer = 0

 */
        if (HideName == false)
        {
            if (e.KeyChar == 'h')
                Cheat += 1;
            if (Cheat == 1 && e.KeyChar == 'i')
                Cheat += 1;
            if (Cheat == 2 && e.KeyChar == 'd')
                Cheat += 1;
            if (Cheat == 3 && e.KeyChar == 'e')
                Cheat += 1;
            if (Cheat == 4 && e.KeyChar == 'm')
                Cheat += 1;
            if (Cheat == 5 && e.KeyChar == 'y')
                Cheat += 1;
            if (Cheat == 6 && e.KeyChar == 'n')
                Cheat += 1;
            if (Cheat == 7 && e.KeyChar == 'a')
                Cheat += 1;
            if (Cheat == 8 && e.KeyChar == 'm')
                Cheat += 1;
            if (Cheat == 9 && e.KeyChar == 'e')
            {
                HideName = true;
                Cheat = 0;
            }
        }
        else
        {
            if (e.KeyChar == 's')
                Cheat += 1;
            if (Cheat == 1 && e.KeyChar == 'h')
                Cheat += 1;
            if (Cheat == 2 && e.KeyChar == 'o')
                Cheat += 1;
            if (Cheat == 3 && e.KeyChar == 'w')
                Cheat += 1;
            if (Cheat == 4 && e.KeyChar == 'm')
                Cheat += 1;
            if (Cheat == 5 && e.KeyChar == 'y')
                Cheat += 1;
            if (Cheat == 6 && e.KeyChar == 'n')
                Cheat += 1;
            if (Cheat == 7 && e.KeyChar == 'a')
                Cheat += 1;
            if (Cheat == 8 && e.KeyChar == 'm')
                Cheat += 1;
            if (Cheat == 9 && e.KeyChar == 'e')
            {
                HideName = false;
                Cheat = 0;
            }
        }
    }

    private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmOptions.ShowDialog();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void frmTheClock_LostFocus(object sender, EventArgs e)
    {
    }
}
