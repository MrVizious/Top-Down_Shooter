using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    [Range(0, 10)]
    private float maxRange = 7f;
    private Vector2 _worldPosition;
    private Vector2 worldPosition
    {
        get
        {
            return Vector2.ClampMagnitude(_worldPosition - (Vector2)transform.position, maxRange) + (Vector2)transform.position;
        }
        set
        {
            _worldPosition = value;
        }
    }
    private void Update()
    {
        target.position = worldPosition;
    }

    public virtual void Look(InputAction.CallbackContext c)
    {
        Vector2 input = c.ReadValue<Vector2>();
        // Mouse controls
        if (c.action.activeControl.device.displayName.ToLower().Equals("mouse"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        }
        else if (c.action.activeControl.device.displayName.ToLower().Equals("gamepad"))
        {
            worldPosition = (Vector2)transform.position + input * maxRange;
        }
        else
        {
            worldPosition = Vector2.zero;
        }

    }
}
