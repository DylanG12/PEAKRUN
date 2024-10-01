using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour 
{
    public GameObject ouch;
    public static bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public float scrreenshakeduration = 0.5f;

    private void Start()
    {
        ouch.SetActive(false);
    }
    void Update()
    {

        if (start)
        {
            ouch.SetActive(true);
            start = false;
            StartCoroutine(Shaking());
        }
         IEnumerator Shaking()
        {
            Vector3 startPosition = transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = curve.Evaluate(elapsedTime / duration);
                transform.position = startPosition + Random.insideUnitSphere;
                yield return null;
            }
            if (scrreenshakeduration >= 0.5f)
            {
                ouch.SetActive(false);
            }

            transform.position = startPosition;
        }
    }
}
