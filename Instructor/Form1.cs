/**************************************************************************************
File name: InstructorForm.cs
Purpose:   1. Create GUI From application
           2. Provide user-interaction (buttons, textboxes, menuitems)
           3. Validates user input and creates a math question
           4. Adds the math question to the data structures List, BinaryTree and HashTable
           5. Sends the math question to the Student app over a network connection using Send button
           6. Receives an answer from the Student app over a network connection
           7. Displays sent questions in a dataGridView
           8. Provides three sorting methods for the List, reflected in the dataGridView by using
              the corresponding buttons
           9. A Binary Search can be performed on the List to search for sent questions using
              the search field and button
           10. A Hash Search can be performed on the Hash Table to search for sent questions using
               the search field and button
           11. All incorrectly answered question are stored in the Linked List and can be diplayed
           12. All sent questions are stored in a Binary Tree
           13. The contents of the Binary Tree can be displayed and saved according to the transversal 
               button selected
Author:    Luke Wait
Date:      05.02.23
Version:   1.0
Notes:     Testing performed and documented in ICTPRG547_DowntownIT_External_Documentation_Template
           Testing also performed through NUnitTest Project
**************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
// user created classes
using BinaryTree;
using MathQuestion;
using CustomMessageBox;

namespace Instructor
{

    public partial class InstructorForm : Form
    {
        // List object
        private List<MathQues> quesList;
        // Hashtable object
        private Hashtable quesHash;
        // BinaryTree object
        private BinaryTree<MathQues> quesTree;
        // LinkedList object
        private LinkedList<MathQues> wrongAnsList;
        // new math question object
        private MathQues newQues;

        // timing tools
        long nbrTicks;
        Stopwatch stopwatch;

        // networking data
        public bool exitStatus = false;
        public const int BYTE_SIZE = 1024;
        public const int PORT_NUMBER = 8888;
        // listens for and accept incoming connection requests
        private TcpListener serverListener;
        // TcpClient is used to connect with the TcpListener object
        private TcpClient serverSocket;
        // set up data stream object
        private NetworkStream netStream;
        // set up thread to run ReceiveStream() method
        private Thread serverThread = null;
        // set up delegate
        delegate void SetTextCallback(string text);
        


        /****************************************************************************
        Method:     InstructorForm()
        Purpose:    Constructs GUI components
                    Initialises private data
        Input:      void
        Output:     Constructor method/no return value
        ****************************************************************************/
        /// <summary>
        /// InstructorForm() method
        /// </summary>
        public InstructorForm()
        {
            // Visual Studio GUI setup
            InitializeComponent();

            // instantiate the private variables
            quesList = new List<MathQues>();
            quesHash = new Hashtable();
            quesTree = new BinaryTree<MathQues>();         
            wrongAnsList = new LinkedList<MathQues>();


            /************************COMBO BOX******************************************/
            // clear out any existing items in the combo box
            operatorComboBox.Items.Clear();
            // add each operator to the combobox
            operatorComboBox.Items.Add("+");
            operatorComboBox.Items.Add("-");
            operatorComboBox.Items.Add("*");
            operatorComboBox.Items.Add("/");
            // select the first item
            operatorComboBox.SelectedIndex = 0;


            /************************DATAGRIDVIEW***************************************/
            // datagridview parameters have been set in Form1.cs[Design] view
            // set appropriate row header width
            dataGridView.RowHeadersWidth = 25;
            // set up font style and size for the data grid view
            dataGridView.DefaultCellStyle.Font = new Font("Calibri", 11);


            /************************SERVER CONNECTION**********************************/
            // disable send button until network connection is made
            sendButton.Enabled = false;
            // run server
            StartServer();

        }// end constructor method



        /***************************************************************************/
        /************************METHODS********************************************/
        /***************************************************************************/

        /************************NETWORKING*****************************************/

        /****************************************************************************
        Method:     StartServer()
        Purpose:    Creates a network connection with a client
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// StartServer()
        /// </summary>
        private void StartServer()
        {
            try
            {
                // create listener and start
                serverListener = new TcpListener(IPAddress.Loopback, PORT_NUMBER);
                serverListener.Start();
                // create acceptance socket
                // this creates a socket connection for the server
                serverSocket = serverListener.AcceptTcpClient();
                // create stream
                netStream = serverSocket.GetStream();
                // set up thread to run ReceiveStream() method
                serverThread = new Thread(ReceiveStream);
                // start thread
                serverThread.Start();

                // enable send button
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                // display exception message
                MyMessageBox.Show(this, ex.StackTrace, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }// end StartServer()

        /****************************************************************************
        Method:     ReceiveStream()
        Purpose:    This method runs as a thread (called by serverThread)
                    Reads contents of received data and decodes into a string
                    Calls the SetText() method to safely update the correctAns string
                    Provides user information on receieved data
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// ReceiveStream()
        /// </summary>
        private void ReceiveStream()
        {
            byte[] bytesReceived = new byte[BYTE_SIZE];
            // loop to read any incoming messages
            while (!exitStatus)
            {
                try
                {
                    // counter of bytes read
                    int bytesRead = netStream.Read(bytesReceived, 0, bytesReceived.Length);

                    // string of bytes read
                    this.SetText(Encoding.ASCII.GetString(bytesReceived, 0, bytesRead));
                    
                }
                catch (System.IO.IOException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MyMessageBox.Show(this, "This is a custom message box.", "Custom MessageBox",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // disable send button
                        sendButton.Enabled = false;
                    });

                    // change exitStatus to true
                    exitStatus = true;
                    
                }
            }
            
        }// end ReceiveStream()

        /****************************************************************************
        Method:     SetText()
        Purpose:    Ensures receive stream contents are updating data in a thread-safe manner
        Input:      string (the received stream from the network connection)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// SetText()
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // if these threads are different, it returns true.           
            if (this.searchDisplayTextBox.InvokeRequired)
            {
                // d is a Delegate reference to the SetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // provide feedback that reply was received and outcome of answer
                string studentFeedback = "";
                if (text.Equals("y"))
                {
                    studentFeedback += "Student answered correctly!";
                }
                else
                {
                    studentFeedback += "Student answered incorrectly!";
                    wrongAnsList.AddLast(newQues);
                }

                this.searchDisplayTextBox.Text = studentFeedback + "\r\n\r\nScore: " + (quesList.Count - wrongAnsList.Count) +
                                        " / " + quesList.Count;

                // enable send button when answer received from Student application
                sendButton.Enabled = true;
            }

        }// end SetText()

        /************************SEARCH AND SORTS***********************************/

        /****************************************************************************
        Method:     BinarySearch()
        Purpose:    returns an index value respective to the found value in a sorted array of integers
        Input:      List<MathQues> (sorted list of math questions to search through)
                    MathQues (question to search for)
        Output:     int (index position of the array where the value was found)
        ****************************************************************************/
        /// <summary>
        /// BinarySearch() method
        /// </summary>
        /// <param name="list">List of questions to be compared to</param>
        /// <param name="quesToSearch">Question to be compared</param>
        /// <returns>Index of found question</returns>
        static int BinarySearch(List<MathQues> list, string quesToSearch)
        {
            bool foundStatus = false;
            int firstIndex = 0;
            int lastIndex = list.Count - 1;
            int posFound = -1;

            // loop while foundStatus is false AND first is less than or equal to last
            while (!foundStatus && firstIndex <= lastIndex)
            {
                // get mid index value
                int mid = (firstIndex + lastIndex) / 2;

                // check if number to search is less than the value positioned in the middle of the sorted List
                // if it is, then change the last position to that of the middle less 1
                // this way, last becomes the last value in the sorted upper half of the List
                if (quesToSearch.CompareTo(list[mid].ToString()) < 0)
                {
                    lastIndex = mid - 1;
                }
                // check if number to search is greater than the value positioned in the middle of the sorted List
                // if it is, then change the first position to that of the middle plus 1
                // this way, first becomes the first value in the sorted lower half of the List
                else if (quesToSearch.CompareTo(list[mid].ToString()) > 0)
                {
                    firstIndex = mid + 1;
                }
                // otherwise, the value has been found
                else
                {
                    foundStatus = true;
                    posFound = mid;
                }
            }
            return posFound;

        }// end BinarySearch()

        /****************************************************************************
        Method:     BubbleSort()
        Purpose:    Sorts a list of math questions in asc or desc order with
                    the bubble sort technique
        Input:      List<MathQues> (the list to be sorted)
                    String (order to sort the list, asc or desc)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// BubbleSort()
        /// </summary>
        /// <param name="list">The list to be sorted</param>
        /// <param name="order">Order to sort the list, asc or desc</param>
        static void BubbleSort(List<MathQues> list, string order)
        {
            int swapCounter = 0;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (order.Equals("asc"))
                    {
                        if (list[i].Answer < list[j].Answer)
                        {
                            // swap values
                            MathQues temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                            swapCounter++;
                        }
                    }
                    else if (order.Equals("desc"))
                    {
                        if (list[i].Answer > list[j].Answer)
                        {
                            // swap values
                            MathQues temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                            swapCounter++;
                        }
                    }

                }
            }
        }// end BubbleSort()

        /****************************************************************************
        Method:     SelectionSort()
        Purpose:    Sorts a list of math questions in asc or desc order with
                    the selection sort technique
        Input:      List<MathQues> (the list to be sorted)
                    String (order to sort the list, asc or desc)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// SelectionSort()
        /// </summary>
        /// <param name="list">The list to be sorted</param>
        /// <param name="order">Order to sort the list, asc or desc</param>
        static void SelectionSort(List<MathQues> list, string order)
        {
            int swapCounter = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                //int selectedIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (order.Equals("asc"))
                    {
                        if (list[j].Answer < list[i].Answer)
                        {
                            MathQues temp = list[j];
                            list[j] = list[i];
                            list[i] = temp;
                            swapCounter++;
                        }
                    }
                    else if (order.Equals("desc"))
                    {
                        if (list[j].Answer > list[i].Answer)
                        {
                            MathQues temp = list[j];
                            list[j] = list[i];
                            list[i] = temp;
                            swapCounter++;
                        }
                    }

                }
            }
        }// end SelectionSort()

        /****************************************************************************
        Method:     InsertionSort()
        Purpose:    Sorts a list of math questions in asc or desc order with
                    the insertion sort technique
        Input:      List<MathQues> (the list to be sorted)
                    String (order to sort the list, asc or desc)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// InsertionSort()
        /// </summary>
        /// <param name="list">The list to be sorted</param>
        /// <param name="order">Order to sort the list, asc or desc</param>
        static void InsertionSort(List<MathQues> list, string order)
        {
            int swapCounter = 0;
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (order.Equals("asc"))
                    {
                        if (list[j].Answer < list[j - 1].Answer)
                        {
                            MathQues temp = list[j];
                            list[j] = list[j - 1];
                            list[j - 1] = temp;
                            swapCounter++;
                        }
                    }
                    else if (order.Equals("desc"))
                    {
                        if (list[j].Answer > list[j - 1].Answer)
                        {
                            MathQues temp = list[j];
                            list[j] = list[j - 1];
                            list[j - 1] = temp;
                            swapCounter++;
                        }
                    }
                }
            }
        }// end InsertionSort() 

        /************************BUTTONS********************************************/

        /****************************************************************************
        Method:     SortButton()
        Purpose:    Sorts contents of quesList using passed in sort method and updates
                    display in dataGridView
        Input:      string (sort type)
                    string (sort order)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// SortButton()
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        public void SortButton(string type, string order)
        {
            // check that quesList isn't empty
            if (quesList.Count > 0)
            {
                switch (type)
                {
                    case "bubble":
                        BubbleSort(quesList, order);
                        break;
                    case "insertion":
                        InsertionSort(quesList, order);
                        break;
                    case "selection":
                        SelectionSort(quesList, order);
                        break;
                    default:
                        MyMessageBox.Show(this, "Invalid sort type", "ERROR!", MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        break;
                }

                DisplayDataGrid();
            }
            else
            {
                MyMessageBox.Show(this, "No questions in memory", "NOTHING TO DISPLAY!", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
            }

        }// end SortButton()

        /****************************************************************************
        Method:     DisplayButton()
        Purpose:    Gets the node values of the Binary Tree instance according to the 
                    transversal type and displays in the searchDisplayTextBox
        Input:      string (transversal type)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// DisplayButton()
        /// </summary>
        /// <param name="transversal">Transversal method of Binary Tree</param>
        public void DisplayButton(string transversal)
        {
            // check if the Binary Tree is empty
            if (quesTree.GetCount() > 0)
            {
                // clear the NodeValues string in Binary Tree instance
                quesTree.NodeValues = "";

                // compile a formatted string of the ordered node values in the
                // Binary Tree class according to transversal type and display
                switch (transversal)
                {
                    case "pre":
                        quesTree.Preorder(quesTree.GetRoot());
                        searchDisplayTextBox.Text = "PRE-ORDER: \r\n" + quesTree.NodeValues;
                        break;
                    case "in":
                        quesTree.Inorder(quesTree.GetRoot());
                        searchDisplayTextBox.Text = "IN-ORDER: \r\n" + quesTree.NodeValues;
                        break;
                    case "post":
                        quesTree.Postorder(quesTree.GetRoot());
                        searchDisplayTextBox.Text = "POST-ORDER: \r\n" + quesTree.NodeValues;
                        break;
                }
            }
            else
            {
                searchDisplayTextBox.Text = "No questions in memory";
            }

        }// end DisplayButton()

        /****************************************************************************
        Method:     SaveButton()
        Purpose:    Gets the node values of the Binary Tree instance according to the 
                    transversal type and displays in the searchDisplayTextBox
                    Calls the SaveToExternalFile() to write to file
        Input:      string (transversal type)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// SaveButton()
        /// </summary>
        /// <param name="transversal">Transversal method of Binary Tree</param>
        public void SaveButton(string transversal)
        {
            // check if the Binary Tree is empty
            if (quesTree.GetCount() > 0)
            {
                // string to be saved
                string fileContent = "";
                // desired name and file type
                string fileName = "";

                // clear the NodeValues string in Binary Tree instance
                quesTree.NodeValues = "";

                // compile a formatted string of the ordered node values in the
                // Binary Tree class, and file name, according to transversal type
                switch (transversal)
                {
                    case "pre":
                        quesTree.Preorder(quesTree.GetRoot());
                        fileContent = "PRE-ORDER: \r\n" + quesTree.NodeValues;
                        fileName = "pre-order.txt";
                        break;
                    case "in":
                        quesTree.Inorder(quesTree.GetRoot());
                        fileContent = "IN-ORDER: \r\n" + quesTree.NodeValues;
                        fileName = "in-order.txt";
                        break;
                    case "post":
                        quesTree.Postorder(quesTree.GetRoot());
                        fileContent = "POST-ORDER: \r\n" + quesTree.NodeValues;
                        fileName = "post-order.txt";
                        break;
                }

                // write to external file
                SaveToExternalFile(fileContent);

            }
            else
            {
                MyMessageBox.Show(this, "No questions in memory", "FILE NOT SAVED!", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
            }

        }// end SaveButton()

        /************************MISC***********************************************/

        /****************************************************************************
        Method:     SaveToExternalFile()
        Purpose:    Saves the passed in fileContent to the project directory
                    with the passed in fileName
                    Checks if file exists and if it does asks user for confirmation
                    before overwriting
        Input:      string fileContent
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// SaveToExternalFile
        /// </summary>
        /// <param name="fileContent">String of data to be written</param>
        public void SaveToExternalFile(string fileContent)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Simplify object initialization
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "All files (*.*)|*.*| txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // write to external file
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, fileContent);
                    MyMessageBox.Show(this, "Saved to:\n\n" + saveFileDialog.FileName, "SAVE FILE SUCCESSFUL",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MyMessageBox.Show(this, ex.StackTrace, "FILE SAVE FAILED!", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                }
            }

        }// end SaveToExternalFile()

        /****************************************************************************
        Method:     DisplayDataGrid()
        Purpose:    Displays cellList data in data grid
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// DisplayDataGrid() method
        /// </summary>
        public void DisplayDataGrid()
        {
            // loop through rows of dataGridView (representing a quesList instance)
            for (int i = 0; i < quesList.Count; i++)
            {
                // loop through columns (representing the elements of a quesList instance)
                for (int j = 0; j < 5; j++)
                {
                    // add to dataGridView
                    switch(j)
                    {
                        case 0:
                            dataGridView.Rows[i].Cells[j].Value = quesList[i].LeftOp;
                            break;
                        case 1:
                            dataGridView.Rows[i].Cells[j].Value = quesList[i].MathOp;
                            break;
                        case 2:
                            dataGridView.Rows[i].Cells[j].Value = quesList[i].RightOp;
                            break;
                        case 3:
                            dataGridView.Rows[i].Cells[j].Value = "=";
                            break;
                        case 4:
                            dataGridView.Rows[i].Cells[j].Value = quesList[i].Answer;
                            break;
                    }
                }              
            }

        }// end DisplayDataGrid()

        /****************************************************************************
        Method:     ExitForm()
        Purpose:    Exits the form application
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// ExitForm() method
        /// </summary>
        public void ExitForm()
        {
            // exit the application
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }

        }// end ExitForm()

        /************************VALIDATION*****************************************/

        /****************************************************************************
        Method:     IsSearchValid()
        Purpose:    Validates search field
        Input:      void
        Output:     bool
        ****************************************************************************/
        /// <summary>
        /// IsSearchValid()
        /// </summary>
        /// <returns>bool indicating validation status</returns>
        public bool IsSearchValid()
        {
            // validation variables
            bool isSearchValid = true;
            string errorMsg = "";
            int numErrors = 0;

            // check if the search text box is not empty
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                errorMsg += "Search field is missing";
                isSearchValid = false;
                numErrors++;
            }
            else
            {
                // check if the search is formatted correctly
                string[] part = searchTextBox.Text.Split(new char[] { ' ' });
                if (part.Length != 5)
                {
                    errorMsg += "Search must follow correct format\nThe spaces are important!\n\n" +
                                "Example: 4 + 4 = 8";
                    isSearchValid = false;
                    numErrors++;
                }
                else
                {
                    int leftOp = 0;
                    string mathOp = "";
                    int rightOp = 0;
                    int answer = 0;
                    // leftOp checks
                    try
                    {
                        leftOp = int.Parse(part[0]);
                    }
                    catch
                    {
                        errorMsg += "The left operator must be numeric!\n";
                        isSearchValid = false;
                        numErrors++;
                    }
                    // mathOp checks
                    string[] validOps = new[] { "+", "-", "*", "/" };
                    if (!validOps.Contains(part[1]))
                    {
                        errorMsg += "The math operator must be (+, -, *, /)!\n";
                        isSearchValid = false;
                        numErrors++;
                    }
                    else
                    {
                        mathOp = part[1];
                    }
                    // rightOp checks
                    try
                    {
                        rightOp = int.Parse(part[2]);
                    }
                    catch
                    {
                        errorMsg += "The right operator must be numeric!\n";
                        isSearchValid = false;
                        numErrors++;
                    }
                    // equals checks
                    if (!part[3].Equals("="))
                    {
                        errorMsg += "You need an equals sign!\n";
                        isSearchValid = false;
                        numErrors++;
                    }
                    // answer checks
                    try
                    {
                        answer = int.Parse(part[4]);
                    }
                    catch
                    {
                        errorMsg += "The answer must be numeric!\n";
                        isSearchValid = false;
                        numErrors++;
                    }

                    // smartass answer check
                    if (isSearchValid)
                    {
                        int ansCheck = 0;
                        switch (mathOp)
                        {
                            case "+":
                                ansCheck = leftOp + rightOp;
                                break;
                            case "-":
                                ansCheck = leftOp - rightOp;
                                break;
                            case "*":
                                ansCheck = leftOp * rightOp;
                                break;
                            case "/":
                                ansCheck = leftOp / rightOp;
                                break;
                        }
                        if (answer != ansCheck)
                        {
                            errorMsg += "The formatting is correct but this equation doesn't add up!\n\n" +
                                        "Only valid questions are saved";
                            isSearchValid = false;
                            numErrors++;
                        }
                    }
                }   
            }

            // if there are any errors, display in pop up
            if (numErrors > 0)
            {
                MyMessageBox.Show(this, errorMsg, numErrors + " ERROR(S)!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSearchValid;

        }// end IsSearchValid()

        /****************************************************************************
        Method:     IsSendValid()
        Purpose:    Validates question input fields
        Input:      void
        Output:     bool
        ****************************************************************************/
        /// <summary>
        /// IsSendValid()
        /// </summary>
        /// <returns>bool indicating validation status</returns>
        public bool IsSendValid()
        {
            // validation variables
            bool isSendValid = true;
            string errorMsg = "";
            int numErrors = 0;

            // declare validated input fields as variables
            int leftOp = 0;
            string mathOp = operatorComboBox.Text;
            int rightOp = 0;
            int answer = 0;

            // check if first number field is empty
            if (string.IsNullOrEmpty(firstNumTextBox.Text))
            {
                errorMsg += "First number is missing\n";
                isSendValid = false;
                numErrors++;
            }
            else
            {
                // check if first number field is numeric using regular expression
                Regex regex = new Regex(@"^[0-9]+$");
                if (!regex.IsMatch(firstNumTextBox.Text))
                {
                    errorMsg += "First number is not numeric\n";
                    isSendValid = false;
                    numErrors++;
                }
                else
                {
                    leftOp = int.Parse(firstNumTextBox.Text);
                }
            }

            // check if second number field is empty
            if (string.IsNullOrEmpty(secondNumTextBox.Text))
            {
                errorMsg += "Second number is missing\n";
                isSendValid = false;
                numErrors++;
            }
            else
            {
                // check if second number field is numeric
                try
                {
                    rightOp = int.Parse(secondNumTextBox.Text);
                }
                catch
                {
                    errorMsg += "Second number is not numeric\n";
                    isSendValid = false;
                    numErrors++;
                }
            }

            // if fields are valid, check that question or answer doesn't exist
            if (isSendValid)
            {
                // calculate answer automatically by taking user input of left and right
                // operand and performing operation based on operatorComboBox selection
                switch (mathOp)
                {
                    case "+":
                        answer = leftOp + rightOp;
                        break;
                    case "-":
                        answer = leftOp - rightOp;
                        break;
                    case "*":
                        answer = leftOp * rightOp;
                        break;
                    case "/":
                        if (rightOp != 0)
                        {
                            answer = leftOp / rightOp;
                        }
                        else
                        {
                            answer = 0;
                        }
                        break;
                }

                // set the value to the global newQues object
                newQues = new MathQues(leftOp, mathOp, rightOp, answer);

                // display answer in the textbox
                answerTextBox.Text = answer.ToString();

                // check if question is in HashTable
                if (quesHash.ContainsKey(newQues.ToString()))
                {
                    errorMsg += "You've already asked that question!\n\n" +
                                "Please ask a different question";
                    isSendValid = false;
                    numErrors++;
                }
                else
                {
                    // check if answer has been used so Binary Tree doesn't break
                    // BinarySearcy compares answers only, returns >= 0 if found
                    int foundIndex = BinarySearch(quesList, newQues.ToString());
                    if (foundIndex >= 0)
                    {
                        errorMsg += "Due to a design flaw an answer can only exist once!\n\n" +
                                    "Please change the question to evaluate to a new answer";
                        isSendValid = false;
                        numErrors++;
                    }
                }
            }

            // if there are any errors, display in pop up
            if (numErrors > 0)
            {
                MyMessageBox.Show(this, errorMsg, numErrors + " ERROR(S)!", MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
            }

            return isSendValid;

        }// end IsSendValid()



        /***************************************************************************/
        /************************EVENT HANDLERS*************************************/
        /***************************************************************************/

        /************************MISC***********************************************/

        /****************************************************************************
        Method:     sendButton_Click() event handler
        Purpose:    Adds contents of firstNumTextBox, operatorTextBox, secondNumTextBox,
                    and answerTextBox to quesList and quesHash
                    Displays contents of quesList in dataGridView by calling DisplayDataGrid()
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void sendButton_Click(object sender, EventArgs e)
        {
            // check that input fields are valid
            if (IsSendValid())
            {
                try
                {
                    // using serializer to convert MathQues object to a format that can be transmitted
                    // over the network (JSON)
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MathQues));
                    using (MemoryStream stream = new MemoryStream())
                    {
                        serializer.WriteObject(stream, newQues);
                        string jsonString = Encoding.ASCII.GetString(stream.ToArray());

                        // Send the JSON string to the server
                        netStream.Write(Encoding.ASCII.GetBytes(jsonString), 0, jsonString.Length);
                    }

                    // add the validated newQues object to the dynamic list structures
                    quesList.Add(newQues);
                    quesTree.Add(newQues);
                    quesHash.Add(newQues.ToString(), newQues);

                    // add row to dataGridView
                    if (quesList.Count > 1)
                    {
                        dataGridView.Rows.Add();
                    }
                    // update dataGridView to display new question
                    DisplayDataGrid();

                    // disable send button until answer received from student 
                    sendButton.Enabled = false;

                    // provide feedback that question has been sent
                    searchDisplayTextBox.Text = "The question has been sent to the student\r\n\r\n" +
                                                "The student must reply before another question can be sent";

                }
                // sending the question fails
                catch (Exception ex)
                {
                    MyMessageBox.Show(this, "Sending the question to the student failed\n" +
                                            "The question was not saved to memory\n\n" + ex.StackTrace, 
                                            "SEND QUESTION FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }// end sendButton event

        /****************************************************************************
        Method:     instructorForm_FormClosed() event handler
        Purpose:    Terminates any active thread before closing application
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void InstructorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // terminate thread if still running
            if (serverThread.IsAlive)
            {
                Console.WriteLine("Server thread is alive");
                serverThread.Interrupt();               
                if (serverThread.IsAlive)
                {
                    Console.WriteLine("Server thread is now terminated");
                }
            }
            else
            {
                Console.WriteLine("Server thread is terminated");
            }
            this.Dispose();
            GC.Collect();
            // close the application for good
            Environment.Exit(0);
            
        }// end instructorForm_FormClosed event

        /****************************************************************************
        Method:     instructorExitButton_Click() event handler
        Purpose:    Exits the application by calling ExitForm()
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void instructorExitButton_Click(object sender, EventArgs e)
        {
            ExitForm();

        }// end instructorExitButton event

        /************************SEARCHES*******************************************/

        /****************************************************************************
        Method:     binarySearchButton_Click() event handler
        Purpose:    Use the BinarySearch() to return index value if record exists
                    Display result in searchTextBox
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void binarySearchButton_Click(object sender, EventArgs e)
        {
            // check that search field is valid
            if (IsSearchValid())
            {
                // check that there questions in the List
                if (quesList.Count > 0)
                {
                    string quesToSearch = searchTextBox.Text;
                    // sort the quesList
                    InsertionSort(quesList, "asc");

                    // time the binary search
                    stopwatch = Stopwatch.StartNew();
                    // use BinarySearch to return index value if record exists
                    int foundIndex = BinarySearch(quesList, quesToSearch);
                    stopwatch.Stop();
                    nbrTicks = stopwatch.ElapsedTicks;

                    // compile outcome of search
                    string displayText = "Binary Search: Time taken in ticks is " + nbrTicks + "\r\n\r\n" + quesToSearch;
                    if (foundIndex >= 0)
                    {
                        displayText += "  <-> found in index position " + foundIndex;
                    }
                    else
                    {
                        displayText += "  <-> NOT found!";
                    }
                    // output to text box
                    searchDisplayTextBox.Text = displayText;

                }
                else
                {
                    searchDisplayTextBox.Text = "No questions in memory";
                }
            }

        }// end binarySearchButton event

        /****************************************************************************
        Method:     hashSearchButton_Click() event handler
        Purpose:    
                    Search the Hash Table for a record matching the search field
                    Display result in searchTextBox
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void hashSearchButton_Click(object sender, EventArgs e)
        {
            // check that search field is valid
            if (IsSearchValid())
            {
                // check that there questions in the Hash Table
                if (quesHash.Count > 0)
                {
                    string quesToSearch = searchTextBox.Text;
                    // time the hash search
                    stopwatch = Stopwatch.StartNew();
                    // check if question is in HashTable
                    bool foundStatus = quesHash.ContainsKey(quesToSearch);
                    stopwatch.Stop();
                    nbrTicks = stopwatch.ElapsedTicks;

                    // compile outcome of search
                    string displayText = "Hash Search: Time taken in ticks is " + nbrTicks + "\r\n\r\n" + quesToSearch;
                    if (foundStatus)
                    {
                        displayText += "  <-> found!";
                    }
                    else
                    {
                        displayText +=  "  <-> NOT found!";
                    }
                    // output to text box
                    searchDisplayTextBox.Text = displayText;

                }
                else
                {
                    searchDisplayTextBox.Text = "No questions in memory";
                }
            }

        }// end hashSearchButton event 

        /****************************************************************************
        Method:     displayLinkedListButton_Click() event handler
        Purpose:    Displays the contents of the wrongAnsList linked list in the 
                    linkedListDisplayTextBox
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void displayLinkedListButton_Click(object sender, EventArgs e)
        {
            string linkedDisplay = "";

            // check if any questions have been sent
            if (quesList.Count == 0)
            {
                linkedDisplay = "No questions sent!";
            }
            // check if all received answers are correct
            else if (wrongAnsList.Count == 0)
            {
                // check if waiting for a reply on first question
                if (quesList.Count == 1 && !sendButton.Enabled)
                {
                    linkedDisplay = "The first sent question has yet to be answered...";
                }
                else
                {
                    // all questions answered correctly
                    linkedDisplay = "All answers submitted have been correct!";

                    if (!sendButton.Enabled)
                    {
                        // waiting for a reply
                        linkedDisplay += "\r\n\r\nHowever a sent question has yet to be answered...";
                    }
                }
            }

            if (wrongAnsList.Count > 0)
            {
                linkedDisplay += "HEAD\r\n";
                // display the linked list in the text box
                foreach(MathQues ques in wrongAnsList)
                {
                    linkedDisplay += "<-> " + ques.ToString() + "\r\n";
                }
                linkedDisplay += "<-> TAIL";
            }

            linkedListDisplayTextBox.Text = linkedDisplay;

        }// end displayLinkedListButton event
        
        /************************LIST SORTS*****************************************/

        /****************************************************************************
        Method:     bubbleSortButton_Click() event handler
        Purpose:    Calls the SortButton() and passes in the sort type and order
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void bubbleSortButton_Click(object sender, EventArgs e)
        {
            SortButton("bubble", "asc");

        }// end bubbleSortButton event

        /****************************************************************************
        Method:     selectionSortButton_Click() event handler
        Purpose:    Calls the SortButton() and passes in the sort type and order
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void selectionSortButton_Click(object sender, EventArgs e)
        {
            SortButton("selection", "desc");

        }// end selectionSortButton event

        /****************************************************************************
        Method:     insertionSortButton_Click() event handler
        Purpose:    Calls the SortButton() and passes in the sort type and order
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void insertionSortButton_Click(object sender, EventArgs e)
        {
            SortButton("insertion", "asc");

        }// end insertionSortButton event 

        /************************BINARY TREE DISPLAYS*******************************/

        /****************************************************************************
        Method:     preDisplayButton_Click() event handler
        Purpose:    Calls the DisplayButton() and passes in the 'pre' transversal type
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void preDisplayButton_Click(object sender, EventArgs e)
        {
            DisplayButton("pre");

        }// end preDisplayButton event

        /****************************************************************************
        Method:     inDisplayButton_Click() event handler
        Purpose:    Calls the DisplayButton() and passes in the 'in' transversal type
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void inDisplayButton_Click(object sender, EventArgs e)
        {
            DisplayButton("in");

        }// end inDisplayButton event      

        /****************************************************************************
        Method:     postDisplayButton_Click() event handler
        Purpose:    Calls the DisplayButton() and passes in the 'post' transversal type
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void postDisplayButton_Click(object sender, EventArgs e)
        {
            DisplayButton("post");

        }// end postDisplayButton event

        /************************BINARY TREE SAVES**********************************/

        /****************************************************************************
        Method:     preSaveButton_Click() event handler
        Purpose:    Calls the SaveButton() and passes in the 'pre' transversal type
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void preSaveButton_Click(object sender, EventArgs e)
        {
            SaveButton("pre");

        }// end preSaveButton event

        /****************************************************************************
        Method:     inSaveButton_Click() event handler
        Purpose:    Calls the SaveButton() and passes in the 'in' transversal type
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void inSaveButton_Click(object sender, EventArgs e)
        {
            SaveButton("in");

        }// end inSaveButton event

        /****************************************************************************
        Method:     postSaveButton_Click() event handler
        Purpose:    Calls the SaveButton() and passes in the 'post' transversal type
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void postSaveButton_Click(object sender, EventArgs e)
        {
            SaveButton("post");

        }// end postSaveButton event



    }// end InstructorForm

}// end namespace
