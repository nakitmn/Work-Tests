using UnityEngine;

namespace Assets.Scripts.Camera_Module
{
    public static class CameraExtensions
    {
        public static Vector2 GetHalfSize(this Camera camera, float sizeModifier = 1f)
        {
            var size = camera.orthographicSize * sizeModifier;

            return new(size * camera.aspect, size);
        }

        public static Vector3 GetBottomLeftCorner(this Camera camera, float sizeModifier = 1f)
        {
            var halfSize = camera.GetHalfSize(sizeModifier);
            var position = camera.transform.position;

            return new(
                position.x - halfSize.x,
                position.y - halfSize.y,
                position.z
            );
        }

        public static Vector3 GetBottomRightCorner(this Camera camera, float sizeModifier = 1f)
        {
            var halfSize = camera.GetHalfSize(sizeModifier);
            var position = camera.transform.position;

            return new(
                position.x + halfSize.x,
                position.y - halfSize.y,
                position.z
            );
        }
    }
}