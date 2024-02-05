using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace HoJin.InteractionSystem
{
    public class InputSystemInteractionInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference interaction;
        [SerializeField] private InputActionReference selectionCanceling;
        private Interactor interactor;



        private void OnEnable()
        {
            interaction.action.Enable();
            selectionCanceling.action.Enable();
        }
        private void Awake()
        {
            TryGetComponent(out interactor);
        }
        private void Start()
        {
            interaction.action.started += OnInteractionStarted;
            interaction.action.performed += OnInteractionPerformed;
            interaction.action.canceled += OnInteractionCanceled;
        }
        private void OnDisable()
        {
            interaction.action.Disable();
            selectionCanceling.action.Disable();
        }



        private void OnInteractionStarted(InputAction.CallbackContext callbackContext)
        {
            interactor.OnInteractionStarted();
        }
        private void OnInteractionPerformed(InputAction.CallbackContext callbackContext)
        {
            interactor.OnInteractionPerformed();
        }
        private void OnInteractionCanceled(InputAction.CallbackContext callbackContext)
        {
            interactor.OnInteractionCanceled();
        }
    }
}