using UnityEngine;

namespace LunarflyArts
{
    [CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue System/ Create Speaker")]
    [System.Serializable]
    public class Speaker : ScriptableObject
    {
        public string speakerName;
    }
}
