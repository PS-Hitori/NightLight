using UnityEngine;
using LunarflyArts;
[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerAnimatorHandler playerAnimatorHandler;
    private PlayerActionsManager playerActionsManager;
    private PlayerLifeSystem playerLifeSystem;
    private int lightOrbCounter = 0;
    private void Awake()
    {
        playerActionsManager = GetComponent<PlayerActionsManager>();
        playerAnimatorHandler = GetComponent<PlayerAnimatorHandler>();
        playerLifeSystem = GetComponent<PlayerLifeSystem>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Key Item"))
        {
            Debug.Log("Key Item Collected");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerLifeSystem.LoseLife();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kill Plane"))
        {
            playerLifeSystem.KillPlayer();
        }
        if (other.gameObject.CompareTag("Hearts"))
        {
            Destroy(other.gameObject);
            Debug.Log("Heart collected");
            playerLifeSystem.GainLife();
        }
        if (other.gameObject.CompareTag("Key Item"))
        {
            Debug.Log("Key Item Collected");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Light Orb"))
        {
            Debug.Log("Light Orb Collected");
            Destroy(other.gameObject);
            lightOrbCounter++;
            Debug.Log("Light Orb Counter: " + lightOrbCounter);
        }
    }

    public int LightOrbCounter
    {
        get { return lightOrbCounter; }
        set { lightOrbCounter = value; }
    }
}