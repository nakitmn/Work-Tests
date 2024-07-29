using Assets.Scripts.Camera_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Border_Module
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
    }
}