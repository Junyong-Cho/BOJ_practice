import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class BOJ_32111{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static int n, o, count, t;
	static char ox[], ans[];
	static boolean isO;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = Integer.parseInt(br.readLine());
		ox = br.readLine().toCharArray();
		ans = new char[n];
		
		if(n<3) {
			System.out.println("YES");
			for(int i = 0; i < n; i++)
				ans[i] = ox[i]=='O'?'+':'-';
			System.out.println(ans);
			return;
		}
		
		for(int i = 0; i < n; i++)
			if(ox[i]=='O') {
				ans[i] = '+';
				o = i;
				i = (i+1)%n;
				while(i!=o) {
					while(ox[i]=='O'&&i!=o) {
						ans[i] = '+';
						i = (i+1)%n;
					}
					if(i==o) break;
					count = 0;
					t = i;
					while(ox[i]=='X') {
						count++;
						i = (i+1)%n;
					}
					if((count&1)==0) {
						System.out.println("NO");
						return;
					}
					for(int j = 0; j <(count>>1); j++)
						ans[(t+j)%n] = '+';
					for(int j = (count>>1); j < count; j++)
						ans[(t+j)%n] = '-';
				}
				break;
			}
			else {
				ans[i] = '-';
			}

		System.out.println("YES");
		System.out.println(ans);
	}
}
