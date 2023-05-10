using UnityEngine;

namespace LunarflyArts
{
    public class PlayerLifeSystem : MonoBehaviour
    {
        private GameObject[] playerHearts;
        private int playerMaxHeart = 3;
        private bool canLoseLife = true;
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
                // Freeze the time
                // There is still no proper death animation
                Time.timeScale = 0f;
            }

            canLoseLife = false;
            Invoke("ResetLoseLifeCooldown", loseLifeCooldown);
        }

        private void ResetLoseLifeCooldown()
        {
            canLoseLife = true;
        }

    }
}