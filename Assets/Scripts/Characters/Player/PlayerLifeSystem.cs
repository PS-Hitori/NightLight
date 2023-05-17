using UnityEngine;
using System.Collections;
namespace LunarflyArts
{
    public class PlayerLifeSystem : MonoBehaviour
    {
        private GameObject[] playerHearts;
        private int playerMaxHeart = 3;
        private bool canLoseLife = true;
        private float loseLifeCooldown = 1.0f;
        private GameObject gameOverScreen;
        private GameObject UIControlScheme;

        private void Awake()
        {
            Canvas uiCanvas = FindObjectOfType<Canvas>();
            playerHearts = new GameObject[playerMaxHeart];
            playerHearts = GameObject.FindGameObjectsWithTag("Hearts");
            gameOverScreen = GameObject.Find("Game Over");
            UIControlScheme = GameObject.FindGameObjectWithTag("UI");
        }

        private void Start()
        {
            if (gameOverScreen == null) return;
            gameOverScreen.SetActive(false);
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
                gameOverScreen.SetActive(true);
                UIControlScheme.SetActive(false);
                Time.timeScale = 0f;
            }

            canLoseLife = false;
            StartCoroutine(ResetLoseLifeCooldown());
        }

        private IEnumerator ResetLoseLifeCooldown()
        {
            yield return new WaitForSeconds(loseLifeCooldown);
            canLoseLife = true;
        }

    }
}