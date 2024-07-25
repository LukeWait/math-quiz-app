/****************************************************************************
File name: MathQues.cs
Purpose:   1. Represents an instance of a math question
           2. Contains private variables accessable with public methods
           3. Implements IComparable interface
           4. Contains method overload of ToString()
           5. Contains CompareTo() method to compare MathQues instances by answer
Author:    Luke Wait
Date:      05.02.23
Version:   1.0
Notes:     Testing performed and documented in ICTPRG547_DowntownIT_External_Documentation_Template
           Testing also performed through NUnitTest Project
****************************************************************************/

using System;
using System.Runtime.Serialization;

namespace MathQuestion
{
    // DataContract enables JSON serialization used to construct a JSON string from a MathQues,
    // send over the network connection and recompile as a MathQues in the Student application
    [DataContract]
    /// <summary>
    /// MathQues class
    /// Purpose:    Provide class template for math question data
    /// Implements: IComparable interface and CompareTo() method
    /// </summary>
    /// <remarks>Luke Wait
    ///          05.02.23
    ///          Version 1.0</remarks>
    public class MathQues : IComparable<MathQues>
    {        
        // private data with public get and set methods
        // DataMembers must be declared in conjunction with the DataContract for all
        // data that needs to be serialized
        [DataMember]
        /// <summary>
        /// Public property: LeftOp (left operand of math question)
        /// </summary>
        public int LeftOp { get; set; }
        [DataMember]
        /// <summary>
        /// Public property: MathOp (math operand of math question)
        /// </summary>      
        public string MathOp { get; set; }
        [DataMember]
        /// <summary>
        /// Public property: RightOp (right operand of math question)
        /// </summary>
        public int RightOp { get; set; }
        [DataMember]
        /// <summary>
        /// Public property: Answer (answer of math question)
        /// </summary>
        public int Answer { get; set; }


        /****************************************************************************
        Method:     MathQues() --- parameterised contructor method
        Purpose:    Creates a new math question instance
        Input:      int leftOp    --- left operand of the question
                    string mathOp    --- math operand of the question
                    int rightOp   --- right operand of the question
                    int answer --- answer to the question
        Output:     Constructor method/no return type
        ****************************************************************************/
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="leftOp">Left operand of the question</param>
        /// <param name="mathOp">Math operand of the question</param>
        /// <param name="rightOp">Right operand of the question</param>
        /// <param name="answer">Answer to the question</param>
        public MathQues(int leftOp, string mathOp, int rightOp, int answer)
        {
            LeftOp = leftOp;
            MathOp = mathOp;
            RightOp = rightOp;
            Answer = answer;

        }// end constructor method


        /****************************************************************************
        Method:     ToString()
        Purpose:    Compiles a formatted string from the MathQues instance data
        Input:      void
        Output:     Formatted string for display
        ****************************************************************************/
        /// <summary>
        /// Overridden ToString() method
        /// </summary>
        /// <returns>Formatted string for display, ex: 4 + 4 = 8</returns>
        public override string ToString()
        {
            return LeftOp + " " + MathOp + " " + RightOp + " = " + Answer;

        }// end ToString()

        /****************************************************************************
        Method:     ToStudentString()
        Purpose:    Compiles a formatted string from the MathQues instance data to be
                    sent to the Student application
        Input:      void
        Output:     Formatted string for display
        ****************************************************************************/
        /// <summary>
        /// ToStudentString() method
        /// </summary>
        /// <returns>Formatted string for display to student, ex: 4 + 4 = ?</returns>
        public string ToStudentString()
        {
            return LeftOp + " " + MathOp + " " + RightOp + " = ?";

        }// end ToStudentString()

        /****************************************************************************
        Method:     CompareTo()
        Purpose:    Compares the answer of the MathQues instance with the answer of another
                    Used for sorting instances (with Sort() method)
                    Implemented method from IComparable interface
        Input:      MathQues object (other instance being compared)
        Output:     int
                    Returns 0 if both student names are equal
                    Returns -1 if this.Name is alphabetically less than other.Name
                    Returns 1 if this.Name is alphabetically greater than other.Name
        ****************************************************************************/
        /// <summary>
        /// Implemented CompareTo() method
        /// </summary>
        /// <param name="other">MathQues object (other instance being compared)</param>
        /// <returns>Returns 0 if both MathQues answers are equal,
        ///          Returns -1 if this.Answer is less than other.Answer,
        ///          Returns 1 if this.Answer is greater than other.Answer</returns>
        public int CompareTo(MathQues other)
        {
            return Answer.CompareTo(other.Answer);

        }// end CompareTo()


    }// end MathQues

}// end namespace
