using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour 
{
    public bool start = false;
    public float durition = 1f;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
        IEnumerator Shaking()
        {
            Vector3 startPosition = transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < durition)
            {
                elapsedTime += Time.deltaTime;
                transform.position = startPosition + Random.insideUnitSphere;
                yield return null;
            }

            transform.position = startPosition;
        }
    }
}
