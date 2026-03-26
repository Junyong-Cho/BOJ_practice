Stream rd = Console.OpenStandardInput(1 << 16);
StreamWriter ans = new(Console.OpenStandardOutput(1 << 16), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();

int[] a = new int[n + 1];

for (int i = 1; i <= n; i++)
    a[i] = nex();

int[] fst = new int[n << 2];
int[] snd = new int[n << 2];

Init(1, n, 1);

int m = nex();

while (m-- > 0)
{
    if (nex() == 1)
    {
        int i = nex();
        a[i] = nex();

        Change(1, n, i, 1);
    }
    else
    {
        int l = nex();
        int r = nex();

        Get(l, r, 1, n, 1, out int f, out int s);

        ans.WriteLine(a[f] + a[s]);
    }
}

ans.Flush();

void Get(int from, int to, int st, int ed, int idx, out int f, out int s)
{
    if (from == st && to == ed)
    {
        f = fst[idx];
        s = snd[idx];
        return;
    }

    int mid = (st + ed) >> 1;

    if (to <= mid)
    {
        Get(from, to, st, mid, idx << 1, out f, out s);
    }
    else if(mid < from)
    {
        Get(from, to, mid + 1, ed, (idx << 1) + 1, out f, out s);
    }
    else
    {
        int f1, s1, f2, s2;

        Get(from, mid, st, mid, idx << 1, out f1, out s1);
        Get(mid + 1, to, mid + 1, ed, (idx << 1) + 1, out f2, out s2);

        if (a[f1] == a[f2])
        {
            f = f1;
            s = f2;
        }
        else if (a[f1] > a[f2])
        {
            f = f1;

            if (s1 != -1 && a[s1] > a[f2])
                s = s1;
            else
                s = f2;
        }
        else
        {
            f = f2;

            if (s2 != -1 && a[s2] > a[f1])
                s = s2;
            else
                s = f1;
        }
    }
}

void Change(int st, int ed, int goal, int idx)
{
    if (st == ed)
        return;

    int mid = (st + ed) >> 1;

    if (goal <= mid)
        Change(st, mid, goal, idx << 1);
    else
        Change(mid + 1, ed, goal, (idx << 1) + 1);

    int f1, s1, f2, s2;

    f1 = fst[idx << 1];
    s1 = snd[idx << 1];

    f2 = fst[(idx << 1) + 1];
    s2 = snd[(idx << 1) + 1];

    if (a[f1] == a[f2])
    {
        fst[idx] = f1;
        snd[idx] = f2;
    }
    else if (a[f1] > a[f2])
    {
        fst[idx] = f1;

        if (s1 != -1 && a[s1] > a[f2])
            snd[idx] = s1;
        else
            snd[idx] = f2;
    }
    else
    {
        fst[idx] = f2;

        if (s2 != -1 && a[s2] > a[f1])
            snd[idx] = s2;
        else
            snd[idx] = f1;
    }
}

void Init(int st, int ed, int idx)
{
    if (st == ed)
    {
        fst[idx] = st;
        snd[idx] = -1;
        return;
    }

    int mid = (st + ed) >> 1;

    Init(st, mid, idx << 1);
    Init(mid + 1, ed, (idx << 1) + 1);

    int f1, s1, f2, s2;

    f1 = fst[idx << 1];
    s1 = snd[idx << 1];

    f2 = fst[(idx << 1) + 1];
    s2 = snd[(idx << 1) + 1];

    if (a[f1] == a[f2])
    {
        fst[idx] = f1;
        snd[idx] = f2;
    }
    else if (a[f1] > a[f2])
    {
        fst[idx] = f1;

        if (s1 != -1 && a[s1] > a[f2])
            snd[idx] = s1;
        else
            snd[idx] = f2;
    }
    else
    {
        fst[idx] = f2;

        if (s2 != -1 && a[s2] > a[f1])
            snd[idx] = s2;
        else
            snd[idx] = f1;
    }
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