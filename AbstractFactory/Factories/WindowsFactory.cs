using System;

namespace AbstractFactory.Interfaces
{
    public interface IMicrosoftGui
    {
        IButton CreateButton();
        ICheckbox CreateCheckBox();
    
    }
}