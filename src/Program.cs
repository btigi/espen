using ii.Espen;
using ii.Espen.Model;
using ii.Espen.Processor;
using Newtonsoft.Json;

//args = new string[3];
//args[0] = @"D:\data\bg";
//args[1] = @"Meetings_Alumu_in_GoD.dia";
//args[2] = @"html";

if (args.Length < 3)
{
    Console.WriteLine("Expected usage");
    Console.WriteLine("  espen unpacked_data_directory filename.dia processor");
    Console.WriteLine("");
    Console.WriteLine("filename.dia is assumed to be /data/dialogs");
    Console.WriteLine("processor must be html or console");
    Console.WriteLine("Referenced text is read from /data/languages/en");
    return;
}

var unpackedDataPath = args[0];
var diaFilename = args[1];
var processorType = args[2];

var diaPath = @$"{unpackedDataPath}\data\dialogs\{diaFilename}";

var dialogContent = File.ReadAllText(diaPath);
var dialog = JsonConvert.DeserializeObject<DialogRoot>(dialogContent);

var dialogPath = $@"{unpackedDataPath}\data\languages\en\DIA_{dialog.Id}.txt";
var textContent = File.ReadAllText(dialogPath);
var text = JsonConvert.DeserializeObject<TextRoot>(textContent);

IProcessor processor = null;
switch (processorType)
{
    case "html":
        processor = new HtmlProcessor();
        break;
    case "console":
        processor = new ConsoleProcessor();
        break;
    default:
        Console.WriteLine("Unknown processor type");
        break;
}

var dialogHandler = new DialogHandler();
dialogHandler.Go(text, dialog, processor);
