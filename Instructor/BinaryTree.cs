/****************************************************************************
File name: BinaryTree<T>.cs
Purpose:   1. Binary Tree class --- generic type <T> which uses IComparable interface
           2. Contains private variables accessable with public Get() methods
           3. Provides Add() to add new Nodes to the BinaryTree
           4. Contains multiple transversal methods to retrieve Node data which is
              systematically stored in the NodeValues string
           5. Provides Contains() and Find() to compare exisiting Nodes          
           6. The CompareTo() method is not implemented here as it is implemented
              directly in the class used as the generic type ... this means that
              any class used for the Node must have the IComparble interface implemented
Author:    Luke Wait
Date:      07.02.23
Version:   1.0
Notes:     The Binary Tree and Node class source code files are provided by Hans Telford, 
           under the Creative Commons (Attribution 4.0 International) license. 
           Refer: https://creativecommons.org/licenses/by/4.0/
****************************************************************************/

using System;
using System.Collections.Generic;

namespace BinaryTree
{

    /// <summary>
    /// BinaryTree<T> class
    /// Purpose:    Provide class template for Binary Tree data
    /// Implements: IComparable interface
    /// </summary>
    /// <remarks>Luke Wait
    ///          07.02.23
    ///          Version 1.0</remarks>
    public class BinaryTree<T> where T : IComparable<T>
    {
        // private data properties accessible only through get methods
        /// <summary>
        /// Private property: root (the root node of the Binary Tree)
        /// </summary>
        private Node<T> root;
        /// <summary>
        /// Private property: count (the node count of the Binary Tree)
        /// </summary>
        private int count;
        // private data with public get and set methods
        /// <summary>
        /// Public property: NodeValues (string of node values)
        /// </summary>
        public string NodeValues { get; set; }

            
        /****************************************************************************
        Method:     BinaryTree() --- basic contructor method with no inputs
        Purpose:    Initialise the Binary Tree structure
                    and set up the root node with a null memory address
        Input:      void
        Output:     Constructor method/no return type
        ****************************************************************************/
        /// <summary>
        /// Constructor method
        /// </summary>
        public BinaryTree()
        {
            root = null;
            count = 0;
            NodeValues = "";

        }// end constructor method


        /************************GET METHODS****************************************/

        /****************************************************************************
        Method:     GetRoot()
        Purpose:    Gets the root node for public access
        Input:      void
        Output:     Node<T>
        ****************************************************************************/
        /// <summary>
        /// GetRoot() method
        /// </summary>
        /// <returns>Root node of the Binary Tree</returns>
        public Node<T> GetRoot()
        {
            return root;

        }// end GetRoot()

        /****************************************************************************
        Method:     GetCount()
        Purpose:    Gets the node count for public access
        Input:      void
        Output:     int
        ****************************************************************************/
        /// <summary>
        /// GetCount() method
        /// </summary>
        /// <returns>Node count of the Binary Tree</returns>
        public int GetCount()
        {
            return count;

        }// end GetCount()

        /****************************************************************************
        Method:     GetHeight()
        Purpose:    Gets the height of the Binary Tree structure (number of nodes
                    along the longest path from root node to furthest leaf node).
        Input:      Node<T>
        Output:     int
        ****************************************************************************/
        /// <summary>
        /// GetHeight() method
        /// </summary>
        /// <param name="root">Node<T> representing root of Binary Tree</T></param>
        /// <returns>Height of the Binary Tree</returns>
        public int GetHeight(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                // compute height of each sub-tree
                int leftSideHeight = GetHeight(root.leftChild);
                int rightSideHeight = GetHeight(root.rightChild);
                // use the larger
                if (leftSideHeight > rightSideHeight)
                {
                    return (leftSideHeight + 1);
                }
                else
                {
                    return (rightSideHeight + 1);
                }
            }

        }// end GetHeight()

        /************************ADD AND COMPARE NODES******************************/

        /****************************************************************************
        Method:     Add()
        Purpose:    Add a node to the Binary Tree structure     
        Input:      <T> data (generic data that will constitute a node - MathQues)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// Add() method
        /// </summary>
        /// <param name="data">Generic data type to be added to Binary Tree</param>
        public void Add (T data)
        {
            // Create the node
            Node<T> newNode = new Node<T>(data);

            // check if the root is null
            // if so, assign the root to newNode
            if (root == null)
            {
                root = newNode;
                count++;
                Console.WriteLine(data + " entered - this is the root");
            }
            else
            {
                Node<T> current = root;
                Node<T> parent;

                while (true)
                {
                    parent = current;
                    // check if data is the same as the parent data
                    // and if so, ignore
                    if (data.CompareTo(current.data) == 0)
                    {
                        // duplicate - ignore the node
                        Console.WriteLine(data + " entered - duplicate value ignored");
                        return;
                    }
                    // check if data is less than the parent data
                    // and if so, assign current to the left node
                    if (data.CompareTo(current.data) == -1)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            count++;
                            Console.WriteLine(data + " entered");
                            return;
                        }
                    }
                    // data is now greater than the parent data
                    // in this case, assign current to the right node
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            count++;
                            Console.WriteLine(data + " entered");
                            return;
                        }
                    }

                } // end while loop

            } // end if-else

        } // end Add() method

        /****************************************************************************
        Method:     Contains()
        Purpose:    Looks for a specific value using Find() and returns boolean
                    True if found and false if not found
        Input:      <T> (generic data type representing data to be compared)
        Output:     bool
        ****************************************************************************/
        /// <summary>
        /// Contains() method
        /// </summary>
        /// <param name="value">Generic data type to compared</param>
        /// <returns>Bool indicating if value was found</returns>
        public bool Contains (T value)
        {
            return (this.Find(value) != null);

        }// end Contains()

