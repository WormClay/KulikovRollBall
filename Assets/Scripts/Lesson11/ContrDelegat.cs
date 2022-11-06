using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    public class ContrDelegat : MonoBehaviour
    {
        delegate Paper myDelegate(Book obj);

        public class Paper
        {
            public int count;
        }
        public class Book: Paper
        {
            public string title;
        }

        public class Library
        {
            public Paper PaperMethod(Paper obj)
            {
                return obj;
            }

            public Book BookMethod(Book obj)
            {
                return obj;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Library library = new Library();
            //covariance
            myDelegate my = library.PaperMethod;
            //contravariance
            my = library.BookMethod;
        }
    }
}

