using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
   public  class BotLogic
    {
        public Card BotSelectCard(List<Card> cardsOnHands, Card[] arrayCardOnTable)
        {
            Random random = new Random();
            return cardsOnHands[random.Next(cardsOnHands.Count - 1)];
        }
    }
}
