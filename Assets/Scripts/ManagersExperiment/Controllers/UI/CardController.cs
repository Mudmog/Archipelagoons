using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Card2 testCard;
    public Image illustration, image;
    public TextMeshProUGUI cardName, health, manaCost, damage;
    private Transform originalParent;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        
    }

    public void Initialize(Card2 testCard)
    {
        this.testCard = testCard;
        illustration.sprite = testCard.illustration;
        cardName.text = testCard.cardName;
        manaCost.text = testCard.manaCost.ToString();
        damage.text = testCard.damage.ToString();
        health.text = testCard.health.ToString();
        originalParent = transform.parent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //This line gives me an error message
       /* if(originalParent.name = $"Player{testCard.ownerID + 1}PlayArea")
        {

        }
        else
        {*/
            transform.SetParent(transform.root);
            image.raycastTarget = false;
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter);
        image.raycastTarget = true;
        AnalyzePointerUp(eventData);
    }

    private void AnalyzePointerUp(PointerEventData eventData)
    {
        if(eventData.pointerEnter.name == $"Player{testCard.ownerID + 1}PlayArea")
        {
            if(PlayerManager.instance.FindPlayerByID(testCard.ownerID).mana >= testCard.manaCost)
            {
                PlayCard(eventData.pointerEnter.transform);
            }
            else
            {
                ReturnToHand();
            }
        }
    }

    private void PlayCard(Transform playArea)
    {
        transform.SetParent(playArea);
        originalParent = playArea;
    }

    private void ReturnToHand()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (transform.parent == originalParent) return;
        transform.position = eventData.position;
    }
}
