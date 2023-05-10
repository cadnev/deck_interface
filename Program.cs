namespace deck_interface
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Создание объекта класса
            DecksInterface myDecksInterface = new DecksInterface("FirstDeck");

            // Упорядоченная колода
            string[] firstDeck = myDecksInterface.GetDeck("FirstDeck");
            Console.WriteLine("FirstDeck: ");
            foreach (string card in firstDeck)
                Console.WriteLine(card);
            
            Console.WriteLine("--------------");
            
            // Создание колоды и перетасовка
            Console.WriteLine(myDecksInterface.Add("SecondDeck") ? "Success": "Deck with that name already exists");
            myDecksInterface.Shuffle("SecondDeck");
            string[] secondDeck = myDecksInterface.GetDeck("SecondDeck");
            Console.WriteLine("Shuffled SecondDeck: ");
            foreach (string card in secondDeck)
                Console.WriteLine(card);
            
            Console.WriteLine("--------------");
            
            // Ручное перемешивание первой колоды
            myDecksInterface.Shuffle("FirstDeck", true);
            firstDeck = myDecksInterface.GetDeck("FirstDeck");
            Console.WriteLine("Manually shuffled FirstDeck: ");
            foreach (string card in firstDeck)
                Console.WriteLine(card);
            
            Console.WriteLine("--------------");
            
            // Удаление колоды
            myDecksInterface.Delete("FirstDeck");
            var deckNames = myDecksInterface.Names;
            foreach (string name in deckNames)
                Console.Write(name + " ");
            Console.WriteLine();
        }
    }
}