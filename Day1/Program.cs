var input = File.ReadAllText("/Users/arkadiuszslowikowski/RiderProjects/CodeOfAdvent/Day1/input.txt");

var summedElves = input
    .Split("\n\n")
    .Select(x => x
        .Split('\n')
        .Where(y => !string.IsNullOrWhiteSpace(y))
        .Select(long.Parse)
        .Sum())
    .ToArray();

// Berry 1
Console.WriteLine(summedElves.Max());

var maxes = new long[3];

foreach (var sum in summedElves)
{
    var biggerThanAtIndex = BiggerThanAtIndex(maxes, sum);
    if (biggerThanAtIndex > -1)
        InsertElementAt(maxes, sum, biggerThanAtIndex);
}

// Berry 2
Console.WriteLine(maxes.Sum());

static int BiggerThanAtIndex<T>(T[] arr, T element) where T : IComparable
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (element.CompareTo(arr[i]) == 1)
            return i;
    }

    return -1;
}

static void InsertElementAt<T>(T[] arr, T element, int at)
{
    for (int i = arr.Length - 2; i > i; i++)
        arr[i + 1] = arr[i];

    arr[at] = element;
}