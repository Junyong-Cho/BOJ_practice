Stream rd = Console.OpenStandardInput(bufferSize: 1<<16);
StreamWriter ans = new(Console.OpenStandardOutput(), bufferSize: 1 << 16);

byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

const int DIV = 1_000_000_007;

int n = nex(), m = nex() + nex();

int[] a = new int[n + 1];

for (int i = 1; i <= n; i++)
    a[i] = nex();

long[] seg = new long[n << 2];

init(1, n, 1);

while (m-- > 0)
{
    if (nex() == 1)
        change(1, n, nex(), 1);
    else
    {
        ans.Write(get(1, n, nex(), nex(), 1));
        ans.Write('\n');
    }
}

ans.Flush();

void change(int st, int ed, int i, int idx)
{
    if (st == ed)
    {
        seg[idx] = nex();
        return;
    }

    int mid = (st + ed) >> 1;

    if (i <= mid)
        change(st, mid, i, idx << 1);
    else
        change(mid + 1, ed, i, (idx << 1) + 1);

    seg[idx] = seg[idx << 1] * seg[(idx << 1) + 1] % DIV;
}

long get(int st, int ed, int from, int to, int idx)
{
    if (st == from && ed == to)
        return seg[idx];

    int mid = (st + ed) >> 1;

    if (to <= mid)
        return get(st, mid, from, to, idx << 1);
    if (mid < from)
        return get(mid + 1, ed, from, to, (idx << 1) + 1);

    return get(st, mid, from, mid, idx << 1) * get(mid + 1, ed, mid + 1, to, (idx << 1) + 1) % DIV;
}

void init(int st, int ed, int idx)
{
    if (st == ed)
    {
        seg[idx] = a[st];
        return;
    }

    int mid = (st + ed) >> 1;
    init(st, mid, idx << 1);
    init(mid + 1, ed, (idx << 1) + 1);

    seg[idx] = seg[idx << 1] * seg[(idx << 1) + 1] % DIV;
}

int Read()
{
    if (len == cur)
    {
        cur = 0;
        len = rd.Read(buff, 0, buff.Length);
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