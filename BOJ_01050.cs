using System.Text;

Stream rd = Console.OpenStandardInput(1 << 16);
StringBuilder builder = new();
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();
int m = nex();

const string LOVE = "LOVE";
const int INF = 1_000_000_001;

Dictionary<string, long> price = new();

while (n-- > 0)
    price[ReadLine()] = nex();


string[] input;
string[] ingreds = new string[m];
Value[][] recipes = new Value[m][];

for (int i = 0; i < m; i++)
{
    input = ReadLine()!.Split('=');

    ingreds[i] = input[0];

    input = input[1].Split('+');

    recipes[i] = new Value[input.Length];
    Value[] t = recipes[i];

    for (int j = 0; j < t.Length; j++)
    {
        t[j] = new()
        {
            Potion = input[j].Substring(1),
            Count = input[j][0] & 0b1111
        };
    }
}

PriorityQueue<string, long> pq = new();
HashSet<string> visit = new();

foreach (string p in price.Keys)
    pq.Enqueue(p, price[p]);

while (pq.Count > 0)
{
    string t = pq.Dequeue();

    if (visit.Add(t) == false)
        continue;
    if (t == LOVE)
        break;

    Update();
}

if (price.ContainsKey(LOVE))
    Console.Write(price[LOVE]);
else
    Console.Write(-1);

void Update()
{
    for (int i = 0; i < m; i++)
    {
        long t = Calc(recipes[i]);

        if (t == -1)
            continue;

        if (price.ContainsKey(ingreds[i]) == false || t < price[ingreds[i]])
        {
            price[ingreds[i]] = t;

            pq.Enqueue(ingreds[i], t);
        }
    }
}

long Calc(Value[] recipe)
{
    long res = 0;

    foreach (Value val in recipe)
    {
        if (price.ContainsKey(val.Potion) == false)
            return -1;
        res += price[val.Potion] * val.Count;

        if (res >= INF)
            return INF;
    }

    return res;
}

int Read()
{
    if (len == cur)
    {
        cur = 0;
        len = rd.Read(buff, 0, 1 << 16);
        if (len == 0)
            return -1;
    }

    return buff[cur++];
}

int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}

string ReadLine()
{
    builder.Clear();

    int c;

    while ((c = Read()) <= ' ') ;
    builder.Append((char)c);

    while ((c = Read()) > ' ')
        builder.Append((char)c);

    return builder.ToString();
}

struct Value
{
    public string Potion;
    public int Count;
}