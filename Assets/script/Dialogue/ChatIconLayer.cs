using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatIconLayer : MonoBehaviour
{
    private string playerTag = "Emily";
    private string changeLayerName = "Default";
    private string normalLayerName = "top";
    [SerializeField] float height = 8f;

    private SpriteRenderer iconRenderer;

    private void Awake()
    {
        iconRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);


        if (player.transform.position.y < transform.position.y - height )
        {
            iconRenderer.sortingLayerName = changeLayerName;
            iconRenderer.sortingOrder = 0;

        }
        else
        {
            iconRenderer.sortingLayerName = normalLayerName;
            iconRenderer.sortingOrder = 0;

        }


    
    
            
       
            
        
    }
}
