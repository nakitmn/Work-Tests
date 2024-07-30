using System.Linq;
using Assets.Scripts.Enemy_Module;
using UnityEngine;

namespace Enemy_Module
{
    public static class EnemySensorExtensions
    {
        public static Enemy GetNearest(this EnemySensor sensor, Vector3 origin)
        {
            return sensor.DetectedEnemies
                .OrderBy(it => Vector3.Distance(it.transform.position, origin))
                .FirstOrDefault();
        }
    }
}