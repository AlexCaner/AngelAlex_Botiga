using System.Collections.Concurrent;
using System.Data.Common;

class Program
{
    static void Main()
    {
        string[,] productes = new string[2, 3];
        string[,] cistella = new string[4, 30];
        double diners = 0;
        MenuP(productes, cistella, diners);
    }
    // MENU 
    static void MenuP(string[,] productes, string[,] cistella, double diners)
    {
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
                    Switch(opcio, productes, cistella, diners);
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
    static void Switch(int opcio, string[,] productes, string[,] cistella, double diners)
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
                    Console.WriteLine("┌───────────────────────────────────┐");
                    Console.WriteLine("│                LOG                │");
                    Console.WriteLine("└───────────────────────────────────┘");
                    Console.Write("Nom Usuari: ");
                    usuari = IntroduirStr();
                    Console.Write("\nContrasenya: ");
                    contrasenya = IntroduirStr();
                    if (usuari == "admin" && contrasenya == "1234")
                    {
                        correcte = true;
                        MenuAdmin(productes, cistella, diners);
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
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│              DINERS               │");
                Console.WriteLine("└───────────────────────────────────┘");
                Console.WriteLine("Cuants diners tens?");
                diners = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                MenuClient(productes, cistella, diners);
                Console.Clear();
                break;
        }
    }
    // Menu Admin
    static void MenuAdmin(string[,] productes, string[,] cistella, double diners)
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
                    SwitchAd(opcio, productes, cistella, diners);
                    if (opcio == maxim) seguir = false;
                    break;
            }
        }
    }
    //Switch Admin
    static void SwitchAd(int opcio, string[,] productes, string[,] cistella, double diners)
    {
        string producte = "", producteNou = "", resposta;
        int nElem = 4, num = 0;
        double preu = 0;
        bool acabar = false;
        Console.Clear();
        switch (opcio)
        {
            case 1:
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│          AFEGIR PRODUCTE          │");
                Console.WriteLine("└───────────────────────────────────┘");
                while (!acabar)
                {
                    PreguntarProducte(productes, ref nElem, cistella, diners);
                    Console.Write("Has acabat d'afegir productes? ");
                    resposta = Console.ReadLine();
                    resposta = resposta.ToUpper();
                    if (resposta == "SI")
                        acabar = true;
                }
                Console.Clear();
                break;
            case 2:
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│           AFEGIR ESPAIS           │");
                Console.WriteLine("└───────────────────────────────────┘");
                Console.WriteLine("Cuants vols afegir?");
                num = Convert.ToInt32(Console.ReadLine());
                AmpliarTenda(ref productes, num);
                Console.Clear();
                break;
            case 3:
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│           MODIFICAR PREU          │");
                Console.WriteLine("└───────────────────────────────────┘");
                Console.WriteLine("Quin es el producte que vols modificar?");
                producte = Console.ReadLine();
                Console.WriteLine("Indica el nou preu");
                preu = Convert.ToDouble(Console.ReadLine());
                ModificarPreu(producte, preu, productes);
                Console.Clear();
                break;
            case 4:
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│        MODIFICAR PRODUCTE         │");
                Console.WriteLine("└───────────────────────────────────┘");
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
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│             PRODUCTES             │");
                Console.WriteLine("└───────────────────────────────────┘");
                MostrarArray(productes);
                Thread.Sleep(2000);
                break;
            case 8:
                MenuP(productes, cistella, diners);
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
    static void MenuClient(string[,] productes, string[,] cistella, double diners)
    {
        PintarN();
        int opcio = 1, maxim = 5;
        bool seguir = true;
        while (seguir)
        {
            MenuClientGraf(opcio, maxim, diners);
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
                    SwitchClient(opcio, productes, cistella, diners);
                    if (opcio == maxim) seguir = false;
                    break;
            }
        }
    }

    // Interfície Menu Client
    static void MenuClientGraf(int opcio, int maxim, double diners)
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
                    Console.Write(" Cis ");
                    PintarN();
                    Console.Write("    │\n");
                    Console.WriteLine("│┌─────────────────────────────────┐│");
                    break;
                case 2:
                    Console.Write("││");
                    if (i == opcio) Pintar();
                    Console.Write("         Afegir Producte         ");
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
        Console.WriteLine($"Tens {diners} euros");
    }

    // Switch Menu Client
    static void SwitchClient(int opcio, string[,] productes, string[,] cistella, double diners)
    {
        Console.Clear();
       
        switch (opcio)
        {
            case 1:
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine($"      CISTELLA        DINERS: {diners}");
                Console.WriteLine("└───────────────────────────────────┘");
                MostrarArrayClient(cistella);
                CistellaClient(cistella, ref diners, productes);
                break;
            case 2:
                string resposta = "", producte = "";
                bool acabar = false;
                int i, posicio = -1, cantitat;
                
                while (!acabar)
                {
                    Console.WriteLine("─────────────────────────────────────");
                    Console.WriteLine("               CATALEG               ");
                    Console.WriteLine("─────────────────────────────────────");
                    MostrarArray(productes);
                    Console.WriteLine("┌───────────────────────────────────┐");
                    Console.WriteLine("│          AFEGIR PRODUCTE          │");
                    Console.WriteLine("└───────────────────────────────────┘");
                    posicio = -1;
                    i = TrobarPosicioVuida(cistella);
                    while(posicio == -1)
                    {
                        Console.WriteLine("Quin producte vols afegir?");
                        producte = Console.ReadLine();
                        posicio = TrobarPosClient(producte, productes);
                        if (posicio == -1) 
                        {
                            Console.WriteLine("No hi ha ningun producte amb aquell nom");
                        }
                    }
                    Console.WriteLine("Quants vols afegir?");
                    cantitat = Convert.ToInt32(Console.ReadLine());
                    AfegirProd(productes, cistella, i, producte, cantitat, posicio, ref diners);

                    Console.Write("Has acabat d'afegir productes? ");
                    resposta = Console.ReadLine();
                    resposta = resposta.ToUpper();
                    if (resposta == "SI")
                        acabar = true;
                    Console.Clear();
                }
                Console.Clear();
                break;
            case 3:
                break;
            case 4:
                Console.WriteLine("┌───────────────────────────────────┐");
                Console.WriteLine("│               TIQUET              │");
                Console.WriteLine("└───────────────────────────────────┘");
                MostrarArrayClient(cistella);
                Console.WriteLine("Total = " + TotalPreu(cistella));
                Thread.Sleep(5000);
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
    static void PreguntarProducte(string[,] productes, ref int nElem, string[,] cistella, double diners)
    {
        string producte = "", preu = "";
        Console.Write("Quin es el producte que vols afegir? ");
        producte = Convert.ToString(Console.ReadLine());
        Console.Write("Quin es el preu que vols posar-li? ");
        preu = Convert.ToString(Console.ReadLine());
        AfegirProducte(producte, preu, productes, ref nElem, cistella, diners);
    }
    static void AfegirProducte(string producte, string preu, string[,] productes, ref int nElem, string[,] cistella, double diners)
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
                AmpliarTenda(ref productes, numB);
                PreguntarProducte(productes, ref nElem, cistella, diners);
            }
            else
            {
                MenuAdmin(productes, cistella, diners);
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
    static void ModificarProducte(string producte, string[,] productes, string productenou, int nElem)
    {
        bool trobat = false;
        for (int i = 0; i < nElem && !trobat; i++)
        {
            if (productes[0, i] == producte)
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
            Console.Write(productes[0, i]);
            Console.Write(" " + productes[1, i] + "\n");
        }
    }
    static void MostrarArrayClient(string[,] cistella)
    {
        for (int i = 0; i < cistella.GetLength(1); i++)
        {
            if (cistella[2, i] != null ) { 
            Console.Write("Producte: " + cistella[0, i]);
            Console.Write("   Preu unitari: " + cistella[1, i]);
            Console.Write("   Unitats: " + cistella[2, i]);
            Console.Write("   Total: " + cistella[3, i] + "\n");
            }
        }
    }
    static double TotalPreu(string[,] cistella)
    {
        double total = 0, prod = 0;
        for (int i = 0; i < cistella.GetLength(1); i++)
        {
            if (cistella[2, i] != null)
            {
                prod = Convert.ToDouble(cistella[3, i]);
                total = total + prod;
            }
        }
        return total;
    }
    static void AfegirProd(string[,] productes, string[,] cistella, int i, string producte, int cantitat, int posicio, ref double diners)
    {
        double preuU = Convert.ToDouble(productes[1, posicio]);
        if (preuU * cantitat + TotalPreu(cistella) > diners)
        {
            Console.WriteLine("No tens suficients diners!");
        }
        else
        {
            cistella[0, i] = productes[0, posicio];
            cistella[1, i] = productes[1, posicio];
            cistella[2, i] = Convert.ToString(cantitat);
            cistella[3, i] = Convert.ToString(preuU * cantitat);
        }
    }
    static int TrobarPosClient(string producte, string[,] productes)
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
        if (trobat) return posicio;
        else return -1;
    }
    static void CistellaClient(string[,] cistella, ref double diners, string[,] productes)
    {
        string comprar;
        Console.WriteLine("Vols comprar ho que tens a la cistella?");
        comprar = Console.ReadLine();
        comprar = comprar.ToUpper();
        if (comprar == "SI")
        {
            diners = diners - TotalPreu(cistella);
            for (int i = 0; i < cistella.GetLength(0) && cistella[0, i] != null; i++)
            {
                cistella[0, i] = null;
                cistella[1, i] = null;
                cistella[2, i] = null;
                cistella[3, i] = null;
            }
        }
        else MenuClient(productes, cistella, diners);
    }
}
