using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetski_Algoritam
{
    class Program
    {

        public static int BROJ_JEDINKI = 20;   //mora biti parni kad se podijeli s 2
        public static int BROJ_ITERACIJA = 30;
        public static Random rnd = new Random();
        private static int POSTOTAK_KRIZANA = 90;
        private static int POSTOTAK_MUTIRANJA = 5;


        static void Main(string[] args)
        {

                List<Jedinka> generacija = new List<Jedinka>(BROJ_JEDINKI);

                for (int j = 0; j < BROJ_JEDINKI; j++)
                {
                    generacija.Add(new Jedinka(rnd.Next(0, 1023)));
                }

                for (int j = 0; j < BROJ_ITERACIJA; j++)
                {
                 //  Console.WriteLine();
                 //  ispis(generacija);
                   krizajlab6(generacija);
                }

              //  Console.WriteLine();
              //    generacija.Sort((prva, druga) => druga.dobrota.CompareTo(prva.dobrota));
              //  ispis(generacija);

                double zbroj = 0;

                foreach(Jedinka j in generacija)
                {
                zbroj += j.dobrota;
                }

                Console.WriteLine("PROSJEK: " + (zbroj / generacija.Count()));
           

        }

        private static void krizajnormalno(List<Jedinka> generacija)
        {
            for(int i = 0; i < generacija.Count(); i = i+2)
            {
               if(rnd.Next(0,100) < POSTOTAK_KRIZANA)
                {
                    String roditelj11dio, roditelj12dio;
                    String roditelj21dio, roditelj22dio;
                    String djete1, djete2;

                    int cutoff = rnd.Next(0, 10);

                    roditelj11dio = new string(generacija[i].binarniprikaz.ToCharArray(),0, cutoff);
                    roditelj12dio = new string(generacija[i].binarniprikaz.ToCharArray(), cutoff, 10-cutoff);

                    roditelj21dio = new string(generacija[i+1].binarniprikaz.ToCharArray(), 0, cutoff);
                    roditelj22dio = new string(generacija[i+1].binarniprikaz.ToCharArray(), cutoff, 10 - cutoff);

                    // Console.WriteLine(i + " "+ roditelj11dio + " " + roditelj12dio);
                    // Console.WriteLine((i+1) + " " + roditelj21dio + " " + roditelj22dio);

                    djete1 = roditelj11dio + roditelj22dio;
                    djete2 = roditelj21dio + roditelj12dio;

                    //mutiraj

                   if (rnd.Next(0, 100) < POSTOTAK_MUTIRANJA)
                    {

                        StringBuilder djete1mutirano = new StringBuilder(djete1);
                        int bitzamutrianje = rnd.Next(0, 9);
                        if(djete1[bitzamutrianje] == '0')
                        {
                            djete1mutirano[bitzamutrianje] = '1';
                        }
                        else
                        {
                            djete1mutirano[bitzamutrianje] = '0';
                        }

                        djete1 = djete1mutirano.ToString();
                    }


                    if (rnd.Next(0, 100) < POSTOTAK_MUTIRANJA)
                    {

                        StringBuilder djete2mutirano = new StringBuilder(djete2);
                        int bitzamutrianje = rnd.Next(0, 9);
                        if (djete2[bitzamutrianje] == '0')
                        {
                            djete2mutirano[bitzamutrianje] = '1';
                        }
                        else
                        {
                            djete2mutirano[bitzamutrianje] = '0';
                        }

                        djete2 = djete2mutirano.ToString();
                    }

                    generacija[i].promjenijedinku(djete1);
                    generacija[i+1].promjenijedinku(djete2);

                    generacija.OrderBy(a => rnd.Next());
                }

            }

        }

        private static void krizajodbaci(List<Jedinka> generacija)
        {

            generacija.Sort((prva, druga) => druga.dobrota.CompareTo(prva.dobrota));

            for (int i = 0; i < generacija.Count() / 2; i = i + 2)
            {
                if (rnd.Next(0, 100) < POSTOTAK_KRIZANA)
                {
                    String roditelj11dio, roditelj12dio;
                    String roditelj21dio, roditelj22dio;
                    String djete1, djete2;

                    int cutoff = rnd.Next(0, 10);

                    roditelj11dio = new string(generacija[i].binarniprikaz.ToCharArray(), 0, cutoff);
                    roditelj12dio = new string(generacija[i].binarniprikaz.ToCharArray(), cutoff, 10 - cutoff);

                    roditelj21dio = new string(generacija[i + 1].binarniprikaz.ToCharArray(), 0, cutoff);
                    roditelj22dio = new string(generacija[i + 1].binarniprikaz.ToCharArray(), cutoff, 10 - cutoff);

                    // Console.WriteLine(i + " "+ roditelj11dio + " " + roditelj12dio);
                    // Console.WriteLine((i+1) + " " + roditelj21dio + " " + roditelj22dio);

                    djete1 = roditelj11dio + roditelj22dio;
                    djete2 = roditelj21dio + roditelj12dio;

                    //mutiraj

                    if (rnd.Next(0, 100) < POSTOTAK_MUTIRANJA)
                    {

                        StringBuilder djete1mutirano = new StringBuilder(djete1);
                        int bitzamutrianje = rnd.Next(0, 9);
                        if (djete1[bitzamutrianje] == '0')
                        {
                            djete1mutirano[bitzamutrianje] = '1';
                        }
                        else
                        {
                            djete1mutirano[bitzamutrianje] = '0';
                        }

                        djete1 = djete1mutirano.ToString();
                    }


                    if (rnd.Next(0, 100) < POSTOTAK_MUTIRANJA)
                    {

                        StringBuilder djete2mutirano = new StringBuilder(djete2);
                        int bitzamutrianje = rnd.Next(0, 9);
                        if (djete2[bitzamutrianje] == '0')
                        {
                            djete2mutirano[bitzamutrianje] = '1';
                        }
                        else
                        {
                            djete2mutirano[bitzamutrianje] = '0';
                        }

                        djete2 = djete2mutirano.ToString();
                    }

                    generacija[generacija.Count()/2 + i].promjenijedinku(djete1);
                    generacija[generacija.Count()/2 + i+1].promjenijedinku(djete2);


                  generacija.OrderBy(a => rnd.Next());
                }

            }

        }





        private static void krizajlab6(List<Jedinka> generacija)
        {

            foreach(Jedinka j in generacija)
            {
                if(j.elitan == true)
                {
                    j.elitan = false;
                }
            }

            generacija.Sort((druga, prva) => prva.dobrota.CompareTo(druga.dobrota));
            Console.WriteLine();
            generacija[0].elitan = true;

            ispis(generacija);


            int index1;
            int index2;
            do
            {
                index1 = rnd.Next(0, generacija.Count());
                index2 = rnd.Next(0, generacija.Count());
            }
            while (generacija[index1].elitan == true || generacija[index2].elitan == true);

            if (rnd.Next(0, 100) < POSTOTAK_KRIZANA)
                {

                StringBuilder roditelj1, roditelj2;
                StringBuilder djete1;

                    djete1 = new StringBuilder("0000000000" , 10);

                    roditelj1 = new StringBuilder(generacija[index1].binarniprikaz);
                    roditelj2 = new StringBuilder(generacija[index2].binarniprikaz);


                    for (int j = 0; j < 10; j++)
                    {
                        if (roditelj1[j].Equals(roditelj2[j]))
                        {
                            djete1[j] = roditelj1[j];
                        }
                        else if(rnd.Next(0, 101) < 50)
                        {
                            djete1[j] = roditelj1[j];
                        }

                        else
                        {
                            djete1[j] = roditelj2[j];
                        }

                    }

                    //mutiraj

                    if (rnd.Next(0, 100) < POSTOTAK_MUTIRANJA)
                    {

                        StringBuilder djete1mutirano = djete1;
                        int bitzamutrianje = rnd.Next(0, 9);
                        if (djete1[bitzamutrianje] == '0')
                        {
                            djete1mutirano[bitzamutrianje] = '1';
                        }
                        else
                        {
                            djete1mutirano[bitzamutrianje] = '0';
                        }

                    }

                    generacija[index1].promjenijedinku(djete1.ToString());
 
                }

        }


        private static void ispis(List<Jedinka> lista)
        {
            foreach (Jedinka i in lista)
            {
                Console.WriteLine(i);
            }
        }


    }
}
