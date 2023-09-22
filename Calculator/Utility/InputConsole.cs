namespace Calculator.Utility;

// "static" di fronte a "class" significa che non è consentito creare istanze di questa classe
// mentre sui metodi significa che possono essere chiamati senza bisogno di creare un'istanza della classe
static class InputConsole {

    public static string ChiediString(string messaggio) {
        Console.Write(messaggio);
        string? input = Console.ReadLine();

        // terminale chiuso?
        if (input == null)
            throw new OperationCanceledException();

        return input;
    }

    // Esercizio per il lettore: aggiungere un metodo generico "public static T ChiediValore<T>(string messaggio, Action<string, T?> validatore)"
    // che permette di chiedere un valore e verificare che sia valido tramite un validatore passato dall'esterno.
    // Aggiornare i metodi "ChiediOpzione" e "ChiediDouble" per chiamare "ChiediValore" riducendo la quantità di codice duplicato.

    public static string ChiediOpzione(string messaggio, string[] opzioni) {
        while (true) {
            string input = ChiediString(messaggio);

            if (!opzioni.Contains(input)) {
                Console.WriteLine("Il valore inserito non è valido...");
                continue;
            }

            return input;
        }
    }

    public static double ChiediDouble(string messaggio) {
        while (true) {
            string input = ChiediString(messaggio);

            bool ok = double.TryParse(input, out double valore);
            if (!ok) {
                Console.WriteLine("Il valore inserito non è valido...");
                continue;
            }

            return valore;
        }
    }
}
