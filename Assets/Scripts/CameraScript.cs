using UnityEngine;
namespace RollBall
{
    public sealed class CameraScript : MonoBehaviour, IExecute
    {
        [SerializeField] private Transform hero;
        [SerializeField] private float smooth = 2f;
        private Vector3 offset;

        private void Start()
        {
            offset = hero.position - transform.position;
        }

        public void Execute()
        {
            transform.position = Vector3.Lerp(transform.position, (hero.position - offset), Time.deltaTime * smooth);
        }

        public void SetHero(Transform hero) 
        {
            this.hero = hero;
        }
    }
}
