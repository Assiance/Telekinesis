using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Extensions
{
    public static class TransformExtensions
    {
        public static void Translate(this Transform target, Vector2 vector2, float z)
        {
            target.Translate(vector2.x, vector2.y, z);
        }
    }
}
