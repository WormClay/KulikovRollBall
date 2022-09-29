using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	private Transform camTransform;

	// How long the object should shake for.
	private float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	[SerializeField] private float shakeAmount = 0.3f;
	[SerializeField] private float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
			if (shakeDuration < 0.1f)
			{
				shakeDuration = 0f;
				camTransform.localPosition = originalPos;
			}
		}
	}

	public void DoShake<T>(T f)
	{
		originalPos = camTransform.localPosition;
		shakeDuration = 0.5f;
	}
}
