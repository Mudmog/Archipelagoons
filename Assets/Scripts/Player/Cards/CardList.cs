using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CardList : MonoBehaviour
{

    public TextAsset json;

    [System.Serializable]
    public class createUnitCardsList
    {
        public Card[] cards;
    }

    public createUnitCardsList UnitCards = new createUnitCardsList(); 
    // Start is called before the first frame update
    void Start()
    {
        UnitCards = JsonUtility.FromJson<createUnitCardsList>(json.text);
        Debug.Log("successfull");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
