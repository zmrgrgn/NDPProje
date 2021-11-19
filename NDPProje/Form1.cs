using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/****************************************************************************
**					    SAKARYA ÜNİVERSİTESİ
**			    BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					   2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:PROJE ÖDEVİ
**				ÖĞRENCİ ADI............:ZÜMRA GİRGİN
**				ÖĞRENCİ NUMARASI.......:B181200038
**              DERSİN ALINDIĞI GRUP...:C GRUBU
****************************************************************************/

namespace NDPProje
{
    public partial class Form1 : Form
    {
        //Atık sınıfımızı kullanarak nesnelerimizi üretiyoruz.
        Atik domates = new Atik(150, Image.FromFile("domates.jpg"));
        Atik salatalik = new Atik(120, Image.FromFile("salatalik.jpg"));
        Atik bardak = new Atik(250, Image.FromFile("bardak.jpg"));
        Atik camsise = new Atik(600, Image.FromFile("camsise.jpg"));
        Atik salca = new Atik(550, Image.FromFile("salca.jpg"));
        Atik kola = new Atik(350, Image.FromFile("kola.jpg"));
        Atik dergi = new Atik(200, Image.FromFile("dergi.jpg"));
        Atik gazete = new Atik(250, Image.FromFile("gazete.jpg"));
        //Random komutu için değişken üretiyoruz.
        int rastgele = 0;
        //Puan için label değişkeni üretiyoruz.
        int labelDeger;
        //Atık Kutuları sınıfımızı kullanarak nesnelerimizi üretiyoruz.
        AtikKutulari organikAtikKutusu = new AtikKutulari(0, 700, 525,0);
        AtikKutulari camAtikKutusu = new AtikKutulari(600, 2200, 1650, 0);
        AtikKutulari metalAtikKutusu = new AtikKutulari(800, 2300, 1725, 0);
        AtikKutulari kagitAtikKutusu = new AtikKutulari(1000, 1200, 900, 0);
        //Bu metodumuzla picturebox'umuzun içindeki fotoğrafa göre buttonlarımızı aktifleştirip pasifleştiriyoruz.
        public void buttonKontrol()
        {
            if (pictureBox1.Image == domates.Image || pictureBox1.Image == salatalik.Image)
            {
                if (progressBar1.Value <= organikAtikKutusu.Kapasite || organikAtikKutusu.Kapasite - progressBar1.Value > domates.Hacim || organikAtikKutusu.Kapasite - progressBar1.Value > salatalik.Hacim)
                {
                    button1.Enabled = true;
                    button3.Enabled = false;
                    button5.Enabled = false;
                    button7.Enabled = false;
                } 
            }
            else if (pictureBox1.Image == dergi.Image || pictureBox1.Image == gazete.Image)
            {
                button1.Enabled = false;
                button3.Enabled = true;
                button5.Enabled = false;
                button7.Enabled = false;
            }
            else if (pictureBox1.Image == bardak.Image || pictureBox1.Image == camsise.Image)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = true;
                button7.Enabled = false;
            }

