using System.Linq;
using UnityEngine;

namespace Enemy_Module
{
    public static class EnemySensorExtensions
    {
        public static Enemy GetNearest(this EnemySensor sensor, Vector3 origin)
        {
            return sensor.HasTargets
                ? sensor.DetectedEnemies
                    .OrderBy(it => Vector3.Distance(it.transform.position, origin))
                    .FirstOrDefault()
                : null;
        }
    }
}