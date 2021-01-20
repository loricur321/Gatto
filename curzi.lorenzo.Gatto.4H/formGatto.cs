using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using curzi.lorenzo.Gatto._4H.Models;

namespace curzi.lorenzo.Gatto._4H
{
    public partial class formGatto : Form
    {

        // foglio di quaderno 20 cm x 30 cm
        const int LATO_X = 200;
        const int LATO_Y = 300;

        const int MARGINE_SINISTRO = 100;
        const int MARGINE_DESTRO = 100;
        const int MARGINE_SUPERIORE = 100;
        const int MARGINE_INFERIORE = 100;


        const int LATO_X_FORM = (MARGINE_SINISTRO + LATO_X + MARGINE_DESTRO);
        const int LATO_Y_FORM = (MARGINE_SUPERIORE + LATO_Y + MARGINE_INFERIORE);

        public formGatto()
        {
            InitializeComponent();

            // blocco il form alle dimensioni fissate (okkio!! tiene conto anche della banda superiore e laterale)
            this.MinimumSize = new Size(LATO_X_FORM, LATO_Y_FORM);
            this.MaximumSize = new Size(LATO_X_FORM, LATO_Y_FORM);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics dc = this.CreateGraphics();
            Pen BluePen = new Pen(Color.Blue, 1); //creo una penna di colore blu

            //disegno il rettangolo che poi conterrà la figura
            dc.DrawRectangle(BluePen, MARGINE_SINISTRO + 0, MARGINE_SUPERIORE + 0, LATO_X, LATO_Y);

            
            //inizlializzo la lettura del file
            StreamReader sr = new StreamReader(@"Punti.csv");
             
            int lenght = LunghezzaFile(); //e tramite il metodo LunghezzaFile calcola la sua lunghezza

            Punto[] gatto = new Punto[lenght]; //dichiaro il vettore di punti

            string riga = sr.ReadLine(); //inizializzo una variabile di supporto che utilizzerò poi per salvare le coordinate all'interno del vettore punti
            for(int i = 0; i < lenght; i++)
            {
                riga = sr.ReadLine(); //leggo la riga 
                gatto[i] = new Punto(riga); // e salvo le coordinate all'interno del vettore
            }
            
            sr.Close(); //chiudo la lettura del file

            //stampa del disegno
            for (int i = 0; i < gatto.Length; i++)
            {
                int j = i + 1;
                if (j == gatto.Length)
                    j = 0;

                dc.DrawLine(BluePen, XForm(gatto[i].X), YForm(gatto[i].Y), XForm(gatto[j].X), YForm(gatto[j].Y));
            }
        }


        //tramite questo metodo adatto la coordinata X per fare in modo che rientri nel rettangolo disegnato in precdenza
        private int XForm(int x) 
        {
            return x + MARGINE_SINISTRO;
        }

        //tramite questo metodo adatto la coordinata Y per fare in modo che rientri nel rettangolo disegnato in precdenza
        private int YForm(int y)
        {
            return (MARGINE_SUPERIORE + LATO_Y) - y ;
        }


        //metodo che calcola la lungheza del file Punti.csv
        public int LunghezzaFile()
        {
            StreamReader sr = new StreamReader(@"Punti.csv");  //inizializzo la lettura del file Punti.csv
            int k = 0; //contatore con cui calcolerò la lunghezza del file

            string a = sr.ReadLine(); //tolgo la prima riga dal file csv

            while(sr.ReadLine() != null)
            {
                k++; //aggiorno la variabile a ogni riga del file
            }

            sr.Close(); //chiudo la lettura del file
            return k;
        }

    }
}
