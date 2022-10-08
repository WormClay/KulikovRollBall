using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    public class ListExecuteObject
    {
        public List<IExecute> ListObject { get; private set; }
        public ListExecuteObject() 
        {
            ListObject = new List<IExecute>();
        }

        public void Add(IExecute el)
        {
            ListObject.Add(el);
        }
    }
}
