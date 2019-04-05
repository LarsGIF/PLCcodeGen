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
    /// Interaction logic for AddItemDlg.xaml
    /// </summary>
    public partial class AddItemDlg : Window
    {
        string parentType;
        TypeOfItem typeOfItem;

        public AddItemDlg()
        {
            InitializeComponent();
        }

        public TypeOfItem TypeOfItem { get => typeOfItem; set => typeOfItem = value; }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            parentType = Tag.ToString();
        }
    }
}
