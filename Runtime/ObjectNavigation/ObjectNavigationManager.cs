using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace InteractionSystem
{
    public class ObjectNavigationManager : MonoBehaviour
    {
        [Tooltip("Action asset reference for navigatoin moving.")]
        [SerializeField] private InputActionReference navigationMovingActionReference;

        [Tooltip("Objects that can move by this.")]
        [SerializeField] private Navigatable[] navigatables;

        [Tooltip("Initial object. If this field don't reference anything, the first in 'navigatables' is selected.")]
        [SerializeField] private GameObject initialNavigated;

        [Tooltip("Position : Navigation works by position of objects.\n" +
            "Order : Navigation works by order of 'navigatables'")]
        [SerializeField] private MovingType movingType;

        [Tooltip("Direction to navigate.")]
        [SerializeField] private Vector3 movingDirectionRotation;

        [Tooltip("If you choose the 'Position' moving type, the angle to be able navigate from navigation direction vector.")]
        [SerializeField] private float navigatableAngle = 45f;

        [Tooltip("<-Distance      Direction->\nRecommend to set value as integer.")]
        [SerializeField, Range(0, 1f)] private float searchingPriority;

        private InputAction navigationMovingAction;
        private Navigatable currentNavigated;
        public event Action<GameObject> OnMove;



        private void Awake()
        {
            navigationMovingAction = navigationMovingActionReference.action.Clone();
            navigationMovingAction.performed += MoveTo;
            navigationMovingAction.performed += (x) => OnMove?.Invoke(currentNavigated.gameObject);





            void MoveTo(InputAction.CallbackContext callbackContext)
            {
                Vector2 inputDirection = callbackContext.ReadValue<Vector2>();
                Vector3 direction = transform.rotation * Quaternion.Euler(movingDirectionRotation) * new Vector3(inputDirection.x, 0, inputDirection.y);

                GameObject moved = null;
                switch (movingType)
                {
                    case MovingType.Position:
                        moved = GetNearestObject();
                        break;
                    case MovingType.Order:
                        moved = GetNextOrder(inputDirection);
                        break;
                }

                if (moved.TryGetComponent(out Navigatable navigatable) && navigatable.IsNavigated && moved != currentNavigated.gameObject)
                {
                    currentNavigated = navigatable;
                }





                GameObject GetNearestObject()
                {
                    float smallestAngle = Mathf.PI * Mathf.Rad2Deg;
                    List<GameObject> onDirections = new List<GameObject>();
                    IEnumerable<Navigatable> among = navigatables.Except(new Navigatable[] { currentNavigated });



                    foreach (var item in among)
                    {
                        float angle = Vector3.Angle(item.transform.position - currentNavigated.transform.position, direction);
                        if (angle <= navigatableAngle)
                        {
                            float angleWithWeight = Mathf.Lerp(smallestAngle, angle, searchingPriority);
                            if (smallestAngle >= angleWithWeight)
                            {
                                if (smallestAngle > angleWithWeight)
                                {
                                    smallestAngle = angle;
                                    onDirections.Clear();
                                }
                                onDirections.Add(item.gameObject);
                            }
                        }
                    }



                    GameObject nearest;
                    try
                    {
                        nearest = onDirections.Where((x) => x.GetComponent<Navigatable>().IsNavigated &&
                                Vector3.Distance(x.transform.position, currentNavigated.transform.position) > 0).
                            OrderBy((x) => Vector3.Distance(x.transform.position, currentNavigated.transform.position)).
                            FirstOrDefault().gameObject;
                    }
                    catch (NullReferenceException)
                    {
                        nearest = currentNavigated.gameObject;
                    }

                    return nearest;
                }
                GameObject GetNextOrder(Vector2 direction)
                {
                    return navigatables.Where((x) => x.IsNavigated).ToArray()
                            [(Array.IndexOf(navigatables, currentNavigated) + navigatables.Length + (int)direction.x) % navigatables.Length].gameObject;
                }
            }
        }
        private void OnEnable()
        {
            navigationMovingAction.Enable();
        }
        private void Start()
        {
            currentNavigated = initialNavigated ? initialNavigated.GetComponent<Navigatable>() : navigatables.First((x) => x.IsNavigated);
        }
        private void OnDisable()
        {
            navigationMovingAction.Disable();
        }
    }
}