            else if (pictureBox1.Image == kola.Image || pictureBox1.Image == salca.Image)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
                button7.Enabled = true;
            }
        }
        //Kutuların %75 doluluğa ulaştıktan sonra çalışmasını sağlıyoruz.
        public void buttonKontrol1()
        {
            if (progressBar1.Value >= organikAtikKutusu.DoluHacim)
            {
                button2.Enabled = true;
            }
            if (progressBar2.Value >= camAtikKutusu.DoluHacim)
            {
                button6.Enabled = true;
            }
            if(progressBar3.Value>=kagitAtikKutusu.DoluHacim)
            {
                button4.Enabled = true;
            }
            if (progressBar4.Value >= metalAtikKutusu.DoluHacim)
            {
                button8.Enabled = true;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Program çalışmaya başlamadan önce buttonlarımızın pasif kalmasını sağlıyor.
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //progressbar'ımızın max ve min değerlerini belirliyoruz.
            progressBar1.Maximum = organikAtikKutusu.Kapasite;
            progressBar1.Minimum = 0;
            
            //Fotoğraf dizisini oluşturuyoruz.
            Image[] ımages = { domates.Image, salatalik.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };
           
            //Organik Atık Kutumuz için fotoğrafın domates veya salatalık olduğu şartını tanımlıyoruz.
            if (ımages[rastgele] == domates.Image)
            {
                //Eğer fotoğrafımız domates fotoğrafı ise puan label'ına hacmini yazdırıyoruz.
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + domates.Hacim;
                label2.Text = (labelDeger).ToString();
                //PrograssBar'ımızı domatesin hacmi kadar ilerletiyoruz.
                progressBar1.Step = domates.Hacim;
                progressBar1.PerformStep();
                //Listboxa adını ve hacmini yazdırıyoruz.
                listBox1.Items.Add("Domates (150)");
            }
            else if (ımages[rastgele] == salatalik.Image)
            {
                //Eğer fotoğrafımız salatalık fotoğrafı ise puan label'ına hacmini yazdırıyoruz.
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + salatalik.Hacim;
                label2.Text = (labelDeger).ToString();
                //PrograssBar'ımızı salatalığın hacmi kadar ilerletiyoruz.
                progressBar1.Step = salatalik.Hacim;
                progressBar1.PerformStep();
                //Listboxa adını ve hacmini yazdırıyoruz.
                listBox1.Items.Add("Salatalık (120)");
            }
            //Random fotoğraf oluşturup picturebox'a atıyoruz.
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            //Form class'ının içerisine yazdığımız metotları burada çağırıyoruz.
            buttonKontrol();
            buttonKontrol1();
            //Kutunun kapasitesi dolunca buttonun kapanmasını sağlıyor.
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        //Timer'ımızın kaçtan geriye düşeceğini belirtmek için değişkene atıyoruz.
        int sayi = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer'ımızı çalıştırıp label'a yazdırıyoruz.
            if (sayi >= 0)
            {
                timer1.Interval = 1000;
                timer1.Enabled = true;
                int sayac = sayi--;
                label1.Text = sayac.ToString();
            }
            //Süre bittiğinde buttonların pasifleşmesini sağlıyoruz.
            else 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button11_Click(object sender, EventArgs e)
        {
            //Yeni oyun buttonuna tıklandığında puanın sıfırlanmasını sağlıyoruz.
            label2.Text = 0.ToString();
            //Timer'ın en baştan başlamasını sağlıyoruz.
            sayi = 60;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            //ProgressBar'larımızın değerlerinin sıfırlamasını sağlıyoruz.
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            //Listbox'larımızın temizlenmesini sağlıyoruz.
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            //Random fotoğrafların picturebox'umuza çıkmasını sağlıyoruz.
            Random rnd = new Random();
            Image[] ımages = { domates.Image, salatalik.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            //Sınıfımızın içindeki metodu çağırıyoruz.
            buttonKontrol();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //Boşalt buttonuna basıldığında progressBarımızın boşaltılmasını, listboxumuzun temizlenmesini sağlıyoruz.
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            //Süremizin 3 saniye artmasını sağlıyoruz.
            sayi = sayi + 3;
            button2.Enabled = false;
        }
        
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Button 1'deki işlemlerin aynısını burada da yaptırıyoruz.
            Image[] ımages = { domates.Image, salatalik.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };
            progressBar3.Maximum = kagitAtikKutusu.Kapasite;
            progressBar3.Minimum = 0;

            if (ımages[rastgele] == dergi.Image)
            {
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + dergi.Hacim;
                label2.Text = (labelDeger).ToString();
                progressBar3.Step = dergi.Hacim;
                progressBar3.PerformStep();
                listBox2.Items.Add("Dergi (200)");
            }
            else if (ımages[rastgele] == gazete.Image)
            {
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + gazete.Hacim;
                label2.Text = (labelDeger).ToString();
                progressBar3.Step = gazete.Hacim;
                progressBar3.PerformStep();
                listBox2.Items.Add("Gazete (250)");
            }
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            buttonKontrol();
            buttonKontrol1();
            if (progressBar3.Value >= kagitAtikKutusu.Kapasite || kagitAtikKutusu.Kapasite - progressBar3.Value < dergi.Hacim || kagitAtikKutusu.Kapasite - progressBar3.Value < gazete.Hacim)
            {
                button3.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Button 1'deki işlemlerin aynısını burada da yaptırıyoruz.
            Image[] ımages = { domates.Image, salatalik.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };
            progressBar2.Maximum = camAtikKutusu.Kapasite;
            progressBar2.Minimum = 0;
            if (ımages[rastgele] == bardak.Image)
            {
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + bardak.Hacim;
                label2.Text = (labelDeger).ToString();
                progressBar2.Step = bardak.Hacim;
                progressBar2.PerformStep();
                listBox3.Items.Add("Bardak (250)");
            }
            else if (ımages[rastgele] == camsise.Image)
            {
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + camsise.Hacim;
                label2.Text = (labelDeger).ToString();
                progressBar2.Step = camsise.Hacim;
                progressBar2.PerformStep();
                listBox3.Items.Add("Cam Şişe (600)");
            }
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            buttonKontrol();
            buttonKontrol1();
            if (progressBar2.Value >= camAtikKutusu.Kapasite || camAtikKutusu.Kapasite - progressBar2.Value < bardak.Hacim || camAtikKutusu.Kapasite - progressBar2.Value < camsise.Hacim)
            {
                button5.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Button 1'deki işlemlerin aynısını burada da yaptırıyoruz.
            Image[] ımages = { domates.Image, salatalik.Image, bardak.Image, camsise.Image, salca.Image, kola.Image, dergi.Image, gazete.Image };
            progressBar4.Maximum = metalAtikKutusu.Kapasite;
            progressBar4.Minimum = 0;

            if (ımages[rastgele] == salca.Image)
            {
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + salca.Hacim;
                label2.Text = (labelDeger).ToString();
                progressBar4.Step = salca.Hacim;
                progressBar4.PerformStep();
                listBox4.Items.Add("Salça Kutusu (550)");
            }
            else if (ımages[rastgele] == kola.Image)
            {
                label2.Text = labelDeger.ToString();
                labelDeger = labelDeger + kola.Hacim;
                label2.Text = (labelDeger).ToString();
                progressBar4.Step = kola.Hacim;
                progressBar4.PerformStep();
                listBox4.Items.Add("Kola Kutusu (350)");
            }
            Random rnd = new Random();
            rastgele = rnd.Next(0, ımages.Length);
            pictureBox1.Image = ımages[rastgele];
            buttonKontrol();
            buttonKontrol1();
            if (progressBar4.Value >= metalAtikKutusu.Kapasite || metalAtikKutusu.Kapasite - progressBar4.Value < salca.Hacim || metalAtikKutusu.Kapasite - progressBar4.Value < kola.Hacim)
            {
                button7.Enabled = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Çıkış buttonuna basıldığında oyundan çıkışın yapılmasını sağlıyoruz.
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            //Kutuya özgü puanın puanların arasına eklenmesini sağlıyoruz.
            label2.Text = labelDeger.ToString();
            labelDeger = labelDeger + kagitAtikKutusu.BosaltmaPuani;
            label2.Text = (labelDeger).ToString();

            //Button 2'deki işlemlerin aynısını burada da yapıyoruz.
            progressBar3.Value = 0;
            listBox2.Items.Clear();
            sayi = sayi + 3;
            button4.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            //Kutuya özgü puanın puanların arasına eklenmesini sağlıyoruz.
            label2.Text = labelDeger.ToString();
            labelDeger = labelDeger + camAtikKutusu.BosaltmaPuani;
            label2.Text = (labelDeger).ToString();

            //Button 2'deki işlemlerin aynısını burada da yapıyoruz.
            progressBar2.Value = 0;
            listBox3.Items.Clear();
            sayi = sayi + 3;
            button6.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            //Kutuya özgü puanın puanların arasına eklenmesini sağlıyoruz.
            label2.Text = labelDeger.ToString();
            labelDeger = labelDeger + metalAtikKutusu.BosaltmaPuani;
            label2.Text = (labelDeger).ToString();

            //Button 2'deki işlemlerin aynısını burada da yapıyoruz.
            progressBar4.Value = 0;
            listBox4.Items.Clear();
            sayi = sayi + 3;
            button8.Enabled = false;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
    //Interface'lerimizi kullanmak için classlarımızı oluşturup form kısmında kullanılacak hale getirdik.
    public interface IAtik
    {
        int Hacim { get; }
        System.Drawing.Image Image { get; }
    }
    class Atik : IAtik
    {
        private int _hacim;
        public int Hacim
        {
            get { return _hacim; }
        }

        private Image _resim;
        public Image Image
        {
            get { return _resim; }
        }

        public Atik(int hacim, Image ımage)
        {
            _hacim = hacim;
            _resim = ımage;
        }
    }
    public interface IDolabilen
    {
        int Kapasite { get; set; }
        int DoluHacim { get; }
        int DolulukOrani { get; }
    }
    public interface IAtikKutusu : IDolabilen
    {
        int BosaltmaPuani { get; }
        bool Ekle();
        bool Bosalt();
    }
    class AtikKutulari : IAtikKutusu
    {
        int _bosaltmaPuani;
        public int BosaltmaPuani
        {
            get {return _bosaltmaPuani; }
        }

        int _kapasite;
        public int Kapasite
        {
            get {return _kapasite; }
            set { _kapasite = value; }
        }

        int _doluHacim;
        public int DoluHacim
        {
            get { return _doluHacim; }
        }

        int _dolulukOrani;
        public int DolulukOrani
        {
            get { return _dolulukOrani; }
            set { _dolulukOrani = value; }
        }
        public AtikKutulari(int bosaltmaPuani, int kapasite, int doluHacim, int dolulukOrani)
        {
            _bosaltmaPuani = bosaltmaPuani;
            _kapasite = kapasite;
            _doluHacim = doluHacim;
            _dolulukOrani = dolulukOrani;
        }
        
        public bool Bosalt()
        {
            throw new NotImplementedException();
        }

        public bool Ekle()
        {
            throw new NotImplementedException();
        }
    }
}
