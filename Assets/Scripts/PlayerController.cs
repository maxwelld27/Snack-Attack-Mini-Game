using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float horizontalInput;
    public float forwardInput;
    private Rigidbody rb;
    public int score = 0;

     // A matrix that holds a 45-degree rotation around the Y-axis
    private Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 rawInput = new Vector3(horizontalInput, 0, forwardInput).normalized;

        // 2. Skew the input using the isometric matrix
        Vector3 skewedInput = isoMatrix.MultiplyPoint3x4(rawInput);

        // 3. Move the player via Rigidbody
        if (rawInput.magnitude > 0.1f)
        {
            Vector3 movement = skewedInput * speed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);

            // Optional: Rotate player to face direction of movement
            Quaternion targetRotation = Quaternion.LookRotation(skewedInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
           
        }

    }
     
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("good"))
        {
            score++;
            Debug.Log(score);
        }
        else if(other.CompareTag("bad"))
        {
            score--;
            Debug.Log(score);
        }
       
    }
}
