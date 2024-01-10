using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace labrab5
{
    /// <summary>
    /// Логика взаимодействия для CompositionEditor.xaml
    /// </summary>
    public partial class CompositionEditor : Window
    {
        public CompositionEditor(Composition? composition = null)
        {
            InitializeComponent();
            if(composition != null)
            {
                this.Title.Text = composition.Name;
                this.Composer.Text = composition.Composer;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        public Composition ResultComposition
        {
            get
            {
                return new Composition() { Composer = this.Composer.Text, Name = this.Title.Text };
            }
        }
    }
}
