﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MST
{
    class StackX
    {
        private int SIZE = 20;
        private int[] st;
        private int top;
        public StackX()
        {
            st = new int[SIZE];
            top = -1;
        }
        public void push(int j)
        { st[++top] = j; }
        public int pop()
        { return st[top--]; }
        public int peek()
        { return st[top]; }
        public Boolean isEmpty() 
        { return (top == -1); }} 
    class Vertex
    {
        public char label;
        public Boolean wasVisited;
        public Vertex(char lab)
        {
            label = lab;
            wasVisited = false;
        }
    } 
    class Graph
    {
        private  int MAX_VERTS = 20;
        private Vertex[] vertexList; 
        private int[,] adjMat; 
        private int nVerts;
        private StackX theStack;
        public Graph()
        {
            vertexList = new Vertex[MAX_VERTS];
            adjMat = new int[MAX_VERTS,MAX_VERTS];
            nVerts = 0;
            for (int j = 0; j < MAX_VERTS; j++) 
                for (int k = 0; k < MAX_VERTS; k++) 
                    adjMat[j,k] = 0;
            theStack = new StackX();
        } 
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        public void addEdge(int start, int end)
        {
            adjMat[start,end] = 1;
            adjMat[end,start] = 1;
        }
        public void displayVertex(int v)
        {
           Console.WriteLine(vertexList[v].label);
        }
        public void mst()
        { 
            vertexList[0].wasVisited = true; 
            theStack.push(0); 
            while (!theStack.isEmpty()) 
            {
                int currentVertex = theStack.peek();
                int v = getAdjUnvisitedVertex(currentVertex);
                if (v == -1) 
                    theStack.pop(); 
                else 
                {
                    vertexList[v].wasVisited = true;
                    theStack.push(v); 
                    displayVertex(currentVertex);
                    displayVertex(v);
                    Console.WriteLine(" ");
                }
            } 
            for (int j = 0; j < nVerts; j++)
                vertexList[j].wasVisited = false;
        }
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < nVerts; j++)
                if (adjMat[v,j] == 1 && vertexList[j].wasVisited == false)
                    return j;
            return -1;
        } }


        class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
            theGraph.addVertex('0');
            theGraph.addVertex('1');
            theGraph.addVertex('2');
            theGraph.addVertex('3');
            theGraph.addVertex('4');
            theGraph.addEdge(0, 3);
            theGraph.addEdge(1, 3);
            theGraph.addEdge(1, 2);
            theGraph.addEdge(1, 4);
            theGraph.addEdge(2, 4);  
            Console.WriteLine("Minimum spanning tree: ");
            theGraph.mst(); 
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
