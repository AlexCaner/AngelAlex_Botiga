using System.Text.Json;

namespace metodesbotiga1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayProductes
            string[,] productes = new string[2, 1];
            int nElem = 0;
            Switch(productes, ref nElem);
        }
        static void Switch(string[,] productes, ref int nElem)
        {


            string resposta = "NO";
            int aux;
            do
            {
                Console.WriteLine("Que opcion quieres: ");
                aux = Convert.ToInt32(Console.ReadLine());
                switch (aux)
                {
                    case 1:
                        do
                        {
                            int numB;
                            if (!ComprovarEspai(productes))
                            {
                                Console.WriteLine("No hi ha més espais per afegir productes, vols afegir més? ");
                                resposta = Convert.ToString(Console.ReadLine());
                                resposta = resposta.ToUpper();
                                if (resposta == "SI")
                                {
                                    Console.WriteLine("Quants més vols afegir? ");
                                    numB = Convert.ToInt32(Console.ReadLine());
                                    AmpliarTenda(ref productes, numB);
                                }
                            }
                            else
                            {
                                PreguntarProducte(productes, ref nElem);
                                Console.Write("Vols continuar afegint productes? ");
                                resposta = Convert.ToString(Console.ReadLine());
                                resposta = resposta.ToUpper();
                                MostrarArray(productes);
                            }
                        } while (resposta.ToUpper() != "NO");
                        break;
                    case 2:
                        MostrarArray(productes);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            } while (aux != 99);
        }
        static void PreguntarProducte(string[,] productes, ref int nElem)
        {
            string producte, preu;
            Console.Write("Quin es el producte que vols afegir? ");
            producte = Convert.ToString(Console.ReadLine());
            Console.Write("Quin es el preu que vols posar-li? ");
            preu = Convert.ToString(Console.ReadLine());
            AfegirProducte(producte, preu, productes, ref nElem);
        }
        static void AfegirProducte(string producte, string preu, string[,] productes, ref int nElem)
        {
            int posicio;
            {
                posicio = TrobarPosicioVuida(productes);
                productes[0, posicio] = producte;
                productes[1, posicio] = preu;
                nElem++;
            }
        }
        static bool ComprovarEspai(string[,] productes)
        {
            bool validacio = false;
            for (int i = 0; i < productes.GetLength(1); i++)
            {
                if (productes[0, i] == null)
                    validacio = true;
            }
            return validacio;
        }
        static void AmpliarTenda(ref string[,] productes, int num)
        {
            string[,] aux = new string[productes.GetLength(0), productes.GetLength(1) + num];
            for (int i = 0; i < productes.GetLength(1); i++)
            {
                aux[0, i] = productes[0, i];
                aux[1, i] = productes[1, i];
            }
            productes = aux;
        }
        static int TrobarPosicioBuida(string[,] productes)
        {
            int posicio = 0;
            bool trobada = false;

            for (int i = 0; i < productes.GetLength(1) && !trobada; i++)
            {
                if (productes[0, i] == null)
                {
                    posicio = i;
                    trobada = true;
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
        static int TrobarPosProducte(string producte, string[,] productes)
        {
            bool trobat = false;
            int posicio = 0;
            for (int i = 0; i < productes.GetLength(1) && !trobat; i++)
            {
                if (producte == productes[0, i])
                {
                    posicio = i;
                    trobat = true;
                }
            }
            return posicio;
        }
        static void MostrarArray(string[,] productes)
        {
            for (int i = 0; i < productes.GetLength(1); i++)
            {
                Console.WriteLine(productes[0, i]);
                Console.WriteLine(productes[1, i]);
            }
        }
        static void ToString(string[,] productes)
        {

        }
