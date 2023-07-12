using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorfalling : MonoBehaviour
{
    [SerializeField] float floorFallingRate = 0.1f;
    private float delay = 2f;
    private Vector3 initialState;
    private Vector3 targetState;
    private Vector3 initialLocation;
    private Vector3 targetLocation;
   
    void Start()
    {
        initialState = transform.localScale;
        targetState = new Vector3 (15, 90, 0);
        initialLocation = transform.localPosition;
        targetLocation = new Vector3(0, 0, 0);

        StartCoroutine(StartIncreasing());
    }

    private IEnumerator StartIncreasing()
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        StartCoroutine(IncreaseCollisionScale());


    }
    private IEnumerator IncreaseCollisionScale()
    {
        targetState.y += floorFallingRate;
        float elapsedTime = 0f;
        while (elapsedTime < 60f) 
        {
            transform.localScale = Vector3.Lerp(initialState, targetState, elapsedTime); 
            transform.localPosition = Vector3.Lerp(initialLocation, targetLocation, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }



    }


}
