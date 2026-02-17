Stream rd = Console.OpenStandardInput(bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int a = nex();
int b = nex();
int k = nex();

if (a == 0)
{
    Console.Write(0);
    return;
}

int[] v = new int[300000];

for (int i = 0; i < v.Length; i++)
    v[i] = i;

b += a;

Queue<int> q = new();

q.Enqueue(a);
q.Enqueue(0);

int b_, c, mn, mx;

while (q.Count > 0) 
{
    a = q.Dequeue();
    b_ = b - a;
    c = q.Dequeue() + 1;

    mx = max(0, k - b_);
    mn = min(a, k);

    mx = a - (mx << 1) + k;
    mn = a - (mn << 1) + k;

    while (true)
    {
        mn = Find(mn);

        if (mx < mn)
            break;

        if (mn == 0)
        {
            Console.Write(c);
            return;
        }

        q.Enqueue(mn);
        q.Enqueue(c);

        Union(mn, mn + 2);
        mn += 2;
    }
}

Console.Write(-1);

int min(int i, int j) => i < j ? i : j;
int max(int i, int j) => i > j ? i : j;

int Find(int i)
{
    if (v[i] == i)
        return i;

    return v[i] = Find(v[i]);
}

bool Union(int i, int j)
{
    i = Find(i);
    j = Find(j);

    if (i == j)
        return false;

    if (i > j)
        (i, j) = (j, i);

    v[i] = j;

    return true;
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