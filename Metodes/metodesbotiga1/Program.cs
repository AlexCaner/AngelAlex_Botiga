namespace metodesbotiga1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayProductes
            string[,] productes = new string[2, 10];
        }
        static void PreguntarProducte()
        {
            string producte = "", preu = "";
            Console.Write("Quin es el producte que vols afegir? ");
            producte = Convert.ToString(Console.ReadLine());
            Console.Write("Quin es el preu que vols posar-li? ");
            preu = Convert.ToString(Console.ReadLine());    

        }
        static void AfegirProducte(string producte, string preu, string[,] productes)
        {
            string resposta = "";
            int numB = 0;
            if (!ComprovarEspai(productes))
            {
                Console.WriteLine("No hi ha més espais per afegir preus, vols afegir més? ");
                resposta = Convert.ToString(Console.ReadLine());
                resposta = resposta.ToUpper();
                if (resposta == "SI")
                {
                    Console.WriteLine("Quants més vols afegir? ");
                    numB = Convert.ToInt32(Console.ReadLine());
                    AmpliarTenda(productes, numB);
                    AfegirProducte(producte, preu, productes);
                }
                else
                    //Retorn al Menu
            }
            else
            {

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
            productes = aux;
        }
        static int TrobarPosicioVuida(string[,] productes)
        {
            bool trobada = false;
            for(int i = 0; i < productes.GetLength(1) && !trobada; i++)
            {
                if (productes[0, i] = "")
                    trobada = true;
            }
        }
    }
}
