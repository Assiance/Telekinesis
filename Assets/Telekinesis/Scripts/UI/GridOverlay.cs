using Assets.Scripts.Framework;
using Assets.Telekinesis.Scripts.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.UI
{
    public class GridOverlay : ESMonoBehaviour
    {
        public Vector2 GridPosition;

        public float GridHeight = 100f;
        public float GridWidth = 100f;

        public float CellHeight = 1f;
        public float CellWidth = 1f;

        //CellSize divided by the Fixed Steps Per Second
        public static float CellPerSecondSpeed
        {
            get
            {
                var stepsPerSecond = 1.0f / Time.fixedDeltaTime;
                return 1.0f / stepsPerSecond;
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            for (float y = GridPosition.y; y <= GridHeight; y += CellHeight)
            {
                Gizmos.DrawLine(new Vector3(GridPosition.x, y, 0.0f),
                                new Vector3(GridWidth, y, 0.0f));
            }

            for (float x = GridPosition.x; x <= GridWidth; x += CellWidth)
            {
                Gizmos.DrawLine(new Vector3(x, GridPosition.y, 0.0f),
                                new Vector3(x, GridHeight, 0.0f));
            }
        }
    }
}
