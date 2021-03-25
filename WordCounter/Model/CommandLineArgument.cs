namespace WordCounter
{
    public record CommandLineArgument(string FilePath, bool IsIndexOptionSet, string DictionaryPath);
}
