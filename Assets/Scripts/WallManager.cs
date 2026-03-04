using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class WallManager : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject container;
    [SerializeField] float height;
    [SerializeField] float length;
    [SerializeField] float horzSpacing;
    [SerializeField] float horzSpacer;
    [SerializeField] float vertSpacing;
    [SerializeField] float vertSpacer;
    [SerializeField] float power;
    [SerializeField] private InputActionReference blowUpBoxAction;
    [SerializeField] private InputActionReference resetBoxAction;
    [SerializeField] private InputActionReference removeBoxAction;

    void Start()
    {
        SpawnBox();
    }

    private void OnEnable()
    {
        blowUpBoxAction.action.Enable();
        blowUpBoxAction.action.performed += OnBlowUpBox;

        resetBoxAction.action.Enable();
        resetBoxAction.action.performed += OnResetBox;

        removeBoxAction.action.Enable();
        removeBoxAction.action.performed += OnRemoveBox;
    }

    private void OnDisable()
    {
        blowUpBoxAction.action.performed -= OnBlowUpBox;
        blowUpBoxAction.action.Disable();

        resetBoxAction.action.performed -= OnResetBox;
        resetBoxAction.action.Disable();

        removeBoxAction.action.performed -= OnRemoveBox;
        removeBoxAction.action.Disable();
    }

    void SpawnBox()
    {
        for (float vertical = 0; vertical < height; vertical++)
        {
            for (float horizontal = 0; horizontal < length; horizontal++)
            {
                //Spawns a cube for each column then row, as a child of the container aka container.transform
                Instantiate(cubePrefab, container.transform.position + new Vector3(0, vertSpacing, horzSpacing), quaternion.identity, container.transform);
                horzSpacing = horzSpacing + horzSpacer;
            }
            vertSpacing = vertSpacing + vertSpacer;
            horzSpacing = 0f;
        }
        vertSpacing = 0f;
    }

    private void OnBlowUpBox(InputAction.CallbackContext context)
    {
        foreach (Transform child in container.transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            {
                rb.AddRelativeForce(UnityEngine.Random.onUnitSphere * power, ForceMode.Impulse);
            }
        }
    }

    private void OnRemoveBox(InputAction.CallbackContext context)
    {
        foreach (Transform child in container.transform)
        {
            Destroy(child.gameObject);
        }
    }

        private void OnResetBox(InputAction.CallbackContext context)
    {
        SpawnBox();
    }
}
