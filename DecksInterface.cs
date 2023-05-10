namespace deck_interface;

public class DecksInterface
{
    private Dictionary<string, string[]> _decks = new(); // Содержит название колоды и сами карты
    private string[] _sortedDeck =
    {
        "2d", "2h", "2c", "2s",
        "3d", "3h", "3c", "3s",
        "4d", "4h", "4c", "4s",
        "5d", "5h", "5c", "5s",
        "6d", "6h", "6c", "6s",
        "7d", "7h", "7c", "7s",
        "8d", "8h", "8c", "8s",
        "9d", "9h", "9c", "9s",
        "10d", "10h", "10c", "10s",
        "Jd", "Jh", "Jc", "Js",
        "Qd", "Qh", "Qc", "Qs",
        "Kd", "Kh", "Kc", "Ks",
        "Ad", "Ah", "Ac", "As"
    };
    
    // Конструктор
    public DecksInterface(string name)
    {
        _decks.Add(name, _sortedDeck);
    }
    
    // Создать именованную колоду карт
    public bool Add(string name)
    {
        return _decks.TryAdd(name, _sortedDeck);
    }

    // Удалить именованную колоду
    public void Delete(string name)
    {
        _decks.Remove(name);
    }

    // Получить список названий колод
    public ICollection<string> Names
    {
        get => _decks.Keys;
    }

    // Перетасовать колоду
    public void Shuffle(string name, bool manually = false)
    {
        var random = new Random();
        string[] cards = _decks[name];

        if (!manually)
        {
            for (int i = cards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]); // Случайные карты в колоде меняются местами
            }
        }
        else // Ручная перетасовка
        {
            for (int c = random.Next(5, 15); c >= 0; c--)
            {
                int slice = (cards.Length / 2) + random.Next(-5, 5); // Срез колоды (+-5 карт от середины)
                string[] deck_part = new string[slice];
                
                // Скопировать первую часть колоды в отдельный массив
                Array.Copy(cards, 0, deck_part, 0, slice);
                // Скопировать вторую часть колоды в начало
                Array.Copy(cards, slice, cards, 0, cards.Length - slice);
                // Скопировать первую часть колоды в конец
                Array.Copy(deck_part, 0, cards, cards.Length - slice, deck_part.Length);
            }
        }
    }

    // Получить колоду по имени
    public string[] GetDeck(string name)
    {
        return _decks[name];
    }
}
