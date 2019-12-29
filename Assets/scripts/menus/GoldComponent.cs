using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldComponent : MonoBehaviour {

    [SerializeField]
    Text goldAmount = null;

    // Update is called once per frame
    void Update () {
        goldAmount.text = "" + Inventory.GetGold();
	}
}
