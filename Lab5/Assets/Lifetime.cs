using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float LifeDuration = 3.0f;
    void Start()
    {
        StartCoroutine(DestroyWithDelay(LifeDuration));
    }
    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
