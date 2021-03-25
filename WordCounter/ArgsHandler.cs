using System.Linq;

namespace WordCounter
{
    public class ArgsHandler
    {
        private const string indexOption = "-index";
        private const string dictionaryOption = "-dictionary";

        public CommandLineArgument ReadArgs(string[] args)
        {
            return args.Length == 0
                ? new CommandLineArgument(string.Empty, false, string.Empty)
                : new CommandLineArgument(
                GetFilePath(args),
                GetIndexOption(args),
                GetDictionaryFilePath(args));
        }

        private string GetFilePath(string[] args)
        {
            return args.FirstOrDefault(a => !IsOption(a)) ?? string.Empty;
        }

        private bool GetIndexOption(string[] args)
        {
            return args.Contains(indexOption);
        }

        private string GetDictionaryFilePath(string[] args)
        {
            return args.FirstOrDefault(a => a.StartsWith(dictionaryOption))?.Split('=')[1] ?? string.Empty;
        }

        private bool IsOption(string argument)
        {
            return argument.StartsWith('-');
        }
    }
}
