using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public string emilyObjectName = "Emily";
    [SerializeField] float magicSpeed = 7f;
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField] Vector2 offset = new(0, 0.8f);


    void Start()
    {
        GameObject emilyObject = GameObject.Find(emilyObjectName);
        if (emilyObject != null)
        {
            direction = ((Vector2)emilyObject.transform.position - (Vector2)transform.position + offset).normalized;

            rb = GetComponent<Rigidbody2D>();
            rb.velocity = direction * magicSpeed;
        }
    }
}
