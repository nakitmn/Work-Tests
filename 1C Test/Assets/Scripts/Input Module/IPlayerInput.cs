using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Input_Module
{
    public interface IPlayerInput
    {
        Vector2 MovementDirection { get; }
    }
}