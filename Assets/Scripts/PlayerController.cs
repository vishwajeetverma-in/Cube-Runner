using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag== "Obstacle")
        {
            SceneManager.LoadScene("Level1");
        }
    }
}

// Spawn the obstacle again and again.empty gameobject "GameManager" will take care of it.



























// when mouse is clicked once jump is fine but when mouse is clicked again (when player is still in the air) it again starts jumping from air to more height.
//  we want that it's next jump should be when it comes down on the ground.For this 
// execution sequence | Awake - Start - (*Physics* FixedUpdate - OnTrigger-OnCollision) - (*Input events* OnMouseDown) - Update - LateUpdate -(*The last* OnDestroy)
// use a temp bool variable "canJump" can to achieve this . when mouses is clicked and canbool is true "then only" force will be applied. the truth value of this variable 
// is controlled inside methods OnCollisionEnter (when player is in contact with ground (colliders are touching each other)) in this case assign "canJump = true"
//                              OnCollisionExit (when player isn't in contact with ground (colliders are not touching each other)) in this case assign "canJump = false"
// As collison runs before Update() so bool value can be changed according to collison and then condition will be applid on force. 
