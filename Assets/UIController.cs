using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public VisualElement Settings_panel;
    public Button SettingsOff;
    public Button SettingsOn;
    public Button SimulateSwitch;
    public DoubleField Xamp;
    public DoubleField Yamp;
    public DoubleField Xfreq;
    public DoubleField Yfreq;
    public DoubleField Xoffset;
    public DoubleField Yoffset;
    public DoubleField DeltaAngle;
    public DoubleField Xpos;
    public DoubleField Ypos;
    public bool SettingsOpen = false;

    // Start is called before the first frame update
    void Start(){
        var root = GetComponent<UIDocument>().rootVisualElement;
        Settings_panel = root.Q<VisualElement>("OptionsFrame");
        SettingsOn = root.Q<Button>("SettingsOn");
        SimulateSwitch = root.Q<Button>("Switch");
        SettingsOff = root.Q <Button>("SettingsOff");
        Xamp = root.Q<DoubleField>("X_amp");
        Yamp = root.Q<DoubleField>("Y_amp");
        Xfreq = root.Q<DoubleField>("X_freq");
        Yfreq = root.Q<DoubleField>("Y_freq");
        Xoffset = root.Q<DoubleField>("X_offset");
        Yoffset = root.Q<DoubleField>("Y_offset");
        DeltaAngle = root.Q<DoubleField>("Delta_angle");
        Xpos = root.Q<DoubleField>("X_pos");
        Ypos = root.Q<DoubleField>("Y_pos");
        SettingsOff.RegisterCallback<ClickEvent>(OnOffClicked);
        SettingsOn.RegisterCallback<ClickEvent>(OnOnClicked);
        SimulateSwitch.RegisterCallback<ClickEvent>(OnSimClicked);
        SettingsOpen = false;


        SettingsOn.style.display = DisplayStyle.Flex;
        Settings_panel.style.display = DisplayStyle.None;

        Debug.Log("assigned: " + (DeltaAngle != null));
    }

    private void OnSimClicked(ClickEvent evt)
    {
        LissajousCurve.Instance.Continue = !LissajousCurve.Instance.Continue;
    }

    private void OnOnClicked(ClickEvent evt)
    {
        SettingsOpen = true;
        SettingsOn.style.display = DisplayStyle.None;
        Settings_panel.style.display = DisplayStyle.Flex;
        Xamp.value = 3;
        Yamp.value = 3;
        Xfreq.value = 0.2f;
        Yfreq.value = 0.4f;
        Xoffset.value = -3;
        Yoffset.value = 0;
        DeltaAngle.value = 0;

    }

    private void OnOffClicked(ClickEvent evt)
    {
        SettingsOpen = false;
        SettingsOn.style.display = DisplayStyle.Flex;
        Settings_panel.style.display = DisplayStyle.None;
        
    }

    // Update is called once per frame
    void Update(){
        if (SettingsOpen)
        {
            LissajousCurve.Instance.xAmplitude = Xamp.value;
            LissajousCurve.Instance.yAmplitude = Yamp.value;
            LissajousCurve.Instance.xFrequency = Xfreq.value;
            LissajousCurve.Instance.yFrequency = Yfreq.value;
            LissajousCurve.Instance.xOffset = Xoffset.value;
            LissajousCurve.Instance.yOffset = Yoffset.value;
            LissajousCurve.Instance.deltaAngle = DeltaAngle.value;
            Xpos.value = LissajousCurve.Instance.xPos;
            Ypos.value = LissajousCurve.Instance.yPos;
        }
    }
}