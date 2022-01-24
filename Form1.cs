using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Threading;

namespace SW_T8_9_10
{
    public partial class Form1 : Form
    {

        private Size desired_image_size;
        Image<Bgr, byte> image_PB1;
        VideoCapture camera;

        Queue<Point> pix_tlace = new Queue<Point>();
        Queue<Point> pix_palace = new Queue<Point>();
        Queue<Point> pix_nadpalone = new Queue<Point>();
        Queue<Point> pix_wypalone = new Queue<Point>();

        private MCvScalar cecha_palnosci = new MCvScalar(0xFF, 0xFF, 0xFF);
        private MCvScalar cecha_nadpalenia = new MCvScalar(0, 0, 0);

        private MCvScalar kolor_tlenia = new MCvScalar(51, 153, 255);
        private MCvScalar kolor_palenia = new MCvScalar(0, 0, 204);
        private MCvScalar kolor_nadpalenia = new MCvScalar(51, 204, 51);
        private MCvScalar kolor_wypalenia = new MCvScalar(100, 100, 100);
        private MCvScalar aktualny_kolor_wypalenia = new MCvScalar(100, 100, 100);

        private int nr_pozaru = 0;
        private float WypaloneCalosc = 0;
        private float ProcentPowierzchni = 0;
        private float CalaPowierzchnia = 125965;
        private float[] ArrayPowierzchniePojedynczychPlam = new float[100];
        private float[] TabPow = new float[100];
        private float[] TabProcentPow = new float[100];

        public Form1()
        {
            InitializeComponent();
            desired_image_size = pictureBox1.Size;
            image_PB1 = new Image<Bgr, byte>(desired_image_size);
            try
            {
                camera = new VideoCapture();
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, desired_image_size.Width);
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, desired_image_size.Height);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button_Browse_Files_PB1_Click(object sender, EventArgs e)
        {
            textBox_Image_Path_PB1.Text = get_image_path();
        }

        private string get_image_path()
        {
            string ret = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Obrazy|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Wybierz obrazek.";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ret = openFileDialog1.FileName;
            }

            return ret;
        }

