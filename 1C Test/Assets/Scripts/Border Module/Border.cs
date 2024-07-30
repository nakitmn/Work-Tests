using Camera_Module;
using UnityEngine;
using Zenject;

namespace Border_Module
{
    public sealed class Border : MonoBehaviour
    {
        private Camera _camera;

        public Vector2 TopLeft => new(_camera.GetBottomLeftCorner().x, transform.position.y);
        public Vector2 BottomRight => _camera.GetBottomRightCorner();

        [Inject] 
        public void Construct(Camera camera)
        {
            _camera = camera;
        }

        public bool IsInBorder(Vector3 position)
        {
            var topLeft = TopLeft;
            var bottomRight = BottomRight;

            return (position.x >= topLeft.x && position.x <= bottomRight.x) &&
                (position.y <= topLeft.y && position.y >= bottomRight.y);
        }

        public Vector3 Clamp(Vector3 position, float borderOffset = 0f)
        {
            var topLeft = TopLeft;
            var bottomRight = BottomRight;

            position.x = Mathf.Clamp(position.x, topLeft.x + borderOffset, bottomRight.x - borderOffset);
            position.y = Mathf.Clamp(position.y, bottomRight.y + borderOffset, topLeft.y - borderOffset);

            return position;
        }
    }
}