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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sigil"))
        {
            sigilsInRange.Add(other.gameObject);

            if (sigilsInRange.Count > 0)
            {
                playerActionsManager.SetCanGrapple(true);
            }

            playerActionsManager.IsLightSigilDetected = true;
        }

        if(other.gameObject.CompareTag("Kill Plane")){
            // Freeze the time
            // There is still no proper death animation
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        sigilsInRange.Remove(other.gameObject);

        if (sigilsInRange.Count == 0)
        {
            playerActionsManager.SetCanGrapple(false);
        }
    }
}