public class AddCheck 
{
    public int AddTwo(int num1, int num2) 
    {
        return num1+num2;
    }

    public static void main(string args)
    {
        AddCheck ac = new AddCheck();
        System.Console.WriteLine(ac.AddTwo(11,10));
    }
}