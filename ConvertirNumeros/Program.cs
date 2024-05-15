Inicio:
    Console.WriteLine("Hola");

    Console.WriteLine("Ingresar un Numero Entero: entre -9999 y 9999");
    int numero = Convert.ToInt16(Console.ReadLine());
    // Int para regresar al inicio 
    int regre;
        

    Console.WriteLine(NumberToString(numero));
    Console.WriteLine();
    Console.WriteLine("Volver a Ingresar numero 1 = si 0 = no");
    regre = Convert.ToInt16(Console.ReadLine());

if (regre==1 )
{
    goto Inicio;
}

else return;

 string NumberToString(int entero)
{

    string[] unidades = new string[] {
        "cero", "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez",
        "once", "doce", "trece", "catorce", "quince", "dieciseis", "diecisiete", "dieciocho", "diecinueve", "veinte" };
    string[] decenas = new string[] {
        "cero", "diez", "veinti", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa", "cien" };
    string[] centenas = new string[] {
        "cero", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos",
        "seiscientos", "setecientos", "ochecientos", "novecientos", "mil" };

    string numeroConLetras = string.Empty;

    bool isMinus = false;

    if (entero < 0)
    {
        isMinus = true;
        entero = Math.Abs(numero);
        
    }

    // Millones
    if (entero / 1_000_000 > 0)
    {
        string textoMillones;
        if (entero / 1_000_000 == 1)
        {
            textoMillones = "millón";
        }
        else
        {
            textoMillones = "millones";
        }

        numeroConLetras = NumberToString(entero / 1_000_000) + " " + textoMillones;
        entero %= 1_000_000;

    }

    // Miles
    if (entero / 1_000 > 0)
    {
        string espacio = numeroConLetras.Length > 0 ? " " : "";
        if (entero / 1_000 == 1)
        {
            numeroConLetras += espacio + centenas[10];
        }
        else
        {
            numeroConLetras += espacio + NumberToString(entero / 1_000) + " " + centenas[10];
        }
        entero %= 1_000;
    }

    // Centenas
    if (entero / 100 > 0)
    {
        string espacio = numeroConLetras.Length > 0 ? " " : "";
        if (entero / 100 == 1 && entero % 100 == 0)
        {
            numeroConLetras += espacio + decenas[10];
        }
        else
        {
            numeroConLetras += espacio + centenas[entero / 100];
        }
        entero %= 100;
    }

    // =< 20
    if (entero <= 20)
    {
        if (entero == 1)
        {
            numeroConLetras = "uno";
        }
        if (entero > 1)
        {
            string espacio = (numeroConLetras.Length > 0) ? " " : "";
            numeroConLetras += espacio + unidades[entero];
        }
    }
    else
    {
        // Decenas
        string espacio = numeroConLetras.Length > 0 ? " " : "";
        if (entero / 10 == 2)
        {
            numeroConLetras += espacio + decenas[entero / 10] + NumberToString(entero % 20);
        }
        else if (entero % 10 == 0)
        {
            numeroConLetras += espacio + decenas[entero / 10];
        }
        else
        {
            numeroConLetras += espacio + decenas[entero / 10] + " y " + NumberToString(entero % 10);
        }
    }

    // 0
    if (string.IsNullOrWhiteSpace(numeroConLetras))
    {
        numeroConLetras = "cero";
    }

    return isMinus ? "Menos " + numeroConLetras: numeroConLetras;
}