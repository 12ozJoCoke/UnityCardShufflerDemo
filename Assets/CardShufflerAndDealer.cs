using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShufflerAndDealer : MonoBehaviour
{
    public List<string> DefaultDeck;
    public List<string> DeckToShuffle;
    public List<string> ActiveDeck;
    public List<GameObject> Players;
    public int numberOfDecks = 1;
    public int cardsToDeal;
    public bool shuffle;
    public bool deal;

    // Start is called before the first frame update
    void Start()
    {
        shuffle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shuffle)
        {
            if (numberOfDecks > 0)
            {
                foreach (string Card in DefaultDeck)
                {
                    DeckToShuffle.Add(Card);
                }
                numberOfDecks -= 1;
            }
            else if (numberOfDecks == 0)
            {
                if (DeckToShuffle.Count > 0)
                {
                    int cardToPlace = Random.Range(0, DeckToShuffle.Count);
                    ActiveDeck.Add(DeckToShuffle[cardToPlace]);
                    DeckToShuffle.Remove(DeckToShuffle[cardToPlace]);
                }
                else if (DeckToShuffle.Count == 0)
                {
                    shuffle = false;
                    //deal = true;
                }
            }
        }

        if (deal)
        {
            Debug.Log(ActiveDeck[0]);
            if (cardsToDeal > 0)
            {
                foreach (GameObject Player in Players)
                {
                    Player.GetComponent<PlayerHandStatus>().CardsInHand.Add(ActiveDeck[0]);
                    ActiveDeck.Remove(ActiveDeck[0]);
                }
                cardsToDeal -= 1;
            }
        }
    }
}
