import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class BOJ_32034{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static StringBuilder sb = new StringBuilder();
	static char coin[];
	static int n, t, even, odd, evenar[], oddar[];
	static long ans;
	
	static public void main(String catchsunpie[]) throws IOException{
		t = Integer.parseInt(br.readLine());
		
		while(t-->0) {
			n = Integer.parseInt(br.readLine());
			coin = br.readLine().toCharArray();
			even = odd = 0;
			ans = 0;
			evenar = new int[n];
			oddar = new int[n];
			for(int i = 0; i < n; i += 2)
				if(coin[i]=='T')
					evenar[even++] = i;
			for(int i = 1; i < n; i += 2)
				if(coin[i]=='T') 
					oddar[odd++] = i;
			if(even!=odd) {
				sb.append("-1\n");
				continue;
			}
			
			for(int i = 0; i < odd; i++) {
				ans += abs(evenar[i]-oddar[i]);
			}
			
			sb.append(ans).append("\n");
		}
		
		
		System.out.println(sb);
	}
	
	static int abs(int i) {
		return i>0?i:~i+1;
	}
}