
// === CALCULATOR ===
// Chiede all'utente di indicare una figura geometrica da una lista:
// - Cerchio
// - Rettangolo
// - Quadrato
//
// In base alla figura scelta, chiedere le dimensioni opportune:
// - Cerchio: raggio
// - Rettangolo: base, altezza
// - Quadrato: lato
//
// Chiedere cosa calcolare:
// - Area
// - Perimetro
//
// Stampare il risultato.
//
// Note:
// - Fare uso di classi per le figure geometriche
// - Usare un'interfaccia comune IFiguraGeometrica con metodi per calcolare area e perimetro
// - Implementare il quadrato come sottoclasse del rettangolo
// - Gestire input non validi
// - Gestire chiusura del terminale (con CTRL + C) lanciando un'exception
// - Evitare codice duplicato
// ========================

using Calculator.FigureGeometriche;
using Calculator.Utility;

try {
    // chiede una figura geometrica
    string[] nomiFigure = new string[] { "cerchio", "rettangolo", "quadrato" };
    string nomeFigura = InputConsole.ChiediOpzione("Indica una figura geometrica fra cerchio, rettangolo e quadrato: ", nomiFigure);

    // chiede le dimensioni
    IFiguraGeometrica figura;
    switch (nomeFigura) {
        case "cerchio":
            double raggio = InputConsole.ChiediDouble("Raggio: ");
            figura = new Cerchio(raggio);
            break;

        case "rettangolo":
            double larghezza = InputConsole.ChiediDouble("Larghezza: ");
            double altezza = InputConsole.ChiediDouble("Altezza: ");
            figura = new Rettangolo(larghezza, altezza);
            break;

        case "quadrato":
            double lato = InputConsole.ChiediDouble("Lato: ");
            figura = new Quadrato(lato);
            break;

        default:
            // questo codice non dovrebbe mai venire eseguito
            throw new Exception($"Figura sconosciuta: '{nomeFigura}'");
    }

    // chiede cosa calcolare
    string[] nomiCalcolabili = new string[] { "area", "perimetro" };
    string calcolare = InputConsole.ChiediOpzione("Cosa vuoi calcolare fra area e perimetro? ", nomiCalcolabili);

    // calcola
    double valore;
    switch (calcolare) {
        case "area":
            valore = figura.GetArea();
            break;

        case "perimetro":
            valore = figura.GetPerimetro();
            break;

        default:
            // questo codice non dovrebbe mai venire eseguito
            throw new Exception($"Opzione sconosciuta: '{calcolare}'");
    }

    // stampa il risultato
    Console.WriteLine($"Valore {calcolare}: {valore}");
} catch(OperationCanceledException) {
    // NOTA: questo messaggio potrebbe non essere mai stampato in debug,
    // perché CTRL + C termina il processo dopo pochi istanti
    Console.WriteLine("Operazione annullata.");
}
