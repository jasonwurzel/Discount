namespace Abstractions;

public interface IBookSetCalculator
{
    /// <summary>
    /// Calculate the discounted price for a given list of <see cref="IBook"/>. 
    /// </summary>
    /// <param name="books">The given list of <see cref="IBook"/></param>
    /// <returns>The discounted price</returns>
    decimal Calculate(List<IBook> books);

    /// <summary>
    /// Calculate the discounted price for a given list of <see cref="IBookSet"/>. 
    /// </summary>
    /// <param name="bookSets">The given list of <see cref="IBookSet"/></param>
    /// <returns>The discounted price</returns>
    decimal Calculate(List<IBookSet> bookSets);

    /// <summary>
    /// Calculate the discounted price for a given <see cref="IBookSet"/>. 
    /// </summary>
    /// <param name="bookSet">The given <see cref="IBookSet"/></param>
    /// <returns>The discounted price</returns>
    decimal Calculate(IBookSet bookSet);
}