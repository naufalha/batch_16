using System;
using AbstractFactory.Interfaces;
namespace AbstractFactory.Products
{
    public class Windows : IButton
    {
        public void Paint() => Console.WriteLine("Windows Button");
    }

    public class WindowsCheckBox : ICheckbox
    {
        public void  Paint() => Console.WriteLine("Windows CheckBox");
    
    }

    public class WindowsGui : IMicrosoftGui
    {
        public IButton CreateButton() => new Windows();
        public ICheckbox CreateCheckBox() => new WindowsCheckBox();
    
    }
 
}