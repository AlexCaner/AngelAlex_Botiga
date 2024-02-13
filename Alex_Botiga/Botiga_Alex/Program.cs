using System.Data.Common;

class Program
{
    // MENU 
    static void Main()
    {
        PintarN();
        int opcio = 1, maxim = 3;
        bool seguir = true; // Si no es la opció sortir, torna a executar el menú
        while (seguir)
        {
            Menu(opcio, maxim); // Cada cop que cliques una tecla, torna a imprimir el menú, pero amb els canvis dins de el metode
            ConsoleKeyInfo tecla = Console.ReadKey(); // Detecta les feltxetes
            Thread.Sleep(1);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow: // Si clica la fletxa de adalt li resta 1 a la ubicació
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.DownArrow: // El mateix al reves
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
                case ConsoleKey.Enter: // Quan li dona a la tecla enter, executa el switch que segons la ubicació on estaba executa la opcio.
                    Switch(opcio);
                    if (opcio == maxim) seguir = false; // En cas de que sigui 9 la opcio, es a dir, sortir, la variable seguir es converteix en fals, així que ja sortira del programa.
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
        for (int i = 0; i < maxim + 1; i++) // Imprimeix un a un les opcions.
        {

            switch (i) // Imprimeix un a un
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
    static void Switch(int opcio)
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
                        MenuAdmin();
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

                MenuClient();
                Console.Clear();
                break;
        }
    }
    // Menu Admin
    static void MenuAdmin()
    {
        PintarN();
        int opcio = 1, maxim = 8;
        bool seguir = true; // Si no es la opció sortir, torna a executar el menú
        while (seguir)
        {
            MenuAd(opcio, maxim); // Cada cop que cliques una tecla, torna a imprimir el menú, pero amb els canvis dins de el metode
            ConsoleKeyInfo tecla = Console.ReadKey(); // Detecta les feltxetes
            Thread.Sleep(1);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow: // Si clica la fletxa de adalt li resta 1 a la ubicació
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.DownArrow: // El mateix al reves
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
                case ConsoleKey.Enter: // Quan li dona a la tecla enter, executa el switch que segons la ubicació on estaba executa la opcio.
                    SwitchAd(opcio);
                    if (opcio == maxim) seguir = false; // En cas de que sigui 9 la opcio, es a dir, sortir, la variable seguir es converteix en fals, així que ja sortira del programa.
                    break;
            }
        }
    }
    //Switch Admin
    static void SwitchAd(int opcio)
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
                break;
            case 6:
                break;
            case 7:
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
        for (int i = 0; i < maxim + 3; i++) // Imprimeix un a un les opcions.
        {

            switch (i) // Imprimeix un a un
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
                    Console.Write("              Mostrar            ");
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
    static void MenuClient()
    {
        PintarN();
        int opcio = 1, maxim = 5;
        bool seguir = true; // Si no es la opció sortir, torna a executar el menú
        while (seguir)
        {
            MenuClient(opcio, maxim); // Cada cop que cliques una tecla, torna a imprimir el menú, pero amb els canvis dins de el metode
            ConsoleKeyInfo tecla = Console.ReadKey(); // Detecta les feltxetes
            Thread.Sleep(1);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow: // Si clica la fletxa de adalt li resta 1 a la ubicació
                    if (opcio > 1)
                    {
                        opcio = opcio - 1;
                    }
                    else opcio = maxim;
                    break;
                case ConsoleKey.DownArrow: // El mateix al reves
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
                case ConsoleKey.Enter: // Quan li dona a la tecla enter, executa el switch que segons la ubicació on estaba executa la opcio.
                    SwitchClient(opcio);
                    if (opcio == maxim) seguir = false; // En cas de que sigui 9 la opcio, es a dir, sortir, la variable seguir es converteix en fals, així que ja sortira del programa.
                    break;
            }
        }
    }

    // Interfície Menu Client
    static void MenuClient(int opcio, int maxim)
    {
        Console.Clear();
        PintarN();
        Console.WriteLine("┌───────────────────────────────────┐");
        Console.WriteLine("│               BOTIGA              │");
        Console.WriteLine("│┌─────────────────────────────────┐│");
        for (int i = 0; i < maxim + 3; i++) // Imprimeix un a un les opcions.
        {

            switch (i) // Imprimeix un a un
            {
                case 1:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("            Productes            ");
                    PintarN();
                    Console.Write("││\n");
                    break;
                case 2:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("            Cistella             ");
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
    static void SwitchClient(int opcio)
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
}