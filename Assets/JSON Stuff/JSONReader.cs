using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{

    public TextAsset json;

    [System.Serializable]
    public class testing
    {
        public string name, goon, rarity, ability;
        public int power, defense, movement;
    }

    [System.Serializable]
    public class testinglist
    {
        public testing[] testing;
    }

    public testinglist tlist = new testinglist(); 
    // Start is called before the first frame update
    void Start()
    {
        tlist = JsonUtility.FromJson<testinglist>(json.text);
        Debug.Log("successfull");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
