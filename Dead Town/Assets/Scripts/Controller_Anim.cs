using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Anim : MonoBehaviour
{
    Animator animator; // references the component being used.
    public CharacterController Control;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // gets the component from Unity
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }


    void Movement()
    {
        
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(Horizontal, 0, Vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            Control.Move(speed * direction * Time.deltaTime);

            float target = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, target, 0f);
        }

        Animation_Move();
        
    }

    void Animation_Move()
    {
        bool Forward = Input.GetKey("w");
        bool Backward = Input.GetKey("s");
        bool Left = Input.GetKey("a");
        bool Right = Input.GetKey("d");

        // if the corresponding key is pressed boolean Move is set to true
        if (Forward)
        {
            animator.SetBool("Forward", true);
        }

        if (Backward)
        {
            animator.SetBool("Backward", true);
        }

        if (Left)
        {
            animator.SetBool("Left", true);
        }

        if (Right)
        {
            animator.SetBool("Right", true);
        }

        // if the corresponding key is released then the boolean Move is set to false
        if (!Forward)
        {
            animator.SetBool("Forward", false);
        }

        if (!Backward)
        {
            animator.SetBool("Backward", false);
        }

        if (!Left)
        {
            animator.SetBool("Left", false);
        }

        if (!Right)
        {
            animator.SetBool("Right", false);
        }
    }
}
