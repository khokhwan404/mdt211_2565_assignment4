class Program
{    
    public static Tree<string> ranking = new Tree<string>();
    public static Stack<string> stackName = new Stack<string>();
    
    public static void GetRank(string worker) 
    { 
        int number = int.Parse(Console.ReadLine());
        if(number != 0)
        {
            string name = Console.ReadLine();
            ranking.AddChild(worker, name);
            GetRank(name);
            stackName.Push(name);

            if(number >= 1)
            {
                for (int i = 1; i < number; i++)
                {
                    string ndName = Console.ReadLine();
                    ranking.AddSibling(stackName.Pop(), ndName);
                    GetRank(ndName);
                    stackName.Push(ndName);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        string inputName = Console.ReadLine();
        ranking.AddChild(null, inputName);
        GetRank(inputName); 

        string vanilla = Console.ReadLine();
        Queue<string> searchNode = ranking.GetAllAncestor(vanilla);

        int i = 0;
        while(i <= searchNode.GetLength()){
            Console.WriteLine(searchNode.Pop());
            i++;
        }
    }
}