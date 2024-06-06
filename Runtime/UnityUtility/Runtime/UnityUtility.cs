using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.UnityUtility
{
    public static class UnityUtility
    {
        #region Collider
        public static IEnumerable<Vector3> GetBoundsVertices(this BoxCollider boxCollider, Space space = Space.World)
        {
            Vector3 center = default;



            if (space.Equals(Space.World))
            {
                center = boxCollider.bounds.center;
            }
            else if (space.Equals(Space.Self))
            {
                center = boxCollider.center;
            }

            return new Vector3[]
            {
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(1f, 1f, 1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(1f, 1f, -1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(-1f, 1f, -1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(-1f, 1f, 1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(1f, -1f, 1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(1f, -1f, -1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(-1f, -1f, -1f)),
                center + Vector3.Scale(0.5f * boxCollider.bounds.size, new Vector3(-1f, -1f, 1f)),
            };
        }
        #endregion



        #region Component
        public static IEnumerable<T> Cast<T>(this IEnumerable<GameObject> enumerable) where T : Component
        {
            List<T> changed = new List<T>();



            foreach (GameObject item in enumerable)
            {
                if (item.TryGetComponent<T>(out T component))
                {
                    changed.Add(component);
                }
            }

            return changed;
        }
        public static IEnumerable<To> Cast<From, To>(this IEnumerable<From> enumerable) where From : Component where To : Component
        {
            List<To> changed = new List<To>();



            foreach (From item in enumerable)
            {
                if (item.TryGetComponent(out To component))
                {
                    changed.Add(component);
                }
            }

            return changed;
        }
        #endregion



        #region LayerMask
        public static bool IsInclude(this LayerMask layerMask, int layer)
        {
            return layerMask.value.Equals(layerMask | (1 << layer));
        }
        public static bool IsInclude(this LayerMask layerMask, LayerMask other)
        {
            return layerMask.Equals(layerMask | other);
        }
        #endregion
    }
}