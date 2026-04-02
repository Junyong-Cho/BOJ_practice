Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int tc = nex();
int[] position = new int[100_001];
int[] value = new int[200_001];
int[] tree = new int[800_000];

while (tc-- > 0)
{
    int n = nex();
    int m = nex();
    int tail = n + m;

    for (int i = 1; i <= n; i++)
    {
        position[i] = m + i;
    }
    value.AsSpan(0, m + 1).Fill(0);
    value.AsSpan(m + 1, n).Fill(1);

    Init(0, tail, 1);

    while (m > 0)
    {
        int a = nex();

        int pos = position[a];

        ans.Write(Get(pos, 0, tail, 1) - 1);
        ans.Write(' ');

        Update(pos, 0, 0, tail, 1);
        Update(m, 1, 0, tail, 1);
        position[a] = m--;
    }

    ans.WriteLine();
}

ans.Flush();

int Get(int pos, int from, int to, int idx)
{
    if (to == pos)
    {
        return tree[idx];
    }

    int mid = (from + to) >> 1;

    if (pos <= mid)
        return Get(pos, from, mid, idx << 1);
    else
        return tree[idx << 1] + Get(pos, mid + 1, to, (idx << 1) + 1);
}

void Update(int pos, int value, int from, int to, int idx)
{
    if (from == to)
    {
        tree[idx] = value;
        return;
    }

    int mid = (from + to) >> 1;

    if (pos <= mid)
        Update(pos, value, from, mid, idx << 1);
    else
        Update(pos, value, mid + 1, to, (idx << 1) + 1);

    tree[idx] = tree[idx << 1] + tree[(idx << 1) + 1];
}

void Init(int from, int to, int idx)
{
    if (from == to)
    {
        tree[idx] = value[from];
        return;
    }

    int mid = (from + to) >> 1;

    Init(from, mid, idx << 1);
    Init(mid + 1, to, (idx << 1) + 1);

    tree[idx] = tree[idx << 1] + tree[(idx << 1) + 1];
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