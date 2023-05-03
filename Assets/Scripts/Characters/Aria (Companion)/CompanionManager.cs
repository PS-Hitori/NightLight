using UnityEngine;
using System.Collections;
namespace LunarflyArts
{
    [RequireComponent(typeof(CompanionAIFollow))]
    public class CompanionManager : MonoBehaviour
    {
        private CompanionManager _instance;
        public CompanionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<CompanionManager>();
                }
                return _instance;
            }
        }
    }
}