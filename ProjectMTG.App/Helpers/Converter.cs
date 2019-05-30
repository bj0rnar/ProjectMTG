using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMTG.Model;

namespace ProjectMTG.App.Helpers
{
    public class Converter
    {
        public static Deck ConvertToDatabaseDeck(ObservableCollection<Card> cardList)
        {
            Deck deck = new Deck();

            foreach (var card in cardList)
            {
                deck.Cards.Add(new DeckCard()
                {
                    DeckId = deck.DeckId,
                    name = card.name,
                    artist = card.artist,
                    colors = card.colors,
                    convertedManaCost = card.convertedManaCost,
                    manaCost = card.manaCost,
                    multiverseId = card.multiverseId,
                    loyalty = card.loyalty,
                    number = card.number,
                    rarity = card.rarity,
                    scryfallId = card.scryfallId,
                    scryfallIllustrationId = card.scryfallIllustrationId,
                    scryfallOracleId = card.scryfallOracleId,
                    subtype = card.subtype,
                    supertype = card.supertype,
                    text = card.text,
                    type = card.type,
                    types = card.types,
                    uuid = card.uuid,
                    uuidV421 = card.uuidV421,
                    power = card.power,
                    toughness = card.toughness
                });
            }

            return deck;
        }

        public static ObservableCollection<Card> ConvertToLocalCards(Deck deck)
        {
            ObservableCollection<Card> cardList = new ObservableCollection<Card>();

            foreach (var card in deck.Cards)
            {
                cardList.Add(new Card()
                {
                    name = card.name,
                    artist = card.artist,
                    colors = card.colors,
                    convertedManaCost = card.convertedManaCost,
                    manaCost = card.manaCost,
                    multiverseId = card.multiverseId,
                    loyalty = card.loyalty,
                    number = card.number,
                    rarity = card.rarity,
                    scryfallId = card.scryfallId,
                    scryfallIllustrationId = card.scryfallIllustrationId,
                    scryfallOracleId = card.scryfallOracleId,
                    subtype = card.subtype,
                    supertype = card.supertype,
                    text = card.text,
                    type = card.type,
                    types = card.types,
                    uuid = card.uuid,
                    uuidV421 = card.uuidV421,
                    power = card.power,
                    toughness = card.toughness
                });
            }

            return cardList;
        }

        public static Deck ConvertToEditableDeck(ObservableCollection<Card> cardList, int deckId)
        {
            //HMMM
            Deck editDeck = new Deck() {DeckId = deckId};

            foreach (var card in cardList)
            {
                editDeck.Cards.Add(new DeckCard()
                {
                    DeckId = deckId,
                    name = card.name,
                    artist = card.artist,
                    colors = card.colors,
                    convertedManaCost = card.convertedManaCost,
                    manaCost = card.manaCost,
                    multiverseId = card.multiverseId,
                    loyalty = card.loyalty,
                    number = card.number,
                    rarity = card.rarity,
                    scryfallId = card.scryfallId,
                    scryfallIllustrationId = card.scryfallIllustrationId,
                    scryfallOracleId = card.scryfallOracleId,
                    subtype = card.subtype,
                    supertype = card.supertype,
                    text = card.text,
                    type = card.type,
                    types = card.types,
                    uuid = card.uuid,
                    uuidV421 = card.uuidV421,
                    power = card.power,
                    toughness = card.toughness
                });
            }

            return editDeck;
        }
    }
}
