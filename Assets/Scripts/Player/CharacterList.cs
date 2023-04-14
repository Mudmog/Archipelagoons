using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public Character baseCharacter;

    public Character[] characters;

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
