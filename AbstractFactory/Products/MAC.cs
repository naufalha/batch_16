using System.Numerics;
using AbstractFactory.Interfaces;

namespace AbstractFactory.Products
{
    public class MacButton : IButton
    {
        public void Paint() => Console.WriteLine("Mac Button");
    }

    public class MacCheckBox : ICheckbox
    {
        public void Paint() => Console.WriteLine("Mac CheckBox");
    }


    public class MacGui : IMacGUi
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckBox() => new MacCheckBox();
    
    }
}