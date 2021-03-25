using System.Linq;

namespace WordCounter
{
    public class ArgsHandler
    {
        private const string indexOption = "-index";
        public CommandLineArgument ReadArgs(string[] args)
        {
            if (args.Length == 0)
            {
                return new CommandLineArgument(string.Empty, false);
            }
            var argList = args.ToList();
            bool isIndexOptionSet = argList.Contains(indexOption);
            string filePath = argList.FirstOrDefault(a => !a.Equals(indexOption)) ?? string.Empty;
            return new CommandLineArgument(filePath, isIndexOptionSet);
        }
    }
}
