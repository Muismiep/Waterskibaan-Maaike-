/*
 * Waterskibaan Project
 * Door: Maaike van der Jagt
 * ICTSE1a
 * 2019
 */

using System;
using System.Collections.Generic;

namespace Waterskibaan
{
    public static class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> Moves = new List<IMoves>() {new Springen(), new OpEenBeen(), new Salto(), new Achteruit(), new DoorJeKnieën(), new ÉenHand()};
            var LijstmetBewegingen = new List<IMoves>();
            var random = new Random();
            var aantalbewegingen = random.Next(1, Moves.Count + 1);

            for (var i = 0; i < aantalbewegingen; i++)
            {
                LijstmetBewegingen.Add(Moves[i]);
            }

            return LijstmetBewegingen;
        }
    }
}
