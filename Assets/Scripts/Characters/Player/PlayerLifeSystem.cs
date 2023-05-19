using UnityEngine;
using System.Collections;
namespace LunarflyArts
{
    public class PlayerLifeSystem : MonoBehaviour
    {
        private GameObject[] playerHearts;
        private int playerMaxHeart = 3;
        private bool canLoseLife = true;
        private bool isPlayerDead = false;
        private float loseLifeCooldown = 1.0f;


        private void Awake()
        {
            Canvas uiCanvas = FindObjectOfType<Canvas>();
            playerHearts = new GameObject[playerMaxHeart];
            playerHearts = GameObject.FindGameObjectsWithTag("Hearts");
        }
        public void LoseLife()
        {
            if (!canLoseLife) return;

            for (int i = playerMaxHeart - 1; i >= 0; i--)
            {
                if (playerHearts[i].activeSelf)
                {
                    playerHearts[i].SetActive(false);
                    break;
                }
            }

            if (playerHearts[0].activeSelf == false)
            {
                isPlayerDead = true;
                Time.timeScale = 0f;
            }

            canLoseLife = false;
            StartCoroutine(ResetLoseLifeCooldown());
        }

        public void KillPlayer(){
            isPlayerDead = true;
            Time.timeScale = 0f;
        }
        public void GainLife()
        {
            for (int i = 0; i < playerMaxHeart; i++)
            {
                if (playerHearts[i].activeSelf == false)
                {
                    playerHearts[i].SetActive(true);
                    break;
                }
            }
        }

        private IEnumerator ResetLoseLifeCooldown()
        {
            yield return new WaitForSeconds(loseLifeCooldown);
            canLoseLife = true;
        }

        public bool IsPlayerDead()
        {
            return isPlayerDead;
        }
    }
}