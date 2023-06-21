using System;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.IO;
using System.Globalization;

namespace Geisterspiel
{
    internal class Geisterspiel
    {

        private const string RekordDatei = "record.txt";

        public static void Main()
        {
            bool schleife;

            do
            {
                Console.Clear();

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
                    "Du hast nichts bei dir, doch als du in deiner Hosentasche kramst findest du einen roten Zettel...\n";

                int verzögerung = 65;                               // Verzögerung in Millisekunden zwischen den Zeichen

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

                Console.ForegroundColor = ConsoleColor.DarkRed;
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
                                "[_______________________] \n\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PS.: An der Seite hängt ein Schild mit der Aufschrift exit = 'beenden' eingeben!!!\n\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Start ");
                Console.ResetColor();

                Console.ReadKey();

                string eingabe;
                int record = GetRecordFromFile();
                int score = 0;

                Console.Clear();
                    
                    schleife = true;

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    Console.WriteLine("Wähle deinen nächsten Schritt Weise\n" +
                        "es könnte dein letzter sein...\n");

                    Console.WriteLine("\tTüre 1" +
                                      "\t\tTüre 2" +
                                      "\t\tTüre 3");

                    eingabe = Console.ReadLine();

                    if (eingabe == "1" | eingabe == "2" | eingabe == "3")
                    {
                        Random random = new Random();

                        int randomnr = random.Next(1, 4);               //Erstellt einen Randomiser der zwischen 1 und 3 wählt, weil die 4 ausgeschlossen wird.

                        int.TryParse(eingabe, out int i_eingabe);

                        if (i_eingabe == randomnr)
                        {

                            score += 1;

                            Console.WriteLine("Hehe Glück gehabt\n");

                        }

                        else if (i_eingabe != randomnr)
                        {

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("                               ");
                            Console.WriteLine("▒█▀▀█ █░░█ █░░█ █░░█ █░░█ █░░█ \r\n" +
                                              "▒█▀▀▄ █░░█ █▀▀█ █▀▀█ █▀▀█ █▀▀█ \r\n" +
                                              "▒█▄▄█ ░▀▀▀ ▀░░▀ ▀░░▀ ▀░░▀ ▀░░▀ ");
                            Console.WriteLine("                               ");
                            Console.ResetColor();

                            text = "Oh nein\n" +
                                "der Geist hat dich entdeckt...\n";

                            verzögerung = 50;

                            foreach (char c in text)
                            {

                                Console.Write(c);

                                if (Console.KeyAvailable)
                                {
                                    // Eine Taste wurde gedrückt, die Ausgabe wird übersprungen

                                    Console.ReadKey(true);

                                    Console.WriteLine("Oh nein\n" +
                                        "der Geist hat dich entdeckt...\n");

                                    break;
                                }

                                Thread.Sleep(verzögerung);
                            }

                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\r\n░██████╗░░█████╗░███╗░░░███╗███████╗  ░█████╗░██╗░░░██╗███████╗██████╗░\r\n" +
                                                  "██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔══██╗██║░░░██║██╔════╝██╔══██╗\r\n" +
                                                  "██║░░██╗░███████║██╔████╔██║█████╗░░  ██║░░██║╚██╗░██╔╝█████╗░░██████╔╝\r\n" +
                                                  "██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██║░░██║░╚████╔╝░██╔══╝░░██╔══██╗\r\n" +
                                                  "╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ╚█████╔╝░░╚██╔╝░░███████╗██║░░██║\r\n" +
                                                  "░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝\n\n");
                            Console.ResetColor();

                            do
                            {

                                schleife = true;

                                Console.WriteLine("Was willst du tun:\n" +
                                              "\t1. Restart\n" +
                                              "\t2. Übersicht\n\n");

                                eingabe = Console.ReadLine();

                                if (eingabe == "1" | eingabe == "2")
                                {
                                    int.TryParse(eingabe, out i_eingabe);

                                    if (i_eingabe == 1)
                                    {

                                        schleife = true;

                                        Console.Clear();
                                        if (score > record)
                                        {

                                            record = score;
                                            SaveRecordToFile(record);

                                        }

                                    }

                                    else if (i_eingabe == 2)
                                    {

                                        if (score > record)
                                        {

                                            record = score;
                                            SaveRecordToFile(record);

                                            Console.WriteLine("Gratuliere! Du hast einen neuen Rekord aufgestellt: " + record);
                                        }

                                        else
                                        {

                                            Console.WriteLine("Deine erreichten Punkte: " + score + "\n" +
                                                              "Dein Rekord liegt bei:   " + record + "\n\n\n");

                                            Console.WriteLine("-------------------------------------------------------------------");

                                                                                                                                 
                                        }

                                    }

                                }

                                else
                                {

                                    schleife = false;

                                    Console.WriteLine("" + eingabe + " ist eine falsche Eingabe\n" +
                                                      "Versuche es mit '1' oder'2'");

                                }

                            } while (!schleife);


                        }

                    }

                    else if (eingabe == "beenden")
                    {

                        Console.ResetColor();

                        Console.WriteLine("Das Spiel wurde erfolgreich beendet");

                        Environment.Exit(0);

                    }

                    else
                    {

                        Console.ResetColor();

                        Console.WriteLine("" + eingabe + " ist eine falsche Eingabe\n" +
                                          "Versuche es mit einer Zahl zwischen 1 und 3 oder gib 'beenden' ein um das Spiel zu schließen.");

                        Console.ReadKey();

                    }

                    Console.ResetColor();
                                    
            } while (schleife);

        }
        static int GetRecordFromFile()
        {

            string recordFilePath = "record.txt";

            if (File.Exists(recordFilePath))
            {

                string recordText = File.ReadAllText(recordFilePath);

                if (int.TryParse(recordText, out int record))
                {

                    return record;

                }

            }

            return 0;                   // Falls keine Rekorddatei vorhanden ist oder ein Fehler beim Lesen der Datei auftritt

        }

        static void SaveRecordToFile(int record)
        {

            string recordFilePath = "record.txt";

            File.WriteAllText(recordFilePath, record.ToString());

        }

    }
}
