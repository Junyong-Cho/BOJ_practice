import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.StringTokenizer;
import java.util.Arrays;

public class Main{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static StringTokenizer st;
	static char num[];
	static int k, maxid;
	
	static public void main(String catchsunpie[]) throws IOException{
		st = new StringTokenizer(br.readLine());
		
		num = st.nextToken().toCharArray();
		
		k = Integer.parseInt(st.nextToken());
		
		if(num.length==1||(num.length==2&&num[1]=='0')) {
			System.out.println(-1);
			return;
		}
		
		int t = 0;
		
		while(true) {
			maxid = t;
			int samecount = 1;
			for(int i = t+1; i < num.length; i++)
				if(num[maxid]<num[i]) {
					maxid = i;
					samecount = 1;
				}
				else if(num[maxid]==num[i]) {
					maxid = i;
					samecount++;
				}
			if(num[maxid]==num[t]) t++;
			else if(samecount==1||k==1) {
				swap(t,maxid);
				t++;
				k--;
			}
			else {
				int sameids[] = new int[k<samecount?k:samecount];
				int size = 1;
				sameids[0] = maxid;
				
				for(int i = maxid-1; i>=t+k&&size<sameids.length; i--)
					if(num[maxid]==num[i])
						sameids[size++] = i;
				
				int frontids[][] = new int[size][2];
				frontids[0][0] = t;
				frontids[0][1] = num[t];
				int fsize = 1;
				
				for(int i = t+1; i<=t+k&&fsize<size; i++)
					if(num[i]!=num[maxid]) {
						frontids[fsize][0] = i;
						frontids[fsize++][1] = num[i];
					}
				
				Arrays.sort(frontids,0,fsize,(i,j)->{
					return i[1]-j[1];
				});
				
				for(int i = 0; i < size; i++) {
					t = frontids[i][0];
					swap(t,sameids[i]);
					k--;
				}
				t++;
			}
			
			if(k==0||t>=num.length) break;
		}
		
		if(k!=0) {

			for(int i = 1; i < num.length; i++)
				if(num[i]==num[i-1]) {
					System.out.println(num);
					return;
				}
			if(k%2==1)
				swap(num.length-1,num.length-2);
		}
		
		System.out.println(num);
	}
	
	static void swap(int i, int j) {
		char c = num[i];
		num[i] = num[j];
		num[j] = c;
	}
}
