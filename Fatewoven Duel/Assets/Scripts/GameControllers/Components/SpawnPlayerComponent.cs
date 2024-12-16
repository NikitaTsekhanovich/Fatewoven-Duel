using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct SpawnPlayerComponent
    {
        public Transform RespawnPointPlayer1;
        public Transform RespawnPointPlayer2;
        public GameObject Player1;
        public GameObject Player2;
        public GameObject Player1AI;
        public GameObject Player2AI;
    }
}

