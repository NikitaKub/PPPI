using System.Collections;
using System.Text;

const string filePath = "F:\\University\\Works\\PPPI\\myText.txt";
bool end = false;
string menuStr = "Menu\n1-Read text\n2-Math\n3-Exit";
while(end == false)
{
    Console.WriteLine(menuStr);
    switch (Int32.Parse(Console.ReadLine())){
        case 1:
            Console.WriteLine("Read text");
            readText();
            break;
        case 2:
            Console.WriteLine("Math");
            Console.WriteLine("Result is " + math());
            break;
        case 3:
            end = true;
            break;
        default:
            Console.WriteLine(menuStr);
            break;
    }
}

void readText()
{
    Console.WriteLine("Write the number of words you want to see");
    int countOfWords = Int32.Parse(Console.ReadLine());
    if (File.Exists(filePath))
    {
        string[] allLines = File.ReadAllLines(filePath);
        ArrayList listStr = new ArrayList();
        StringBuilder sb = new StringBuilder();
        foreach (string line in allLines)
        {
            for (int j = 0; j < line.Length; j++)
            {
                if (Char.IsWhiteSpace(line[j]) || line[j] == ',' || line[j] == '.')
                {
                    if (sb.ToString() != "")
                    {
                        listStr.Add(sb.ToString());
                    }
                    sb.Clear();
                }
                else
                {
                    sb.Append(line[j]);
                }
            }
        }
        for (int i = 0; i < countOfWords; i++)
        {
            if (i == countOfWords - 1)
            {
                
                Console.Write(listStr.ToArray()[i] + ".");
            }
            else
            {
                Console.Write(listStr.ToArray()[i] + ", ");
            }
            
        }
        Console.WriteLine();
    }
}
// Метод калькулятор, повертає значенння результату обчислення
int math()
{
    // Флаг для того, щоб була змоги повторити ввід символу операції або вийти з методу, якщо потрібно
    bool flag = true;
    while (flag == true) {
        // Вводимо символ операції
        Console.WriteLine("Write the math operation symbol(+, -, /, *) or exit");
        string operationSymbol = Console.ReadLine();
        // Змінні для чисел
        int num1 = 0, num2 = 0;
        // Світч по символу операції
        switch (operationSymbol)
        {
            case "+":
                // Метод для вводу з консолі значень
                inputNums(ref num1, ref num2); 
                // Операція обчислення
                return num1 + num2;
            case "-":
                inputNums(ref num1, ref num2);
                return num1 - num2;
            case "/":
                inputNums(ref num1, ref num2);
                return num1 / num2;
            case "*":
                inputNums(ref num1, ref num2);
                return num1 * num2;
            case "exit":
                // Вихід з методу
                flag= false;
                break;
            default:
                Console.WriteLine("Try again");
                break;
        }
    }
    return 0;
}

void inputNums(ref int num1,ref int num2)
{
    // Після отримання посилання на змінні, змінюємо їх на результат з консолі
    Console.WriteLine("Write first number");
    num1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Write second number");
    num2 = Convert.ToInt32(Console.ReadLine());
}