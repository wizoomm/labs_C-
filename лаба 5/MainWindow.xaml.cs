using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace labrab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppDbContext dbContext;
        public MainWindow(AppDbContext _dbContext)
        {
            this.dbContext = _dbContext;
            InitializeComponent();
            dbContext.Compositions.Load();
            CompositionsListView.ItemsSource = dbContext.Compositions.Local.ToObservableCollection();

            this.Closing += (s, e) =>
            {
                dbContext.SaveChanges();
                dbContext.Dispose();
            };
        }

        private bool CompositionsFilter(object obj)
        {
            Composition composition = obj as Composition;
            return composition.SearchMatches(FilterTextBox.Text);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Composition selected = (Composition)this.CompositionsListView.SelectedItem;
            CompositionEditor editor = new CompositionEditor(selected);
            if (editor.ShowDialog() == true)
            {
                dbContext.Compositions.Remove(selected);
                dbContext.Compositions.Add(editor.ResultComposition);
                dbContext.SaveChanges();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CompositionEditor editor = new CompositionEditor();
            if (editor.ShowDialog() == true)
            {
                dbContext.Compositions.Add(editor.ResultComposition);
                dbContext.SaveChanges();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Composition selected = (Composition)this.CompositionsListView.SelectedItem;
            dbContext.Compositions.Remove(selected);
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CompositionsListView.ItemsSource);
            if (FilterTextBox.Text.Length > 0)
            {
                view.Filter = CompositionsFilter;
            }
            else
            {
                view.Filter = null;
            }
            view.Refresh();
        }
    }
}