﻿namespace Abstractions;

public interface IShoppingCart
{
    void AddBook(IBook book);

    decimal GetPrice();
}