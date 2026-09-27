// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("Start typing, press Enter when you're done:");

var text = new StringBuilder();
var sw = new Stopwatch();

while (true)
{
    // Read one key at a time without echoing it automatically
    var key = Console.ReadKey(intercept: true);

    // Enter means the user is done typing
    if (key.Key == ConsoleKey.Enter)
        break;

    // Start the timer on the first key press
    if (!sw.IsRunning)
        sw.Start();

    // Backspace: remove the last character from the text and the screen
    if (key.Key == ConsoleKey.Backspace)
    {
        if (text.Length > 0)
        {
            text.Length--;
            Console.Write("\b \b");
        }
        continue;
    }

    // Ignore special keys (Shift, Ctrl, arrows, ...)
    if (char.IsControl(key.KeyChar))
        continue;

    text.Append(key.KeyChar);
    Console.Write(key.KeyChar);
}

sw.Stop();
Console.WriteLine();
Console.WriteLine();

int chars = text.Length;
double seconds = sw.Elapsed.TotalSeconds;

if (chars == 0 || seconds <= 0)
{
    Console.WriteLine("You didn't type anything.");
    return;
}

double charsPerSecond = chars / seconds;
double wpm = (chars / 5.0) / (seconds / 60.0); // Standard: 1 word = 5 characters

Console.WriteLine($"Characters typed : {chars}");
Console.WriteLine($"Time taken       : {seconds:F2} seconds");
Console.WriteLine($"Speed            : {charsPerSecond:F2} chars/sec");
Console.WriteLine($"Speed            : {wpm:F1} WPM");