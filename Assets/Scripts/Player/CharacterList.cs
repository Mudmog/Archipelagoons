using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CharacterList : MonoBehaviour
{
    public Unit baseCharacter;
    public Unit[] characters;

    // Start is called before the first frame update
    void Start() {
        generateList();
    }
    public void generateList() {
        for (int x = 0; x < characters.Length; x++) {
            characters[x] = Instantiate(baseCharacter, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
