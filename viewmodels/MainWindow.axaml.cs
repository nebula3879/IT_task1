using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace SetApp
{
    public partial class MainWindow : Window
    {
        private LinearList<string> myList;

        public MainWindow()
        {
            InitializeComponent();
            myList = new LinearList<string>();
            UpdateListContent();
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            var input = InputBox?.Text?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                myList.Add(input);
                if (InputBox != null)
                {
                    InputBox.Text = string.Empty;
                }
                UpdateListContent();
            }
        }

        private void OnRemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var input = InputBox?.Text?.Trim();
            
            if (string.IsNullOrEmpty(input))
            {
                // Если поле ввода пустое, удаляем текущий элемент
                try
                {
                    // Получаем текущий элемент
                    var currentElement = myList.CurrentElement;
                    
                    // Удаляем его
                    myList.Remove(currentElement);
                    
                    UpdateListContent();
                }
                catch (InvalidOperationException)
                {
                    // Если текущий элемент не установлен, ничего не делаем
                }
            }
            else
            {
                // Если указано значение, удаляем его
                myList.Remove(input);
                if (InputBox != null)
                {
                    InputBox.Text = string.Empty;
                }
                UpdateListContent();
            }
        }

        private void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            myList.Clear();
            UpdateListContent();
        }

        private void OnNextButtonClick(object sender, RoutedEventArgs e)
        {
            bool success = myList.MoveToNext();
            if (success)
            {
                UpdateCurrentElement();
            }
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            if (!myList.IsEmpty)
            {
                myList.MoveToStart();
                UpdateCurrentElement();
            }
        }

        private void UpdateCurrentElement()
        {
            try
            {
                if (CurrentElementText != null)
                {
                    CurrentElementText.Text = myList.CurrentElement.ToString();
                }
            }
            catch (InvalidOperationException)
            {
                if (CurrentElementText != null)
                {
                    CurrentElementText.Text = "Нет текущего элемента";
                }
            }
        }

        private void UpdateListContent()
        {
            if (ListContent != null)
            {
                ListContent.Text = myList.IsEmpty ? "Список пуст." : string.Join(", ", myList.ToArray());
            }
            if (CountText != null)
            {
                CountText.Text = myList.Count.ToString();
            }
            if (EmptyText != null)
            {
                EmptyText.Text = myList.IsEmpty ? "Да" : "Нет";
            }
            UpdateCurrentElement();
        }
    }
}
