using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curzi.lorenzo.Gatto._4H.Models
{
    class Punto
    {
        //dichiarazione dei field privati
        int _x; //attrivuto che indica la x nel piano cartesiano
        int _y; //attrivuto che indica la y nel piano cartesiano


        //------------------------------------------------------------
        //Property che consentono di accedere agli attributi _x e _y
        public int X
        {
            get
            {
                return _x;
            }

            set

            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set

            {
                _y = value;
            }
        }
        //------------------------------------------------------------
        //costruttore di default
        public Punto()
        {

        }

        //------------------------------------------------------------
        //costruttore standard
        public Punto(int x, int y) 
        {
            X = x;
            Y = y;
        }

        //-----------------------------------------------------------
        //costruttore che riceve una stringa x,y
        //esso ricava da questa stringa i punti x e y che poi verrano inseriti all'interno dei field _x e _y
        public Punto(string punto)
        {
            string[] punti = punto.Split(','); //splitta i valori usando il simbolo ','
            X = Convert.ToInt32(punti[0]); // e li assegna alle porperty di _x e _y
            Y = Convert.ToInt32(punti[1]);
        }
    }
}
