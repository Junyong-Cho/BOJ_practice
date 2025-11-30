using System.Text;
using static System.Console;

int n = nex();
int[] a = new int[n];
int[][] tree = new int[n << 2][];
for (int i = 0; i < n; i++)
    a[i] = nex();

init(0, n - 1, 1);

int m = nex();

StringBuilder ans = new();

while (m-- > 0)
    ans.Append($"{get(0, n - 1, nex() - 1, nex() - 1, nex(), 1)}\n");

Write(ans);
long get(int st, int ed, int from, int to, int goal, int idx)
{
    if(st==from && ed == to)
        return tree[idx].Length - binarySearch(tree[idx], goal);
    int mid = (st + ed) >> 1;

    idx <<= 1;

    if (to <= mid)
        return get(st, mid, from, to, goal, idx);
    if (mid < from)
        return get(mid + 1, ed, from, to, goal, idx + 1);

    long res = get(st, mid, from, mid, goal, idx);
    res += get(mid + 1, ed, mid + 1, to, goal, idx + 1);

    return res;
}

int binarySearch(int[] tree, int goal)
{
    if (goal < tree[0])
        return 0;
    if (tree[tree.Length - 1] <= goal)
        return tree.Length;

    int low = 0, high = tree.Length - 1, mid;

    while (true)
    {
        mid = (low + high) >> 1;

        if (tree[mid] <= goal)
        {
            if (goal < tree[mid + 1])
                return mid + 1;
            low = mid + 1;
        }
        else
        {
            if (tree[mid - 1] <= goal)
                return mid;
            high = mid - 1;
        }
    }
}

void init(int from, int to, int idx)
{
    tree[idx] = new int[to - from + 1];

    for (int i = from; i <= to; i++)
        tree[idx][i - from] = a[i];

    if (from == to)
        return;

    Array.Sort(tree[idx]);
    int mid = (from + to) >> 1;

    idx <<= 1;

    init(from, mid, idx);
    init(mid + 1, to, idx + 1);
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