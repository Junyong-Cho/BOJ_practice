Stream rd = Console.OpenStandardInput(bufferSize: 1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int t = nex(), n, idx;
long a;

int[][] cor;
int[] y;
SortedSet<int> tree;
Dictionary<int, int> dic;

while (t-- > 0)
{
    n = nex();

    cor = new int[n][];
    tree = new();

    for (int i = 0; i < n; i++)
    {
        cor[i] = new int[] { nex(), nex() };
        tree.Add(cor[i][1]);
    }

    Array.Sort(cor, (i, j) => i[0] == j[0] ? i[1] - j[1] : j[0] - i[0]);
    idx = 0;
    dic = new();
    foreach (int i in tree)
        dic[i] = idx++;

    y = new int[idx << 2];

    a = 0;

    idx--;

    for (int i = 0, d; i < n; i++)
    {
        d = dic[cor[i][1]];

        a += Get(d, 0, idx, 1);

        Add(d, 0, idx, 1);
    }

    ans.WriteLine(a);
}

ans.Flush();

void Add(int i, int st, int ed, int idx)
{
    if (st == ed)
    {
        y[idx]++;
        return;
    }

    int mid = (st + ed) >> 1;

    if (i <= mid)
        Add(i, st, mid, idx << 1);
    else
        Add(i, mid + 1, ed, (idx << 1) + 1);

    y[idx] = y[idx << 1] + y[(idx << 1) + 1];
}

int Get(int i, int st, int ed, int idx)
{
    if (st == ed)
        return y[idx];

    int mid = (st + ed) >> 1;

    if (i <= mid)
        return Get(i, st, mid, idx << 1);
    else
        return y[idx << 1] + Get(i, mid + 1, ed, (idx << 1) + 1);
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
    bool pos = true;
    while ((n = Read()) <= ' ') ;
    if (n == '-')
    {
        pos = false;
        n = Read();
    }
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return pos ? n : ~n + 1;
}