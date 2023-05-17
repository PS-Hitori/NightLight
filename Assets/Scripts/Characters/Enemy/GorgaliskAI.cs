using UnityEngine;
using System.Collections;

namespace LunarflyArts
{
    public class GorgaliskAI : MonoBehaviour
    {
        public GameObject darkOrbPrefab;
        public GameObject lightOrbPrefab;
        public GameObject lightOrbSpawn;
        private int dodgeCount;
        public float orbSpeed = 2.5f;
        public float orbLifetime = 5f;
        public float attackInterval = 7.5f;
        private int bossHealth = 10;

        private Transform player;
        private float attackTimer = 0f;
        private bool canPerformAttack = true;

        private bool lightOrbSpawned = false;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            attackTimer = attackInterval;
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                PerformAttack();
                attackTimer = attackInterval;
                if (dodgeCount >= 3 && !lightOrbSpawned)
                {
                    dodgeCount = 0;
                    SpawnLightOrb();
                    lightOrbSpawned = true;
                }
                else
                {
                    dodgeCount++;
                }
            }
        }

        private void PerformAttack()
        {
            GameObject orb = Instantiate(darkOrbPrefab, transform.position, Quaternion.identity);
            Vector2 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
            orb.GetComponent<Rigidbody2D>().velocity = directionToPlayer * orbSpeed;
            StartCoroutine(Destroy(orb));
        }

        private IEnumerator Destroy(GameObject orb)
        {
            float timer = 0f;
            while (timer < orbLifetime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            Destroy(orb);
        }

        private void SpawnLightOrb()
        {
            GameObject lightOrb = Instantiate(lightOrbPrefab, new Vector3(Random.Range(-lightOrbSpawn.transform.position.x, lightOrbSpawn.transform.position.x), lightOrbSpawn.transform.position.y, 0f), Quaternion.identity);
            Rigidbody2D rb = lightOrb.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, -orbSpeed); // Set the velocity to fall from the sky
            lightOrbSpawned = true;
            dodgeCount = 0;
        }

        public void DamageBoss(int damageAmount)
        {
            bossHealth -= damageAmount;
            Debug.Log("Boss Health: " + bossHealth.ToString());
            if (bossHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        // Function to handle player collecting the light orb
        public void CollectLightOrb()
        {
            if (lightOrbSpawned)
            {
                DamageBoss(1); // Adjust the damage amount as desired
            }
        }

        private IEnumerator ResetAttackCooldown()
        {
            yield return new WaitForSeconds(2f); // Adjust the delay as desired
            canPerformAttack = true;
        }
    }
}
