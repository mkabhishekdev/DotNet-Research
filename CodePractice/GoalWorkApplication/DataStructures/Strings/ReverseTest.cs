public class ReverseTest
{
    public string CheckInput(string input)
    {
        string result = "";
        
        for(int i=input.Length-1; i>=0;i--)
        {
            result += input[i];
        }

        return result;
    }
}



/*
"abhi"
"ihba"
*/