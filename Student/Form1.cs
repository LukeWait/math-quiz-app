/**************************************************************************************
File name: StudentForm.cs
Purpose:   1. Create GUI From application
           2. Provide user-interaction (buttons, textboxes, menuitems)
           3. Receives a math question from the Instructor app over a network connection
           4. Submit button takes user input and checks against the correct answer, then the result
              is displayed and sent to the Instructor app
Author:    Luke Wait
Date:      05.02.23
Version:   1.0
Notes:     Testing performed and documented in ICTPRG547_DowntownIT_External_Documentation_Template
**************************************************************************************/

using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Json;
// user created classes
using MathQuestion;
using CustomMessageBox;

namespace Student
{

    public partial class StudentForm : Form
    {
        // new math question object
        private MathQues newQues;
        // question results stats
        private string correctAns = "";
        private int numQues = 0;
        private int numCorrect = 0;

        // networking data
        public bool exitStatus = false;
        public const int BYTE_SIZE = 1024;
        public const string HOST_NAME = "localhost";
        public const int PORT_NUMBER = 8888;
        // set up a client connection for TCP network service
        private TcpClient clientSocket;
        // set up data stream object
        private NetworkStream netStream;
        // set up thread to run ReceiveStream() method
        private Thread clientThread = null;
        // set up delegate
        delegate void SetTextCallback(string text);
        


        /****************************************************************************
        Method:     StudentForm()
        Purpose:    Constructs GUI components
                    Initialises private data
        Input:      void
        Output:     Constructor method/no return value
        ****************************************************************************/
        /// <summary>
        /// StudentForm() method
        /// </summary>
        public StudentForm()
        {
            // Visual Studio GUI setup
            InitializeComponent();

            // disable submit button until question has been received from Instructor
            submitButton.Enabled = false;
            // start the client
            StartClient();            

        }// end constructor method



        /**************************************************************************/
        /************************METHODS*******************************************/
        /**************************************************************************/

        /************************NETWORKING****************************************/

        /****************************************************************************
        Method:     StartClient()
        Purpose:    Creates a network connection with a server
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// StartClient()
        /// </summary>
        private void StartClient()
        {
            try
            {
                // create TCPClient object (as the socket)
                clientSocket = new TcpClient(HOST_NAME, PORT_NUMBER);
                // create stream
                netStream = clientSocket.GetStream();
                // set up thread to run ReceiveStream() method
                clientThread = new Thread(ReceiveStream);
                // start thread
                clientThread.Start();
                
            }
            catch (Exception e)
            {
                // display exception message
                MyMessageBox.Show(this, e.StackTrace, "NETWORK ERROR!", MessageBoxButtons.OK, 
                                                    MessageBoxIcon.Error);
            }
            
        }// end StartClient()

        /****************************************************************************
        Method:     ReceiveStream()
        Purpose:    This method runs as a thread (called by serverThread)
                    Reads contents of received data and decodes into a MathQues object
                    Calls the SetText() method to safely update the question field
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
                    
                    // Pass the JSON representation of the object to the SetText method
                    this.SetText(Encoding.ASCII.GetString(bytesReceived, 0, bytesRead));

                }
                catch (System.IO.IOException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MyMessageBox.Show(this, "Instructor has left the session", "CONNECTION LOST!",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // disable submit button
                        submitButton.Enabled = false;
                    });
                    
                    exitStatus = true;
                }

            }
            
        }// end ReceiveStream()

        /****************************************************************************
        Method:     SetText()
        Purpose:    Ensures receive stream contents are updating data in a thread-safe manner
        Input:      string
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
            if (this.questionTextBox.InvokeRequired)
            {
                // d is a Delegate reference to the SetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // string of bytes read
                string jsonString = text;

                // Deserialize the JSON string to a MathQues object
                MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonString));
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MathQues));
                newQues = (MathQues)serializer.ReadObject(stream);

                this.questionTextBox.Text = newQues.ToStudentString();

                // increment the total number of questions
                numQues++;

                // clear the answer field
                answerTextBox.Clear();

                // enable the submitButton
                submitButton.Enabled = true;

                // provide feedback that question has been received
                MyMessageBox.Show(this, "A new question has been received from the instuctor",
                                        "NEW QUESTION RECEIVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }// end SetText()

        /************************MISC**********************************************/

