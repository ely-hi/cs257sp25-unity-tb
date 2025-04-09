using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevMashAnimator : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMesh;
    Animator animator;
    void Awake()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetFloat("Velocity", navMesh.velocity.magnitude);
    }
}
