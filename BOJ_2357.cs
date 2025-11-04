using System.Text;
using static System.Console;

int n = nex(), m = nex();

int[] a = new int[n + 1];

for (int i = 1; i <= n; i++)
    a[i] = nex();

int[,] tree = new int[n << 2, 2];

set(1, n, 1);

StringBuilder ans = new();
int[] t;

while (m-- > 0)
{
    t = get(1, n, nex(), nex(), 1);

    ans.Append($"{t[0]} {t[1]}\n");
}

Write(ans);

int min(int i, int j) => i < j ? i : j;
int max(int i, int j) => i > j ? i : j;

int[] get(int st, int ed, int from, int to, int idx)
{
    if (st == ed) return new int[] { tree[idx, 0], tree[idx, 1] };
    if (st == from && ed == to)
        return new int[] { tree[idx, 0], tree[idx, 1] };

    int mid = (st + ed) >> 1;
    int t = idx << 1;

    if (to <= mid) return get(st, mid, from, to, t);
    if (mid < from) return get(mid + 1, ed, from, to, t + 1);

    int[] res = get(st, mid, from, mid, t);
    int[] tmp = get(mid + 1, ed, mid + 1, to, t + 1);

    res[0] = min(res[0], tmp[0]);
    res[1] = max(res[1], tmp[1]);

    return res;
}

void set(int st, int ed, int idx)
{
    if (st == ed)
    {
        tree[idx, 0] = tree[idx, 1] = a[st];
        return;
    }

    int mid = (st + ed) >> 1;

    int t = idx << 1;

    set(st, mid, t);
    set(mid+1, ed, t + 1);

    tree[idx, 0] = min(tree[t, 0], tree[t + 1, 0]);
    tree[idx, 1] = max(tree[t, 1], tree[t + 1, 1]);
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