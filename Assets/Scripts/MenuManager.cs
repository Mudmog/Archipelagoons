using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI pearlsText;
    private Player player;
    Canvas theCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player(Clone)").GetComponent<Player>();
        theCanvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pearlsText.SetText(player.getPearls().ToString());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P)) {
            HandlePearlsUpdate(10);
        }
    }

    void HandlePearlsUpdate(int pearlChange) {
        player.changePearls(pearlChange);
        pearlsText.SetText(player.getPearls().ToString());
    }
}
