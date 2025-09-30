using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task9
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand ChangeColor = new RoutedUICommand(
            "Изменить цвет",
            "ChangeColor",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            new KeyGesture(Key.C, ModifierKeys.Control)
            });
    }
}
