using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        while (menu.getStatus())
        {
        menu.SelectOption();
        }

    }
}