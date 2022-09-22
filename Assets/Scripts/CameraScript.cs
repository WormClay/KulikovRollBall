using UnityEngine;
namespace RollBall
{
    public sealed class CameraScript : MonoBehaviour
    {
        [SerializeField] private Transform hero;
        [SerializeField] private float smooth = 2f;
        private Vector3 offset;

        private void Start()
        {
            offset = hero.position - transform.position;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, (hero.position - offset), Time.deltaTime * smooth);
        }
    }
}
