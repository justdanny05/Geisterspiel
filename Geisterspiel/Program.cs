using System;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

namespace Program
{
    internal class Geisterspiel
    {
        public static void Main ()
        {         
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\r\n█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\r\n" +
                              "█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░█████████\r\n" +
                              "█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░░░█░░░░▄▀░░░░█░░▄▀░░░░░░░░░░█░░░░░░▄▀░░░░░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░█░░░░▄▀░░░░█░░▄▀░░░░░░░░░░█░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░█████████░░▄▀░░███████████░░▄▀░░███░░▄▀░░█████████████░░▄▀░░█████░░▄▀░░█████████░░▄▀░░████░░▄▀░░███░░▄▀░░█████████░░▄▀░░██░░▄▀░░███░░▄▀░░███░░▄▀░░█████████░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░█████████░░▄▀░░░░░░░░░░███░░▄▀░░███░░▄▀░░░░░░░░░░█████░░▄▀░░█████░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░███░░▄▀░░░░░░░░░░█░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░██░░░░░░█░░▄▀▄▀▄▀▄▀▄▀░░███░░▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█████░░▄▀░░█████░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░███░░▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░███░░▄▀░░███░░░░░░░░░░▄▀░░█████░░▄▀░░█████░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░░░███░░░░░░░░░░▄▀░░█░░▄▀░░░░░░░░░░███░░▄▀░░███░░▄▀░░░░░░░░░░█░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░██░░▄▀░░█░░▄▀░░███████████░░▄▀░░███████████░░▄▀░░█████░░▄▀░░█████░░▄▀░░█████████░░▄▀░░██░░▄▀░░█████████████░░▄▀░░█░░▄▀░░███████████░░▄▀░░███░░▄▀░░█████████░░▄▀░░█████████\r\n" +
                              "█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░░░░░░░█░░░░▄▀░░░░█░░░░░░░░░░▄▀░░█████░░▄▀░░█████░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░░░░░█░░░░░░░░░░▄▀░░█░░▄▀░░█████████░░░░▄▀░░░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░░░█\r\n" +
                              "█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█████░░▄▀░░█████░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█\r\n" +
                              "█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░█░░░░░░░░░░░░░░█████░░░░░░█████░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░█████████░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█\r\n" +
                              "█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\n");
            Console.ResetColor();

            Console.WriteLine("Tippen Sie eine beliebeige Taste um zu Starten...");
            Console.ReadKey();

            Console.Clear();

            string text = "Du wachst auf und siehst, dass du dich in einem dunkelen Raum, mit jewals drei Türen befindest.\n" +
                "Du hast nicht bei dir, doch als du in deiner Hosentasche kramst findest du einen Zettel...";

            int verzögerung = 75;                               // Verzögerung in Millisekunden zwischen den Zeichen

            foreach (char c in text)
            {

                Console.Write(c);

                if (Console.KeyAvailable)
                {
                    // Eine Taste wurde gedrückt, die Ausgabe wird übersprungen

                    Console.ReadKey(true);               // true, um die Eingabe nicht anzuzeigen
                    Console.WriteLine("Du wachst auf und siehst, dass du dich in einem dunkelen Raum, mit jewals drei Türen befindest.\n" +
                        "Du hast nicht bei dir, doch als du in deiner Hosentasche kramst findest du einen Zettel...");
                    break;
                }

                Thread.Sleep(verzögerung);
            }

            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine(" _______________________ \n" +
                            "[	Zettel:		]\n" +
                            "|  			|\n" +
                            "| Haha du wurdest ent-	|\n" +
                            "| führt hehehe mal	|\n" +
                            "| gucken wieviel Glück	|\n" +
                            "| du hast whuuuuu...	|\n" +
                            "|			|\n" +
                            "| Hinter einer der drei |\n" +
                            "| Türen wartet ein Geist|\n" +
                            "| und willlll dich 	|\n" +
                            "| erschreckennnnnn	|\n" +
                            "|			|\n" +
                            "| Mal gucken wie lange 	|\n" +
                            "| du durchhälst muhahaha|\n" +
                            "|			|\n" +
                            "[_______________________] ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PS.: An der Seite ist ein Schild mit dem Aufdruck exit = 'beenden eingeben' am hängen!!!");
            Console.ResetColor();

            Console.ReadKey();
            bool schleife;
            do
            {
                schleife = true;
                int record = 0;
                Console.Clear();
                Console.WriteLine("Wähle deinen nächsten Schritt Weise\n" +
                    "es könnte dein letzter seinnnn....");
                Console.WriteLine("\tTüre 1" +
                                  "\t\tTüre 2" +
                                  "\t\tTüre 3");
                string eingabe = Console.ReadLine();

                if (eingabe == "1" | eingabe == "2" | eingabe == "3")
                {
                    Random random = new Random();
                    int randomnr = random.Next(1, 4);               //Erstellt einen Randomiser der zwischen 1 und 3 wählt, weil die 4 ausgeschlossen wird.
                    int.TryParse(eingabe, out int i_eingabe);
                    do
                    {
                        if (i_eingabe == randomnr)
                        {
                            record = +1;

                        }
                    } while (schleife);
                }
                else if (eingabe == "beenden") 
                {                    
                    Console.WriteLine("Das Spiel wurde erfolgreich beendet");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("-" + eingabe + " ist eine falsche Eingabe\n" +
                        "Versuche es mit einer Zahl zwischen 1 und 3 oder gib beenden ein um das Spiel zu schließen.");
                    Console.ReadKey();
                }
            } while (schleife);
        }
    }
}