using UnityEngine;
using LunarflyArts;
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerAnimatorHandler playerAnimatorHandler;
    private PlayerActionsManager playerActionsManager;
    private PlayerLifeSystem playerLifeSystem;
    private void Awake()
    {
        playerActionsManager = GetComponent<PlayerActionsManager>();
        playerAnimatorHandler = GetComponent<PlayerAnimatorHandler>();
        playerLifeSystem = GetComponent<PlayerLifeSystem>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerActionsManager.SetIsJumping(false);
        }
        if (other.gameObject.CompareTag("Key Item"))
        {
            Debug.Log("Key Item Collected");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Slime"))
        {
            playerLifeSystem.LoseLife();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kill Plane"))
        {
            // Freeze the time
            // There is still no proper death animation
            Time.timeScale = 0f;
        }
        if (other.gameObject.CompareTag("Light Orb"))
        {
            Destroy(other.gameObject);
            Debug.Log("Light Orb Collected");
        }
        if(other.gameObject.CompareTag("Slime")){
            Destroy(other.gameObject);
            Debug.Log("Slime Killed");
        }
    }
}