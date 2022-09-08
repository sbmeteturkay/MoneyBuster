using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderQueue : MonoBehaviour
{
    [SerializeField] int queue = 3000;
    private void OnEnable()
    {
        GetComponent<MeshRenderer>().material.renderQueue = queue;
    }
}
