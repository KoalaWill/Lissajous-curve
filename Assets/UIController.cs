using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private VisualElement Settings_panel;
    private Button SettingsOff;
    private Button SettingsOn;
    private Button SimulateSwitch;
    private DoubleField Xamp;
    private DoubleField Yamp;
    private DoubleField Xfreq;
    private DoubleField Yfreq;
    private DoubleField Xoffset;
    private DoubleField Yoffset;
    private DoubleField DeltaAngle;
    private DoubleField Xpos;
    private DoubleField Ypos;
    private bool SettingsOpen = true;

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
        DeltaAngle = root.Q<DoubleField>("DeltaAngle");
        Xpos = root.Q<DoubleField>("Xpos");
        Ypos = root.Q<DoubleField>("Ypos");
        SettingsOff.RegisterCallback<ClickEvent>(OnOffClicked);
        SettingsOn.RegisterCallback<ClickEvent>(OnOnClicked);
        SimulateSwitch.RegisterCallback<ClickEvent>(OnSimClicked);
        SettingsOn.style.display = DisplayStyle.None;

        Xamp.value = LissajousCurve.Instance.xAmplitude;
        Yamp.value = LissajousCurve.Instance.yAmplitude;
        Xfreq.value = LissajousCurve.Instance.xFrequency;
        Yfreq.value = LissajousCurve.Instance.yFrequency;
        Xoffset.value = LissajousCurve.Instance.xOffset;
        Yoffset.value = LissajousCurve.Instance.yOffset;
        DeltaAngle.value = LissajousCurve.Instance.deltaAngle;
        Xpos.value = LissajousCurve.Instance.xPos;
        Ypos.value = LissajousCurve.Instance.yPos;
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

    }

    private void OnOffClicked(ClickEvent evt)
    {
        SettingsOpen = false;
        SettingsOn.style.display = DisplayStyle.Flex;
        Settings_panel.style.display = DisplayStyle.None;
        
    }

    // Update is called once per frame
    void Update(){
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
