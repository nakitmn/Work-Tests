using UnityEngine;

namespace Input_Module
{
    public sealed class KeyboardPlayerInput : IPlayerInput
    {
        public Vector2 MovementDirection => new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
         ).normalized;
    }
}