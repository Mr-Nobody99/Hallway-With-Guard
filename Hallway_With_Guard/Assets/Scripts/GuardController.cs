using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour {

    private Animator animator;
    private float distance;
    public float agroRange;

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
        agroRange = 10;
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

        if (distance > agroRange)
        {
            animator.SetBool("Walking", false);
            animator.SetBool("CombatStance", false);
            _navMeshAgent.isStopped = true;
        }
        else if (distance < agroRange)
        {
            _navMeshAgent.isStopped = false;
            animator.SetBool("CombatStance", false);
            animator.SetBool("Walking", true);
            SetDestination();
        }
        if (distance <= 2.5f)
        {
            animator.ResetTrigger("Attack");
            animator.SetBool("Walking", false);
            animator.SetBool("CombatStance", true);
            _navMeshAgent.isStopped = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        print("Attack");
        //animator.ResetTrigger("Attack");
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        //StartCoroutine(Attack());
    }

    private void SetDestination()
    {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
    }
}
