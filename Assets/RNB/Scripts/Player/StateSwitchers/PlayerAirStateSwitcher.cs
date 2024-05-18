using RNB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.StateSwitcher
{
    public enum Airstates
    {
        NotInAir,
        FallingDown,
        Jumping
    }

    public class PlayerAirStateSwitcher : FSM_SwitcherBase<Airstates>
    {

    }
}