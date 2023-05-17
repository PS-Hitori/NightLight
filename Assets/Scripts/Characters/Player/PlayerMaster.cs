using UnityEngine;

namespace LunarflyArts
{
    public class PlayerMaster : MonoBehaviour
    {
        [SerializeField] private GameObject[] _playerPrefabs;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start(){
            Instantiate(_playerPrefabs[0], transform.position, Quaternion.identity);
        }
        private void Update(){
            if(_gameManager.IsLilaHadLamp){
                Instantiate(_playerPrefabs[1], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if(_gameManager.IsLilaHadMetAria){
                Instantiate(_playerPrefabs[2], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }   
    }
}
