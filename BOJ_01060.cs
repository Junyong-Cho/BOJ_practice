using System.Text;
using static System.Console;

int l = nex();
int[] set = new int[l+1];

for (int i = 1; i <= l; i++)
    set[i] = nex();

Array.Sort(set);

int n = nex();


StringBuilder ans = new StringBuilder();

HashSet<int> hs = new();

for(int i = 1; i <= l && n > 0; i++)
{
    if (set[i] - set[i - 1] == 2)
    {
        hs.Add(set[i] - 1);
        ans.Append($"{set[i] - 1} ");
        n--;
    }
    if (n > 0)
    {
        hs.Add(set[i]);
        ans.Append($"{set[i]} ");
        n--;
    }
}

if(n > 0)
{
    PriorityQueue<int, long[]> pq = new(Comparer<long[]>.Create((i,j) => i[0] == j[0]? i[1].CompareTo(j[1]) : i[0].CompareTo(j[0])));
    
    for(int i = 0; i < l; i++)
    {
        if (set[i + 1] - set[i] <= 100)
        {
            for (int j = 1; set[i] + j < set[i + 1]; j++)
            {
                pq.Enqueue(set[i] + j, new long[] { (long)(set[i + 1] - set[i] - j) * j, set[i] + j });
            }
        }
        else
        {
            for(int j = 1; j <= 50; j++)
            {
                pq.Enqueue(set[i] + j, new long[] { (long)(set[i + 1] - set[i] - j) * j, set[i] + j });
                pq.Enqueue(set[i + 1] - j, new long[] { (long)(set[i + 1] - set[i] - j) * j, set[i + 1] - j });
            }
        }
    }

    while (pq.Count > 0 && n > 0)
    {
        int t = pq.Dequeue();
        if (hs.Contains(t)) continue;
        hs.Add(t);
        ans.Append($"{t} ");
        n--;
    }

    for (int i = 1; n > 0; i++)
    {
        if (hs.Contains(i)) continue;
        ans.Append($"{i} ");
        n--;
    }
}

Write(ans);
int nex()
{
    int n, c;
    while ((n = Read()) <= ' ') ;
    n &= 0b1111;
    while ((c = Read()) >= '0')
        n = (n << 3) + (n << 1) + (c & 0b1111);
    return n;
}


