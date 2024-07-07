using Abstractions;

namespace Domain;

public class Book : IBook
{
    public PossibleBookTitles Title { get; }

    internal Book(PossibleBookTitles title)
    {
        Title = title;
    }
}