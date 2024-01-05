using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private PlayerDefinition _playerDefinition;


        private void Start()
        {
            //Create a new player
            CreatePlayer();
        }

        public GameObject CreatePlayer()
        {
            //Create a new game object
            var player = new GameObject("Player");

            //Add a rigidbody
            var rigidbody = player.AddComponent<Rigidbody>();

            //if the definition has movement data, create a movement component
            var movement = _playerDefinition.MovementData != null ? MovementController.Create(player, _playerDefinition.MovementData) : null;

            //if the definition has a model, create it
            var model = _playerDefinition.model != null ? Instantiate(_playerDefinition.model, player.transform) : null;

            return player;
        }

    }
}