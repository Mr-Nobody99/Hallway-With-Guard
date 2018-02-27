using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour {

    private Animator animator;
    private float distance;

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("Nav mesh agent component not attached to " + gameObject);
        }     
	}

    private void Update()
    {
            distance = Vector3.Distance(transform.position, _destination.position);
            print(distance);
            if(distance > 2.5f)
            {
                _navMeshAgent.isStopped = false;
                animator.SetBool("Walking", true);
                SetDestination();
            }
            else
            {
                animator.SetBool("Walking", false);
                _navMeshAgent.isStopped = true;
            }
    }

    private void SetDestination()
    {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
    }
}
