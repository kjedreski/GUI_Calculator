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
            /*store all types in this array */
            List<string> types = new List<string>();
            List<string> methods = new List<string>();
            string[] test;
            // lists are dynamically sized arrays
            // .ToArray at end.
            // find all types and stow in list,
            foreach (Type t in DLL.GetTypes())
            {
                types.Add(t.ToString());
                /*First, let's gather names of all methods */
                // MessageBox.Show();
                //dynamically find all types
                foreach (MethodInfo m in t.GetMethods())
                {
                    methods.Add(m.ToString());
                }
            }
            //Now make both lists arrays
            string[] Types = types.ToArray();
            string[] Methods = methods.ToArray();
        

            /* 
            //dynamically Create checklist boxes for each TYPE and labels
            CheckedListBox box;
            CheckBox SubBox;
            Label lab;
            // list to store all the CheckedListBox's
            List<CheckedListBox> BoxList = new List<CheckedListBox>();
            //dfgfd
            for (int i = 0; i < Types.Length; i++)
            {
                //dynamically add labels
                lab = new Label();
                lab.Text = Types[i];
                lab.Location = new Point(i*150, 75);

                //dynamically add CheckedListBoxes
                box = new CheckedListBox();
                box.Name = "CheckedListBox" + i.ToString();
                box.Tag = "CheckedListBox"+i.ToString();
                box.AutoSize = true;
                box.Location = new Point(i*150, 100); 
                this.Controls.Add(box);
                this.Controls.Add(lab);
                // add this Control box to dynamic list
                BoxList.Add(box);
            }
            //make BoxList an array
            CheckedListBox[] BoxArray = BoxList.ToArray();

            // dynamically add methods as checklistsboxes
            //TODO: Parse out the raw stuff.
            for (int i = 0; i < BoxArray.Length; i++)
            {
                for (int d =0; d <Methods.Length; d++)
                {
                    //TODO: Parse here.
                    //TODO: Seperate Simple and Complex.
                    BoxArray[i].Items.Add(Methods[d]);
                }
            }
             * */

            


        }
        /*checklistbox, populate it with items from DLL */
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*on click make calc */
            // checkedListBox1 is Simple operations
            // checkedListBox2 is Complex operations
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show(itemChecked.ToString());
                }
            }
            if (checkedListBox2.CheckedItems.Count > 0)
            {
                foreach (object itemChecked in checkedListBox2.CheckedItems)
                {
                    MessageBox.Show(itemChecked.ToString());
                }
            }

        }
    }
}
