using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipher_picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMyImage("C:/Users/Misha_MKR/Desktop/cipher_picture/tt.jpg", 500, 384);//C:\Users\Misha_MKR\Desktop\cipher_pictureC:\Users\Misha_MKR\Desktop\cipher_picture
        }

        private Bitmap MyImage;
        public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        {
            if (MyImage != null)
            {
                MyImage.Dispose();
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = (Image)MyImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(str))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

            string binaryStr = sb.ToString();
            int[] masbinary = new int[(textBox1.Text.Length + 1) * 8];
            for (int i = 0; i < textBox1.Text.Length * 8; i++)
                masbinary[i] = (int)Char.GetNumericValue(binaryStr[i]);

            Bitmap MyImage2 = MyImage;
            int countmasbinary = 0;
            for (int i = 0; i < masbinary.Length / 3; i++)
            {
                Color pixelColor = MyImage.GetPixel(i, i / 500);
                byte r = pixelColor.R;
                byte g = pixelColor.G;
                byte b = pixelColor.B;
                if (r % 2 == 1 & masbinary[countmasbinary] == 0)
                    r--;
                else
                if (r % 2 == 0 & masbinary[countmasbinary] == 1)
                    r++;

                if (g % 2 == 1 & masbinary[countmasbinary + 1] == 0)
                    g--;
                else
                if (g % 2 == 0 & masbinary[countmasbinary + 1] == 1)
                    g++;

                if (b % 2 == 1 & masbinary[countmasbinary + 2] == 0)
                    b--;
                else
                if (b % 2 == 0 & masbinary[countmasbinary + 2] == 1)
                    b++;
                countmasbinary += 3;

                MyImage2.SetPixel(i, i / 500, Color.FromArgb(r, g, b));
            }

            if (masbinary.Length % 3 == 2)
            {
                Color pixelColor = MyImage.GetPixel(masbinary.Length / 3, masbinary.Length / 3 / 500);
                byte r = pixelColor.R;
                byte g = pixelColor.G;
                if (r % 2 == 1 & masbinary[countmasbinary] == 0)
                    r--;
                else
                if (r % 2 == 0 & masbinary[countmasbinary] == 1)
                    r++;

                if (g % 2 == 1 & masbinary[countmasbinary + 1] == 0)
                    g--;
                else
                if (g % 2 == 0 & masbinary[countmasbinary + 1] == 1)
                    g++;

                MyImage2.SetPixel(masbinary.Length / 3, masbinary.Length / 3 / 500, Color.FromArgb(r, g, pixelColor.B));
            }

            if (masbinary.Length % 3 == 1)
            {
                Color pixelColor = MyImage.GetPixel(masbinary.Length / 3, masbinary.Length / 3 / 500);
                byte r = pixelColor.R;
                if (r % 2 == 1 & masbinary[countmasbinary] == 0)
                    r--;
                else
                if (r % 2 == 0 & masbinary[countmasbinary] == 1)
                    r++;
                
                MyImage2.SetPixel(masbinary.Length / 3, masbinary.Length / 3 / 500, Color.FromArgb(r, pixelColor.G, pixelColor.B));
            }

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(500, 384);
            pictureBox2.Image = (Image)MyImage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[,] masbinary = new int[100000, 8];
            int x = 0, y = 0,i=0,j=0;
            while (true)
            {
                Color pixelColor = MyImage.GetPixel(x,y);
                x++;y++;
                masbinary[i, j] = pixelColor.R % 2;
                j++;
                if(j>7)
                {
                    j = 0;
                    if (masbinary[i, 0] == masbinary[i, 1] & masbinary[i, 1] == masbinary[i, 2] & masbinary[i, 2] == masbinary[i, 3] & masbinary[i, 3] == masbinary[i, 4] & masbinary[i, 4] == masbinary[i, 5] & masbinary[i, 5] == masbinary[i, 6] & masbinary[i, 6] == masbinary[i, 7] & masbinary[i, 7] == 0)
                        break;
                    i++;
                }

                masbinary[i, j] = pixelColor.G % 2;
                j++;
                if (j > 7)
                {
                    j = 0;
                    if (masbinary[i, 0] == masbinary[i, 1] & masbinary[i, 1] == masbinary[i, 2] & masbinary[i, 2] == masbinary[i, 3] & masbinary[i, 3] == masbinary[i, 4] & masbinary[i, 4] == masbinary[i, 5] & masbinary[i, 5] == masbinary[i, 6] & masbinary[i, 6] == masbinary[i, 7] & masbinary[i, 7] == 0)
                        break;
                    i++;
                }

                masbinary[i, j] = pixelColor.B % 2;
                j++;
                if (j > 7)
                {
                    j = 0;
                    if (masbinary[i, 0] == masbinary[i, 1] & masbinary[i, 1] == masbinary[i, 2] & masbinary[i, 2] == masbinary[i, 3] & masbinary[i, 3] == masbinary[i, 4] & masbinary[i, 4] == masbinary[i, 5] & masbinary[i, 5] == masbinary[i, 6] & masbinary[i, 6] == masbinary[i, 7] & masbinary[i, 7] == 0)
                        break;
                    i++;
                }
                x++;
                if(x>500)
                {
                    x = 0;
                    y++;
                }
            }
            string text="";
            for(int counti=0;counti<i;counti++)
                for (int countj = 0; countj < 8; countj++)
                    text += masbinary[counti, countj].ToString();
                var stringArray = Enumerable.Range(0, text.Length / 8).Select(perem => Convert.ToByte(text.Substring(perem * 8, 8), 2)).ToArray();
                var str = Encoding.Unicode.GetString(stringArray);
                textBox2.Text += str.ToString();
            




        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowMyImage("C:/Users/Misha_MKR/Desktop/cipher_picture/tt.jpg", 500, 384);
        }
    }
}
