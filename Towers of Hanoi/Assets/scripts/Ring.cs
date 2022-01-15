using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float width;

    private void Update()
    {
        //Changes the scale
        gameObject.transform.localScale = new Vector3(width, 1, 1);
    }
}
