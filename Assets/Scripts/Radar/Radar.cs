using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public sealed class Radar : MonoBehaviour
    {
        private Transform playerPos;
        private readonly float mapScale = 3;
        public static List<RadarObject> RadObjects = new List<RadarObject>();
        private void Start()
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public static void RegisterRadarObject(GameObject o, Image i)
        {
            if (i != null)
            {
                Image image = Instantiate(i);
                RadObjects.Add(new RadarObject { Owner = o, Icon = image });
            }
        }

        public static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadObjects)
            {
                if (t.Owner == o)
                {
                    Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }

        private void DrawRadarDots()
        {
            foreach (RadarObject radObject in RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position - playerPos.position);
                radObject.Icon.transform.SetParent(transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x * mapScale,
                                                                radarPos.z * mapScale, 0) + transform.position;
            }
        }

        private void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }

    public sealed class RadarObject
    {
        public Image Icon;
        public GameObject Owner;
    }
}
