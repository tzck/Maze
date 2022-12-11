using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class Tracking : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform[] points;
    private int current = 0;
    private float maxDist = 5.0f;
    private float minDist = 1.0f;
    private float speed = 8.0f;

    private float runSpeed = 11.0f;
    private float normSpeed = 8.0f;
    public Transform player;
    private Animator animator;
    private bool sighted = false;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator.GetComponent<Animator>();
        agent.autoBraking = false;
        //agent.updatePosition = false;
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        //animator.SetInteger("con", 0);
        if (Vector3.Distance(transform.position, player.position) <= maxDist)
        {
            speed = runSpeed;
            sighted = true;
            transform.LookAt(player);               
            //transform.position += transform.forward * speed * Time.deltaTime;
            // animator.SetInteger("con", 3); //shout
            // animator.SetInteger("con", 2);
            

            if (Vector3.Distance(transform.position, player.position) <= minDist)
            {
                //if (worldDeltaPosition.magnitude > agent.radius)
                    //transform.position = agent.nextPosition - 0.9f*worldDeltaPosition;
            }   
        } else {
            sighted = false;
            speed = normSpeed;
            // animator.SetInteger("con", 1);
        }
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f && sighted == false) {
            speed = normSpeed;
            GotoNextPoint();
        }
    }

     void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[current].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        current = (current + 1) % points.Length;
    }
}
