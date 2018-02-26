using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float WalkSpeed = 2;
    public float runSpeed = 6;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if(inputDir != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = ((running) ? runSpeed : WalkSpeed) * inputDir.magnitude;

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        float speedFactor = ((running)?1:.5f)*inputDir.magnitude;
        animator.SetFloat("SpeedFactor",speedFactor);
	}
}
