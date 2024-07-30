using UnityEngine;

namespace Input_Module
{
    public interface IPlayerInput
    {
        Vector2 MovementDirection { get; }
    }
}