using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Singleton { get; private set; }


    [Header("Left Hand")]
    [SerializeField] private InputActionProperty _leftHandActivate;
    [SerializeField] private InputActionProperty _leftHandSelect;
    // [SerializeField] private InputActionProperty _leftHandJoystick;

    [Header("Right Hand")]
    [SerializeField] private InputActionProperty _rightHandActivate;
    [SerializeField] private InputActionProperty _rightHandSelect;
    // [SerializeField] private InputActionProperty _rightHandJoystick;


    public bool IsLeftHand_TriggerHold { get; private set; } = false;
    public bool IsLeftGripHold { get; private set; } = false;

    public bool IsRightHand_TriggerHold { get; private set; } = false;
    public bool IsRightHand_GripHold { get; private set; } = false;

    public bool AButtonPressed { get; private set; } = false;
    public bool BButtonPressed { get; private set; } = false;
    
    public bool XButtonPressed { get; private set; } = false;
    public bool YButtonPressed { get; private set; } = false;
    
    public Vector2 LeftHand_Joystick2DValue { get; private set; } = Vector2.zero;
    public Vector2 RightHand_Joystick2DValue { get; private set; } = Vector2.zero;

    private readonly float HOLD_THRESHOLD = 0.01f;

    void Awake()
    {
        Singleton = this;
    }

    void OnDestroy()
    {
        Singleton = null;
    }

    void Update()
    {
        IsLeftHand_TriggerHold = _leftHandActivate.action.ReadValue<float>() >= HOLD_THRESHOLD;
        IsLeftGripHold = _leftHandSelect.action.ReadValue<float>() >= HOLD_THRESHOLD;

        IsRightHand_TriggerHold = _rightHandActivate.action.ReadValue<float>() >= HOLD_THRESHOLD;
        IsRightHand_GripHold = _rightHandSelect.action.ReadValue<float>() >= HOLD_THRESHOLD;

        AButtonPressed = Input.GetKey(KeyCode.JoystickButton0);
        BButtonPressed = Input.GetKey(KeyCode.JoystickButton1);
        
        XButtonPressed = Input.GetKey(KeyCode.JoystickButton2);
        YButtonPressed = Input.GetKey(KeyCode.JoystickButton3);

        // LeftHand_Joystick2DValue = _leftHandJoystick.action.ReadValue<Vector2>();
        // RightHand_Joystick2DValue = _rightHandJoystick.action.ReadValue<Vector2>();
    }
}