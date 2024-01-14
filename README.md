# C#

C# + .NET Framework

## [Introduction to classes](/HW05/)

ЗАВДАННЯ:
1. Розробити один з класів, відповідно до варіанту (Варіант по списку).
2. Реалізувати не менше п'яти закритих полів (різних типів), що представляють основні характеристики даного класу.
3. Створити не менше трьох методів управління класом і методи доступу до його закритих полів.
4. Створити метод, в який передаються аргументи за посиланням.
5. Створити не менше двох статичних полів (різних типів), що представляють спільні  характеристики об'єктів даного класу.
6. Обов'язковою вимогою є реалізація декількох перевантажених конструкторів, аргументи яких визначаються студентом, виходячи із специфіки реалізованого класу, і так само реалізувати конструктор за замовчуванням.

-----

## [Exception handling](/HW06/)

Розробити клас TryPassword для перевірки пароля до заданих правил:
1. Довжина пароля повинна бути рівна або більша за зазначену.
2. Пароль повинен містити малі літери a…z;
3. Пароль повинен містити великі літери A…Z;
4. Пароль повинен містити арабські цифри;
5. Пароль повинен містити спеціальні символи %, *, ), ?, @, #, $, ~, …
Кількість правил для перевірки встановлюється через конструктор. Для перевірки 
клас повинен мати функцію з параметром рядкового типу. Функція повертає false у
випадку не відповідності пароля одному із встановлених правил генерується 
відповідна виняткова ситуація, інакше – true.

-----

## [Exception handling, indexers](/HW07/)

Задание 1.
В С # индексация начинается с нуля, но в некоторых языках программирования это не так. Например, в Turbo Pascal индексация массиве начинается с 1. Напишите класс RangeOfArray, который  позволяет работать с массивом такого типа, в котором индексный диапазон устанавливается пользователем. Например, в диапазоне от 6 до 10, или от -9 до 15.
Подсказка:  В классе можно объявить две переменных, которые будут содержать верхний и нижний индекс допустимого диапазона.

Задание 2.
Задание: Написать приложение, имитирующее работу банкомата
Реализовать классы Banc, Client, Account в различных пространствах имен (общее пространство имен «Bankomat»). Изначально клиенту нужно открыть счёт в банке, получить номер счёта, получить свой пароль, положить сумму на счёт.
1.	Приложение предлагает ввести пароль предполагаемой кредитной карточки, даётся 3 попытки на правильный ввод пароля. Если попытки исчерпаны, приложение выдаёт соответствующее сообщение и завершается.
2.	При успешном вводе пароля выводится меню. Пользователь может выбрать одно из нескольких действий:
    - вывод баланса на экран
    - пополнение счёта
    - снять деньги со счёта
    - выход
3. Если пользователь выбирает вывод баланса на экран, приложение отображает состояние предполагаемого счёта, после чего предлагает либо вернуться в меню, либо совершить выход.
4. Если пользователь выбирает пополнение счёта, программа запрашивает сумму для пополнения и выполняет операцию, сопровождая её выводом соответствующего комментария. Затем следует предложение вернуться в меню или выполнить выход.
5. Если пользователь выбирает снять деньг со  счёта, программа запрашивает сумму. Если сумма превышает сумму счёта пользователя, программа выдаёт сообщение и переводит пользователя в меню. Иначе отображает сообщение о  том, что сумма снята со счёта и уменьшает сумму счёта на указанную величину.


-----

## [Classes and tests](/HW08/)

Розробити клас Rational - дріб. 
містить Numerator -чисельник, Denominator - знаменник
Клас має проходити всі тести в проекті.

-----

## [Inheritance. Polymorphism](/HW09/)

Розробіть похідні класи зображенні на малюнку.
Пасажиру потрібно проїхати з пункту А до пункту В з використанням різних транспортних засобів. 
Кількість транспортних засобів генерується випадково. 
Обчислити час і вартість проїзду пасажира

![Transport](/HW09/Transport_Screenshot01.png)

-----

## [Interfaces](/HW10/)

