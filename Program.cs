class Program
{    
    public static Stack<string> stackInputName = new Stack<string>();
    public static string InputName()
    {
        string name = Console.ReadLine();
        return name;
    }

    public static int InputNumber()
    {
        int number = int.Parse(Console.ReadLine());
        return number;  
    }

    static void GetRank(Tree<string> ranking) 
    {
        if(ranking.GetLength() == 0)
        {
            string name = InputName();
            ranking.AddChild(-1, name);
            GetRank(ranking);
        }   

        int number = InputNumber();
        if(number != 0)
        {
            string name = InputName();
            stackInputName.Push(name);
            ranking.AddChild(number, name);
            GetRank(ranking);

            if(number >= 1)
            {
                for (int i = 1; i < number; i++)
                {
                    string ndName = InputName();
                    stackInputName.Push(ndName);
                    ranking.AddSibling(i, ndName);
                    GetRank(ranking);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Tree<string> ranking = new Tree<string>();
        GetRank(ranking);

        string searchNode = Console.ReadLine();
        
    }
}