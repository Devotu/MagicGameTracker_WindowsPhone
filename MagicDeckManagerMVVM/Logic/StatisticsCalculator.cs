
using System.Collections.Generic;
using System.Linq;
using System;

using MagicGameTracker.Model;
using MagicGameTracker.ViewModel;
using MagicGameTracker.Logic.StatisticsReports;
using MagicGameTracker.Logic.MagicEnums;

namespace MagicGameTracker.Logic
{
    public class StatisticsCalculator
    {
        public DeckReport CalculateDeckStatistics(DeckItem deck)
        {
            DeckReport deckReport = new DeckReport();
            List<string> colorsWonAgainst = new List<string>();
            List<string> colorsLostAgainst = new List<string>();
            Double performanceRatingSum = 0;
            
            foreach (var game in deck.DeckGames)
            {
                if (game.Win)
                {
                    colorsWonAgainst.Add(game.Colors);
                    if (game.Date > deck.DeckAlterations.Last().Date)
                    {
                        deckReport.WinSinceAltered = deckReport.WinSinceAltered + 1; 
                        deckReport.Wins = deckReport.Wins + 1;
                    } 
                    else
                    {
                        deckReport.Wins = deckReport.Wins + 1;
                    }
                } 
                else
                {
                    colorsLostAgainst.Add(game.Colors);
                    if (game.Date > deck.DeckAlterations.Last().Date)
                    {
                        deckReport.LossesSinceAltered = deckReport.LossesSinceAltered + 1;
                        deckReport.Losses = deckReport.Losses + 1;
                    } 
                    else
                    {
                        deckReport.Losses = deckReport.Losses + 1;
                    }
                }

                if (performanceRatingSum != 0)
                {
                    performanceRatingSum = performanceRatingSum + game.PerformanceRating;
                } 
                else
                {
                    performanceRatingSum = game.PerformanceRating;
                }
            }

            if (deck.DeckGames.Count != 0)
            {
                deckReport.PerformancRating = (performanceRatingSum / deck.DeckGames.Count);
            }
            else
            {
                deckReport.PerformancRating = 50;
            }

            if (deckReport.Wins + deckReport.Losses != 0)
            {
                deckReport.WinPercent = Decimal.Round( 
                    (Decimal.Divide((decimal)deckReport.Wins, 
                    (decimal)(deckReport.Wins + deckReport.Losses))) *100,
                    1);
                if (deckReport.WinSinceAltered + deckReport.LossesSinceAltered != 0)
                {
                    deckReport.WinPercentSinceAltered = Decimal.Round( 
                        (Decimal.Divide((decimal)deckReport.WinSinceAltered, 
                        (decimal)(deckReport.WinSinceAltered + deckReport.LossesSinceAltered))) *100,
                        1);
                }
            }

            deckReport.mostCommonWinColor = GetMostCommonColor(colorsWonAgainst);
            deckReport.mostCommonLossColor = GetMostCommonColor(colorsLostAgainst);

            return deckReport;
        }



        internal PlayerReport CalculatePlayerStatistics(MagicViewModel mvm)
        {
            PlayerReport playerReport = new PlayerReport();

            List<string> colorsWonAgainst = new List<string>();
            List<string> colorsLostAgainst = new List<string>();
            List<string> colorsPlayed = new List<string>();
            List<string> colorsPlayedAgainst = new List<string>();

            foreach (var game in mvm.Games)
            {
                colorsPlayedAgainst.Add(game.Colors);
                colorsPlayed.Add(game.GameDeck.Colors);

                if (game.Win)
                {
                    colorsWonAgainst.Add(game.Colors);
                    playerReport.Wins = playerReport.Wins +1;
                }
                else
                {
                    colorsLostAgainst.Add(game.Colors);
                    playerReport.Losses = playerReport.Losses + 1;
                }
            }

            if (playerReport.Wins + playerReport.Losses != 0)
            {
                playerReport.WinPercent = Decimal.Round(
                    (Decimal.Divide((decimal)playerReport.Wins,
                    (decimal)(playerReport.Wins + playerReport.Losses))) * 100,
                    1);
            }

            playerReport.mostCommonWinColor = GetMostCommonColor(colorsWonAgainst);
            playerReport.mostCommonLossColor = GetMostCommonColor(colorsLostAgainst);
            playerReport.mostCommonPlayColor = GetMostCommonColor(colorsPlayed);
            playerReport.mostCommonOppositionColor = GetMostCommonColor(colorsPlayedAgainst);
            AddColorsUsed(playerReport.colorsUsed, colorsPlayed);


            List<string> colorsPresentInDecks = new List<string>();

            foreach (var deck in mvm.Decks)
            {
                if (deck.DeckId != 1)
                {
                    colorsPresentInDecks.Add(deck.Colors);
                }
            }

            AddColorsUsed(playerReport.colorsInDecks, colorsPresentInDecks);

            return playerReport;
        }

        private ManaColor GetMostCommonColor(List<string> colorStrings)
        {
            List<SortableColor> fiveColors = new List<SortableColor> 
            {
                new SortableColor {color = ManaColor.Black, number = 0},
                new SortableColor {color = ManaColor.White, number = 0},
                new SortableColor {color = ManaColor.Red, number = 0},
                new SortableColor {color = ManaColor.Blue, number = 0},
                new SortableColor {color = ManaColor.Green, number = 0},
                new SortableColor {color = ManaColor.Devoid, number = 0},
                new SortableColor {color = ManaColor.None, number = 0},
            };

            foreach (var str in colorStrings)
            {
                for (int i = 0; i < 7; i++)
                {
                    bool inUse = false;
                    try //HACK programmering med try/catch
                    {
                        if (str.Substring(i, 1) == "1")
                        {
                            inUse = true;
                        }
                    }
                    catch (Exception)
                    { }
                    
                    fiveColors.ElementAt(i).number = inUse ? fiveColors.ElementAt(i).number + 1 : fiveColors.ElementAt(i).number + 0;
                }
            }

            var orderedListOfColors = fiveColors.OrderBy(c => c.number).ToList();

            if (orderedListOfColors[orderedListOfColors.Count - 1].number != orderedListOfColors[orderedListOfColors.Count - 2].number)
            {
                return orderedListOfColors.Last().color;
            }
            else
            {
                return ManaColor.None;
            }
        }

        private class SortableColor
        {
            public ManaColor color { get; set; }
            public int number { get; set; }
        }

        private void AddColorsUsed(List<double> colorList, List<string> colorsPlayed)
        {
            foreach (var str in colorsPlayed)
            {                
                for (int i = 0; i < 7; i++)
                {
                    bool inUse = false;
                    try //HACK programmering med try/catch
                    {
                        if (str.Substring(i, 1) == "1")
                        {
                            inUse = true;
                        }
                    }
                    catch (Exception)
                    { }

                    colorList[i] = inUse ? colorList[i] + 1 : colorList[i] + 0;
                }
            }            
        }
    }
}
