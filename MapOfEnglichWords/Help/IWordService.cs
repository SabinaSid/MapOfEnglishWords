using MapOfEnglishWords.db;

namespace MapOfEnglishWords.Help
{
    public interface IWordService
    {
        WordDto[] GetAll();
        WordDto GetById(int Id);
        WordDto[] GetInitialize();
        WordDto[] GetForRepeat();
        WordDto[] GetParent(int id);
        WordDto[] GetChildren(int id);
        void AddRelation(int wordId, int parentId);
        void Add(WordDto wordDto);
        void Update(WordDto wordDto);
        void UpdateForTrainer(int wordId);
        void DeleteRelation(int wordId, int parentId);
        void DeleteById(int wordId);
        WordDto GetByName(string wordName);
    }
}