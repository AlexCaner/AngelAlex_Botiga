using System.Collections.Concurrent;
using System.Data.Common;

class Program
{
    // MENU 
    static void Main()
    {
        string[,] productes = new string[2, 3];
        PintarN();
        int opcio = 1, maxim = 3;
        bool seguir = true;
        while (seguir)
        {
            Menu(opcio, maxim);
            ConsoleKeyInfo tecla = Console.ReadKey();
            Thread.Sleep(1);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.DownArrow:
                    if (opcio < maxim)
                    {
                        opcio = opcio + 1;
                    }
                    else opcio = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.RightArrow:
                    if (opcio < maxim)
                    {
                        opcio = opcio + 1;
                    }
                    else opcio = 1;
                    break;
                case ConsoleKey.Enter:
                    Switch(opcio, productes);
                    if (opcio == maxim) seguir = false;
                    break;
            }
        }
    }
    // INTERFÍCIE MENU
    static void Menu(int opcio, int maxim)
    {
        Console.Clear();
        PintarN();
        Console.WriteLine("┌───────────────────────────────────┐");
        Console.WriteLine("│               USUARI              │");
        Console.WriteLine("│┌─────────────────────────────────┐│");
        for (int i = 0; i < maxim + 1; i++)
        {

            switch (i)
            {
                case 1:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("          Administrador          ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 2:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("              Client             ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 3:
                    Console.WriteLine("││                                 ││");
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("              Sortir             ");
                    PintarN();
                    Console.Write("││\n");
                    break;
            }
            Console.ResetColor();
            PintarN();
        }
        Console.WriteLine("│└─────────────────────────────────┘│");
        Console.WriteLine("└───────────────────────────────────┘");
    }
    // BUSCA EL METODE SEGONS EL QUE LI HAGIS DONAT
    static void Switch(int opcio, string[,] productes)
    {
        int intents = 0;
        string usuari = "", contrasenya = "";
        bool correcte = false;
        Console.Clear();
        switch (opcio)
        {
            case 1:
                while (correcte != true)
                {
                    Console.Write("Nom Usuari: ");
                    usuari = IntroduirStr();
                    Console.Write("\nContrasenya: ");
                    contrasenya = IntroduirStr();
                    if (usuari == "admin" && contrasenya == "1234")
                    {
                        correcte = true;
                        MenuAdmin(productes);
                    }
                    else
                    {
                        Console.WriteLine("Les dades son incorrectes");
                        intents++;
                        Console.WriteLine($"Et queden {3 - intents} intents");
                        Thread.Sleep(2000);
                        if (intents >= 3) Main();
                        correcte = false;
                    }
                    Console.Clear();
                }
                break;
            case 2:

                MenuClient(productes);
                Console.Clear();
                break;
        }
    }
    // Menu Admin
    static void MenuAdmin(string[,] productes)
    {
        PintarN();
        int opcio = 1, maxim = 8;
        bool seguir = true;
        while (seguir)
        {
            MenuAd(opcio, maxim);
            ConsoleKeyInfo tecla = Console.ReadKey();
            Thread.Sleep(1);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.DownArrow:
                    if (opcio < maxim)
                    {
                        opcio = opcio + 1;
                    }
                    else opcio = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.RightArrow:
                    if (opcio < maxim)
                    {
                        opcio = opcio + 1;
                    }
                    else opcio = 1;
                    break;
                case ConsoleKey.Enter:
                    SwitchAd(opcio, productes);
                    if (opcio == maxim) seguir = false;
                    break;
            }
        }
    }
    //Switch Admin
    static void SwitchAd(int opcio, string[,] productes)
    {

        string producte = "", producteNou = "";
        int nElem = 4, num = 0;
        double preu = 0;
        Console.Clear();
        switch (opcio)
        {
            case 1:
                while (ComprovarEspai(productes))
                {
                    PreguntarProducte(productes, ref nElem);
                    MostrarArray(productes);
                    Thread.Sleep(2000);
                }
                Console.Clear();
                break;
            case 2:
                Console.WriteLine("Cuants vols afegir?");
                num = Convert.ToInt32(Console.ReadLine());
                AmpliarTenda(productes, num);
                Console.Clear();
                break;
            case 3:
                Console.WriteLine("Quin es el producte que vols modificar?");
                producte = Console.ReadLine();
                Console.WriteLine("Indica el nou preu");
                preu = Convert.ToDouble(Console.ReadLine());
                ModificarPreu(producte, preu, productes);
                Console.Clear();
                break;
            case 4:
                Console.WriteLine("Quin producte vols modificar?");
                producte = Console.ReadLine();
                Console.WriteLine("Quin es el nou?");
                producteNou = Console.ReadLine();
                ModificarProducte(producte, productes, producteNou, nElem);
                Console.Clear();
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                MostrarArray(productes);
                Thread.Sleep(2000);
                break;
            case 8:
                Main();
                break;

        }
    }
    // Interfície Gràfica Admin
    static void MenuAd(int opcio, int maxim)
    {
        Console.Clear();
        PintarN();
        Console.WriteLine("┌───────────────────────────────────┐");
        Console.WriteLine("│               BOTIGA              │");
        Console.WriteLine("│┌─────────────────────────────────┐│");
        for (int i = 0; i < maxim + 3; i++)
        {

            switch (i)
            {
                case 1:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("         Afegir Producte         ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 2:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("         Ampliar Tenda           ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 3:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("         Modificar Preu          ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 4:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("        Modificar Producte       ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 5:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("         Ordenar Producte        ");
                    PintarN();
                    Console.Write("││\n");
                    break; ;
                case 6:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("           Ordenar Preu          ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 7:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("             Mostrar             ");
                    PintarN();
                    Console.Write("││\n");
                    break; ;
                case 8:
                    Console.WriteLine("││                                 ││");
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("           Tencar Sessiò         ");
                    PintarN();
                    Console.Write("││\n");
                    break; ;
            }
            Console.ResetColor();
            PintarN();
        }
        Console.WriteLine("│└─────────────────────────────────┘│");
        Console.WriteLine("└───────────────────────────────────┘");
    }
    // Menú Client
    static void MenuClient(string[,] productes)
    {
        PintarN();
        int opcio = 1, maxim = 5;
        bool seguir = true;
        while (seguir)
        {
            MenuClient(opcio, maxim);
            ConsoleKeyInfo tecla = Console.ReadKey();
            Thread.Sleep(1);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.DownArrow:
                    if (opcio < maxim)
                    {
                        opcio = opcio + 1;
                    }
                    else opcio = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.RightArrow:
                    if (opcio < maxim)
                    {
                        opcio = opcio + 1;
                    }
                    else opcio = 1;
                    break;
                case ConsoleKey.Enter:
                    SwitchClient(opcio, productes);
                    if (opcio == maxim) seguir = false;
                    break;
            }
        }
    }

    // Interfície Menu Client
    static void MenuClient(int opcio, int maxim)
    {
        Console.Clear();
        for (int i = 0; i < maxim + 3; i++)
        {

            switch (i)
            {
                case 1:
                    PintarN();
                    Console.WriteLine("┌───────────────────────────────────┐");
                    Console.Write("│      BOTIGA              ");
                    if (i == opcio) Pintar();
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.Write(" Cis ");
                    PintarN();
                    Console.Write("    │\n");
                    Console.WriteLine("│┌─────────────────────────────────┐│");
                    break;
                case 2:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("            Productes            ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 3:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("         Ordenar Cistella        ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 4:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("          Mostra Tiquet          ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 5:
                    Console.WriteLine("││                                 ││");
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("           Tencar Sessiò         ");
                    PintarN();
                    Console.Write("││\n");
                    break; ;

            }
            Console.ResetColor();
            PintarN();
        }
        Console.WriteLine("│└─────────────────────────────────┘│");
        Console.WriteLine("└───────────────────────────────────┘");
    }

    // Switch Menu Client
    static void SwitchClient(int opcio, string[,] productes)
    {
        Console.Clear();
        switch (opcio)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                Main();
                break;
        }
    }

    // static void Cistella(string[] producrte, double[] quantitat, )
    //{
    //     int i = 0;

    // }

    static void Pintar()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
    }
    static void PintarN()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
    }
    static string IntroduirStr()
    {
        string dada;
        dada = Console.ReadLine();
        return dada;
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
            {
                MenuAdmin(productes);
            }
        }
        else
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
    static void AmpliarTenda(string[,] productes, int num)
    {
        string[,] aux = new string[productes.GetLength(0), productes.GetLength(1) + num];
        for (int i = 0; i < productes.GetLength(1); i++)
            aux[0, i] = productes[0, i];
        productes = aux;
    }
    static int TrobarPosicioVuida(string[,] productes)
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
    static void MostrarArray(string[,] productes)
    {
        for (int i = 0; i < productes.GetLength(1); i++)
        {
            Console.WriteLine(productes[0, i]);
        }
    }
}
