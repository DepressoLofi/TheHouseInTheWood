using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorfalling : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] Vector3 initialState;
    [SerializeField] Vector3 targetState;
    [SerializeField] Vector3 initialLocation;
    [SerializeField] Vector3 targetLocation;

    void Start()
    {
        initialState = transform.localScale;
        targetState = new Vector3(9.3f, 270, 0);
        initialLocation = transform.localPosition;
        targetLocation = new Vector3(0, 0, 0);

        StartCoroutine(StartIncreasing());
    }

    private IEnumerator StartIncreasing()
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(IncreaseCollisionScale());


    }
    private IEnumerator IncreaseCollisionScale()
    {
   
        float elapsedTime = 0f;
        float duration = 60f;
        while (elapsedTime < duration)
        {
 
            float t = elapsedTime / duration;

            transform.localScale = Vector3.Lerp(initialState, targetState, t);
            transform.localPosition = Vector3.Lerp(initialLocation, targetLocation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetState;
        transform.localPosition = targetLocation;



    }


}
