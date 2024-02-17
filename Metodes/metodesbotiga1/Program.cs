namespace metodesbotiga1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayProductes
            string[,] productes = new string[2, 10];
            int nElem = 4;
        }
        static void PreguntarProducte(string[,] productes, ref int nElem)
        {
            string producte = "", preu = "";
            Console.Write("Quin es el producte que vols afegir? ");
            producte = Convert.ToString(Console.ReadLine());
            Console.Write("Quin es el preu que vols posar-li? ");
            preu = Convert.ToString(Console.ReadLine());
            AfegirProducte(producte, preu, productes, ref nElem);
        }
        static void AfegirProducte(string producte, string preu, string[,] productes, ref int nElem)
        {
            string resposta = "";
            int numB = 0, tipus = 0, posicio = 0;
            if (!ComprovarEspai(productes))
            {
                Console.WriteLine("No hi ha més espais per afegir productes, vols afegir més? ");
                resposta = Convert.ToString(Console.ReadLine());
                resposta = resposta.ToUpper();
                if (resposta == "SI")
                {
                    Console.WriteLine("Quants més vols afegir? ");
                    numB = Convert.ToInt32(Console.ReadLine());
                    AmpliarTenda(productes, numB);
                    AfegirProducte(producte, preu, productes, ref nElem);
                }
                else
                    //Retorn al Menu
            }
            else
            {
                posicio = TrobarPosicioVuida(productes, tipus);
                productes[0, posicio] = producte;
                productes[1, posicio] = preu;
                nElem++;
            }

        }
        static bool ComprovarEspai(string[,] productes)
        {
            bool validacio = false;
            for (int i = 0; i < productes.GetLength(0); i++)
            {
                if (productes[0, i] == "")
                    validacio = true;
            }
            return validacio;
        }
        static void AmpliarTenda(string[,] productes, int num)
        {
            string[,] aux = new string[productes.GetLength(0), productes.GetLength(1) + num];
            for (int i = 0; i < productes.GetLength(1); i++)
                aux[0, i] = productes[0, i];
            productes = aux;
        }
        static int TrobarPosicioVuida(string[,] productes, int tipus)
        {
            int posicio = 0;
            bool trobada = false;
            if (tipus == 1)
            {
                for (int i = 0; i < productes.GetLength(1) && !trobada; i++)
                {
                    if (productes[0, i] == "")
                    {
                        trobada = true;
                        posicio = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < productes.GetLength(1) && !trobada; i++)
                {
                    if (productes[1, i] == "")
                    {
                        trobada = true;
                        posicio = i;
                    }
                }
            }
            return posicio;
        }
        static void ModificarPreu(string producte, double preu, string[,] productes)
        {
            int posicio = TrobarPosProducte(producte, productes);
            string preuN = "";
            preuN = preu.ToString();
            productes[1, posicio] = preuN;
        }
        static int TrobarPosProducte(string producte, string[,] productes)
        {
            bool trobat = false;
            int posicio = 0;
            for(int i = 0; i < productes.GetLength(1) && !trobat; i++)
            {
                if (producte == productes[0, i])
                {
                    posicio = i;
                    trobat = true;
                }       
            }
            return posicio;
        }
        static void ModificarProducte(string producteantic, string[,] productes, string productenou, int nElem)
        {
            bool trobat = false;
            for (int i = 0; i < nElem && !trobat; i++)
            {
                if (productes[0, i] == producteantic)
                {
                    productes[0, i] = productenou;
                    trobat = true;
                }
            }
        }
    }

}
