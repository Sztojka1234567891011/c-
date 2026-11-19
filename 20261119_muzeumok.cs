using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzeumok
{

    internal class Program
    {
        public static List<belepes> forgalom = new List<belepes>();
        public static string[] helyszinek = new string[]{"Kastély", "Fegyvertár", "Agrárgép Kiállítás", "Vadászmúzeum", "Helytörténeti Gyűjtemény", "Népművészeti Kiállítás","Kastely", "Fegyvertar", "Agrargep Kiallitas", "Vadaszmuzeum", "Helytorteneti Gyujtemeny", "Nepmuveszeti Kiallitas"};
        public static int A, B, C;//jegyárak
        static void feladat1(string filename)
        {
            StreamReader sr = new StreamReader(filename, Encoding.UTF8);
            string[] elsoSor = sr.ReadLine().Split(' ');
            A = int.Parse(elsoSor[0]);
            B = int.Parse(elsoSor[1]);
            C = int.Parse(elsoSor[2]);

            forgalom.Clear();
            while (!sr.EndOfStream)
            { 
                forgalom.Add(new belepes(sr.ReadLine()));

            }

            sr.Close();
        }
        static void feladat2()
        {
            Console.WriteLine($"2. feladat:{forgalom.Count} látogató volt a múzeumokban.");
        }
        static void feladat3()
        {

            Console.WriteLine("3. feladat");
            Console.WriteLine($"\tAz elsőlátogató {forgalom[0].ora:00}" +
                $":{forgalom[0].perc:00}-kor lépett be a {helyszinek[forgalom[0].helyszin]}" +
                $" múzeumban.");

            int utolsoIndex = forgalom.Count - 1;
            Console.WriteLine($"\tAz utolsólátogató {forgalom[utolsoIndex].ora:00}" +
                $":{forgalom[utolsoIndex].perc:00}-kor lépett be a {helyszinek[forgalom[utolsoIndex].helyszin]}" +
                $" múzeumban.");

        }
        static void feladat4()
        {
            Console.WriteLine("4.feladat: Kérek egy jegysorszámot: ");
            string beJA = Console.ReadLine();
            bool nincs = true;
            foreach (var item in forgalom)
            {
                if (item.jegyAzonosito == beJA)
                {
                    Console.WriteLine($"item.ora:0:{item.perc:00}-kor {helyszinek[item.helyszin]}");
                    nincs = false;
                }

            }
            if (nincs) Console.WriteLine("\tNincs ilyen látogató!");
            

          
        }
        static void feladat5()
        {
           int ii = forgalom.Count - 1;
            while (!(forgalom[ii].jegytipus == "-"))
            {
                ii--;
            }
            if((forgalom[ii].ora *100 + forgalom[ii].perc) <1730)
                Console.WriteLine("5.feladat: Jogos az igazgatóság döntése");
            else Console.WriteLine("5.feladat: Nem jogos az igazgatóság döntése");
            Console.WriteLine(ii);

        }
        static void Main(string[] args)
        {
            feladat1("muzdat.txt");
            feladat2();
            feladat3();
            feladat4();
            feladat5();

            Console.ReadKey();
        }
    }
}
---------------------------------------------
  class:
    internal class belepes
    {
        public int ora { get; set; }
        public int perc { get; set; }
        public string jegyAzonosito { get; set; }
        public int helyszin { get; set; }// 0, 1, 2, 3, 4, 5
        public string jegytipus { get; set; }// t, k, tn, kn, -
        public belepes(string line)
        {
            string[] sz = line.Split(' ');
            this.ora = Convert.ToInt32(sz[0].Substring(0, 2));// 16:44
            this.perc = Convert.ToInt32(sz[0].Substring(3, 2));// 16:44
            this.jegyAzonosito = sz[1];//R124087
            this.helyszin = Convert.ToInt32(sz[2]);//1
            this.jegytipus = sz[3];//T
        }
    }
}

házi:
5.feladatot ugy meg csinálni ahogy a kérdés van
