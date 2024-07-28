/****************************************************************************
File name: Node<T>.cs
Purpose:   1. Node class --- generic type <T> which uses IComparable interface
           2. Contains publicy accessible data - generic data type input, 
              and references to the left and right child nodes
           3. Contains Display() to display the data component of the Node in Console
           4. Contains Search() to find a particular data value
           5. The CompareTo() method is not implemented here as it is implemented
              directly in the class used as the generic type ... this means that
              any class used for the Node must have the IComparble interface implemented
Version: 1.0.0
Author: ┬  ┬ ┬┬┌─┌─┐┬ ┬┌─┐╦╔╦╗
        │  │ │├┴┐├┤ │││├─┤║ ║
        ┴─┘└─┘┴ ┴└─┘└┴┘┴ ┴╩ ╩
Date: February 7, 2023
License: The Binary Tree and Node class source code files are provided by Hans Telford, 
         under the Creative Commons (Attribution 4.0 International) license. 
         Refer: https://creativecommons.org/licenses/by/4.0/

GitHub Repository: https://github.com/LukeWait/math-quiz-app 
****************************************************************************/

using System;

namespace BinaryTree
{

    /// <summary>
    /// Node<T> class
    /// Purpose:    Provide class template for Node data
    /// Implements: IComparable interface
    /// </summary>
    /// <remarks>Luke Wait
    ///          07.02.23
    ///          Version 1.0</remarks>
    public class Node<T> where T : IComparable<T>
    {
        // public data
        /// <summary>
        /// Public property: data (generic data type)
        /// </summary>
        public T data;
        /// <summary>
        /// Public property: leftChild (reference to the left child Node)
        /// </summary>
        public Node<T> leftChild;
        /// <summary>
        /// Public property: rightChild (reference to the right child Node)
        /// </summary>
        public Node<T> rightChild;


        /****************************************************************************
        Method:     Node() --- contructor method with generic data type input
        Purpose:    Initialise the Node with the input data and sets right and 
                    left child nodes to null as none exist at this point
        Input:      void
        Output:     Constructor method/no return type
        ****************************************************************************/
        /// <summary>
        /// Node()
        /// </summary>
        /// <param name="data">Generic data type, can be any object</param>
        public Node(T data)
        {
            this.data = data;
            rightChild = null;
            leftChild = null;

        }// end constructor method


        /****************************************************************************
        Method:     Display()
        Purpose:    Creates formatted string to display the Node data component
                    in the Console
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// Display()
        /// </summary>
        public void Display()
        {
            Console.Write("[");
            Console.Write(data);
            Console.Write("]");

        }// end Display()

        /****************************************************************************
        Method:     GetRoot()
        Purpose:    Find a particular data value and returns true if found
                    Uses the CompareTo() method of the passed in Node
        Input:      Node<T> (a Node), T (the data of a Node)
        Output:     bool
        ****************************************************************************/
        /// <summary>
        /// Search()
        /// </summary>
        /// <param name="node">An instance of a Node to be compared</param>
        /// <param name="data">The data being compared to the data of the Node</param>
        /// <returns>bool indicating if the data matches the Node data</returns>
        public bool Search(Node<T> node, T data)
        {
            // if node is null, then this is the root node
            if (node == null)
            {
                return false;
            }
            else
            {
                // existing node --- check if data is > node.data
                if (node.data.CompareTo(data) > 0)
                {
                    return Search(node.rightChild, data);
                }
                // existing data --- check if data is < node.data
                else if (node.data.CompareTo(data) < 0)
                {
                    return Search(node.leftChild, data);
                }
                // if existing data is the same as node.data
                else
                {
                    return true;
                }
            }

        }// end Search()

    }// end Node<T>

}// end namespace


