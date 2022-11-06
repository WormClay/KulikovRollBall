using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public sealed class RadarObj : MonoBehaviour
    {
        [SerializeField] private Image ico;
        private void OnValidate()
        {
            ico = Resources.Load<Image>("RadarObject");
            Debug.Log("ico:"+ ico);
        }

        private void OnDisable()
        {
            Radar.RemoveRadarObject(gameObject);
        }

        private void OnEnable()
        {
            Radar.RegisterRadarObject(gameObject, ico);
        }
    }
}
