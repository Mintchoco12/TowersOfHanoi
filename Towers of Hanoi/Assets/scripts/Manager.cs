using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject ringPrefab;
    public GameObject holdingRing;

    public GameWinScreen gameWinScreen;

    public float currentTime;
    public Text timeText;
    public Text winTimeText;
    public bool timerActive;

    public bool won = false;

    //Selects the number of rings
    [Range(2, 7)]
    public int numberOfRings = 5;

    private void Start()
    {
        //Generates the towers
        var leftTower = Instantiate(towerPrefab);
        leftTower.transform.position = new Vector3(-10, 0, 0);
        leftTower.GetComponent<Tower>().manager = gameObject;

        var middleTower = Instantiate(towerPrefab);
        middleTower.transform.position = new Vector3(0, 0, 0);
        middleTower.GetComponent<Tower>().manager = gameObject;

        var rightTower = Instantiate(towerPrefab);
        rightTower.transform.position = new Vector3(10, 0, 0);
        rightTower.GetComponent<Tower>().manager = gameObject;

        //Generates the rings
        for (int i = 0; i < numberOfRings; i++)
        {
            var ring = Instantiate(ringPrefab);
            ring.GetComponent<Ring>().width = numberOfRings - i + 1;
            leftTower.GetComponent<Tower>().rings.Add(ring);
        }

        //Starts the timer
        currentTime = 0;
        StartTimer();
    }

    public void Update()
    {
        //Shows the timer
        if (timerActive == true)
        {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
    }

    //Shows timer in minutes:seconds
    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        winTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    //Lifts the ring 
    public void Lift(GameObject ring)
    {
        holdingRing = ring;
        holdingRing.transform.position = new Vector3(0, 8, 0);
    }

    //Drops the ring to the tower
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

    //Shows the winscreen
    public void Won()
    {
        won = true;
        StopTimer();
        gameWinScreen.Setup();
        gameObject.SetActive(false);
    }

    //Starts the timer
    public void StartTimer()
    {
        timerActive = true;
    }

    //Stops the timer
    public void StopTimer()
    {
        timerActive = false;
    }
}
