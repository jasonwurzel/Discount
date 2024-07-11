using Abstractions;

namespace Domain;

public class Book : IBook
{
    protected bool Equals(Book other)
    {
        return Title == other.Title;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Book)obj);
    }

    public override int GetHashCode()
    {
        return (int)Title;
    }

    public BookTitle Title { get; }
    
    internal Book(BookTitle title)
    {
        Title = title;
    }
}