using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    public class ShowGismo : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Bonus.png");
        }

        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Transform t = transform;
            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            //var flat = new Vector3(ActiveDis, 0, ActiveDis);
            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(transform.position, 1);
#endif
        }
    }
}
