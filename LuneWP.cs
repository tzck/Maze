using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LuneWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentPoint = 0;
    private float speed = 8.0f;
    //private float runSpeed = 11.0f;
    // private float gravity = 20.0f;
    private Animator animator;
    private bool end = false;
    public NavMeshAgent agent;
    private Transform goal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("condition", 0);
        if (end) {
            Reverse();
        } else {
            if (Vector3.Distance(this.transform.position, waypoints[currentPoint].transform.position) < 0.5) {
            currentPoint++;
            }
            if (currentPoint >= waypoints.Length) {
            end = true;
            }
        }
        
        
        animator.SetInteger("condition", 1);
        goal = waypoints[currentPoint].transform;
        this.transform.LookAt(waypoints[currentPoint].transform);
        agent.SetDestination(goal.position);
        //this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void Reverse() {
        currentPoint = waypoints.Length;
        if (Vector3.Distance(this.transform.position, waypoints[currentPoint].transform.position) < 0.5) {
            currentPoint--;
        }
        if (currentPoint == 0) {
            end = false;
        }
    }
}
