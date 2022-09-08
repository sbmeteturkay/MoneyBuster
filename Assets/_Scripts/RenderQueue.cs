using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderQueue : MonoBehaviour
{
    [SerializeField] int queue = 3000;
    void Start()
    {
        GetComponent<MeshRenderer>().material.renderQueue = queue;
    }
}
