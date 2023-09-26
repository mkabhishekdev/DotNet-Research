using System.Text.RegularExpressions;

public class ValidPalindrome 
{
    public bool IsPalindrome(string s)
    {
       if(string.IsNullOrEmpty(s))
           return true;
       bool result=false;
       string test1 = Regex.Replace(s,"[^a-zA-Z0-9]","").ToLower();
       List<char> revStore = new List<char>();

       for(int i=s.Length-1;i>=0;i--)
       {
           revStore.Add(s[i]);
       } 
     
       string preResult = new string(revStore.ToArray()).ToLower();
       string test2 = Regex.Replace(preResult, "[^a-zA-Z0-9]","").ToLower();
       if(test2.Equals(test1))
       {
        result=true;
       }
       else
       {
        result=false;
       }
       return result;
    }
}