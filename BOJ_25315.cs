using static System.Console;

int n = nex();
int[] count = new int[n];

long[][] smash = new long[n][];
Queue<int>[] across = new Queue<int>[n];
PriorityQueue<int,int[]> pq = new(Comparer<int[]>.Create((i,j) => i[1]==j[1]?i[0]-j[0]:i[1]-j[1]));

for(int i = 0; i < n; i++)
{
    smash[i] = new long[5];
    for(int j = 0; j < 5; j++)
        smash[i][j] = nex();
    
    across[i] = new();
}

for(int i = 0; i < n; i++)
{
    for(int j = i+1; j < n; j++)
    {
        if (cross(smash[i], smash[j]))
        {
            across[i].Enqueue(j);
            across[j].Enqueue(i);
        }
    }

    count[i] = across[i].Count;

    pq.Enqueue(i, new int[]{count[i], (int)smash[i][4]});
}

long ans = 0;
int t;

while (pq.Count > 0)
{
    t = pq.Dequeue();
    
    ans += smash[t][4]*(count[t]+1);

    while(across[t].Count>0)
        count[across[t].Dequeue()]--;
}

Write(ans);

bool cross(long[] p1, long[] p2)
{
    int d1 = CCW(p1[0],p1[1],p1[2],p1[3],p2[0],p2[1]);
    int d2 = CCW(p1[0],p1[1],p1[2],p1[3],p2[2],p2[3]);

    if(d1*d2>0)
        return false;

    d1 = CCW(p2[0],p2[1],p2[2],p2[3],p1[0],p1[1]);
    d2 = CCW(p2[0],p2[1],p2[2],p2[3],p1[2],p1[3]);

    if(d1*d2>0)
        return false;

    return true;
}

int CCW(long x1, long y1, long x2, long y2, long x3, long y3)
{
    return x1*(y2-y3)+x2*(y3-y1)+x3*(y1-y2)<0?-1:1;
}

int nex()
{
    int n, c;
    bool pos = true;
    while((n = Read())<=' ');
    if (n == '-')
    {
        pos = false;
        n = Read();
    }
    n &= 0b1111;
    while((c = Read())>='0')
        n = (n<<3) + (n<<1) + (c&0b1111);
    return pos?n:~n+1;
}