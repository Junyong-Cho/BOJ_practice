Stream rd = Console.OpenStandardInput(1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int l = nex();
int k = nex();
int c = nex();

SortedSet<int> tree = new();

while (k-- > 0)
    tree.Add(nex());

var cut = tree.ToArray();

int low = 1, high = l, mid;
int count, right, f;

int ans = max(cut[0], l - cut[0]);
int first = cut[0];

while (low <= high)
{
    mid = (low + high) >> 1;

    count = c;
    right = l;
    f = 0;

    if (right - cut[cut.Length - 1] > mid || cut[0] > mid) 
    {
        low = mid + 1;
        continue;
    }

    for (int i = cut.Length - 2; i >= 0; i--)
    {
        if (right - cut[i] > mid)
        {
            count--;
            right = cut[i + 1];

            if (right - cut[i] > mid)
            {
                low = mid + 1;
                goto L;
            }

            f = cut[i + 1];

            if (count == 0)
            {
                if (right > mid)
                {
                    low = mid + 1;
                    goto L;
                }

                break;
            }
        }
    }

    if (count > 0)
        f = cut[0];

    ans = mid;
    high = mid - 1;
    first = f;
L:
    continue;
}

Console.Write($"{ans} {first}");

int max(int i, int j) => i > j ? i : j;

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