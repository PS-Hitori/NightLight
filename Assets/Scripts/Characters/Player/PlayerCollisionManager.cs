using UnityEngine;
using LunarflyArts;
using System.Collections.Generic;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerAnimatorHandler playerAnimatorHandler;
    private PlayerActionsManager playerActionsManager;
    public List<GameObject> sigilsInRange = new List<GameObject>();

    private void Awake()
    {
        playerActionsManager = GetComponent<PlayerActionsManager>();
        playerAnimatorHandler = GetComponent<PlayerAnimatorHandler>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerActionsManager.SetIsJumping(false);
        }
        if(other.gameObject.CompareTag("Key Item")){
            Debug.Log("Key Item Collected");
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Slime")){
            // Freeze the time
            // There is still no proper death animation
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Kill Plane")){
            // Freeze the time
            // There is still no proper death animation
            Time.timeScale = 0f;
        }

        if(other.gameObject.CompareTag("Light Orb")){
            Destroy(other.gameObject);
            Debug.Log("Light Orb Collected");
        }
    }
}