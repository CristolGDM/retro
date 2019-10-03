﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainMenu : MenuComponent {

    [SerializeField]
    GameObject PcSection1;
    [SerializeField]
    GameObject PcSection2;
    [SerializeField]
    GameObject PcSection3;
    [SerializeField]
    GameObject PcSection4;

    [SerializeField]
    GameObject ItemOption;
    [SerializeField]
    GameObject MagicOption;
    [SerializeField]
    GameObject StatusOption;

    protected override void LoadOptions() {
        List<List<GameObject>> Options = new List<List<GameObject>>();
        Options.Add(new List<GameObject> { ItemOption });
        Options.Add(new List<GameObject> { MagicOption });
        Options.Add(new List<GameObject> { StatusOption });

        SelectableOptions = Options;
    }
}