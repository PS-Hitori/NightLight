using UnityEngine;
using System.Collections.Generic;
namespace LunarflyArts
{
    public class CompanionCollisionManager : MonoBehaviour
    {
        public List<GameObject> sigilsInRange = new List<GameObject>();
        private CompanionActionManager companionActionManager;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Ignore collision with player
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }

        }
    }
}