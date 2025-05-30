import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.StringTokenizer;
import java.util.Queue;
import java.util.LinkedList;
import java.util.HashSet;

public class BOJ_1039{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static Queue<int[]> q = new LinkedList<>();
	static StringTokenizer st;
	static HashSet<String> hs = new HashSet<>();
	static char num[];
	static int k, ans;
	
	static public void main(String catchsunpie[]) throws IOException{
		
		st = new StringTokenizer(br.readLine());
		
		num = st.nextToken().toCharArray();
		
		if(num.length==1||(num.length==2&&num[1]=='0')) {
			System.out.println(-1);
			return;
		}
		
		k = Integer.parseInt(st.nextToken());
		
		ans = 0;
		int a = toInt(num);
		hs.add(a+" 1");
		q.add(new int[] {a,1});
		
		bfs();
		
		System.out.println(ans);
	}
	
	static void bfs() {
		while(!q.isEmpty()) {
			int t[] = q.remove();
			char num[] = Integer.toString(t[0]).toCharArray();
			
			for(int i = 1; i < num.length; i++) {
				if(num[i]=='0') continue;
				swap(num,0,i);
				if(t[1]==k) {
					ans = max(ans,toInt(num));
				}
				else {
					int a = toInt(num);
					if(hs.add(a+" "+(t[1]+1)))
						q.add(new int[] {a,t[1]+1});
				}
				swap(num,0,i);
			}
			
			for(int i = 1; i < num.length; i++)
				for(int j = i+1; j < num.length; j++) {
					swap(num,i,j);
					if(t[1]==k) {
						ans = max(ans,toInt(num));
					}
					else {
						int a = toInt(num);
						if(hs.add(a+" "+(t[1]+1)))
							q.add(new int[] {a,t[1]+1});
					}
					swap(num,i,j);
				}
			
		}
	}
	
	static int toInt(char num[]) {
		int n = 0;
		
		for(int i = 0; i < num.length; i++)
			n = (n<<3) + (n<<1) + (num[i]&0b1111);
		return n;
	}
	
	static void swap(char num[], int i, int j) {
		char c = num[i];
		num[i] = num[j];
		num[j] = c;
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
}