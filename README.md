## Тестовое задание на практику в ePlat4m
Необходимо разработать класс (либо RESTful сервис), предоставляющий интерфейс
- Создать именованную колоду карт (колода создаётся упорядоченной)
- Удалить именованную колоду
- Получить список названий колод
- Перетасовать колоду
- Получить колоду по имени (в её текущем упорядоченном/перетасованном состоянии)

Необходимо спроектировать интерфейсы так, чтобы алгоритм перетасовки мог задаваться через конфигурацию приложения (путём выбора из «простой» и «эмуляция перетасовки вручную»).
Необходимо самостоятельно спроектировать API для колоды и все типы данных.

## Решение
В результате был создан класс `DecksInterface`, через который происходит взаимодействие с колодами. Методы класса позволяют выполнить все поставленные задачи:
- Конструктор `DecksInterface(string name)` и метод` bool Add(string name)` позволяют создать упорядоченную колоду карт;
- `void Delete(string name)` удаляет именованную колоду;
- Свойство `ICollection<string> Names` позволяет получить названия существующих колод;
- `void Shuffle(string name, bool manually = false)` перемешивает именованную колоду обычным алгоритмом или "эмулирует перетасовку вручную";
- `string[] GetDeck(string name)` возвращает карты колоды.
> Сортировщик карт может работать с любым размером колоды.

Поле класса `_decks` необходимо, чтобы хранить название и карты колоды, а `_sortedDeck` - чтобы создавать упорядоченную колоду.
Карты обозначаются комбинацией двух символов: первый - значение карты, второй - масть.
Значения:
- A - туз;
- K - король;
- Q - дама;
- J - валет
- остальные карты называются цифрой

Масти:
- d(diamonds) - бубы
- h(hearts) - черви
- c(clubs) - трефы
- s(spades) - пики