using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject ringPrefab;
    public GameObject holdingRing;

    public bool won = false;

    [Range(2, 7)]
    public int numberOfRings = 5;


    private void Start()
    {
        var leftTower = Instantiate(towerPrefab);
        leftTower.transform.position = new Vector3(-10, 0, 0);
        leftTower.GetComponent<Tower>().manager = gameObject;

        var middleTower = Instantiate(towerPrefab);
        middleTower.transform.position = new Vector3(0, 0, 0);
        middleTower.GetComponent<Tower>().manager = gameObject;

        var rightTower = Instantiate(towerPrefab);
        rightTower.transform.position = new Vector3(10, 0, 0);
        rightTower.GetComponent<Tower>().manager = gameObject;


        for (int i = 0; i < numberOfRings; i++)
        {
            var ring = Instantiate(ringPrefab);
            ring.GetComponent<Ring>().width = numberOfRings - i + 1;
            leftTower.GetComponent<Tower>().rings.Add(ring);
        }
    }

    public void Lift(GameObject ring)
    {
        holdingRing = ring;
        holdingRing.transform.position = new Vector3(0, 8, 0);
    }

    public void Drop(GameObject tower)
    {
        if (tower.GetComponent<Tower>().rings.Count == 0)
        {
            tower.GetComponent<Tower>().rings.Add(holdingRing);
            holdingRing = null;
        }
        else if (holdingRing.GetComponent<Ring>().width < tower.GetComponent<Tower>().rings[tower.GetComponent<Tower>().rings.Count - 1].GetComponent<Ring>().width)
        {
            tower.GetComponent<Tower>().rings.Add(holdingRing);
            holdingRing = null;
        }
    }

    public void Won()
    {
        Debug.Log("je heb gewonnen!!!!!!!!!");
    }
}
