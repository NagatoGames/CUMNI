using System.Collections.Generic;

public class DiceCombinationManager
{
    public Combination rollDices(List<Dice> dices)
    {
        System.Random rnd = new System.Random();
        foreach (Dice dice in dices)
        {
            dice.Animator.SetBool("save", dice.NeedSave);
            if (!dice.NeedSave)
            {
                dice.Value = rnd.Next(1, 7);
                dice.Animator.SetInteger("value", dice.Value);
                //Debug.Log(dice.ToString());
                dice.Animator.SetBool("save", true);
            }
            dice.NeedSave = false;
        }
        return getCombination(dices);
    }

    public Combination getCombination(List<Dice> dices)
    {
        if (isPoker(dices)) return Combination.POKER;
        if (isFourOfAKind(dices)) return Combination.FOUR_OF_A_KIND;
        if (isFullHouse(dices)) return Combination.FULL_HOUSE;
        if (isBigStreet(dices)) return Combination.BIG_STREET;
        if (isSmallStreet(dices)) return Combination.SMALL_STREET;
        if (isSet(dices)) return Combination.SET;
        if (isTwoPair(dices)) return Combination.TWO_PAIR;
        if (isPair(dices)) return Combination.PAIR;
        return Combination.NONE;
    }

    public bool isPoker(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int firstDiceValue = dices[0].Value;
        foreach (Dice dice in dices)
        {
            if (dice.Value != firstDiceValue)
                return false;
        }
        return true;
    }

    public bool isFourOfAKind(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
            }
        }
        return (count1 == 4 || count2 == 4 || count3 == 4 || count4 == 4 || count5 == 4 || count6 == 4);
    }

    public bool isFullHouse(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        return isSet(dices) && isTwoPair(dices);
    }

    public bool isBigStreet(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
            }
        }
        return count2 >= 1 && count3 >= 1 && count4 >= 1 && count5 >= 1 && count6 >= 1;
    }

    public bool isSmallStreet(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
            }
        }
        return count1 >= 1 && count2 >= 1 && count3 >= 1 && count4 >= 1 && count5 >= 1;
    }

    public bool isSet(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
            }
        }
        return (count1 == 3 || count2 == 3 || count3 == 3 || count4 == 3 || count5 == 3 || count6 == 3);
    }

    public bool isTwoPair(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
            }
        }
        int pairCount = 0;
        if (count1 >= 2) pairCount++;
        if (count2 >= 2) pairCount++;
        if (count3 >= 2) pairCount++;
        if (count4 >= 2) pairCount++;
        if (count5 >= 2) pairCount++;
        if (count6 >= 2) pairCount++;

        return pairCount >= 2;
    }

    public bool isPair(List<Dice> dices)
    {
        if (dices.Count == 0) return false;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
            }
        }
        return (count1 == 2 || count2 == 2 || count3 == 2 || count4 == 2 || count5 == 2 || count6 == 2);
    }

    public string getPossibleCombination(List<Dice> dices, int moveCountLeft)
    {
        if (isPossiblePoker(dices, moveCountLeft)) return "can be poker";
        if (isPossibleFourOfAKind(dices, moveCountLeft)) return "can be four of a kind";
        if (isPossibleFullHouse(dices, moveCountLeft)) return "can be full house";
        if (isPossibleStreet(dices, moveCountLeft)) return "can be street";
        if (isPossibleSetOrTwoPair(dices, moveCountLeft)) return "can be set or two pair";
        return "error";
    }

    public bool isPossiblePoker(List<Dice> dices, int moveCountLeft)
    {
        if (dices.Count == 0) return false;
        return isFourOfAKind(dices) && moveCountLeft > 0;
    }

    public bool isPossibleFourOfAKind(List<Dice> dices, int moveCountLeft)
    {
        if (dices.Count == 0) return false;
        return isSet(dices) && moveCountLeft > 0;
    }

    public bool isPossibleFullHouse(List<Dice> dices, int moveCountLeft)
    {
        if (dices.Count == 0) return false;
        return (isSet(dices) || isTwoPair(dices)) && moveCountLeft > 0;
    }

    public bool isPossibleStreet(List<Dice> dices, int moveCountLeft)
    {
        if (dices.Count == 0) return false;
        int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
        foreach (Dice dice in dices)
        {
            switch (dice.Value)
            {
                case 1: count1++; break;
                case 2: count2++; break;
                case 3: count3++; break;
                case 4: count4++; break;
                case 5: count5++; break;
                case 6: count6++; break;
            }
        }
        int nowNumbersActive = 0;
        if (count1 >= 1) nowNumbersActive++;
        if (count2 >= 1) nowNumbersActive++;
        if (count3 >= 1) nowNumbersActive++;
        if (count4 >= 1) nowNumbersActive++;
        if (count5 >= 1) nowNumbersActive++;
        if (count6 >= 1) nowNumbersActive++;

        return nowNumbersActive >= 4 && moveCountLeft > 0;
    }

    public bool isPossibleSetOrTwoPair(List<Dice> dices, int moveCountLeft)
    {
        if (dices.Count == 0) return false;
        return isPair(dices) && moveCountLeft > 0;
    }
}
