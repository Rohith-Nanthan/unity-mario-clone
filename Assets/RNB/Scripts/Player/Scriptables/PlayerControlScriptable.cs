using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.Scriptables
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    [CreateAssetMenu(fileName = "NewPlayerControl", menuName = "RNB/PlayerScriptable/PlayerControl", order = 1)]
    public class PlayerControlScriptable : ScriptableObject
    {
        public float _MovementSpeedInGround = 5f;
        public float _MovementSpeedInAir = 5f;

        [Header("Falling Down")]
        public float _InitialFallingDownSpeed = 5f;
        public float _FallingDownAccleration = 9.8f;
        public float _MaxFallingDownSpeed = 30f;

        [Header("Jump")]
        public float _InitialJumpSpeed = 8f;
        public float _JumpSpeedDeaccleration = 9.8f;
    }
}