        /****************************************************************************
        Method:     Find()
        Purpose:    Implementation of the CompareTo()
                    Starts at root node and searches through Binary Tree based
                    on value being compared - left if value to find is smalller
                    than current node, right if value to find is greater
        Input:      <T> (generic data type representing data to be compared)
        Output:     Node<T> (will be null if not found)
        ****************************************************************************/
        /// <summary>
        /// Find() method
        /// </summary>
        /// <param name="value">Generic data type to compared</param>
        /// <returns>Node if found, null if not found</returns>
        public Node<T> Find (T value)
        {
            Node<T> nodeToFind = GetRoot();

            while (nodeToFind != null)
            {
                if (value.CompareTo(nodeToFind.data) == 0)
                {
                    // found
                    return nodeToFind;
                }
                else
                {
                    // search left if the value to find is smaller than the current node
                    if (value.CompareTo(nodeToFind.data) == -1)
                    {
                        nodeToFind = nodeToFind.leftChild;
                    }
                    // search right if the value to find is greater than the current node
                    else if (value.CompareTo(nodeToFind.data) == 1)
                    {
                        nodeToFind = nodeToFind.rightChild;
                    }
                }
            }

            // not found
            return null;

        }// end Find()

        /************************TRANSVERSAL METHODS********************************/

        /****************************************************************************
        Method:     Preorder()
        Purpose:    Traverse through the Binary Tree structure using Preorder method 
                    of Root-L-R while saving the node data to the NodeValues string
        Input:      Node<> representing the root of the binary tree
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// PreOrder() method
        /// </summary>
        /// <param name="root">Represents the root of the Binary Tree instance</param>
        public void Preorder(Node<T> root)
        {
            // Order of method: (Root-L-R)
            if (root != null)
            {
                //Console.Write(root.data + " ");
                if (root.GetType().ToString().Contains("MathQues"))
                {
                    NodeValues += root.data.ToString() + "\r\n";
                }
                else
                {
                    NodeValues += root.data + "\r\n";
                }

                Preorder(root.leftChild);
                Preorder(root.rightChild);

            }

        }// end Preorder()

        /****************************************************************************
        Method:     Postorder()
        Purpose:    Traverse through the Binary Tree structure using Postorder method 
                    of L-R-Root while saving the node data to the NodeValues string
        Input:      Node<> representing the root of the Binary Tree
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// PostOrder() method
        /// </summary>
        /// <param name="root">Represents the root of the Binary Tree instance</param>
        public void Postorder(Node<T> root)
        {
            // Order of method: (L-R-Root)
            if (root != null)
            {
                Postorder(root.leftChild);
                Postorder(root.rightChild);

                //Console.Write(root.data + " ");
                if (root.GetType().ToString().Contains("MathQues"))
                {
                    NodeValues += root.data.ToString() + "\r\n";
                }
                else
                {
                    NodeValues += root.data + "\r\n";
                }

            }

        }// end Postorder()

        /****************************************************************************
        Method:     Inorder()
        Purpose:    Traverse through the Binary Tree structure using Inorder method 
                    of L-Root-R while saving the node data to the NodeValues string
        Input:      Node<> representing the root of the Binary Tree
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// InOrder() method
        /// </summary>
        /// <param name="root">Represents the root of the Binary Tree instance</param>
        public void Inorder(Node<T> root)
        {
            // Order of method: (L-Root-R)
            if (root != null)
            {
                Inorder(root.leftChild);

                //Console.Write(root.data + " ");
                if (root.GetType().ToString().Contains("MathQues"))
                {
                    NodeValues += root.data.ToString() + "\r\n";
                }
                else
                {
                    NodeValues += root.data + "\r\n";
                }
                
                Inorder(root.rightChild);
                
            }

        }// end Inorder()

        /****************************************************************************
        Method:     DisplayBreadthFirst()
        Purpose:    Traverse through the Binary Tree structure using Breadth-First method 
                    using a queue to systematically traverse every node by level (left to right)
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// DisplayBreadthFirst() method
        /// </summary>
        public void DisplayBreadthFirst()
        {
            // breadth-first using a queue
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(this.root);

            while (q.Count > 0)
            {
                Node<T> n = q.Dequeue();
                Console.Write(n.data + " ");
                if (n.leftChild != null)
                {
                    q.Enqueue(n.leftChild);
                }
                if (n.rightChild != null)
                {
                    q.Enqueue(n.rightChild);
                }

            }

        }// end DisplayBreadthFirst()

        /****************************************************************************
        Method:     DisplayDepthFirst()
        Purpose:    Traverse through the Binary Tree structure using Depth-First method 
                    using a stack to systematically traverse every node starting with the root node
                    and moving down the right side of the root node
        Input:      void
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// DisplayDepthFirst() method
        /// </summary>
        public void DisplayDepthFirst()
        {
            // depth-first using a stack
            Stack<Node<T>> s = new Stack<Node<T>>();
            s.Push(this.root);

            while (s.Count > 0)
            {
                Node<T> n = s.Pop();
                Console.Write(n.data + " ");

                if (n.leftChild != null)
                {
                    s.Push(n.leftChild);
                }
                if (n.rightChild != null)
                {
                    s.Push(n.rightChild);
                }

            }

        }// end DisplayDepthFirst()


    }// end BinaryTree<T>

}// end namespace
