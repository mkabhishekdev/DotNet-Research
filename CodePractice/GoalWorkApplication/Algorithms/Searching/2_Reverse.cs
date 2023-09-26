using System.Collections;
using System.Collections.Generic;

public class Reverse
{
    public string ReverseSentence(string input)
    {
        string result = "";
        List<Char> store = new List<Char>();

        for(int i=input.Length-1; i>=0; i--)
        {
            store.Add(input[i]);
        }
        result = new string(store.ToArray());
        return result;
    }
    
}