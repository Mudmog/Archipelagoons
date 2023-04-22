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
        public CardData[] cardData;
    }
    [SerializeField]
    public createUnitCardsList UnitCards = new createUnitCardsList(); 
    // Start is called before the first frame update
    void Awake()
    {
        UnitCards = JsonUtility.FromJson<createUnitCardsList>(json.text);
        Debug.Log("successfull");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
