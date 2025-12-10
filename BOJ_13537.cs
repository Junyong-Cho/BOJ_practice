Stream rd = Console.OpenStandardInput();
StreamWriter ans = new(Console.OpenStandardOutput(), bufferSize: 1 << 16);
byte[] buff = new byte[1 << 16];
int len = 0, cur = 0;

int n = nex();

int[] a = new int[n];

for (int i = 0; i < n; i++)
    a[i] = nex();

int[][] tree = new int[n << 2][];

init(0, n - 1, 1);

int m = nex();

while (m-- > 0)
{
    ans.Write(get(0, n - 1, 1, nex() - 1, nex() - 1, nex()));
    ans.Write('\n');
}

ans.Flush();

int get(int st, int ed, int idx, int from, int to, int k)
{
    if (from == st && to == ed)
        return tree[idx].Length - binarySearch(tree[idx], k);

    int mid = (st + ed) >> 1;

    if (to <= mid)
        return get(st, mid, idx << 1, from, to, k);
    if (mid < from)
        return get(mid + 1, ed, (idx << 1) + 1, from, to, k);
    return get(st, mid, idx << 1, from, mid, k)
        + get(mid + 1, ed, (idx << 1) + 1, mid + 1, to, k);
}

int binarySearch(int[] tree, int k)
{
    int low = 0, high = tree.Length - 1, mid;

    if (k < tree[low])
        return 0;
    if (tree[high] <= k)
        return high + 1;

    while (true)
    {
        mid = (low + high) >> 1;
        if (tree[mid] <= k)
        {
            if (k < tree[mid + 1])
                return mid + 1;
            low = mid + 1;
        }
        else
        {
            if (tree[mid - 1] <= k)
                return mid;
            high = mid - 1;
        }
    }
}

void init(int from, int ed, int idx)
{
    if (from == ed)
    {
        tree[idx] = new int[] { a[from] };
        return;
    }

    int mid = (from + ed) >> 1;

    init(from, mid, idx << 1);
    init(mid + 1, ed, (idx << 1) + 1);

    tree[idx] = new int[ed - from + 1];

    merge(tree[idx], tree[idx << 1], tree[(idx << 1) + 1]);
}

void merge(int[] ptree, int[] ltree, int[] rtree)
{
    int left = 0, ll = ltree.Length;
    int right = 0, rl = rtree.Length;

    for (int i = 0; i < ptree.Length; i++)
    {
        if (left == ll)
        {
            Array.Copy(rtree, right, ptree, i, rl - right);
            break;
        }
        if (right == rl)
        {
            Array.Copy(ltree, left, ptree, i, ll - left);
            break;
        }
        ptree[i] =
            ltree[left] <= rtree[right] ?
            ltree[left++] : rtree[right++];
    }
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