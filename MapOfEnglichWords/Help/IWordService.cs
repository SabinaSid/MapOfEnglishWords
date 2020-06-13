using MapOfEnglishWords.db;

namespace MapOfEnglishWords.Help
{
    public interface IWordService
    {
        WordDto[] GetAll();
        WordDto[] GetInitialize();
        WordDto[] GetParent(int id);
        WordDto[] GetChildren(int id);
    }
}