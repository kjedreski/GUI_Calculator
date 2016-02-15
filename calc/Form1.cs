using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        // make combo box non editable (top left).
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
   
        }

        /*prompts user to load in DLL file, enforces DLL */
        private string displayFileStuff()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //filter to DLL's only
            openFile.Filter = "DLL | *.dll";
            //open file explorer
            openFile.ShowDialog();
            //grab file location of selection
            string file = openFile.FileName;
            //TEST: shows file name
            MessageBox.Show(file);
            return file;
      

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            /*Once calc.dll is opened -- use Reflection API to display
             * all class names from DLL as well as parameters and methods 
             */
            /* 
             * Allow user to pick any number of methods to construct a calulator, dynamically
             */
            /*
            this.Activate();
            file = openFileDialog.OpenFile();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
            System.IO.FileStream fileStream = fileInfo.OpenRead();
            fileStream.Close(); */
            MessageBox.Show("test");
        }

        private void openFileDialog_FileOk_1(object sender, CancelEventArgs e)
        {
            MessageBox.Show("test1");

        }

        //when you change Top right from File to Open
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*When forms loads, prompt user to find the DLL file, load string file path */
             string file = displayFileStuff();
             var DLL = Assembly.LoadFile(file);
            /*First, load all class names into an array */
             foreach ( Type t in DLL.GetExportedTypes())
             {
                 MessageBox.Show(t.ToString());
             }
             /*Type TypeD = d.GetType();
             // load all properties into array
             PropertyInfo[] properties = TypeD.GetProperties();
             //Load all methods in array
             Console.WriteLine("Meta Data for {0}", TypeD);
             MethodInfo[] methods = TypeD.GetMethods();
             foreach (MethodInfo method in methods)
             {
                 Console.WriteLine(method.Name + "() " + method.ReturnType);
             } */

        }
    }
}
