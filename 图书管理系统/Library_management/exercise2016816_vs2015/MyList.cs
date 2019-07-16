using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015
{
    //结点类，使用泛型
    public class Node<T>
    {
        public T Data//存储的数据
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> Next//指向下一个结点
        {
            get { return next; }
            set { next = value; }
        }
        public Node(T _data)//有参的构造函数
        {
            data = _data;
            next = null;
        }
        //私有字段
        private T data;
        private Node<T> next;
    }
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }//头结点
        public Node<T> Tail { get; set; }//尾结点
        protected int Count { get { return count; } }//结点个数，只读
        public LinkedList()//构造函数，初始化头指针，结点个数
        {
            Head = new Node<T>(default(T));
            Tail = Head;
            count = 0;
        }
        public bool IsEmpty()//判空
        {
            return count == 0 ? true : false;
        }
        public void In(T inData)//输入
        {
            Node<T> newNode = new Node<T>(inData);
            Tail.Next = newNode;
            Tail = newNode;
            count++;
        }
        //字段
        public int count;
    }
}