Уявімо, ви робите систему фільтрації коментарів на якомусь веб-порталі, будь то новини, відео-хостинг,…
Ви хочете фільтрувати коментарі за різними критеріями, вміти легко додавати нові фільтри і модифікувати старі.
Припустимо, ми будемо фільтрувати спам, коментарі з негативним змістом і занадто довгі коментарі.
Спам будемо фільтрувати за наявністю зазначених ключових слів в тексті.
Негативний зміст визначатимемо за наявністю одного з трьох смайликів: :( =( :|

Занадто довгі коментарі будемо визначати виходячи з даного числа - максимальної довжини коментаря.
Ви вирішили абстрагувати фільтр у вигляді наступного інтерфейсу:
```
interface TextAnalyzer{
    Label processText(String text);
}
```

Label - тип-перерахування, які містить мітки, якими будемо позначати текст:
enum Label{ SPAM, NEGATIVE_TEXT, TOO_LONG, OK }

Далі, вам необхідно реалізувати три класи, які реалізують даний інтерфейс: 
SpamAnalyzer, NegativeTextAnalyzer і TooLongTextAnalyzer.
SpamAnalyzer повинен конструюватися від масиву рядків з ключовими словами. Об'єкт цього класу повинен зберігати в своєму стані цей масив рядків в приватному поле keywords.
NegativeTextAnalyzer повинен конструюватися конструктором за замовчуванням.
TooLongTextAnalyzer повинен конструюватися від int'а з максимальною допустимою довжиною коментаря. Об'єкт цього класу повинен зберігати в своєму стані це число в приватному поле maxLength.

-----

## [Exception handling. Operator overloading](/HW11/)

Цель: Разработать программу, моделирующую танковый бой.  В танковом бою участвуют 5 танков «Т-34» и 5 танков «Pantera». Каждый танк («Т-34» и «Pantera») описываются параметрами: «Боекомплект»,  «Уровень брони», «Уровень маневренности». Значение данных параметров задаются случайными числами от 0 до 100. Каждый танк участвует в парной битве, т.е. первый танк «Т-34» сражается с первым танком «Pantera» и т.д. Победа присуждается тому танку, который превышает противника по двум и более параметрам из трех (пример: см. программу).  Основное требование:  сражение (проверку на победу в бою) реализовать путем перегрузки оператора «*» (произведение).

1.	В решение добавить новый проект с именем «Day7(Tanks)», в котором будут промоделированы танковые сражения.   В данный проект добавить ссылку на библиотеку классов «MyClassLib».
2.	В библиотеке классов «MyClassLib» создать папку «WordOfTanks», а в ней  разработать класс с именем «Tank». 
В классе должно быть реализовано:
- поля:
закрытые поля, предназначенные для представления 
1. Названия танка. 
2. Уровня боекомплекта танка. 
3. Уровня брони.
4. Уровня маневренности.
-конструктор:
Конструктор с параметрами, обеспечивающий инициализацию всех полей класса Tank. При этом Боекомплект,  Уровень брони, Уровень маневренности инициализируются случайными числами от 0 до 100 %. Название танка передаются в конструктор из функции Main().
- перегрузка оператора «^»(произведение):
При перегрузке оператора «^» (произведение) должна быть реализована проверка на победу в бою одного танка по отношению к другому. Критерий победы – победивший   танк должен превышать проигравший танк не менее чем по двум  из трех параметров (Боекомплект,  Уровень брони, Уровень маневренности). 
- методы:
Получение текущих значений параметров танка: Боекомплект,  Уровень брони, Уровень маневренности в виде строки.

-----

## [Delegates](/HW12/)

Петро розробив генератор звітів в проекті Delegates.Reports, який рахує просту статистику про погоду за кількома параметрами за кілька днів. Його генератор може створювати два звіти: звіт в HTML, який рахує середнє і стандартне відхилення, і звіт в Markdown, який рахує медіани.
Однак, що робити, якщо потрібно порахувати медіани і вивести результат в HTML? 
А якщо потрібен буде третій звіт в HTML? 
Поточне рішення вкрай незручно для таких ситуацій.
Допоможіть Петру перевести його код з успадкування на делегування. Розділіть відповідальності за оформлення звіту і по обчисленню показників. В результаті сам клас ReportMaker вам, можливо, вже й не знадобиться.

-----

## [Events](/HW14/)

Алгоритм програми:
1. Розробити клас клієнт з такими характеристиками: ПІБ, рахунок, дата оформлення рахунку, процент на залишок на рахунку.
2. Передбачити відповідні методи для роботи з елементами класу клієнт, зокрема.
3. В класі банку зімітувати роботу банку протягом одного року. Врахувавши що число
кожного першого числа потрібно виплатити відсотки СВОЇМ клієнтам. (Викликається подія)
4. Список клієнтів можна додати в масив.
5. Підписати на виплату відсотків лише тих клієнтів у яких на рахунку більше 1000 грн., якщо термін закінчився то клієнта потрібно відписати від події нарахування дивідендів.
6. Кожен місяць потрібно виводити повну інформацію про ВСІХ клієнтів банку.
Потрібно також зробити подією.

-----

## [Collections. Generics](/HW17/)

Задание 1. Программа «Карточная игра!»
Создать модель карточной игры. 
Требования:
1. Класс Game формирует и обеспечивает:
1.1.1. Список игроков (минимум 2);
1.1.2. Колоду карт (36 карт);
1.1.3. Перетасовку карт (случайным образом);
1.1.4. Раздачу карт игрокам (равными частями каждому 
игроку);
1.1.5. Игровой процесс. Принцип: Игроки кладут по одной карте. У кого карта больше, то тот игрок забирает все карты и кладет их в конец своей 
колоды. 
Упрощение: при совпадении карт забирает первый игрок, шестерка не забирает туза. 
Выигрывает игрок, который забрал все карты.
2. Класс Player (набор имеющихся карт, вывод имеющихся карт).
3. Класс Karta (масть и тип карты (6–10, валет, дама, король, туз).

-----

## [Binary tree. Tests](/HW18/)

ЗАДАНИЕ «Бинарное дерево»
В проекте Generics.BinaryTrees создайте  класс бинарного дерева поиска так, чтобы он проходил приложенные тесты. Оптимизируйте код метода GetEnumerable так, чтобы он работал за O(n) по времени, где n - количество элементов в дереве, и O(1) по памяти. 

-----

## [Interaction with the file system](/HW19/)

Задание 1: Чтение и запись в файл
Написать приложение, позволяющее:
•	 создать новый файл с именем «Day17.txt». В случае 
наличия файла с таким именем — вывести сообщение;
•	 открыть и прочесть файл с именем «Day17.txt». В случае 
отсутствия — вывести сообщение об отсутствии;
•	 записать форматированную информацию в файл.
Структура записываемой информации:
Исходные данные: двумерный массив дробных чисел. двумерный массив целых чисел.
■ фамилия, имя, отчество, дата рождения
■ с новой строки количество строк и столбцов массива 
дробных чисел.
■ с новой строки значения элементов двумерного 
массива дробных чисел (каждая строка массива 
в новой строке файла). 
■ с новой строки количество строк и столбцов массива 
целых чисел.
■ с новой строки двумерный массив целых чисел, 
записанных в одну строку. 
■ с новой строки текущая дата.
•	 прочесть информацию из файла и преобразовать ее 
в соответствии с исходной структурой. Реализовать простейшее меню.

Задание 2: Программа «Анализатор кода»
Прочитать текст C#-программы (выбрать самостоятельно) 
и все слова public в объявлении полей классов заменить на слово private. В исходном коде в каждом слове длиннее двух символов все строчные символы заменить прописными. Также в коде программы удалить все «лишние» пробелы и табуляции, оставив только необходимые для 
разделения операторов. Записать символы каждой строки 
программы в другой файл в обратном порядке.

-----

## [LINQ](/HW20/)

Task 1. Дана целочисленная последовательность. Извлечь из нее все положительные
числа, сохранив их исходный порядок следования.

Task 2. Дана целочисленная последовательность. Извлечь из нее все нечетные
числа, сохранив их исходный порядок следования и удалив все вхождения
повторяющихся элементов, кроме первых.

Task 3. Дана целочисленная последовательность. Извлечь из нее все четные
отрицательные числа, поменяв порядок извлеченных чисел на обратный.

Task 4. Даны цифра D (целое однозначное число) и целочисленная
последовательность A. Извлечь из A все различные положительные числа,
оканчивающиеся цифрой D (в исходном порядке).

Task 5. Даны целое число K (> 0) и строковая последовательность A. Из элементов
A, извлечь те строки, которые имеют длину >K и начинаются с заглавной латинской
буквы.

Task 6. Исходная последовательность содержит сведения о клиентах фитнес-центра.
Каждый элемент последовательности включает следующие целочисленные поля:
<Код клиента> <Год> <Номер месяца> <Продолжительность занятий (в часах)>
Найти элемент последовательности с минимальной продолжительностью занятий.
Вывести эту продолжительность, а также соответствующие ей год и номер месяца (в
указанном порядке на той же строке). Если имеется несколько элементов с
минимальной продолжительностью, то вывести данные того из них, который
является последним в исходной последовательности.
Указание. Для нахождения требуемого элемента следует использовать методы
OrderByDescending и Last

-----

## [LINQ](/HW21/)

Task 1.	Дана последовательность непустых строк. Используя метод Aggregate, получить строку, состоящую из начальных символов всех строк исходной последовательности.

Task 2.	Дана целочисленная последовательность. Используя метод Aggregate, найти произведение последних цифр всех элементов последовательности. Чтобы избежать целочисленного переполнения, при вычислении произведения использовать вещественный числовой тип.

Task 3.	Дано целое число N (> 0). Используя методы Range и Sum, найти сумму 1 + (1/2) + … + (1/N) (как вещественное число).

Task 4.	Дана целочисленная последовательность A. Сгруппировать элементы последовательности A, оканчивающиеся одной и той же цифрой, и на основе этой группировки получить последовательность строк вида «D:S», где D – ключ группировки (то есть некоторая цифра, которой оканчивается хотя бы одно из чисел последовательности A), а S – сумма всех чисел из A, которые оканчиваются цифрой D. Полученную последовательность упорядочить по возрастанию ключей. Указание. Использовать метод GroupBy.

Task 5.	Выходная последовательность содержит сведения о клиентах магазина. Каждый элемент последовательности включает код клиента, ФИО, Дата покупки, список покупок: название, цена, количество. Вывести информацию о купленных товарах каждым клиентом, количество товаров, стоимость купленных товаров. Проанализировать покупок по месяцам: количество и сумма покупки.

Task 6.	Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности включает следующие поля:
<Номер школы> <Год поступления> <Фамилия>
Обработка отдельных последовательностей для каждого года, присутствующего в исходных данных, найти школу с наибольшим номером среди школ, которые окончили абитуриенты, поступившие в этом году, и вывести год и найденный номер школы. Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию номера года. Указание. Использовать группировку по полю «год» и метод Max.

-----

## [Regular Expressions](/HW22/)

Розробити клас для перевірки коректності введеної інформації через регулярні
вирази:
1. номер мобільного телефону
2. паспорт громадянина України
3. перевірка належності п’ятизначного числа діапазону [10311;89645]
4. перевірки правильності введення імені користувача українською мовою. Ім’я
має вводитись з великої літери, далі всі літери мають записуватися у нижньому
регістрі. (Наприклад Олег, Олег-Олександр)
5. перевірка коректність запису часу у форматі ГГ:ХХ:СС.
6. перевірка чи введене число (може бути додатне, від’ємне, ціле, дробове)
7. перевірити чи дата лежить в межах від 01.01.1900 року до 31.12.2021 року

-----

## [WebClient. Parsing](/HW23/)

Реалізувати клас Weather, за допомогою якого можна буде отримувати 
поточні дані погоди з сайту https://gismeteo.ua/. Конструктор класу повинен 
приймати рядок з URL-адресою сторінки з інформацією про погоду. Наприклад, для Житомира: https://www.gismeteo.ua/ua/weather-zhytomyr-4943/.
Для зчитування HMTL-коду сторінки сайту використовуйте клас WebClient, який знаходиться у просторі імен System.Net. Для того, щоб коректно оброблювати рядки, отримані з сайтів використовуйте кодування Unicode (UTF-8)

Після парсингу коду погодного сайту у конструкторі потрібно занести усі 
отримані дані у поля класу, щоб їх можна було отримувати у віконному проекті. Не забувайте, що доступ до полів ззовні класу повинен здійснюватись тільки 
через методи (не можна створювати відкриті поля).
У класі передбачте читання даних з сайту та зберігання у класі в обсязі, 
достатньому для формування форми, як показано на наступному рисунку:

![Weather](/HW23/Weather_Screenshot02.png)

Одразу після запуску віконного додатку на формі має з’являтися інформація, прочитана з погодного сайту за допомогою класу Weather. При натисканні на кнопку «Оновити» інформація має заново зчитуватися з погодного сайту і оновлюватися на формі.

-----

## [Object serialization](/HW24/)

Программа «Передача объектов»
1. Создать библиотеку классов с именем «ClassLib». 
2. В библиотеке «ClassLib» создать класс с именем «РС», описывающий компьютер. Данный класс 
должен включать:
■ 3–4 поля (марка, серийный номер и т.д.), 
■ свойства (к каждому полю), 
■ конструкторы (по умолчанию, с параметрами), 
■ методы, моделирующие функционирование ПЭВМ 
(включение/выключение, перегрузку). 
3. Создать новый проект (тип — консольное приложение) с именем «SerializConsolApp». Добавить 
ссылку на библиотеку «ClassLib»
4. В функции Main() данного проекта создать коллекцию (на базе обобщенного класса List<T> ) 
и добавить в коллекцию 4–5 объектов класса «РС». 
5. Произвести сериализацию коллекции в бинарный файл с именем «listSerial.txt»в каталоге на диске D. В случае наличия аналогичного файла в каталоге старый файл перезаписать новым файлом и вывести об этом уведомление. 
6. Создать новый проект (тип — консольное приложение) с именем «DeserializConsolApp». Добавить ссылку на библиотеку «ClassLib».
7. В функции Main() произвести десериализацию коллекции, созданной в проекте с именем «SerializConsolApp» и вывести на экран.
8. В проекте «SerializConsolApp» реализовать функцию сохранения каждого объекта коллекции в отдельном каталоге с именами («объект1.txt», «объект2. txt», «объект3. txt»…). В проекте «DeserializConsolApp» функцию чтения объектов из файлов и вывода на экран значений полей объектов

-----