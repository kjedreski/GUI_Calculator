using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void displayFileStuff()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "DLL | *.dll";
            openFile.ShowDialog();
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
        }

        private void openFileDialog_FileOk_1(object sender, CancelEventArgs e)
        {


        }

        //when you change Top right from File to Open
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*When forms loads, prompt user to find the DLL file */
             displayFileStuff();
        }
    }
}
