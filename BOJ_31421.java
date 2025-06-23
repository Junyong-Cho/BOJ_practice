import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class BOJ_31421{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static char ho[];
	static int n, count, start, end;
	static StringBuffer ans = new StringBuffer();
	
	static public void main(String catchsunpie[]) throws IOException{
		n = Integer.parseInt(br.readLine());
		ho = (" "+br.readLine()+" ").toCharArray();
		
		if(n==1&&ho[1]=='B') {
			System.out.print(-1);
			return;
		}
		
		end = n;
		while(ho[end]=='B') end--;
		start = 1;
		while(ho[start]=='W') start++;
		if(start==n+1) {
			System.out.print(0);
			return;
		}
		if(start>end) {
			System.out.print(-1);
			return;
		}
		
		if(end<n) {
			count++;
			ans.append(end).append("\n");
			while(ho[end]=='W') end--;
			for(int i = end; ; i--) {
				if(i==0) {
					count++;
					ans.append(end);
					end = i;
					break;
				}
				if(ho[i]=='W') {
					count += 2;
					ans.append(i).append("\n");
					ans.append(end).append("\n");
					end = i;
					break;
				}
			}
		}
		if(start<end) {
			if(start==1) {
				while(ho[start]=='B') start++;
				count++;
				ans.append(start-1).append("\n");
			}
	
			for(int i = start; i < end; i++) {
				if(ho[i]=='B') {
					count += 2;
					ans.append(i-1).append("\n");
					while(ho[i]=='B') i++;
					ans.append(--i).append("\n");
				}
			}
		}
		
		if(count>n)
			System.out.print(-1);
		else
			System.out.print(count+"\n"+ans);
	}
}