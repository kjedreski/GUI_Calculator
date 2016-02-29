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
using System.Numerics;
namespace calc
{
    public partial class Form1 : Form
    {
        /*Methods 1 has all methods for Simple */
        /*Methods 2 has all methods for Complex */
        string[] Types;
        string[] Methods1;
        string[] Methods2;
        List<string> box1 = new List<string>();
        List<string> box2 = new List<string>();
        string file;
        string Tname1;
        Assembly DLL;



        public Form1()
        {
            InitializeComponent();
        }

        private void hide_AllOps()
        {
            //These are the operation buttons,
            // Toggling this function will hide them from user
            /*Simple  */
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            /*Complex */
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();

        }

        private void rsetLists()
        {
            box1.Clear();
            box2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hide_AllOps();
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
           // MessageBox.Show(file);
            return file;
      

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void openFileDialog_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        //when you change Top right from File to Open
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*When forms loads, prompt user to find the DLL file, load string file path */
             file = displayFileStuff();
              DLL = Assembly.LoadFile(file);

            //richTextBox1.Text = "kjhdslkjfhsdlkjhflkjdshfhds";
           
            /*store all types in this array */
            /*methods1, is simple.
             * methods2 is complex 
             */
            List<string> types = new List<string>();
            List<string> methods1 = new List<string>();
            List<string> methods2 = new List<string>();
            string[] test;
            int counter = 0;
           // label4.Text = DLL.GetName;
            // lists are dynamically sized arrays
            // .ToArray at end.
            // find all types and stow in list


            foreach (Type t in DLL.GetTypes())
            {
                types.Add(t.ToString());
                /*First, let's gather names of all methods */
                // MessageBox.Show();
                //dynamically find all types
                richTextBox1.Text += t.ToString() + '\n'+'\n';
                foreach (MethodInfo m in t.GetMethods())
                {
                    if (counter == 0)
                    {
                        methods1.Add(m.ToString());
                        richTextBox1.Text += m.ToString() + '\n';
                    }
                    else if (counter == 1)
                    {
                        methods2.Add(m.ToString());
                        richTextBox1.Text += m.ToString() + '\n';
                    }
                }
                counter++;
                richTextBox1.Text += '\n';
            }
            //Now make both lists arrays
             Types = types.ToArray();
             Methods2 = methods2.ToArray();
             Methods1 = methods1.ToArray();
             
          
        


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
            // reset and hide all available operations
            // reset  lists
            hide_AllOps();
            rsetLists();

            /*on click make calc */
            // box1 is Simple operations
            // box2 is Complex operations
                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    //test msg
                    //MessageBox.Show(itemChecked.ToString());
                    box1.Add(itemChecked.ToString());
                }
                foreach (object itemChecked in checkedListBox2.CheckedItems)
                {
                    //test msg
                    //MessageBox.Show(itemChecked.ToString());
                    box2.Add(itemChecked.ToString());
                }
            // throw ALL items that are checked in lists, and convert to array
            string[] SimpleBox = box1.ToArray();
            string[] ComplexBox = box2.ToArray();

            /*Now invoke reflection and instantiate a calculator */
            /*Methods1 is Simple.  Methods2 is Complex. */
            /*BIG ASS LOOP */

            //MessageBox.Show(Types[0]);
            foreach (string method in SimpleBox)
            {
                /*Instantiate a Simple calculator real time */
                //save code below for later ***********
                if (method == "Addition")
                {
                    button5.Show();
                }
                else if (method == "Subtract")
                {
                    button3.Show();
                }
                else if (method == "Multiply")
                {
                    button2.Show();
                }
                else if (method == "Divide")
                {
                    button4.Show();
                }
                //**************************************
                //groupBox1.Hide();

            }
            foreach (string method in ComplexBox)
            {
                /*Now invoke reflection and instantiate a calculator */
                /*Methods1 is Simple.  Methods2 is Complex. */
                /*Instantiate a Complex calculator real time */
                if (method == "Addition")
                {
                    button6.Show();
                }
                else if (method == "Subtract")
                {
                    button8.Show();
                }
                else if (method == "Multiply")
                {
                    button9.Show();
                }
                else if (method == "Divide")
                {
                    button7.Show();
                }
            }  
        }

        private void clearTextBoxes()
        {
            /* */
            textBox1.Text = "";
            textBox2.Text = "";
            Real1.Text = "";
            Complex1.Text = "";
            Real2.Text = "";
            Complex2.Text = "";
        }

        private void invokeSimple(string operation)
        {
            Type typeC = DLL.GetType("SimpleCalc.SimpleMath");
            int arg1 = Convert.ToInt32(textBox2.Text);
            int arg2 = Convert.ToInt32(textBox1.Text);
            // clear text boxes here.
            clearTextBoxes();
            //MessageBox.Show(typeC.GetMethod("Add"));
            Object obj = Activator.CreateInstance(typeC);
            MethodInfo method = typeC.GetMethod(operation);
            AnswerBox.Text = Convert.ToString(method.Invoke(obj, new object[] { arg1, arg2 }));
        }

        private void invokeComplex(string operation)
        {
            Type typeC = DLL.GetType("ComplexCalc.ComplexMath");
            // complex num 1
            Complex arg1 = new Complex(Convert.ToDouble(Real1.Text), Convert.ToDouble(Complex1.Text));
            Complex arg2 = new Complex(Convert.ToDouble(Real2.Text), Convert.ToDouble(Complex2.Text));
            // clear text boxes here.
            clearTextBoxes();
            //MessageBox.Show(typeC.GetMethod("Add"));
            Object obj = Activator.CreateInstance(typeC);
            MethodInfo method = typeC.GetMethod(operation);
            Result2.Text = Convert.ToString(method.Invoke(obj, new object[] { arg1, arg2 }));

        }

        /*Simple Operation  */
        private void button5_Click(object sender, EventArgs e)
        {
            invokeSimple("Add");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            invokeSimple("Subtract");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            invokeSimple("Multiply");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            invokeSimple("Divide");
        }
        /*End simple operation button controls */
     
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        // okay, stop ignoring


        // COMPLEX operations start here *****************
        private void button6_Click(object sender, EventArgs e)
        {
            invokeComplex("Add");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            invokeComplex("Subtract");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            invokeComplex("Multiply");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            invokeComplex("Divide");
        }


    }
}
