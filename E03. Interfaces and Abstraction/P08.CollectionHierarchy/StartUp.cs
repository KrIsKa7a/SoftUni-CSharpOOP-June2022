namespace CollectionHierarchy
{
    using Models;
    using Models.Interfaces;

    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ');
            int removeOpCnt = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemCollection =
                new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToAnyCollection(addCollection, words);
            AddToAnyCollection(addRemCollection, words);
            AddToAnyCollection(myList, words);

            RemoveFromAnyCollection(addRemCollection, removeOpCnt);
            RemoveFromAnyCollection(myList, removeOpCnt);
        }

        private static void AddToAnyCollection(IAddCollection<string> collection, string[] words)
        {
            foreach (string word in words)
            {
                Console.Write(collection.Add(word) + " ");
            }
            Console.WriteLine();
        }

        private static void RemoveFromAnyCollection(IAddRemoveCollection<string> collection,
            int removeOpCnt)
        {
            for (int i = 0; i < removeOpCnt; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
