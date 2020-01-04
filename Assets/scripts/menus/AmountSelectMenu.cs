using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountSelectMenu : MenuComponent {

    [SerializeField]
    private GameObject DecimalOption = null;
    [SerializeField]
    private GameObject UnitOption = null;
    [SerializeField]
    private GameObject ConfirmationText = null;
    [SerializeField]
    private GameObject CurrentValueText = null;

    private Action<int> ActionWhenConfirmed;
    private GameObject currentOption = null;

    private string defaultConfirmText = "";
    private Action<int> defaultCallback = (int placeholder) => { };

    private int currentValue = 1;
    private int maxValue = 1;

    protected override void LoadOptions() {
        List<List<GameObject>> tempList = new List<List<GameObject>> {
            new List<GameObject> { DecimalOption, UnitOption }
        };

        SelectableOptions = tempList;
        currentOption = UnitOption;
    }

    protected override void Update() {
        string temp = "0" + currentValue;
        CurrentValueText.GetComponent<Text>().text = temp.Substring(temp.Length - 2);

        base.Update();
    }

    protected override void SelectOption(GameObject option) {
        ActionWhenConfirmed(currentValue);
    }

    public void SetConfirmationText(string confirmText) {
        ConfirmationText.GetComponent<Text>().text = confirmText;
    }

    public void SetCallback(Action<int> callback) {
        ActionWhenConfirmed = callback;
    }

    public void SetMaxValue(int max) {
        maxValue = max;
    }

    public override void CloseMenu() {
        ConfirmationText.GetComponent<Text>().text = defaultConfirmText;
        ActionWhenConfirmed = defaultCallback;
        currentValue = 1;
        maxValue = 1;
        base.CloseMenu();
    }

    private void IncreaseCurrentValue(int amount) {
        if(currentValue == maxValue) {
            currentValue = 1;
        }
        else if (currentValue + amount > maxValue) {
            currentValue = maxValue;
        }
        else {
            currentValue += amount;
        }
    }

    private void DecreaseCurrentValue(int amount) {
        if (currentValue > maxValue) {
            currentValue = maxValue;
        }
        else if(currentValue == 1) {
            currentValue = maxValue;
        }
        else if (currentValue - amount < 1) {
            currentValue = 1;
        }
        else {
            currentValue -= amount;
        }
    }

    protected override GameObject CurrentOption() {
        return currentOption;
    }

    public override void MoveDown() {
        if (currentOption == DecimalOption) {
            DecreaseCurrentValue(10);
        } else {
            DecreaseCurrentValue(1);
        }
    }

    public override void MoveUp() {
        if(currentOption == DecimalOption) {
            IncreaseCurrentValue(10);
        }
        else {
            IncreaseCurrentValue(1);
        }
    }

    public override void MoveLeft() {
        currentOption = currentOption == DecimalOption ? UnitOption : DecimalOption;
    }

    public override void MoveRight() {
        MoveLeft();
    }
}
