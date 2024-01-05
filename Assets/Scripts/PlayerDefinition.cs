using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "PlayerDefinition", menuName = "PlayerDefinition")]
    public class PlayerDefinition : ScriptableObject
    {
        public GameObject model;
        public PlayerMovementData MovementData;

    }
}