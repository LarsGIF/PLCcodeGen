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

namespace PLCcodeGen
{
    /// <summary>
    /// Interaction logic for AddCodeBlockDlg.xaml
    /// </summary>
    public partial class AddCodeBlockDlg : Window
    {
        TypeOfCode selCodeType;
        public TypeOfCode SelCodeType { get => selCodeType; set => selCodeType = value; }

        public AddCodeBlockDlg()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            this.Title = "Add " + Tag.ToString();
            itemLbl.Content = Tag.ToString() + " name:";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CdeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
