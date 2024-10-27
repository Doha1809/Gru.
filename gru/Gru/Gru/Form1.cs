using System.Windows.Forms;

namespace Gru
{
    public partial class Form1 : Form
    {

        Gruu gru = new Gruu("produttore", "1234", 271, 114, 150,50, 15);
        Stazione stazione = new Stazione("123");
        
        
        public Form1()
        {
            InitializeComponent();
            stazione.Gru_1 = gru; 
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            stazione.alzare();
            if (gru.altezza_braccio > gru.Altezza_max)
            {
                MessageBox.Show("l'operazione non è possibile");
                gru.altezza_braccio = gru.altezza_braccio - gru.Incremento;

            }
            else
            {

                MessageBox.Show($"altezza_braccio è{gru.altezza_braccio}");
                pictureBox6.Location = new Point(339, (int)gru.altezza_braccio);
            }

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

            stazione.abbassare();
            if (gru.altezza_braccio < gru.Altezza_min)
            {
                MessageBox.Show("l'operazione non è possibile");
                gru.altezza_braccio = gru.altezza_braccio+gru.Decremento;

            }
            else
            {

                MessageBox.Show($"altezza_braccio è{gru.altezza_braccio}");
                pictureBox6.Location = new Point(339, (int)gru.altezza_braccio);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            stazione.riportare();
            pictureBox6.Location = new Point(339, 114);
        }
       

    }
}

class Gruu
{

    private double altezza_max;
    public double Altezza_max
    {
        get { return altezza_max; }
    }
    private double altezza_min;
    public double Altezza_min
    {
        get { return altezza_min; }
        set { altezza_min = value; }
    }
    private string produttore;
    public string Produttore
    {
        get { return produttore; }
    }
    private string num_seriale_identif;
    public string Num_seriale_identif
    {
        get { return num_seriale_identif; }
    }
    private double peso_max;
    public double Peso_max
    {
        get { return Peso_max; }
    }
    public double altezza_braccio;
    private double incremento;
    public double Incremento
    {
        get { return incremento; }
    }
    private double decremento;
    public double Decremento
     {
        get { return decremento; }
    }
    public PictureBox pictureBox;
    private double valore;

        public Gruu(string produttore, string num_seriale_identif, double altezza_max, double altezza_min, double peso_max, double incremento, double decremento)
        {
            this.produttore = produttore;
            this.num_seriale_identif = num_seriale_identif;
            this.altezza_max = altezza_max;
            this.altezza_min = altezza_min;
            this.peso_max = peso_max;
            altezza_braccio =this.altezza_min;
            this.incremento = incremento;
            this.decremento = decremento;
        }
   
public void alzare()
        {

            altezza_braccio = altezza_braccio + incremento;
    }
        public void abbassare()
        {
            altezza_braccio = altezza_braccio - decremento;

            if (altezza_braccio < altezza_min)
            {
                MessageBox.Show("l'operazione non è possibile");
            }
            else
            {
                MessageBox.Show($"altezza_braccio è{altezza_braccio}");
                
        }
        }
        public void riportare()
        {
            altezza_braccio = altezza_min;
            MessageBox.Show($"Il braccio della Gru è stato riportato alla posizione di sicurezza, cioè{altezza_braccio}");
        }
}

class Stazione
{
    private Gruu gru_1;
    public Gruu Gru_1
    {
        get { return gru_1; }
        set { gru_1 = value; }
    }

    private string num_seriale_identif;
   
   public  Stazione(string num_seriale_identif)
    {
        this.num_seriale_identif=num_seriale_identif;
        gru_1 = null;
    }
    public void alzare()
    {
        gru_1.alzare();
    }

    public void abbassare()
    {
        gru_1.abbassare();
    }

    public void riportare()
    {
        gru_1.riportare();
    }
}
