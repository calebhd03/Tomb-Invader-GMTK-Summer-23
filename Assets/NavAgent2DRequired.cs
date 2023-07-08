using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent2DRequired : MonoBehaviour
{
    private void Awake()
    {
        NavMeshAgent agent= GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis= false;
    }
}
