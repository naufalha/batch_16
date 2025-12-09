using AbstractFactory.Interfaces;
     // --- Client code that depends on abstract factory ---

using AbstractFactory.Products;
public class Application
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        // Application only knows about interfaces
        public Application(IMacGUi gui)
    {
        _button = gui.CreateButton();
        _checkbox = gui.CreateCheckBox();
    }

        public void Render()
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }