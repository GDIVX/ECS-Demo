using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "PlayerMovementData")]
    public class PlayerMovementData : ScriptableObject, IMovementData
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpForce;

        public float GetJumpForce()
        {
            return _jumpForce;
        }

        public float GetMovementSpeed()
        {
            return _movementSpeed;
        }

    }
}