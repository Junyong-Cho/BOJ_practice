using System.Text;
using static System.Console;

int n = nextInt(), m = nextInt() + nextInt();
long[] arr = new long[n + 1];

for (int i = 1; i <= n; i++)
    arr[i] = nextLong();

long[] tree = new long[(n << 2) + 1];

set(1, n, 1);

StringBuilder ans = new();

while (m-- > 0)
{
    if (nextInt() == 1)
        update(1, n, nextInt(), nextLong(), 1);
    else
        ans.Append($"{get(1, n, nextInt(), nextInt(), 1)}\n");
}

Write(ans);

long update(int st, int ed, int goal, long u, int idx)
{
    if (st == ed)
        return tree[idx] = u;

    int mid = (st + ed) >> 1;

    if (goal <= mid)
        return tree[idx] = tree[(idx << 1) + 1] + update(st, mid, goal, u, idx << 1);

    return tree[idx] = tree[idx << 1] + update(mid + 1, ed, goal, u, (idx << 1) + 1);
}

long get(int st, int ed, int from, int to, int idx)
{
    if (st == from && ed == to) return tree[idx];

    int mid = ((st + ed) >> 1);

    if (to <= mid)
        return get(st, mid, from, to, idx << 1);
    if (mid < from)
        return get(mid + 1, ed, from, to, (idx << 1) + 1);

    return get(st, mid, from, mid, idx << 1) + get(mid + 1, ed, mid + 1, to, (idx << 1) + 1);
}

long set(int st, int ed, int idx)
{
    if (st == ed) return tree[idx] = arr[st];
    int mid = (st + ed) >> 1;

    tree[idx] = set(st, mid, idx << 1) + set(mid + 1, ed, (idx << 1) + 1);

    return tree[idx];
}

int nextInt()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}

long nextLong()
{
    long n, c;
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
