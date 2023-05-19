using UnityEngine;

public class BatAI : MonoBehaviour
{
    public Transform player;
    private GameObject lightOrbPrefab;
    public float attackChargeTime = 2f;
    public float chargeSpeed = 10f;
    public float retreatDistance = 5f;
    public float attackRadius = 5f;

    private bool isCharging = false;
    private bool isRetreating = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRadius && !isCharging && !isRetreating)
        {

            StartCoroutine(ChargeAttack());
        }
        else if (!isCharging && !isRetreating)
        {

            StartCoroutine(ChargeAttack());
        }
        else if (isCharging)
        {

            Vector3 direction = player.position - transform.position;
            transform.Translate(direction.normalized * chargeSpeed * Time.deltaTime);


            if (distanceToPlayer <= 1f)
            {
                StopCharging();
            }
        }
        else if (isRetreating)
        {

            Vector3 direction = transform.position - player.position;
            transform.Translate(direction.normalized * chargeSpeed * Time.deltaTime);


            if (distanceToPlayer >= retreatDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator ChargeAttack()
    {
        isCharging = true;


        yield return new WaitForSeconds(attackChargeTime);

        isCharging = false;
        isRetreating = true;
    }

    private void StopCharging()
    {
        isCharging = false;
        isRetreating = true;
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            if (collider2D.transform.position.y > transform.position.y + 0.5f)
            {
                Destroy(gameObject);
                // Load the light orb prefab
                lightOrbPrefab = Resources.Load<GameObject>("Assets/Prefabs/Pickup/Light Orb");
                // Instantiate the light orb prefab
                Instantiate(lightOrbPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
