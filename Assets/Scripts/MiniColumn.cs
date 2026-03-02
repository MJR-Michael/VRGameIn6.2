using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class MiniColumn : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject container;
    [SerializeField] float height;
    [SerializeField] float length;
    [SerializeField] float horzSpacing;
    [SerializeField] float horzSpacer;
    [SerializeField] float vertSpacing;
    [SerializeField] float vertSpacer;

    void Start()
    {
        for (float vertical = 0; vertical < height; vertical++)
        {
            horzSpacing = 0f;
            for (float horizontal = 0; horizontal < length; horizontal++)
            {
                Instantiate(cubePrefab, new Vector3(horzSpacing, vertSpacing, 0), Quaternion.identity);
                horzSpacing = horzSpacing + horzSpacer;
            }
            vertSpacing = vertSpacing + vertSpacer;
        }
    }

    void Update()

    //switch to new input system soon
    //inputActions.Player.RemoveCollider.performed
    {
        if (Input.GetButtonDown("DeleteAll"))
        {
            Destroy(container);
        }
    }
}
