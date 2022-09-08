using System;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    public bool isMoneyHere = false;
    public GameObject shredPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (ObjectMove.movingObjectIndex == 1)
        {
            shredPanel.SetActive(true);
            isMoneyHere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isMoneyHere)
        {
            shredPanel.SetActive(false);
            isMoneyHere = false;
        }
    }
}
