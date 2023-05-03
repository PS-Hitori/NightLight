using UnityEngine;
public enum CharacterUI
{
    Lila,
    Aria
}

public enum ControlScheme
{
    Keyboard,
    Xbox,
    PS4
}

public class ControlSchemeManager : MonoBehaviour
{
    public CharacterUI currentCharacterUI { get; private set; }
    public ControlScheme currentControlScheme { get; private set; }
    private Canvas lilaUI;
    private Canvas ariaUI;

    private GameObject PCInterface;
    private GameObject XboxInterface;
    private GameObject PS4Interface;

    private void Awake()
    {
        // Get the Canvas components
        lilaUI = GameObject.FindGameObjectWithTag("LilaUI").GetComponent<Canvas>();
        ariaUI = GameObject.FindGameObjectWithTag("AriaUI").GetComponent<Canvas>();
        PCInterface = GameObject.FindGameObjectWithTag("PC");
        XboxInterface = GameObject.FindGameObjectWithTag("Xbox");
        PS4Interface = GameObject.FindGameObjectWithTag("Playstation");
    }

    private void Start()
    {
        // Set the control UI to Lila
        SetCharacterUI(CharacterUI.Lila);
    }

    private void Update()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            string joystickNames = Input.GetJoystickNames()[0];
            if (joystickNames.Contains("Xbox"))
            {
                // If there is a controller connected, set the control scheme to Xbox
                SetControlScheme(ControlScheme.Xbox);
            }
            else if (joystickNames.Contains("Wireless Controller"))
            {
                // If there is a controller connected, set the control scheme to PS4
                SetControlScheme(ControlScheme.PS4);
            }
        }
        else
        {
            // If there is no controller connected, set the control scheme to Keyboard
            SetControlScheme(ControlScheme.Keyboard);
        }
    }

    public void SetControlScheme(ControlScheme controlScheme)
    {
        // Disable all control scheme canvases
        PCInterface.SetActive(false);
        XboxInterface.SetActive(false);
        PS4Interface.SetActive(false);
        // Enable the control scheme canvas for the specified control scheme
        switch (controlScheme)
        {
            case ControlScheme.Keyboard:
                PCInterface.SetActive(true);
                break;
            case ControlScheme.Xbox:
                XboxInterface.SetActive(true);
                break;
            case ControlScheme.PS4:
                PS4Interface.SetActive(true);
                break;
        }
        currentControlScheme = controlScheme;
    }

    public void SetCharacterUI(CharacterUI characterUI)
    {
        // Disable both UI canvases
        lilaUI.enabled = false;
        ariaUI.enabled = false;

        // Enable the UI canvas for the specified control scheme
        switch (characterUI)
        {
            case CharacterUI.Lila:
                lilaUI.enabled = true;
                break;
            case CharacterUI.Aria:
                ariaUI.enabled = true;
                break;
        }
        currentCharacterUI = characterUI;
    }
}