        private void button_From_File_PB1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = get_image_bitmap_from_file(textBox_Image_Path_PB1.Text, ref image_PB1);
            Wyczysc_dane_pozaru();
        }

        private Bitmap get_image_bitmap_from_file(string path, ref Image<Bgr, byte> Data)
        {
            Mat temp = CvInvoke.Imread(path);
            CvInvoke.Resize(temp, temp, desired_image_size);
            Data = temp.ToImage<Bgr, byte>();
            return Data.Bitmap;
        }

        private void Wyczysc_dane_pozaru()
        {
            nr_pozaru = 0;
            pix_wypalone.Clear();
        }

        private void Pozar_Calosci()
        {

            byte[,,] pozar = image_PB1.Data;
            for (int y = 1; y < desired_image_size.Height - 2; y++)
            {
                for (int x = 1; x < desired_image_size.Width - 2; x++)
                {
                    if (Sprawdz_czy_cecha_palnosci(pozar[y, x, 0], pozar[y, x, 1], pozar[y, x, 2]))
                    {
                        nr_pozaru = nr_pozaru + 1;

                        aktualny_kolor_wypalenia.V0 = kolor_wypalenia.V0 + 8 * nr_pozaru;
                        aktualny_kolor_wypalenia.V1 = kolor_wypalenia.V1 + 8 * nr_pozaru;
                        aktualny_kolor_wypalenia.V2 = kolor_wypalenia.V2 + 8 * nr_pozaru;
                        pix_tlace.Enqueue(new Point(x, y));

                        Cykl_Pozaru();

                        pozar = image_PB1.Data;

                        ArrayPowierzchniePojedynczychPlam[nr_pozaru - 1] = pix_wypalone.Count();

                    }
                }
            }
            label_liczba_ognisk_rdzy.Text = "Liczba ognisk rdzy: " + nr_pozaru;
            WypaloneCalosc = pix_wypalone.Count();
            procent_pow_zardzewialej();
            procent_pow_poszczegolnych_plam();
            image_PB1.Data = pozar;
            pictureBox1.Image = image_PB1.Bitmap;
        }

        private void Cykl_Pozaru()
        {

            do
            {
                Krok_Pozaru();
            } while (pix_tlace.Count > 0);

        }

        private void Krok_Pozaru()
        {
            
            byte[, ,] temp = image_PB1.Data;

            Tlace_do_palacych(temp);

            foreach (Point pix in pix_palace)
            {
                Tlenie_od_palacego(temp, pix);
            }

            foreach (Point pix in pix_palace)
            {
                Nadpalenie_palacego(temp, pix);
            }

            Wypalenie_palacego(temp);

            image_PB1.Data = temp;
            pictureBox1.Image = image_PB1.Bitmap;         
            Application.DoEvents();
        }

        private void Tlace_do_palacych(byte[, ,] temp)
        {
            while (pix_tlace.Count > 0)
            {
                Point p = pix_tlace.Dequeue();
                pix_palace.Enqueue(p);
                temp[p.Y, p.X, 0] = (byte)kolor_palenia.V0;
                temp[p.Y, p.X, 1] = (byte)kolor_palenia.V1;
                temp[p.Y, p.X, 2] = (byte)kolor_palenia.V2;
            }
        }

        private void Tlenie_od_palacego(byte[, ,] temp, Point pix_in)
        {
            if (Czy_piksel_w_zakresie(pix_in))
            {
                Point[] sasiedzi = Wylicz_wspolrzedne_sasiednich_pikseli(pix_in);
                foreach (Point p in sasiedzi)
                {
                    if (Sprawdz_czy_cecha_palnosci(temp[p.Y, p.X, 0], temp[p.Y, p.X, 1], temp[p.Y, p.X, 2]))
                    {
                        pix_tlace.Enqueue(new Point(p.X, p.Y));
                        temp[p.Y, p.X, 0] = (byte)kolor_tlenia.V0;
                        temp[p.Y, p.X, 1] = (byte)kolor_tlenia.V1;
                        temp[p.Y, p.X, 2] = (byte)kolor_tlenia.V2;
                    }
                }
            }
        }

        private void Nadpalenie_palacego(byte[, ,] temp, Point pix_in)
        {
           
            if (Czy_piksel_w_zakresie(pix_in))
            {
                Point[] sasiedzi = Wylicz_wspolrzedne_sasiednich_pikseli(pix_in);
                bool nalezy_nadpalic = false;
                foreach (Point p in sasiedzi)
                {

                    nalezy_nadpalic = Sprawdz_czy_cecha_nadpalenia(temp[p.Y, p.X, 0], temp[p.Y, p.X, 1], temp[p.Y, p.X, 2]);

                    if (nalezy_nadpalic)
                    {
                        pix_nadpalone.Enqueue(new Point(p.X, p.Y));
                        temp[p.Y, p.X, 0] = (byte)kolor_nadpalenia.V0;
                        temp[p.Y, p.X, 1] = (byte)kolor_nadpalenia.V1;
                        temp[p.Y, p.X, 2] = (byte)kolor_nadpalenia.V2;
                    }
                }
            }
        }

        private void Wypalenie_palacego(byte[, ,] temp)
        {
            while (pix_palace.Count > 0)
            {
                Point p = pix_palace.Dequeue();
                pix_wypalone.Enqueue(p);
                temp[p.Y, p.X, 0] = (byte)(aktualny_kolor_wypalenia.V0);
                temp[p.Y, p.X, 1] = (byte)(aktualny_kolor_wypalenia.V1);
                temp[p.Y, p.X, 2] = (byte)(aktualny_kolor_wypalenia.V2);
            }
        }

        private Point[] Wylicz_wspolrzedne_sasiednich_pikseli(Point pix_in)
        {
            List<Point> sasiedzi = new List<Point>();
            sasiedzi.Add(new Point(pix_in.X - 1, pix_in.Y));
            sasiedzi.Add(new Point(pix_in.X + 1, pix_in.Y));
            sasiedzi.Add(new Point(pix_in.X, pix_in.Y - 1));
            sasiedzi.Add(new Point(pix_in.X, pix_in.Y + 1));

            return sasiedzi.ToArray();
        }

        private bool Czy_piksel_w_zakresie(Point pix_in)
        {
            int max_W, max_H;
            max_W = desired_image_size.Width - 1;
            max_H = desired_image_size.Height - 1;
            if (pix_in.X > 0 && pix_in.X < max_W && pix_in.Y > 0 && pix_in.Y < max_H)
                return true;
            else
                return false;
        }

        private bool Sprawdz_czy_cecha_palnosci(byte B, byte G, byte R)
        {
            if (B == 0x0 && G == 0x0 && R == 0x0)
                return true;
            else
                return false;
        }

        private bool Sprawdz_czy_cecha_nadpalenia(byte B, byte G, byte R)
        {
            if (B == 0xff && G == 0xff && R == 0xff)
                return true;
            else
                return false;
        }

        private bool Sprawdz_czy_jakiekolwiek_nadpalenie(byte B, byte G, byte R)
        {
            if (B == 0x0 && G == 0x0 && R == 0x0)
                return false;
            else if (B == 0xff && G == 0xff && R == 0xff)
                return true;
            else if (B == kolor_tlenia.V0 && G == kolor_tlenia.V1 && R == kolor_tlenia.V2)
                return false;
            else if (B == kolor_nadpalenia.V0 && G == kolor_nadpalenia.V1 && R == kolor_nadpalenia.V2)
                return false;
            else if (B == kolor_palenia.V0 && G == kolor_palenia.V1 && R == kolor_palenia.V2)
                return false;
            else if (B == aktualny_kolor_wypalenia.V0 && G == aktualny_kolor_wypalenia.V1 && R == aktualny_kolor_wypalenia.V2)
                return false;
            else
                return true;
        }

        private void button_analizuj_powierzchne_Click(object sender, EventArgs e)
        {
            Wyczysc_dane_pozaru();
            Application.DoEvents();
            Pozar_Calosci();
        }

        private void procent_pow_zardzewialej()
        {

            ProcentPowierzchni = WypaloneCalosc / CalaPowierzchnia * 100;
            label_procent_pow_zardzewialej.Text = "Procentowa wartość powierzchni zardzewiałej: \n" + ProcentPowierzchni + " %";
            
        }


        private void procent_pow_poszczegolnych_plam()
        {
            
            for (int i = 0; i< nr_pozaru; i++)
            {
                if (i == 0)
                {
                    TabPow[i] = ArrayPowierzchniePojedynczychPlam[i];
                }
                else
                {
                    TabPow[i] = ArrayPowierzchniePojedynczychPlam[i] - ArrayPowierzchniePojedynczychPlam[i-1];
                }
                
                TabProcentPow[i] = TabPow[i] / CalaPowierzchnia * 100;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                CvInvoke.Circle(image_PB1, e.Location, 2, new MCvScalar(255, 255, 255), -1);
                pictureBox1.Image = image_PB1.Bitmap;
            }
        }

        private void button_Czysc_Click(object sender, EventArgs e)
        {
            image_PB1.SetZero();
            pictureBox1.Image = image_PB1.Bitmap;
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Image_Path_PB1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown_Numer_obiektu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_pokaz_plame_Click(object sender, EventArgs e)
        {
            label_procent_plam.Text = "Procentowa wartość plamy " + numericUpDown_numer_plamy.Value + ": " + TabProcentPow[(int)numericUpDown_numer_plamy.Value-1] + " %";
        }
    }
}