        /****************************************************************************
        Method:     IsSubmitValid()
        Purpose:    Checks the input fields of the Student for are valid
        Input:      void
        Output:     bool
        ****************************************************************************/
        /// <summary>
        /// IsSubmitValid()
        /// </summary>
        /// <returns>bool indicating validation status</returns>
        public bool IsSubmitValid()
        {
            // validation variables
            bool isSubmissionValid = true;
            string errorMsg = "";
            int numErrors = 0;
            // reset correctAns string
            correctAns = "n";

            // check if text field is empty
            if (string.IsNullOrEmpty(answerTextBox.Text))
            {
                errorMsg += "Answer is missing";
                isSubmissionValid = false;
                numErrors++;
            }
            else
            {
                // check if text input is numeric
                try
                {
                    int answer = int.Parse(answerTextBox.Text);

                    // if answer is correct change correctAns
                    if (answer == newQues.Answer)
                    {
                        correctAns = "y";
                    }
                }
                catch
                {
                    errorMsg += "Answer is not numeric\n";
                    isSubmissionValid = false;
                    numErrors++;
                }
            }

            // if there are any errors, display in pop up
            if (numErrors > 0)
            {
                MyMessageBox.Show(this, errorMsg, numErrors + " ERROR(S)!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

            return isSubmissionValid;

        }// end isSubmissionValid()

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



        /**************************************************************************/
        /************************EVENT HANDLERS************************************/
        /**************************************************************************/

        /****************************************************************************
        Method:     submitButton_Click() event handler
        Purpose:    Submits the student answer to the instructor app
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void submitButton_Click(object sender, EventArgs e)
        {
            // checks that answer field is valid
            if (IsSubmitValid())
            {
                try
                {
                    // send correctAns to Instructor application
                    byte[] bytesToSend = Encoding.ASCII.GetBytes(correctAns);
                    netStream.Write(bytesToSend, 0, bytesToSend.Length);

                    // update the question text box to display answer
                    questionTextBox.Text = newQues.ToString();

                    // disable the submitButton until a new question is received
                    submitButton.Enabled = false;

                    // provide feedback that answer was submitted and give student the answer
                    string studentFeedback = "Your answer has been submitted to the instructor\n\n";
                    if (correctAns.Equals("y"))
                    {
                        numCorrect++;
                        studentFeedback += "You answered correctly!\n" + newQues.ToString();
                    }
                    else
                    {
                        studentFeedback += "You answered incorrectly!\n" + "The correct answer is:\n" + newQues.ToString();
                    }

                    MyMessageBox.Show(this, studentFeedback + "\n\nScore: " + numCorrect + " / " +
                                            numQues, "SUBMIT ANSWER SUCCESSFUL",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                // sending the correctAns string fails
                catch (Exception ex)
                {
                    MyMessageBox.Show(this, "Submitting your answer to the instructor failed\n" +
                                            "Please try re-submitting your answer\n\n" + ex.StackTrace,
                                            "SUBMIT ANSWER FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }// end submitButton event

        /****************************************************************************
        Method:     studentForm_FormClosed() event handler
        Purpose:    Terminates any active threads before closing application
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // terminate client thread if still running
            if (clientThread.IsAlive)
            {
                Console.WriteLine("Client thread is alive");
                clientThread.Interrupt();
                if (clientThread.IsAlive)
                {
                    Console.WriteLine("Client thread is now terminated");
                }
            }
            else
            {
                Console.WriteLine("Client thread is terminated");
            }
            this.Dispose();
            GC.Collect();
            // close the application for good
            Environment.Exit(0);
            
        }// end studentForm_FormClosed event

        /****************************************************************************
        Method:     studentExitButton_Click() event handler
        Purpose:    Exits the application by calling ExitForm()
        Input:      object sender (the button instance)
                    EventArgs e (event generated data)
        Output:     void
        ****************************************************************************/
        private void studentExitButton_Click(object sender, EventArgs e)
        {
            ExitForm();

        }// end studentExitButton event

        

    }// end StudentForm

}// end namespace
