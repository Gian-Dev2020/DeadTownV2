using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{
    public CharacterController controller; // references the controller from unity
    
    public float speed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        // When run it'll range from -1 to 1 (-1 being either the left of down axis)
        float Horizontal = Input.GetAxisRaw("Horizontal"); //Raw axis does not give any input smoothing
        float Vertical = Input.GetAxisRaw("Vertical");

        // Vector 3 works on x, y, z. So Horizontal would be x, 0 would be y, and Vertical would be z
        // normalized ensures that if the character moves diagonaly it retains the same speed
        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Will move the character.
            // Time.deltaTime is from the last frame, it makes independent to the amount of time and frames since the character moved.
            controller.Move(direction * speed * Time.deltaTime);

            float Angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);
        }
    }
}
