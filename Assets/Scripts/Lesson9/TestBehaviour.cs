using UnityEngine;

namespace RollBall
{
    public sealed class TestBehaviour : MonoBehaviour
    {
        public int count = 10;
        public int offset = 1;
        public GameObject obj;
        public float Test;
        private Transform root;
        private void Start()
        {
            CreateObj();
        }
        public void CreateObj()
        {
            root = new GameObject("Root").transform;
            for (var i = 1; i <= count; i++)
            {
                Instantiate(obj, new Vector3(0, offset * i, 0), Quaternion.identity, root);
            }
        }
        public void AddComponent()
        {
            gameObject.AddComponent<BoxCollider>();
        }
        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
}

