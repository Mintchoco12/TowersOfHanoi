using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject manager;
    public List<GameObject> rings = new List<GameObject>();

    //Checks for mouseinput
    private void OnMouseDown()
    {
        //Holds ring if it isn't already holding one
        if (manager.GetComponent<Manager>().holdingRing == null)
        {
            manager.GetComponent<Manager>().Lift(rings[rings.Count - 1]);
            rings.Remove(rings[rings.Count - 1]);
        }
        //Drops the ring
        else
        {
            manager.GetComponent<Manager>().Drop(gameObject);
        }
    }

    private void Update()
    {
        //Makes new rings smaller and puts them on top of the previous ring
        for (int i = 0; i < rings.Count; i++)
        {
            rings[i].transform.position = new Vector3(gameObject.transform.position.x, i - 4, 0);
        }

        //Checks win condition
        if (rings.Count == manager.GetComponent<Manager>().numberOfRings && gameObject.transform.position.x == 10 && manager.GetComponent<Manager>().won == false)
        {
            manager.GetComponent<Manager>().Won();
        }
    }
}
