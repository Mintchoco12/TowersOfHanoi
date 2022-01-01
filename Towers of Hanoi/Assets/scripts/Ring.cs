using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float width;

    private void OnMouseDown()
    {
        
    }

    private void Update()
    {
        gameObject.transform.localScale = new Vector3(width, 1, 1);
    }
}
